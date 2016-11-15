using System.Web.Optimization;

namespace LessonProject
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = false; // without minify
            //BundleTable.EnableOptimizations = true; // with minify

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap*"));
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/common.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css")
                .Include("~/Content/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/fineuploader")
                .Include("~/Scripts/fine-uploader/header.js")
                .Include("~/Scripts/fine-uploader/util.js")
                .Include("~/Scripts/fine-uploader/button.js")
                .Include("~/Scripts/fine-uploader/ajax.requester.js")
                .Include("~/Scripts/fine-uploader/deletefile.ajax.requester.js")
                .Include("~/Scripts/fine-uploader/handler.base.js")
                .Include("~/Scripts/fine-uploader/window.receive.message.js")
                .Include("~/Scripts/fine-uploader/handler.form.js")
                .Include("~/Scripts/fine-uploader/handler.xhr.js")
                .Include("~/Scripts/fine-uploader/uploader.basic.js")
                .Include("~/Scripts/fine-uploader/dnd.js")
                .Include("~/Scripts/fine-uploader/uploader.js")
                .Include("~/Scripts/fine-uploader/jquery-plugin.js")
                );

            bundles.Add(new StyleBundle("~/Content/css/jqueryui")
               .Include("~/Content/jquery-ui*"));

            bundles.Add(new StyleBundle("~/Content/css/fineuploader")
             .Include("~/Content/fineuploader.css"));
        }
    }
}