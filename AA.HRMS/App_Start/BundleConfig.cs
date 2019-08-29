using System.Web;
using System.Web.Optimization;

namespace AA.HRMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css/style").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/style.css",
                "~/Content/css/owl.carousel.css",
                "~/Content/css/owl.theme.css",
                "~/Content/css/owl.transitions.css",
                "~/Content/css/meanmenu/meanmenu.min.css",
                "~/Content/css/animate.css",
                "~/Content/css/normalize.css",
                "~/Content/css/scrollbar/jquery.mCustomScrollbar.min.css",
                "~/Content/css/jvectormap/jquery-jvectormap-2.0.3.css",
                "~/Content/css/notika-custom-icon.css",
                "~/Content/css/wave/waves.min.css",
                "~/Content/css/main.css",
                "~/Content/css/responsive.css",
                 "~/Content/css/jquery.dataTables.min.css",
                 "~/Content/css/wave/button.css",
                 "~/Content/css/font-awesome.min.css",
                 "~/Content/css/buttons.dataTables.min.css",
                 "~/Content/themes/base/jquery-ui.css",
                 "~/Content/css/datepicker/datepicker3.css"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/js/script").Include(
                "~/Scripts/js/vendor/jquery-1.12.4.min.js",
                "~/Scripts/js/bootstrap.min.js",
                "~/Scripts/js/wow.min.js",
                "~/Scripts/js/jquery-price-slider.js",
                "~/Scripts/js/owl.carousel.min.js",
                "~/Scripts/js/jquery.scrollUp.min.js",
                "~/Scripts/js/meanmenu/jquery.meanmenu.js",
                "~/Scripts/js/counterup/jquery.counterup.min.js",
                "~/Scripts/js/counterup/waypoints.min.js",
                "~/Scripts/js/counterup/counterup-active.js",
                "~/Scripts/js/scrollbar/jquery.mCustomScrollbar.concat.min.js",
                "~/Scripts/js/jvectormap/jquery-jvectormap-2.0.2.min.js",
                "~/Scripts/js/jvectormap/jquery-jvectormap-world-mill-en.js",
                "~/Scripts/js/jvectormap/jvectormap-active.js",
                "~/Scripts/js/sparkline/jquery.sparkline.min.js",
                "~/Scripts/js/sparkline/sparkline-active.js",
                "~/Scripts/js/flot/jquery.flot.js",
                "~/Scripts/js/flot/jquery.flot.resize.js",
                "~/Scripts/js/flot/jquery.flot.pie.js",
                "~/Scripts/js/flot/jquery.flot.tooltip.min.js",
                "~/Scripts/js/flot/jquery.flot.orderBars.js",
                "~/Scripts/js/flot/curvedLines.js",
                "~/Scripts/js/flot/flot-active.js",
                "~/Scripts/js/knob/jquery.knob.js",
                "~/Scripts/js/knob/jquery.appear.js",
                "~/Scripts/js/knob/knob-active.js",
                "~/Scripts/js/wave/waves.min.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/datapicker/bootstrap-datepicker.js",
                "~/Scripts/datapicker/datepicker-active.js",
                "~/Scripts/js/wave/wave-active.js",
                "~/Scripts/js/todo/jquery.todo.js",
                "~/Scripts/js/plugins.js",
                "~/Scripts/js/chat/moment.min.js",
                "~/Scripts/js/chat/jquery.chat.js",
                "~/Scripts/js/main.js",
                "~/Scripts/js/tawk-chat.js",
                "~/Scripts/js/data-table/jquery.dataTables.min.js",
                "~/Scripts/js/data-table/data-table-act.js",
                "~/Scripts/dataTables.buttons.min.js",
                "~/Scripts/buttons.flash.min.js",
                "~/Scripts/buttons.html5.min.js",
                "~/Scripts/buttons.print.min.js",
                "~/Scripts/pdfmake.min.js",
                "~/Scripts/vfs_fonts.js"
            ));



        }
    }
}
