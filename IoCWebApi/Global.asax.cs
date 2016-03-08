using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace IoCWebApi
{
    [ExcludeFromCodeCoverage]
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Seperation of concern... Startup-Logik befindet sich in den entsprechenden Klassen in App_Start
        }
    }
}
