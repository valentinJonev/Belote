using System;
using System.Collections.Generic;

namespace Belot.WebApi.Common
{
    public class BaseApiResponse
    {
        public BaseApiResponse()
        {
            Errors = new List<string>();
        }

        public string Message { get; set; }

        public List<string> Errors { get; private set; }

        public static BaseApiResponse InternalServerError(string message = null)
        {
            var response = new BaseApiResponse()
            {
                Message = "Server error"
            };

            if (message != null)
            {
                response.AddError(message);
            }

            return response;
        }

        public static BaseApiResponse NotFound(Uri requestUri)
        {
            return new BaseApiResponse()
            {
                Message = string.Format("Not found", requestUri.ToString())
            };
        }

        public static BaseApiResponse OperationImpossible(string message = null)
        {
            var response = new BaseApiResponse()
            {
                Message = "Impossible",
            };

            if (message != null)
            {
                response.AddError(message);
            }

            return response;
        }

        public static BaseApiResponse Forbidden(string message = null)
        {
            var response = new BaseApiResponse()
            {
                Message = "Forbidden"
            };
            if (message != null)
            {
                response.AddError(message);
            }

            return response;
        }

        public void AddError(string errorMessage)
        {
            Errors.Add(errorMessage);
        }
    }
}