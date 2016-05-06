using System;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace Belot.WebApi.Common
{
    public class BadRequestResponse : BaseApiResponse
    {
        public BadRequestResponse()
        {
            Message = "Bad request";
            ModelErrors = new Dictionary<string, BadRequestError>();
        }

        public IDictionary<string, BadRequestError> ModelErrors { get; private set; }
        
        public static BadRequestResponse Create(ModelStateDictionary modelState)
        {
            var response = new BadRequestResponse();
            response.PopulateModelErrors(modelState);

            return response;
        }

        public static BadRequestResponse Create(string message)
        {
            var response = new BadRequestResponse();
            response.AddError(message);

            return response;
        }

        public static BadRequestResponse Create(IEnumerable<string> validationErrors)
        {
            var response = new BadRequestResponse();
            BadRequestError badRequestError;
            if (!response.ModelErrors.TryGetValue(string.Empty, out badRequestError))
            {
                badRequestError = new BadRequestError();
                response.ModelErrors.Add(string.Empty, badRequestError);
            }

            foreach (string err in validationErrors)
            {
                badRequestError.AddError(err);
            }

            return response;
        }

        public static BadRequestResponse CreateForNull()
        {
            var response = new BadRequestResponse();
            response.AddError("Content cannot be null");

            return response;
        }

        private void PopulateModelErrors(ModelStateDictionary modelState)
        {
            foreach (KeyValuePair<string, ModelState> validationItem in modelState)
            {
                string propertyName = StripOutModelName(validationItem.Key);

                BadRequestError badRequestError;
                if (!ModelErrors.TryGetValue(propertyName, out badRequestError))
                {
                    badRequestError = new BadRequestError();
                    ModelErrors.Add(propertyName, badRequestError);
                }

                foreach (ModelError err in validationItem.Value.Errors)
                {
                    if (!string.IsNullOrWhiteSpace(err.ErrorMessage))
                    {
                        badRequestError.AddError(err.ErrorMessage);
                    }

                    if (err.Exception != null)
                    {
                        badRequestError.AddException(err.Exception.Message);
                    }
                }
            }
        }

        private string StripOutModelName(string propertyName)
        {
            int cutIndex = propertyName.IndexOfAny(new char[] { '.', '[' });
            if (cutIndex > -1)
            {
                return propertyName.Substring(cutIndex + 1);
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class BadRequestError
    {
        public BadRequestError()
        {
            Errors = new List<string>();
            Exceptions = new List<string>();
        }

        public IList<string> Errors { get; private set; }

        public IList<string> Exceptions { get; private set; }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void AddException(string exceptionMessage)
        {
            Exceptions.Add(exceptionMessage);
        }
    }
}