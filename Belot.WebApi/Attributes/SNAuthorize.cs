using System.Web.Http;
using System.Web.Http.Controllers;

namespace Belot.WebApi.Attributes
{
    public class SNAuthorize : AuthorizeAttribute
    {
        // Summary:
        //     Calls when an action is being authorized.
        //
        // Parameters:
        //   actionContext:
        //     The context.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The context parameter is null.
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}