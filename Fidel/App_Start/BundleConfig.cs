using System.Web;
using System.Web.Optimization;

namespace Fidel
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/DataTables").Include(
                      "~/Content/dataTables.bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/SweetAlert").Include(
                      "~/Content/SweetAlert/sweetalert2.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                        "~/Scripts/SweetAlert/sweetalert2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/DataTable").Include(
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.min.js"
                      ));


            bundles.Add(new StyleBundle("~/Content/DataTable").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/DatePicker").Include(
                      "~/Scripts/bootstrap-datepicker.min.js"
                      ));


            bundles.Add(new StyleBundle("~/Content/DatePicker").Include(
                      "~/Content/bootstrap-datepicker3.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/GrupoFamiliar").Include(
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                      "~/Scripts/Api/GrupoFamiliar.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/CreatePersona").Include(
                      "~/Scripts/Api/Persona/Create.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/EditPersona").Include(
                      "~/Scripts/Api/Persona/Edit.js"
                      ));


            bundles.Add(new StyleBundle("~/Content/GrupoFamiliar").Include(
                      "~/Content/Api/GrupoFamiliar.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css"
            ));
        }
    }
}
