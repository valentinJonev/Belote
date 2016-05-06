using Microsoft.Owin.Security.OAuth;
using Owin;
using Belot.WebApi.Owin;

namespace Belot.WebApi
{
	public partial class Startup
	{
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                Provider = new OAuthTokenProvider(req => req.Query.Get("access_token"))
            });
        }
    }
}