using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GildedRose
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
         // Web API configuration and services

         // Register our Basic Authentication filter.
         //config.Filters.Add(new IdentityBasicAuthenticationAttribute());


         // Web API routes
         config.MapHttpAttributeRoutes();

            /*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/
      }
   }
}
