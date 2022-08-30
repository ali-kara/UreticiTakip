using System.Web.Optimization;

namespace UreticiTakip_Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Bundles/jqueryval").Include(
            "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Bundles/CustomJS").Include(
            "~/Scripts/Custom/DatePicker.js"));

                 
            bundles.Add(new ScriptBundle("~/Bundles/DatepickerJS")
               .Include("~/Scripts/boostrap-datepicker.js")
               .Include("~/Scripts/moment-with-locales.js")
               .Include("~/Scripts/moment.js")
               );

            bundles.Add(new StyleBundle("~/Bundles/DatepickerCSS")
                .Include("~/Content/bootstrap-datetimepicker.css"));


            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/Site.css")
                .Include("~/Content/hint.min.css"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}