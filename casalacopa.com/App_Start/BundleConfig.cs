using System.Web.Optimization;

namespace casalacopa.com
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/iconFont.css", "~/Content/bootstrap.css", "~/Content/datepicker.css", "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                "~/Scripts/vendor/bootstrap.js",
                "~/Scripts/vendor/bootstrap-datepicker.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/vendor/angular.js",
                "~/Scripts/vendor/angular-route.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/controllers")
                .Include("~/Scripts/controllers/location.js",
                        "~/Scripts/controllers/book.js"));
            bundles.Add(new ScriptBundle("~/bundles/directives_services")
                .Include("~/Scripts/directives/directives.js"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/Scripts/app.js"));
        }
    }
}