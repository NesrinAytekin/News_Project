using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace News_Project.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //Admin/Category/Create
                //Admin/Category/Details/1
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces:new[] { "News_Project.UI.Controllers" }
            );
        }
    }
}
