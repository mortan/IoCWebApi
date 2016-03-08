using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IoCWebApi.App_Start.RouteConfig), "PreStart")]


namespace IoCWebApi.App_Start
{
    [ExcludeFromCodeCoverage]
    public static class RouteConfig
    {
        public static void PreStart()
        {
            var routes = RouteTable.Routes;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
