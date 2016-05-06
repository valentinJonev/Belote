using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Belot.WebApi.Common
{
    public static class ApiExtensions
    {
        public static void AddValidationErrors(this ModelStateDictionary modelState, IEnumerable<string> errors)
        {
            foreach (var err in errors)
            {
                modelState.AddModelError(string.Empty, err);
            }
        }
    }
}