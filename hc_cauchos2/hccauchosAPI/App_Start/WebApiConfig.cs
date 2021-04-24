using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiSegura.Security;

namespace hccauchosAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //,"proxyConfig": "proxy.conf.json"
            //--proxy-config proxy.conf.json
            config.EnableCors();
            // Configuración de rutas y servicios de API
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var cors = new EnableCorsAttribute("*", "*", "*"); config.EnableCors(cors);
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                //new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
                
            //config.EnableCors(new EnableCorsAttribute("anonymous", "anonymous", "anonymous"));
        }
    }
}