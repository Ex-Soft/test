using System;
using System.IO;
using System.Windows.Forms;

namespace CapturingConsoleOutput
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnTestClick(object sender, EventArgs e)
        {
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriterWithDebugWriteLine())
            {
                System.Console.SetOut(writer);
                System.Console.WriteLine("blah-blah-blah");
                //writer.Flush();
                //var message = writer.GetStringBuilder().ToString();
                //System.Diagnostics.Debug.WriteLine(message);
            }
            System.Console.SetOut(originalConsoleOut);
        }
    }

    public class StringWriterWithDebugWriteLine : StringWriter
    {
        public override void Write(char[] buffer, int index, int count)
        {
            base.Write(buffer, index, count);
            System.Diagnostics.Debug.Write(new string(buffer, index, count));
        }

        public override void WriteLine(string? value)
        {
            base.WriteLine(value);
            System.Diagnostics.Debug.WriteLine(value);
        }
    }
}
