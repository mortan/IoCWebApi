using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(IoCWebApi.App_Start.WebApiConfig), "PostStart")]

namespace IoCWebApi.App_Start
{
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig
    {
        public static void PostStart()
        {
            GlobalConfiguration.Configure(config => {
                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            });
        }
    }
}
