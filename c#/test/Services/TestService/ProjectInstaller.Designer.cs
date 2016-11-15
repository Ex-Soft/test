namespace TestService
{
	partial class ProjectInstaller
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TestServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.TestServiceInstaller = new System.ServiceProcess.ServiceInstaller();
			// 
			// TestServiceProcessInstaller
			// 
			this.TestServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.TestServiceProcessInstaller.Password = null;
			this.TestServiceProcessInstaller.Username = null;
			// 
			// TestServiceInstaller
			// 
			this.TestServiceInstaller.ServiceName = "TestService";
			this.TestServiceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.TestServiceProcessInstaller,
            this.TestServiceInstaller});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller TestServiceProcessInstaller;
		private System.ServiceProcess.ServiceInstaller TestServiceInstaller;
	}
}