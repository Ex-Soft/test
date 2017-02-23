// http://stackoverflow.com/questions/329033/what-is-the-difference-between-currentculture-and-currentuiculture-properties-of
// http://www.siao2.com/2007/01/11/1449754.aspx Why we have both CurrentCulture and CurrentUICulture
// https://blogs.msdn.microsoft.com/snippets/2008/11/10/what-we-should-know-about-currentculture-and-currentuiculture/ What we should know about CurrentCulture and CurrentUICulture?
// http://donkeybridge.blogspot.com/2011/03/dotnet-currentculture-vs.html Dot.Net: CurrentCulture vs CurrentUICulture

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace TestCultureWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            listBoxResult.Items.Add($"Thread.CurrentThread.CurrentCulture: \"{Thread.CurrentThread.CurrentCulture}\"");
            listBoxResult.Items.Add($"Thread.CurrentThread.CurrentUICulture: \"{Thread.CurrentThread.CurrentUICulture}\"");
            listBoxResult.Items.Add($"CultureInfo.CurrentCulture: \"{CultureInfo.CurrentCulture}\"");
            listBoxResult.Items.Add($"CultureInfo.CurrentUICulture: \"{CultureInfo.CurrentUICulture}\"");
            listBoxResult.Items.Add($"CultureInfo.DefaultThreadCurrentCulture: \"{CultureInfo.DefaultThreadCurrentCulture}\"");
            listBoxResult.Items.Add($"CultureInfo.DefaultThreadCurrentUICulture: \"{CultureInfo.DefaultThreadCurrentUICulture}\"");
            listBoxResult.Items.Add($"CultureInfo.InstalledUICulture: \"{CultureInfo.InstalledUICulture}\"");
            listBoxResult.Items.Add($"CultureInfo.InvariantCulture: \"{CultureInfo.InvariantCulture}\"");
        }

        private void BtnDoItClick(object sender, EventArgs e)
        {
            listBoxResult.Items.Add($"Thread.CurrentThread.CurrentCulture: \"{Thread.CurrentThread.CurrentCulture}\"");
            listBoxResult.Items.Add($"Thread.CurrentThread.CurrentUICulture: \"{Thread.CurrentThread.CurrentUICulture}\"");
            listBoxResult.Items.Add($"CultureInfo.CurrentCulture: \"{CultureInfo.CurrentCulture}\"");
            listBoxResult.Items.Add($"CultureInfo.CurrentUICulture: \"{CultureInfo.CurrentUICulture}\"");
            listBoxResult.Items.Add($"CultureInfo.DefaultThreadCurrentCulture: \"{CultureInfo.DefaultThreadCurrentCulture}\"");
            listBoxResult.Items.Add($"CultureInfo.DefaultThreadCurrentUICulture: \"{CultureInfo.DefaultThreadCurrentUICulture}\"");
            listBoxResult.Items.Add($"CultureInfo.InstalledUICulture: \"{CultureInfo.InstalledUICulture}\"");
            listBoxResult.Items.Add($"CultureInfo.InvariantCulture: \"{CultureInfo.InvariantCulture}\"");
        }
    }
}
