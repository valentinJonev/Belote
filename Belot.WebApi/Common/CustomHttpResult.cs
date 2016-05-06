using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Belot.WebApi.Common
{
    public class CustomHttpResult : IHttpActionResult
    {
        private HttpRequestMessage request;
        private HttpStatusCode statusCode;
        private object response;

        public CustomHttpResult(HttpRequestMessage request, HttpStatusCode statusCode, object response = null)
        {
            this.request = request;
            this.statusCode = statusCode;
            this.response = response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            if (response != null)
            {
                return Task.FromResult(request.CreateResponse(statusCode, response));
            }
            else
            {
                return Task.FromResult(request.CreateResponse(statusCode));
            }
        }
    }
}