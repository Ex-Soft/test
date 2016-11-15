using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExampleWithMyExtendedWebBrowser
{
    public partial class FormWithExtendedBrowser : Form
    {
        public FormWithExtendedBrowser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.extendedWebBrowser1.Navigate(textBox1.Text);
        }

        private void extendedWebBrowser1_NewWindow2(object sender, NewWindow2EventArgs e)
        {
            //Intercepting this event will allow us to create a new form in which
            //we will open the new webpage, to do that we must set the ppDisp property
            //of the NewWindow2EventArgs
            FormWithExtendedBrowser form1 = new FormWithExtendedBrowser();
            form1.Show();
            e.PPDisp = form1.extendedWebBrowser1.Application;
        }
    }
}
