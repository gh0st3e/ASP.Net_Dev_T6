﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab5B
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "MResearch",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MResearch", action = "index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AResearch",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AResearch", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CHResearch",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CHResearch", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
