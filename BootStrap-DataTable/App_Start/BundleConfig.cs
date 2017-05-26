using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace BootStrap_DataTable.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region script bundles
            bundles.Add(new ScriptBundle("~/bundles/employee").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap4.min.js",
                "~/Scripts/App/common.js"
                ));
            #endregion
            #region style bundles
            bundles.Add(new StyleBundle("~/Content/employee").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.min.css",
                      "~/Content/Site.css"));
            #endregion
           // BundleTable.EnableOptimizations = true;

        }
    }
}