//#define LIVE_APPLICATION
#define GLOBAL_DATA_TABLE
using System;
using System.Configuration;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace AnyTest
{
    public class MainForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageButtons;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.DataGrid dataGridMaster;
        private System.Windows.Forms.DataGrid dataGridDetails;
        private System.Windows.Forms.DataGrid dataGridSubDetails;
        private System.Windows.Forms.TabPage tabPageDataII;
        private System.Windows.Forms.DataGrid dataGridDataII;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;

        private System.ComponentModel.Container components = null;

        Button
          MyButton,
          StopButton;

        MainMenu
          MyMenu;

        DataSet
            ds;
        private System.Windows.Forms.Label labelWithLongText;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPageControls;
        private TabPage tabPageSplitContainer;
        private SplitContainer splitContainer1;
        private Button button5;
        private Button button4;
        private Button button6;
        private Button btnPlatform;

        #if GLOBAL_DATA_TABLE
            DataTable
                tmpDataTable;
        #endif

        public MainForm()
        {
            InitializeComponent();

            #if GLOBAL_DATA_TABLE
                tmpDataTable = new DataTable();
                dataGridDataII.DataSource = tmpDataTable;
            #endif

            int
                InputValue = 12133;

            string
                InputValueStr = Convert.ToString(InputValue),
                Suffix = "th";

            byte
                Remainder = Convert.ToByte(InputValueStr.Substring(InputValueStr.Length - 2));

            if (Remainder < 11 || Remainder > 13)
                Remainder = Convert.ToByte(InputValueStr.Substring(InputValueStr.Length - 1));

            switch (Remainder)
            {
                case 1:
                    {
                        Suffix = "st";
                        break;
                    }
                case 2:
                    {
                        Suffix = "nd";
                        break;
                    }
                case 3:
                    {
                        Suffix = "rd";
                        break;
                    }
            }

            InputValueStr += Suffix;
            Log.Log.WriteToLog(InputValueStr, true);

            InputValue = InputValue / Convert.ToInt32(Math.Pow(10, Convert.ToString(InputValue).Length - 1));
            Log.Log.WriteToLog(Convert.ToString(InputValue), true);

            tabControlMain.Height = this.ClientRectangle.Height;

            dataGridMaster.Location = new Point(0, 0);
            dataGridMaster.Width = tabPageData.ClientRectangle.Width;
            dataGridMaster.Height = tabPageData.ClientRectangle.Height / 3;
            dataGridMaster.AllowNavigation = false;

            dataGridDetails.Location = new Point(0, dataGridMaster.Height);
            dataGridDetails.Width = tabPageData.ClientRectangle.Width;
            dataGridDetails.Height = tabPageData.ClientRectangle.Height / 3;
            dataGridDetails.AllowNavigation = false;

            dataGridSubDetails.Location = new Point(0, dataGridMaster.Height + dataGridDetails.Height);
            dataGridSubDetails.Width = tabPageData.ClientRectangle.Width;
            dataGridSubDetails.Height = tabPageData.ClientRectangle.Height - dataGridMaster.Height - dataGridDetails.Height;
            dataGridSubDetails.AllowNavigation = false;

            Text = "MainForm";

            MyButton = new Button();
            MyButton.Text = "Click";
            MyButton.Location = new Point(0, 0);
            MyButton.Click += new EventHandler(MyButtonClick);
            tabPageButtons.Controls.Add(MyButton);

            StopButton = new Button();
            StopButton.Text = "Stop";
            StopButton.Location = new Point(this.ClientRectangle.Width - StopButton.Width, (this.ClientRectangle.Height - StopButton.Height) / 2);
            //StopButton.Anchor=AnchorStyles.Top|AnchorStyles.Right|AnchorStyles.Bottom;
            StopButton.Click += new EventHandler(StopButtonClick);

            Controls.Add(StopButton);

            MyMenu = new MainMenu();

            MenuItem
              m1 = new MenuItem("Файл");

            MyMenu.MenuItems.Add(m1);

            MenuItem
              m2 = new MenuItem("Сервис");

            MyMenu.MenuItems.Add(m2);

            MenuItem
              subm1 = new MenuItem("Открыть");

            m1.MenuItems.Add(subm1);

            MenuItem
              subm2 = new MenuItem("Закрыть");

            m1.MenuItems.Add(subm2);

            MenuItem
              subm3 = new MenuItem("Выйти");

            m1.MenuItems.Add(subm3);

            MenuItem
              subm4 = new MenuItem("Координаты");

            m2.MenuItems.Add(subm4);

            MenuItem
              subm5 = new MenuItem("Изменить размер");

            m2.MenuItems.Add(subm5);

            MenuItem
              subm6 = new MenuItem("Восстановить");

            m2.MenuItems.Add(subm6);

            subm1.Click += new EventHandler(MMOpenClick);
            subm2.Click += new EventHandler(MMCloseClick);
            subm3.Click += new EventHandler(StopButtonClick);
            subm4.Click += new EventHandler(MMCoordClick);
            subm5.Click += new EventHandler(MMChangeClick);
            subm6.Click += new EventHandler(MMRestoreClick);
            Menu = MyMenu;

            DataColumn
                col;

            ds = new DataSet();

            ds.Tables.Add("Master");
            col = ds.Tables["Master"].Columns.Add("Id", typeof(int));
            col.AllowDBNull = false;
            col.Unique = true;
            col.AutoIncrement = true;
            col.AutoIncrementSeed = -1;
            col.AutoIncrementStep = -1;
            col.ReadOnly = true;
            ds.Tables["Master"].Columns.Add("Name", typeof(string));
            ds.Tables["Master"].PrimaryKey = new DataColumn[] { ds.Tables["Master"].Columns["Id"] };

            ds.Tables.Add("Details");
            ds.Tables["Details"].Columns.Add("Id", typeof(int));
            ds.Tables["Details"].Columns.Add("SubId", typeof(int));
            ds.Tables["Details"].Columns.Add("Name", typeof(string));
            ds.Tables["Details"].PrimaryKey = new DataColumn[] { ds.Tables["Details"].Columns["Id"], ds.Tables["Details"].Columns["SubId"] };
            ds.Relations.Add(new DataRelation("MasterDetailsRelation", ds.Tables["Master"].Columns["Id"], ds.Tables["Details"].Columns["Id"]));

            ds.Tables.Add("SubDetails");
            ds.Tables["SubDetails"].Columns.Add("Id", typeof(int));
            ds.Tables["SubDetails"].Columns.Add("SubId", typeof(int));
            ds.Tables["SubDetails"].Columns.Add("SubSubId", typeof(int));
            ds.Tables["SubDetails"].Columns.Add("Name", typeof(string));
            ds.Tables["SubDetails"].PrimaryKey = new DataColumn[] { ds.Tables["SubDetails"].Columns["Id"], ds.Tables["SubDetails"].Columns["SubId"], ds.Tables["SubDetails"].Columns["SubSubId"] };
            ds.Relations.Add(new DataRelation("MasterDetailsSubDetailsRelation", new DataColumn[] { ds.Tables["Details"].Columns["Id"], ds.Tables["Details"].Columns["SubId"] }, new DataColumn[] { ds.Tables["SubDetails"].Columns["Id"], ds.Tables["SubDetails"].Columns["SubId"] }));

            DataRow
                row;

            int
                tmpId;

            row = ds.Tables["Master"].NewRow();
            row["Name"] = "Иванов";
            ds.Tables["Master"].Rows.Add(row);

            tmpId = Convert.ToInt32(row["Id"]);

            row = ds.Tables["Details"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 1;
            row["Name"] = "Иван";
            ds.Tables["Details"].Rows.Add(row);

            row = ds.Tables["Details"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 2;
            row["Name"] = "Петр";
            ds.Tables["Details"].Rows.Add(row);

            row = ds.Tables["Details"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 3;
            row["Name"] = "Сидор";
            ds.Tables["Details"].Rows.Add(row);

            row = ds.Tables["Master"].NewRow();
            row["Name"] = "Петров";
            ds.Tables["Master"].Rows.Add(row);

            tmpId = Convert.ToInt32(row["Id"]);

            row = ds.Tables["Details"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 1;
            row["Name"] = "ИванИван";
            ds.Tables["Details"].Rows.Add(row);
            row = ds.Tables["Details"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 2;
            row["Name"] = "ПетрПетр";
            ds.Tables["Details"].Rows.Add(row);
            row = ds.Tables["Details"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 3;
            row["Name"] = "СидорСидор";
            ds.Tables["Details"].Rows.Add(row);

            row = ds.Tables["SubDetails"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 1;
            row["SubSubId"] = 1;
            row["Name"] = "ИванИван_1";
            ds.Tables["SubDetails"].Rows.Add(row);
            row = ds.Tables["SubDetails"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 1;
            row["SubSubId"] = 2;
            row["Name"] = "ПетрПетр_1";
            ds.Tables["SubDetails"].Rows.Add(row);
            row = ds.Tables["SubDetails"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 1;
            row["SubSubId"] = 3;
            row["Name"] = "СидорСидор_1";
            ds.Tables["SubDetails"].Rows.Add(row);

            row = ds.Tables["Master"].NewRow();
            row["Name"] = "Сидоров";
            ds.Tables["Master"].Rows.Add(row);

            tmpId = Convert.ToInt32(row["Id"]);

            row = ds.Tables["Details"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 1;
            row["Name"] = "ИванИванИван";
            ds.Tables["Details"].Rows.Add(row);

            row = ds.Tables["Details"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 2;
            row["Name"] = "ПетрПетрПетр";
            ds.Tables["Details"].Rows.Add(row);

            row = ds.Tables["Details"].NewRow();
            row["Id"] = tmpId;
            row["SubId"] = 3;
            row["Name"] = "СидорСидорСидор";
            ds.Tables["Details"].Rows.Add(row);

            dataGridMaster.SetDataBinding(ds, "Master");
            dataGridDetails.SetDataBinding(ds, "Master" + '.' + "MasterDetailsRelation");
            dataGridSubDetails.SetDataBinding(ds, "Master" + '.' + "MasterDetailsRelation" + "." + "MasterDetailsSubDetailsRelation");

            comboBox1.DataSource = ds.Tables["Master"];
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";

            tabControlMain.SelectedTab = tabPageData;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageButtons = new System.Windows.Forms.TabPage();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.dataGridSubDetails = new System.Windows.Forms.DataGrid();
            this.dataGridDetails = new System.Windows.Forms.DataGrid();
            this.dataGridMaster = new System.Windows.Forms.DataGrid();
            this.tabPageDataII = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridDataII = new System.Windows.Forms.DataGrid();
            this.tabPageControls = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.labelWithLongText = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPageSplitContainer = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnPlatform = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSubDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMaster)).BeginInit();
            this.tabPageDataII.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDataII)).BeginInit();
            this.tabPageControls.SuspendLayout();
            this.tabPageSplitContainer.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageButtons);
            this.tabControlMain.Controls.Add(this.tabPageData);
            this.tabControlMain.Controls.Add(this.tabPageDataII);
            this.tabControlMain.Controls.Add(this.tabPageControls);
            this.tabControlMain.Controls.Add(this.tabPageSplitContainer);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(400, 450);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageButtons
            // 
            this.tabPageButtons.Location = new System.Drawing.Point(4, 22);
            this.tabPageButtons.Name = "tabPageButtons";
            this.tabPageButtons.Size = new System.Drawing.Size(392, 424);
            this.tabPageButtons.TabIndex = 0;
            this.tabPageButtons.Text = "Buttons";
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.dataGridSubDetails);
            this.tabPageData.Controls.Add(this.dataGridDetails);
            this.tabPageData.Controls.Add(this.dataGridMaster);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Size = new System.Drawing.Size(392, 424);
            this.tabPageData.TabIndex = 1;
            this.tabPageData.Text = "Data";
            // 
            // dataGridSubDetails
            // 
            this.dataGridSubDetails.DataMember = "";
            this.dataGridSubDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridSubDetails.Location = new System.Drawing.Point(0, 200);
            this.dataGridSubDetails.Name = "dataGridSubDetails";
            this.dataGridSubDetails.Size = new System.Drawing.Size(100, 100);
            this.dataGridSubDetails.TabIndex = 2;
            // 
            // dataGridDetails
            // 
            this.dataGridDetails.DataMember = "";
            this.dataGridDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridDetails.Location = new System.Drawing.Point(0, 100);
            this.dataGridDetails.Name = "dataGridDetails";
            this.dataGridDetails.Size = new System.Drawing.Size(100, 100);
            this.dataGridDetails.TabIndex = 1;
            // 
            // dataGridMaster
            // 
            this.dataGridMaster.DataMember = "";
            this.dataGridMaster.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridMaster.Location = new System.Drawing.Point(0, 0);
            this.dataGridMaster.Name = "dataGridMaster";
            this.dataGridMaster.Size = new System.Drawing.Size(100, 100);
            this.dataGridMaster.TabIndex = 0;
            // 
            // tabPageDataII
            // 
            this.tabPageDataII.Controls.Add(this.button2);
            this.tabPageDataII.Controls.Add(this.button1);
            this.tabPageDataII.Controls.Add(this.dataGridDataII);
            this.tabPageDataII.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataII.Name = "tabPageDataII";
            this.tabPageDataII.Size = new System.Drawing.Size(392, 424);
            this.tabPageDataII.TabIndex = 2;
            this.tabPageDataII.Text = "Data II";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridDataII
            // 
            this.dataGridDataII.DataMember = "";
            this.dataGridDataII.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridDataII.Location = new System.Drawing.Point(0, 0);
            this.dataGridDataII.Name = "dataGridDataII";
            this.dataGridDataII.Size = new System.Drawing.Size(304, 416);
            this.dataGridDataII.TabIndex = 0;
            this.dataGridDataII.DataSourceChanged += new System.EventHandler(this.dataGridDataII_DataSourceChanged);
            // 
            // tabPageControls
            // 
            this.tabPageControls.Controls.Add(this.btnPlatform);
            this.tabPageControls.Controls.Add(this.button3);
            this.tabPageControls.Controls.Add(this.labelWithLongText);
            this.tabPageControls.Controls.Add(this.comboBox1);
            this.tabPageControls.Location = new System.Drawing.Point(4, 22);
            this.tabPageControls.Name = "tabPageControls";
            this.tabPageControls.Size = new System.Drawing.Size(392, 424);
            this.tabPageControls.TabIndex = 3;
            this.tabPageControls.Text = "Controls";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelWithLongText
            // 
            this.labelWithLongText.AutoSize = true;
            this.labelWithLongText.Location = new System.Drawing.Point(16, 48);
            this.labelWithLongText.Name = "labelWithLongText";
            this.labelWithLongText.Size = new System.Drawing.Size(655, 13);
            this.labelWithLongText.TabIndex = 1;
            this.labelWithLongText.Text = "LongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongL" +
    "ongLongLongLongLongLongLong";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(16, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "comboBox1";
            // 
            // tabPageSplitContainer
            // 
            this.tabPageSplitContainer.Controls.Add(this.splitContainer1);
            this.tabPageSplitContainer.Location = new System.Drawing.Point(4, 22);
            this.tabPageSplitContainer.Name = "tabPageSplitContainer";
            this.tabPageSplitContainer.Size = new System.Drawing.Size(392, 424);
            this.tabPageSplitContainer.TabIndex = 4;
            this.tabPageSplitContainer.Text = "tabPageSplitContainer";
            this.tabPageSplitContainer.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button5);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button6);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Size = new System.Drawing.Size(392, 424);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(38, 388);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(24, 388);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(137, 388);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnPlatform
            // 
            this.btnPlatform.Location = new System.Drawing.Point(97, 80);
            this.btnPlatform.Name = "btnPlatform";
            this.btnPlatform.Size = new System.Drawing.Size(75, 23);
            this.btnPlatform.TabIndex = 3;
            this.btnPlatform.Text = "Platform";
            this.btnPlatform.Click += new System.EventHandler(this.BtnPlatformClick);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(492, 473);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSubDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMaster)).EndInit();
            this.tabPageDataII.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDataII)).EndInit();
            this.tabPageControls.ResumeLayout(false);
            this.tabPageControls.PerformLayout();
            this.tabPageSplitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

        protected void MyButtonClick(object sender, EventArgs e)
        {
            Button
              tmpButton = (Button)sender;

            if (tmpButton.Top == 0)
                tmpButton.Location = new Point(tmpButton.Parent.ClientRectangle.Width - tmpButton.Width, tmpButton.Parent.ClientRectangle.Height - tmpButton.Height);
            else
                tmpButton.Location = new Point(0, 0);
        }

        protected void StopButtonClick(object sender, EventArgs e)
        {
            Button
              tmpButton = sender as Button;

            MenuItem
              tmpMenuItem = sender as MenuItem;

            string
              tmpStr = "Остановить программу?";

            if (tmpButton != null)
            {
                tmpStr += " (From Button)" + tmpButton.Name;
            }

            if (tmpMenuItem != null)
            {
                tmpStr += " (From Menu) \"" + tmpMenuItem.Text + "\"";
            }

            DialogResult
              result = MessageBox.Show(tmpStr, "Завершение", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void MMOpenClick(object sender, EventArgs e)
        {
            string
                inp = "123b345",
                str = "";

            try
            {
                double
                    a = Convert.ToDouble(inp);

                str = "a=" + a.ToString();
            }
            catch (OverflowException eException)
            {
                str = "OverflowException " + eException.Message;
            }
            catch (InvalidCastException eException)
            {
                str = "InvalidCastException " + eException.Message;
            }
            catch (FormatException eException)
            {
                str = "FormatException " + eException.Message;
            }
            catch (Exception eException)
            {
                str = "Exception " + eException.Message;
            }

            MessageBox.Show(str, "Заглушка", MessageBoxButtons.OK);
            MessageBox.Show("Неактивная команда", "Заглушка", MessageBoxButtons.OK);
        }

        private void MMCloseClick(object sender, EventArgs e)
        {
            MessageBox.Show("Неактивная команда", "Заглушка", MessageBoxButtons.OK);
        }

        private void MMCoordClick(object sender, EventArgs e)
        {
            string
              size = String.Format("{0}: {1}, {2}\n{3}: {4}, {5}", "Вверху, Слева", Top, Left, "Внизу, Справа", Bottom, Right);

            MessageBox.Show(size, "Координаты окна", MessageBoxButtons.OK);
        }

        private void MMChangeClick(object sender, EventArgs e)
        {
            Width = Height = 200;
        }

        private void MMRestoreClick(object sender, EventArgs e)
        {
            Width = Height = 500;
        }

        private void MainForm_Resize(object sender, System.EventArgs e)
        {
            StopButton.Location = new Point(this.ClientRectangle.Width - StopButton.Width, (this.ClientRectangle.Height - StopButton.Height) / 2);

            dataGridMaster.Width = tabPageData.ClientRectangle.Width;
            dataGridMaster.Height = tabPageData.ClientRectangle.Height / 3;

            dataGridDetails.Location = new Point(0, dataGridMaster.Height);
            dataGridDetails.Width = tabPageData.ClientRectangle.Width;
            dataGridDetails.Height = tabPageData.ClientRectangle.Height / 3;

            dataGridSubDetails.Location = new Point(0, dataGridMaster.Height + dataGridDetails.Height);
            dataGridSubDetails.Width = tabPageData.ClientRectangle.Width;
            dataGridSubDetails.Height = tabPageData.ClientRectangle.Height - dataGridMaster.Height - dataGridDetails.Height;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Button
                tmpButton;

            if ((tmpButton = sender as Button) == null)
                return;

            string
                SQLText = string.Empty;

            switch (tmpButton.Name)
            {
                case "button1":
                    {
                        SQLText = "select * from Staff";
                        break;
                    }
                case "button2":
                    {
                        SQLText = "select * from TEST_CHAR";
                        break;
                    }
                default:
                    {
                        throw (new Exception("Unknown sender: \"" + tmpButton.Name + "\""));
                    }
            }

            OleDbConnection
                cn = null;

            try
            {
                try
                {
                    string
                        strConn = ConfigurationSettings.AppSettings["connectionString"];

                    #if WITHOUT_CONNECTION_POOL
						strConn+=";OLE DB Services=-4"; // strConn+=";Pooling=False" // 4 SqlConnection
                    #endif

                    cn = new OleDbConnection(strConn);

                    OleDbCommand
                        cmd = cn.CreateCommand();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQLText;

                    OleDbDataAdapter
                        da = new OleDbDataAdapter(cmd);

                    #if GLOBAL_DATA_TABLE
                        tmpDataTable.Reset();
                        //dataGridDataII.DataSource = null;
                    #else
						DataTable
							tmpDataTable=new DataTable();
                    #endif
                    da.Fill(tmpDataTable);
                    #if !GLOBAL_DATA_TABLE
						dataGridDataII.DataSource = tmpDataTable;
                    #endif
                    dataGridDataII.Refresh();
                }
                catch (Exception eException)
                {
                    throw (new Exception(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace));
                }
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        private void dataGridDataII_DataSourceChanged(object sender, System.EventArgs e)
        {
            MessageBox.Show("DataSourceChanged");
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            for (long i = 0; i < long.MaxValue; ++i)
            {
                labelWithLongText.Text = i.ToString();
                #if LIVE_APPLICATION
					Application.DoEvents();
                #else
                    labelWithLongText.Update();
                    //label1.Refresh();
                #endif
            }
        }

        private void BtnPlatformClick(object sender, EventArgs e)
        {
            string platform = IntPtr.Size == 8 ? "x64" : "x86";

            System.Diagnostics.Debug.WriteLine(Path.GetDirectoryName(Application.ExecutablePath));
            System.Diagnostics.Debug.WriteLine(Environment.CurrentDirectory);
            Directory.SetCurrentDirectory("..");
            System.Diagnostics.Debug.WriteLine(Environment.CurrentDirectory);
        }
    }
}
