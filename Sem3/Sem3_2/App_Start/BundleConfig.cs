using System.Web;
using System.Web.Optimization;

namespace Sem3_2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/myScript").Include(
                      "~/Content/js/myScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/homeScript").Include(
                      "~/Content/js/homeScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/productScript").Include(
                      "~/Content/js/productScript.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/css/myStyle.css",
                      "~/Content/font-awesome-4.5.0/css/font-awesome.min.css"));
        }
    }
}
