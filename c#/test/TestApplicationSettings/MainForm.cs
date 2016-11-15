using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace TestApplicationSettings
{
    public partial class MainForm : Form
    {
        private readonly FormSettings _frmSettings = new FormSettings();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            FormClosing += MainFormFormClosing;

            //Associate settings property event handlers.
            _frmSettings.SettingChanging += FrmSettingsSettingChanging;
            _frmSettings.SettingsSaving += FrmSettingsSettingsSaving;

            //Data bind settings properties with straightforward associations.
            var bndBackColor = new Binding("BackColor", _frmSettings, "FormBackColor", true,
                                           DataSourceUpdateMode.OnPropertyChanged);
            DataBindings.Add(bndBackColor);
            var bndLocation = new Binding("Location", _frmSettings, "FormLocation", true,
                                          DataSourceUpdateMode.OnPropertyChanged);
            DataBindings.Add(bndLocation);

            // Assign Size property, since databinding to Size doesn't work well. 
            Size = _frmSettings.FormSize;

            //For more complex associations, manually assign associations.
            var savedText = _frmSettings.FormText;
            //Since there is no default value for FormText. 
            if (savedText != null)
                Text = savedText;
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            //Synchronize manual associations first.
            _frmSettings.FormText = Text + '.';
            _frmSettings.FormSize = Size;
            _frmSettings.Save();
        }

        private void BtnBackColorClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                Color c = colorDialog.Color;
                BackColor = c;
            }
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            _frmSettings.Reset();
            BackColor = SystemColors.Control;
        }

        private void BtnReloadClick(object sender, EventArgs e)
        {
            _frmSettings.Reload();
        }

        private void FrmSettingsSettingChanging(object sender, SettingChangingEventArgs e)
        {
            tbStatus.Text = string.Format("{0}: {1}", e.SettingName, e.NewValue);
        }

        private static void FrmSettingsSettingsSaving(object sender, CancelEventArgs e)
        {
            //Should check for settings changes first.
            DialogResult dr = MessageBox.Show(
                @"Save current values for application settings?",
                @"Save Settings", MessageBoxButtons.YesNo);
            if (DialogResult.No == dr)
            {
                e.Cancel = true;
            }
        }
    }
}
