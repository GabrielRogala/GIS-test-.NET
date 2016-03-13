using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GIS_test1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GetDir",
                url: "Photos/GetPhotos",
                defaults: new { controller = "Photos", action = "GetDir" }
            );

            routes.MapRoute(
                name: "GetFiles",
                url: "Photos/GetPhotos/{id}",
                defaults: new { controller = "Photos", action = "GetFiles" }
            );

            routes.MapRoute(
                name: "Delete",
                url: "Photos/Delete/{id}/{file}/",
                defaults: new { controller = "Photos", action = "Delete"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
