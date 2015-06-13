using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace HuariqueRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Culture = new CultureInfo("es-PE");
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            foreach (var formatter in config.Formatters)
            {
                Trace.WriteLine(string.Format("{0}: {1}",
                 formatter.GetType().Name,
                 string.Join(", ", formatter.SupportedMediaTypes.Select(x => x.MediaType))
                 ));
            }
        }
    }
}
