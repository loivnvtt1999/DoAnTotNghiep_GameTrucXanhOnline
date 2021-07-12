using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace TrucXanh_WebVersion
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                   name: "LoginAdmin",
                   url: "admin",
                   defaults: new { controller = "_admin", action = "Login", id = UrlParameter.Optional }
               );
            routes.MapRoute(
                   name: "PlayGame",
                   url: "tro-choi",
                   defaults: new { controller = "_game", action = "playGame", id = UrlParameter.Optional }
               );
            routes.MapRoute(
                name: "MenuGame",
                url: "menu-tro-choi",
                defaults: new { controller = "_game", action = "menuGame", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Continue",
                url: "choi-tiep-tuc/{Alias}",
                defaults: new { controller = "_game", action = "continueGame" }
            );
            routes.MapRoute(
                name: "Level",
                url: "danh-sach-man-choi",
                defaults: new { controller = "_level", action = "getListLevel", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 name: "Image",
                 url: "danh-sach-hinh-anh",
                 defaults: new { controller = "_image", action = "getListImage", id = UrlParameter.Optional }
             );
            routes.MapRoute(
               name: "LoginAccount",
               url: "",
               defaults: new { controller = "_account", action = "Login", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
