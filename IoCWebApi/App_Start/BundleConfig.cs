using System.Diagnostics.CodeAnalysis;
using System.Web.Optimization;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IoCWebApi.App_Start.BundleConfig), "PreStart")]

namespace IoCWebApi.App_Start
{
    [ExcludeFromCodeCoverage]
    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void PreStart()
        {
            var bundles = BundleTable.Bundles;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
