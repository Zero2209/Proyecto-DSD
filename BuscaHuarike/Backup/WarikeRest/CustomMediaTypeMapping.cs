using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApiDemo
{
    public class CustomMediaTypeMapping : MediaTypeMapping
    {
        public CustomMediaTypeMapping(MediaTypeHeaderValue mediaType)
            : base(mediaType)
        { }

        public override double TryMatchMediaType(HttpRequestMessage request)
        {

            return (request.Headers.AcceptLanguage.ToString() == "es-PE") ? 1.0 : 0.0;

        }
    }
}