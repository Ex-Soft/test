using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace TestClipboard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCopyClick(object sender, EventArgs e)
        {
            string
                s = "4\t4.4\t4\t31.03.13\r\n";

            Clipboard.SetDataObject(s);
        }

        private void btnPasteClick(object sender, EventArgs e)
        {
            object
                o;

            string
                s;

            IDataObject
                iData;

            if (Clipboard.ContainsData(DataFormats.CommaSeparatedValue))
            {
                o = Clipboard.GetData(DataFormats.CommaSeparatedValue);

                if (o is MemoryStream)
                {
                    var sr = new StreamReader((MemoryStream)o);
                    s = sr.ReadToEnd();
                }
            }

            if (Clipboard.ContainsData(DataFormats.Text))
            {
                o = Clipboard.GetData(DataFormats.Text);

                if (o is string)
                    s = Convert.ToString(o);
            }

            if (Clipboard.ContainsData(DataFormats.UnicodeText))
            {
                o = Clipboard.GetData(DataFormats.UnicodeText);

                if (o is string)
                    s = Convert.ToString(o);
            }

            if (Clipboard.ContainsData(DataFormats.OemText))
            {
                o = Clipboard.GetData(DataFormats.OemText);

                if (o is string)
                    s = Convert.ToString(o);
            }

            if (Clipboard.ContainsData(DataFormats.Rtf))
            {
                o = Clipboard.GetData(DataFormats.Rtf);

                if (o is string)
                    s = Convert.ToString(o);
            }

            if (Clipboard.ContainsData("XML spreadsheet"))
            {
                o = Clipboard.GetData("XML spreadsheet");

                if (o is MemoryStream)
                {
                    var sr = new StreamReader((MemoryStream)o);
                    s = sr.ReadToEnd();
                    s = s.TrimEnd('\x0');
                    XElement xml = XElement.Parse(s);
                }
            }

            if (Clipboard.ContainsText())
                s = Clipboard.GetText();

            if (Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue))
                s = Clipboard.GetText(TextDataFormat.CommaSeparatedValue);
            
            if (Clipboard.ContainsText(TextDataFormat.Text))
                s = Clipboard.GetText(TextDataFormat.Text);
            
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
                s = Clipboard.GetText(TextDataFormat.UnicodeText);
            
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
                s = Clipboard.GetText(TextDataFormat.Rtf);
            
            if (Clipboard.ContainsText(TextDataFormat.Html))
                s = Clipboard.GetText(TextDataFormat.Html);

            if ((iData = Clipboard.GetDataObject()) != null)
            {
                if (iData.GetDataPresent(DataFormats.CommaSeparatedValue))
                {
                    o = iData.GetData(DataFormats.CommaSeparatedValue);

                    if (o is MemoryStream)
                    {
                        var sr = new StreamReader((MemoryStream)o);
                        s = sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
