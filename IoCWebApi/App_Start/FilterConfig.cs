using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IoCWebApi.App_Start.FilterConfig), "PreStart")]

namespace IoCWebApi.App_Start
{
    [ExcludeFromCodeCoverage]
    public static class FilterConfig
    {
        public static void PreStart()
        {
            var filters = GlobalFilters.Filters;

            filters.Add(new HandleErrorAttribute());
        }
    }
}
