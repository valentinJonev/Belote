using System.IO;
using System.Net;
using System.Web.Http;
using Belot.WebApi.Attributes;

namespace Belot.WebApi.Common
{
    [SNAuthorize]
    public class BaseApiController : ApiController
    {
        protected IHttpActionResult Created()
        {
            return new CustomHttpResult(Request, HttpStatusCode.Created);
        }

        protected IHttpActionResult NoContent()
        {
            return new CustomHttpResult(Request, HttpStatusCode.NoContent);
        }

        protected IHttpActionResult InternalServerError(BaseApiResponse response)
        {
            return new CustomHttpResult(Request, HttpStatusCode.InternalServerError, response);
        }

        protected new IHttpActionResult BadRequest()
        {
            return new CustomHttpResult(Request, HttpStatusCode.BadRequest, BadRequestResponse.Create(ModelState));
        }

        protected new IHttpActionResult BadRequest(string message)
        {
            return new CustomHttpResult(Request, HttpStatusCode.BadRequest, BadRequestResponse.Create(message));
        }

        protected new IHttpActionResult NotFound()
        {
            return new CustomHttpResult(Request, HttpStatusCode.NotFound, BaseApiResponse.NotFound(Request.RequestUri));
        }

        protected IHttpActionResult Conflict(string message)
        {
            return new CustomHttpResult(Request, HttpStatusCode.Conflict, BaseApiResponse.OperationImpossible(message));
        }

        protected IHttpActionResult NotModified()
        {
            return new CustomHttpResult(Request, HttpStatusCode.NotModified);
        }

        protected IHttpActionResult Forbidden()
        {
            return new CustomHttpResult(Request, HttpStatusCode.Forbidden);
        }
    }
}