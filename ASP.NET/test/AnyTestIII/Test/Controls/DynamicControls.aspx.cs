using System;
using System.Web.UI.WebControls;

namespace AnyTest
{
	/// <summary>
	/// Summary description for DynamicControls.
	/// </summary>
	public class DynamicControls : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolderButtonOnClickOnInit;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolderButtonOnCommandOnInit;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolderButtonOnClickOnLoad;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolderButtonOnCommandOnLoad;
		protected System.Web.UI.WebControls.TextBox TextBoxButtonEventSender;
		
		private void Page_Init(object sender, System.EventArgs e)
		{
			Button
				tmpButton=new Button();

			tmpButton.ID="ButtonOnClickOnInit";
			tmpButton.Text="Button with OnClick";
			tmpButton.Click+=new EventHandler(Button_ClickOnInit);
			PlaceHolderButtonOnClickOnInit.Controls.Add(tmpButton);

			tmpButton=new Button();
			tmpButton.ID="ButtonOnCommandOnInit";
			tmpButton.Text="Button with OnCommand";
			tmpButton.CommandName="Show";
			tmpButton.CommandArgument="OnInit";
			tmpButton.Command+=new CommandEventHandler(Button_CommandOnInit);
			PlaceHolderButtonOnCommandOnInit.Controls.Add(tmpButton);
		}
		//--------------------------------------------------------------------------- 
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			Button
				tmpButton=new Button();

			tmpButton.ID="ButtonOnClickOnLoad";
			tmpButton.Text="Button with OnClick";
			tmpButton.Click+=new EventHandler(Button_ClickOnLoad);
			PlaceHolderButtonOnClickOnLoad.Controls.Add(tmpButton);

			tmpButton=new Button();
			tmpButton.ID="ButtonOnCommandOnLoad";
			tmpButton.Text="Button with OnCommand";
			tmpButton.CommandName="Show";
			tmpButton.CommandArgument="OnLoad";
			tmpButton.Command+=new CommandEventHandler(Button_CommandOnLoad);
			PlaceHolderButtonOnCommandOnLoad.Controls.Add(tmpButton);
		}
		//--------------------------------------------------------------------------- 

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void Button_ClickOnInit(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if((tmpButton=sender as Button)!=null)
				TextBoxButtonEventSender.Text=tmpButton.ID;
		}
		//--------------------------------------------------------------------------- 

		private void Button_ClickOnLoad(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if((tmpButton=sender as Button)!=null)
				TextBoxButtonEventSender.Text=tmpButton.ID;
		}
		//--------------------------------------------------------------------------- 

		private void Button_CommandOnInit(object sender, CommandEventArgs e)
		{
			Button
				tmpButton;

			if((tmpButton=sender as Button)!=null)
				TextBoxButtonEventSender.Text=tmpButton.ID+" CommandName: "+e.CommandName+" CommandArgument: "+e.CommandArgument;
		}
		//--------------------------------------------------------------------------- 

		private void Button_CommandOnLoad(object sender, CommandEventArgs e)
		{
			Button
				tmpButton;

			if((tmpButton=sender as Button)!=null)
				TextBoxButtonEventSender.Text=tmpButton.ID+" CommandName: "+e.CommandName+" CommandArgument: "+e.CommandArgument;
		}
		//--------------------------------------------------------------------------- 
	}
}
