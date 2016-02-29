using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace WXQuestionnaire.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
             bundles.Add(new StyleBundle("~/bundles/commonCSS").Include(
                 // debug
                "~/Content/bootstrap.css",
                "~/css/font-awesome.min.css"
                // release
                ));
            bundles.Add(new ScriptBundle("~/bundles/commonJS").Include(
                "~/Scripts/jquery-{version}.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/commonAdminCSS").Include(
                "~/Content/bootstrap.css",
                "~/css/font-awesome.min.css",
                "~/Content/admin/css/components.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/commonAdminJS").Include(
                "~/Content/admin/js/jquery-1.11.0.min.js",
                "~/Content/admin/js/jquery-migrate-1.2.1.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/metronicJS").Include(
               "~/Content/admin/js/metronic.js"
               ));
        }
    }
}
