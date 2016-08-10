using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ManagementApp.Infrastructure.Utilities
{
    public static class JsonExtensions
    {
        public static string ToJson<T>(this T obj,
         bool includeNull = true, bool useCamelCase = true)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new JsonConverter[] { new StringEnumConverter() },
                NullValueHandling = includeNull ? NullValueHandling.Include : NullValueHandling.Ignore
            };

            if (useCamelCase)
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}