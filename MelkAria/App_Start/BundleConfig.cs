using System.Web;
using System.Web.Helpers;
using System.Web.Optimization;

namespace MelkAria
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.IgnoreList.Clear();
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/AdminJS").Include(
               "~/Scripts/sina/jquery-3.3.1.min.js",
               //"~/Scripts/jquery.validate.js",
               "~/Scripts/sina/jquery.validate.min.js",
               "~/Scripts/sina/jquery.validate.unobtrusive.min.js",
               // "~/Scripts/jquery.unobtrusive-ajax.min.js",
               //"~/Content/vendors/jquery/dist/jquery.min.js",
               "~/Content/vendors/popper.js/dist/umd/popper.min.js",
               "~/Content/vendors/bootstrap/dist/js/bootstrap.min.js",

               "~/Content/vendors/datatables.net/js/jquery.dataTables.min.js",
               "~/Content/vendors/datatables.net-buttons/js/dataTables.buttons.min.js",
               "~/Content/vendors/datatables.net-buttons/js/buttons.print.min.js",
               "~/Content/vendors/datatables.net-buttons/js/buttons.html5.min.js",
               "~/Content/vendors/autosize/dist/autosize.min.js",
               "~/Content/vendors/jquery-mask-plugin/dist/jquery.mask.min.js",
               "~/Content/vendors/salvattore/dist/salvattore.min.js",
               "~/Content/vendors/flot/jquery.flot.js",
               "~/Content/vendors/flot/jquery.flot.resize.js",
               "~/Content/vendors/flot.curvedlines/curvedLines.js",
               "~/Content/vendors/jqvmap/dist/jquery.vmap.min.js",
               "~/Content/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
               "~/Content/vendors/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js",
               "~/Content/vendors/peity/jquery.peity.min.js",
               "~/Content/vendors/jqTree/tree.jquery.js",
               "~/Content/vendors/remarkable-bootstrap-notify/dist/bootstrap-notify.min.js",
               "~/Content/vendors/sweetalert2/dist/sweetalert2.min.js",
               "~/Content/JS/app.min.js",
               "~/Scripts/jquery.validate.js",
               "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Content/vendors/jquery.scrollbar/jquery.scrollbar.min.js",
               "~/Content/vendors/jquery-scrollLock/jquery-scrollLock.min.js"
               ));
            //bundles.Add(new ScriptBundle("~/bundles/AdminCSS").Include(
            //    "~/Content/vendors/material-design-iconic-font/dist/css/material-design-iconic-font.min.css",
            //    "~/Content/vendors/animate.css/animate.min.css",
            //    "~/Content/vendors/jquery.scrollbar/jquery.scrollbar.css",
            //    "~/Content/vendors/fullcalendar/dist/fullcalendar.min.css",
            //    "~/Content/vendors/sweetalert2/dist/sweetalert2.min.css",
            //    "~/Content/CSS/app.min.css",
            //    "~/Content/CSS/MyStyle.css"
            //    ));
            bundles.Add(new StyleBundle("~/bundles/HomeCSS").Include(

            "~/Content/HomeVendors/css/main.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/HomeJS").Include(
               "~/Content/HomeVendors/js/bootstrap.js",
               "~/Content/HomeVendors/js/main.js",
               "~/Content/HomeVendors/js/swiper.js",
               "~/Content/HomeVendors/js/scripts.js"
              ));
            AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;
             BundleTable.EnableOptimizations = true;

        }
    }
}
