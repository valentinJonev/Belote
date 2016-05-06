using System;
using System.Text.RegularExpressions;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using Belot.Auth.Core.Config;

[assembly: OwinStartup(typeof(Belot.Auth.Startup))]

namespace Belot.Auth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(168 * 60),
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/"),
                Provider = new OAuth2Provider()
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                Provider = new OAuthTokenProvider(req => req.Query.Get("access_token"))
            });

            app.MapSignalR("/signalr", new HubConfiguration()
            {
                EnableDetailedErrors = true,
                EnableJSONP = true,
                EnableJavaScriptProxies = true
            });

            GlobalConfiguration.Configure(Register);
        }

        private static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            ConfigureJsonFormatter(config);
        }

        private static void ConfigureJsonFormatter(HttpConfiguration config)
        {
            var formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver = new JsonLowerCaseUnderscoreContractResolver();
        }
    }

    public class JsonLowerCaseUnderscoreContractResolver : DefaultContractResolver
    {
        private Regex regex = new Regex("[a-zA-Z](?=[A-Z])");

        protected override string ResolvePropertyName(string propertyName)
        {
            return regex.Replace(propertyName, "$0_").ToLower();
        }
    }
}