using DevExpress.XtraEditors;

namespace TestUserControl
{
    class CustomUserControl : XtraUserControl
    {
        protected override void OnFirstLoad()
        {
            System.Diagnostics.Debug.WriteLine("CustomUserControl.OnFirstLoad()");

            base.OnFirstLoad();
        }

        protected override void Dispose(bool disposing)
        {
            System.Diagnostics.Debug.WriteLine("CustomUserControl.Dispose()");
            base.Dispose(disposing);
        }
    }
}
