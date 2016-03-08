using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(IoCWebApi.App_Start.RoutesConfig), "PostStart")]

namespace IoCWebApi.App_Start
{
    [ExcludeFromCodeCoverage]
    public static class RoutesConfig
    {
        public static void PostStart()
        {
            // WebApi routes müssen vor MVC routes definiert werden!!!
            GlobalConfiguration.Configure(config => {
                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            });

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