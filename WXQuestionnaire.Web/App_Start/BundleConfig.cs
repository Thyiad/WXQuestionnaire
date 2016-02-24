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
                "~/Content/bootstrap.css",
                "~/Content/css/font-awesome.min.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/commonJS").Include(
                "~/Scripts/jquery-{version}.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/commonAdminCSS").Include(
                "~/Content/bootstrap.css",
                "~/Content/css/font-awesome.min.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/commonAdminJS").Include(
                "~/Scripts/jquery-{version}.js"
                ));
        }
    }
}
