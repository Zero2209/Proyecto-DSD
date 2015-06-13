using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using WarikeRest.Models;

namespace WarikeRest
{
    public static class WebApiConfig
    {
           public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{action}/{id}",
             defaults: new { id = RouteParameter.Optional }
        );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            foreach (var formatter in config.Formatters)
            {
                Trace.WriteLine(formatter.GetType().Name);
                Trace.WriteLine("\tCanReadType: " + formatter.CanReadType(typeof(User)));
                Trace.WriteLine("\tCanWriteType: " + formatter.CanWriteType(typeof(User)));
                Trace.WriteLine("\tBase: " + formatter.GetType().BaseType.Name);
                Trace.WriteLine("\tMedia Types: " + String.Join(", ", formatter.SupportedMediaTypes));
            }
        }
    }
    
}
