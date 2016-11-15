using System;
using System.Windows.Forms;

namespace TestPool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonDoIt_Click(object sender, EventArgs e)
        {
            int
                size = 0;

            int.TryParse(TextBoxPoolSize.Text, out size);

            if(size<=0)
                return;

            SmthPool
                smthPool=new SmthPool(size);

            smthPool.AddPoolPosition("test");
            smthPool.AddPoolPosition();
            smthPool.AddPoolPosition("test");
            smthPool.AddPoolPosition();
            smthPool.RemovePoolPosition();
            smthPool.RemovePoolPosition("test");
            smthPool.RemovePoolPosition("test");
            smthPool.RemovePoolPosition();
        }
    }
}
