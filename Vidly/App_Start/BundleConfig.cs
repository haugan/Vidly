using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // READ MORE ON BUNDLING (COMBINE & COMPRESS LIBS): https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // JAVASCRIPT LIBRARIES
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/respond.js",
                "~/Scripts/DataTables/media/js/jquery.dataTables.js",
                "~/Scripts/DataTables/media/js/dataTables.bootstrap.js",
                "~/Scripts/typeahead.bundle.js"));

            // VALIDATION
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // MODERNIZR
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            // CSS STYLING
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap-flatly.css",
                "~/Content/DataTables/media/css/dataTables.bootstrap.css",
                "~/Content/typeahead.css",
                "~/Content/site.css"));
        }
    }
}
