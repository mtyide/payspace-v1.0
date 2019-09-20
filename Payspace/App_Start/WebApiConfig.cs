using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Payspace
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"^[0-9]+$" });
            config.Routes.MapHttpRoute("ApiWithActionAndName", "api/{controller}/{action}/{name}", null, new { id = @"^[a-z]+$" });
            config.Routes.MapHttpRoute("ApiWithAction", "api/{controller}/{action}", null, null);
        }
    }
}
