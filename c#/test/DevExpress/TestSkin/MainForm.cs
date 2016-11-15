#define SET_SKIN_IN_ON_SHOWN

using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;

namespace TestSkin
{
	public partial class MainForm : XtraForm
	{
		const string SkinName = "DevExpress Dark Style";

		public MainForm()
		{
			InitializeComponent();

			#if SET_SKIN_IN_ON_SHOWN
				Load += MainFormOnLoad;
				Shown += MainFormOnShown;
			#else
				btnSetSkin.Click += BtnSetSkinClick;
			#endif
		}

		#if SET_SKIN_IN_ON_SHOWN

		void MainFormOnLoad(object sender, System.EventArgs e)
		{
			SetWindowState(FormWindowState.Maximized);
		}

		void MainFormOnShown(object sender, System.EventArgs e)
		{
			SetSkin(SkinName);
		}

		#endif

		bool IsValidSkinName(string skinName)
		{
			var result = SkinManager.Default.GetValidSkinName(skinName);
			return result == skinName;
		}

		void SetSkin(string skinName)
		{
			DevExpress.UserSkins.BonusSkins.Register();

			if (IsValidSkinName(skinName))
			{
				SkinManager.EnableFormSkins();
				SkinManager.EnableMdiFormSkins();
				SkinManager.EnableFormSkinsIfNotVista();

				UserLookAndFeel.Default.Style = LookAndFeelStyle.Skin;
				UserLookAndFeel.Default.SetSkinStyle(skinName);

				LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
			}
			else
			{
				SkinManager.DisableFormSkins();
				SkinManager.DisableMdiFormSkins();

				UserLookAndFeel.Default.UseDefaultLookAndFeel = true;
			}
		}

		void BtnSetSkinClick(object sender, System.EventArgs e)
		{
			SetWindowState(FormWindowState.Maximized);
			SetSkin(SkinName);
		}

		void SetWindowState(FormWindowState windowState)
		{
			WindowState = windowState;
		}
	}
}
