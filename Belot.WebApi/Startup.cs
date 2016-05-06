using Belot.WebApi.App_Start;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Http = System.Web.Http;

[assembly: OwinStartup(typeof(Belot.WebApi.Startup))]

namespace Belot.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Http.GlobalConfiguration.Configuration.DependencyResolver = new ServiceResolver();

            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
            app.MapSignalR("/signalr", new HubConfiguration()
            {
                EnableDetailedErrors = true,
                EnableJSONP = true,
                EnableJavaScriptProxies = true
            });

            Http.GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}