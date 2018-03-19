using System.Web;
using System.Web.Optimization;

namespace ProvalusApplicantTrackingHub {
    public class BundleConfig {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/DataTables/jquery.dataTables.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Script/DataTables/dataTables.semanticui.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/dist/bootstrap3-editable/js/bootstrap-editable.js",
                        "~/Scripts/inputs-ext/address/address.js"));

            bundles.Add(new ScriptBundle("~/bundles/semantic").Include(
                        "~/semantic/dist/semantic.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/DataTables/dataTables.semanticui.css",
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap3-editable/css/bootstrap-editable.css",
                        "~/semantic/dist/semantic.css",
                        "~/Content/site.css"));

            // Semantic UI helper scripts
            bundles.Add(new ScriptBundle("~/helpers/tablesort").Include(
                        "~/Scripts/tablesort.js"));

           
                        
        }
    }
}
