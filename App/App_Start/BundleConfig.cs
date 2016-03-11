using System.Web;
using System.Web.Optimization;

namespace App
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/scripts/jquery.validate.unobtrusive.js"
                        ));


            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                      "~/scripts/jquery-1.12.0.min.js",
                      "~/scripts/jquery.validate.unobtrusive.js",
                      "~/scripts/moment.min.js",
                      "~/scripts/bootstrap.min.js",
                      "~/scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTable").Include(
                      "~/scripts/jquery.dataTables.min.js",
                      "~/scripts/dataTables.bootstrap.min.js" ));



            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/razorAjax").Include(
                      "~/scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/site.css"));
        }
    }
}
