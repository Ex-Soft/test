using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Host.ServiceReference1;

namespace Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new Service1Client();

            var result = client.GetData(1);
            System.Diagnostics.Debug.WriteLine(result);

            CompositeType
                compositeTypeIn = new CompositeType { BoolValue = true, StringValue = "StringValue" },
                compositeTypeOut = client.GetDataUsingDataContract(compositeTypeIn);

            System.Diagnostics.Debug.WriteLine(string.Format("{{ BoolValue = \"{0}\", StringValue =\"{1}\" }}", compositeTypeOut.BoolValue, compositeTypeOut.StringValue));
        }
    }
}
