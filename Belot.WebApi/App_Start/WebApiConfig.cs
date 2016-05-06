using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text.RegularExpressions;
using System.Web.Http;
using Belot.WebApi.Attributes;
using Newtonsoft.Json.Serialization;

namespace Belot.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{*url}",
                defaults: new { controller = "ErrorApi", action = "Handle404" });

            ConfigureJsonFormatterOnly(config);
            
            config.Filters.Add(new ValidateModelStateAttribute());
            config.Filters.Add(new CheckModelForNullAttribute());
        }

        private static void ConfigureJsonFormatterOnly(HttpConfiguration config)
        {
            var formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver = new JsonLowerCaseUnderscoreContractResolver();

            RemoveFormattersExcept(config.Formatters, formatter);
        }

        private static void RemoveFormattersExcept(MediaTypeFormatterCollection allFormatters, MediaTypeFormatter formatter)
        {
            allFormatters.Insert(0, formatter);
            for (int i = allFormatters.Count - 1; i > 0; i--)
            {
                allFormatters.RemoveAt(i);
            }
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
