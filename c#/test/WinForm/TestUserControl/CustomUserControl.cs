using System;
using System.Windows.Forms;

namespace TestUserControl
{
    public partial class CustomUserControl : UserControl
    {
        public CustomUserControl()
        {
            InitializeComponent();

            Disposed += CustomUserControlDisposed;
        }

        void CustomUserControlDisposed(object sender, EventArgs e)
        {
            Disposed -= CustomUserControlDisposed;

            System.Diagnostics.Debug.WriteLine("OnDisposed");
        }
    }
}
