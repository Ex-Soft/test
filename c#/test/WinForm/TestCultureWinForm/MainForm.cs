// http://stackoverflow.com/questions/329033/what-is-the-difference-between-currentculture-and-currentuiculture-properties-of
// http://www.siao2.com/2007/01/11/1449754.aspx

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

namespace TestCultureWinForm
{
    public partial class MainForm : Form
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        static extern ushort GetSystemDefaultUILanguage();

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        static extern ushort GetUserDefaultUILanguage();

        public MainForm()
        {
            InitializeComponent();

            listBoxResult.Items.Add(string.Format("GetSystemDefaultUILanguage(): 0x{0:x4}", GetSystemDefaultUILanguage()));
            listBoxResult.Items.Add(string.Format("GetUserDefaultUILanguage(): 0x{0:x4}", GetUserDefaultUILanguage()));
            listBoxResult.Items.Add(string.Format("Thread.CurrentThread.CurrentUICulture: \"{0}\"", Thread.CurrentThread.CurrentUICulture));
            listBoxResult.Items.Add(string.Format("CultureInfo.CurrentCulture: \"{0}\"", CultureInfo.CurrentCulture));
            listBoxResult.Items.Add(string.Format("CultureInfo.CurrentUICulture: \"{0}\"", CultureInfo.CurrentUICulture));
            listBoxResult.Items.Add(string.Format("CultureInfo.DefaultThreadCurrentCulture: \"{0}\"", CultureInfo.DefaultThreadCurrentCulture));
            listBoxResult.Items.Add(string.Format("CultureInfo.DefaultThreadCurrentUICulture: \"{0}\"", CultureInfo.DefaultThreadCurrentUICulture));
            listBoxResult.Items.Add(string.Format("CultureInfo.InstalledUICulture: \"{0}\"", CultureInfo.InstalledUICulture));
            listBoxResult.Items.Add(string.Format("CultureInfo.InvariantCulture: \"{0}\"", CultureInfo.InvariantCulture));
            listBoxResult.Items.Add(string.Format("CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[0]: \"{0}\"", CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[0]));
            listBoxResult.Items.Add(string.Format("Encoding.Default: \"{0}\"", Encoding.Default));
        }

        private void BtnDoItClick(object sender, EventArgs e)
        {
            byte[]
                cp866Bytes = { 0x89, 0xae, 0xa1, 0xa0, 0xad, 0xeb, 0xa9, 0x20, 0xa2, 0x20, 0xe0, 0xae, 0xe2 },
                asciiBytes = Encoding.Convert(Encoding.GetEncoding(866), Encoding.ASCII, cp866Bytes);

            string tmpString = Encoding.Default.GetString(cp866Bytes);
            tmpString = Encoding.GetEncoding(866).GetString(cp866Bytes);
            tmpString = Encoding.ASCII.GetString(asciiBytes);

            using (var memoryStream = new MemoryStream(cp866Bytes))
            {
                var tmp = Encoding.Default.GetString(memoryStream.ToArray());
            }
        }
    }
}
