using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WEBQPlayer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Game",
                url: "scene/{folder1}/{folder2}/{folder3}/{folder4}",
                defaults: new { controller = "Index", action = "Game", folder1 = UrlParameter.Optional, folder2 = UrlParameter.Optional, folder3 = UrlParameter.Optional, folder4 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GameMain",
                url: "scene/",
                defaults: new { controller = "Index", action = "Game", folder1 = UrlParameter.Optional, folder2 = UrlParameter.Optional, folder3 = UrlParameter.Optional, folder4 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Processor",
                url: "callback/{id}",
                defaults: new { controller = "Index", action = "Processor", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "TestCPU",
                url: "TestCPU/",
                defaults: new { controller = "Index", action = "TestCPU" }
            );

            routes.MapRoute(
                name: "Stats",
                url: "Stats/",
                defaults: new { controller = "Index", action = "Stats" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Index", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}
