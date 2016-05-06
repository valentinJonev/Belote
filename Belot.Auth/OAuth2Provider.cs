using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Belot.Auth.Core;
using Belot.Auth.Core.Config;

namespace Belot.Auth
{
    public class OAuth2Provider : OAuthAuthorizationServerProvider
    {
        private const string KEY_USER_ID = "user_id";
        private const string KEY_LOCALE_ID = "locale_id";
        private const string KEY_LOCALE_URLS = "locale_urls";

        private static readonly Random rand = new Random();

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var auth = new AuthProvider();

            string username = context.UserName, password = context.Password;
            if (username == null || password == null)
            {
                return;
            }

            IdentityUser user = await auth.UserManager.FindAsync(username, password);
            if (user != null)
            {
                context.Validated(GenerateTicket(context.Options.AuthenticationType, user));
            }
        }

        private AuthenticationTicket GenerateTicket(string authenticationType, IdentityUser user)
        {
            var identity = new ClaimsIdentity(authenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim("user_id", user.Id));

            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties()
            {
                AllowRefresh = true
            });

            int localeId = GetRandomLocaleId();
            List<string> localeUrls = GetLocaleUrls(localeId);

            ticket.Properties.Dictionary.Add(KEY_USER_ID, user.Id);
            ticket.Properties.Dictionary.Add(KEY_LOCALE_ID, localeId.ToString());
            ticket.Properties.Dictionary.Add(KEY_LOCALE_URLS, string.Join(",", localeUrls));

            return ticket;
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            string userId;
            if (context.Properties.Dictionary.TryGetValue(KEY_USER_ID, out userId))
            {
                context.AdditionalResponseParameters.Add(KEY_USER_ID, userId);
            }

            string localeId;
            if (context.Properties.Dictionary.TryGetValue(KEY_LOCALE_ID, out localeId))
            {
                context.AdditionalResponseParameters.Add(KEY_LOCALE_ID, localeId);
            }

            string localeUrls;
            if (context.Properties.Dictionary.TryGetValue(KEY_LOCALE_URLS, out localeUrls))
            {
                context.AdditionalResponseParameters.Add(KEY_LOCALE_URLS, localeUrls);
            }

            return Task.FromResult<object>(null);
        }

        private int GetRandomLocaleId()
        {
            ApiInstanceCollection instances = ApiInstanceSettings.Settings.Instances;
            var allLocaleIds = new HashSet<int>();

            for (int idx = 0; idx < instances.Count; idx++)
            {
                if (!allLocaleIds.Contains(instances[idx].LocaleId))
                {
                    allLocaleIds.Add(instances[idx].LocaleId);
                }
            }

            return allLocaleIds.ElementAt(rand.Next(allLocaleIds.Count));
        }

        private List<string> GetLocaleUrls(int localeId)
        {
            ApiInstanceCollection instances = ApiInstanceSettings.Settings.Instances;
            var localeUrls = new HashSet<string>();

            for (int idx = 0; idx < instances.Count; idx++)
            {
                if (instances[idx].LocaleId == localeId && !localeUrls.Contains(instances[idx].Url))
                {
                    localeUrls.Add(instances[idx].Url);
                }
            }

            return localeUrls.ToList();
        }
    }
}