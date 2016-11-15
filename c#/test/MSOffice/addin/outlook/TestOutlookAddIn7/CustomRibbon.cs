using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace TestOutlookAddIn7
{
    public partial class CustomRibbon : OfficeRibbon
    {
        public CustomRibbon()
        {
            InitializeComponent();
        }

        private void CustomRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("blah-blah-blah");
            Microsoft.Office.Interop.Outlook.Application
                application = Globals.ThisAddIn.Application;
        }
    }
}
