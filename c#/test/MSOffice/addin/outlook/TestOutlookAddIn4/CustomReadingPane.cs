using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace TestOutlookAddIn4
{
    partial class CustomReadingPane
    {
        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass("IPM.Note.CustomReadingPane")]
        [Microsoft.Office.Tools.Outlook.FormRegionName("TestOutlookAddIn4.CustomReadingPane")]
        public partial class CustomReadingPaneFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void CustomReadingPaneFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void CustomReadingPane_FormRegionShowing(object sender, System.EventArgs e)
        {
            Outlook.MailItem
                mailItem;

            if((mailItem=OutlookItem as Outlook.MailItem)!=null)
                textBox1.Text = ThisAddIn.GetMailItemHeaderFrom(mailItem);
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void CustomReadingPane_FormRegionClosed(object sender, System.EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Outlook.MailItem
                mailItem;

            if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                System.Windows.Forms.MessageBox.Show(mailItem.MessageClass);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Outlook.MailItem
                mailItem;

            if ((mailItem = OutlookItem as Outlook.MailItem) != null)
            {
                mailItem.MessageClass = "IPM.Note";
                mailItem.Save();
                System.Windows.Forms.MessageBox.Show(mailItem.MessageClass);
            }
        }
    }
}
