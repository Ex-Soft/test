using System;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class TestLinkForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton LinkButtonMeta;
		protected System.Web.UI.WebControls.LinkButton LinkbuttonIFrame;
		protected System.Web.UI.WebControls.LinkButton LinkbuttonResponse;
		protected System.Web.UI.HtmlControls.HtmlAnchor AnchorDownload;
		protected System.Web.UI.WebControls.ImageButton ImageButtonDownload;
		protected System.Web.UI.HtmlControls.HtmlGenericControl IFrameAutoDownload;
		protected System.Web.UI.WebControls.ImageButton btnImg5;
		protected System.Web.UI.WebControls.ImageButton btnImg6;

		private void Page_Init(object sender, System.EventArgs e)
		{
			if(IFrameAutoDownload.EnableViewState)
				IFrameAutoDownload.EnableViewState=false;
		}
		//---------------------------------------------------------------------------

		private void Page_Load(object sender, System.EventArgs e)
		{
			//
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
			this.ImageButtonDownload.Click+=new System.Web.UI.ImageClickEventHandler(ImageButton_Click);
			this.AnchorDownload.ServerClick+=new EventHandler(AnchorDownload_ServerClick);
			this.LinkbuttonIFrame.Command+=new CommandEventHandler(LinkbuttonIFrame_Command);
			this.LinkButtonMeta.Command+=new System.Web.UI.WebControls.CommandEventHandler(this.LinkButtonMeta_Command);
			this.LinkbuttonResponse.Command+=new CommandEventHandler(LinkbuttonResponse_Command);
			this.Load+=new System.EventHandler(this.Page_Load);
			this.Init+=new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void LinkButtonMeta_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			LinkButton
				tmpLinkButton;

			if((tmpLinkButton=sender as LinkButton)==null)
				return;

			switch(e.CommandName)
			{
				case "Download" :
				{
					string
						CommandArgument=Convert.ToString(e.CommandArgument);

					if(CommandArgument=="Download")
					{
						string
							scriptString="<script type=\"text/javascript\">\n<!--\n";

						scriptString+="var AutoDownload=true;";
						scriptString+="\n// -->\n";
						scriptString+="<";
						scriptString+="/";
						scriptString+="script>";

						Response.Write(scriptString);
					}

					break;	
				}
			}
		}
		//---------------------------------------------------------------------------

		private void LinkbuttonIFrame_Command(object sender, CommandEventArgs e)
		{
			LinkButton
				tmpLinkButton;

			if((tmpLinkButton=sender as LinkButton)==null)
				return;

			switch(e.CommandName)
			{
				case "Download" :
				{
					string
						CommandArgument=Convert.ToString(e.CommandArgument);

					if(CommandArgument=="Download")
						IFrameAutoDownload.Attributes["src"]="c:\\autoexec.bat";						

					break;	
				}
			}
		}
		//---------------------------------------------------------------------------

		private void AnchorDownload_ServerClick(object sender, EventArgs e)
		{
			HtmlAnchor
				tmpHtmlAnchor;

			if((tmpHtmlAnchor=sender as HtmlAnchor)==null)
				return;

			IFrameAutoDownload.Attributes["src"]="c:\\autoexec.bat";
		}
		//---------------------------------------------------------------------------

		private void ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ImageButton
				tmpImageButton;

			if((tmpImageButton=sender as ImageButton)==null)
				return;

			IFrameAutoDownload.Attributes["src"]="c:\\autoexec.bat";
		}
		//---------------------------------------------------------------------------

		private void LinkbuttonResponse_Command(object sender, CommandEventArgs e)
		{
			LinkButton
				tmpLinkButton;

			if((tmpLinkButton=sender as LinkButton)==null)
				return;

			switch(e.CommandName)
			{
				case "Download" :
				{
					string
						CommandArgument=Convert.ToString(e.CommandArgument);

					if(CommandArgument=="Download")
					{
						string
							CurrPath=Server.MapPath(null),
							FileName="Log.log";

						if(!CurrPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
							CurrPath+=Path.DirectorySeparatorChar; 

						Response.Clear();
						Response.ContentType="application/octet-stream";
						Response.AddHeader("Content-Disposition","attachment; filename="+FileName);
						Response.Flush();
						Response.WriteFile(CurrPath+FileName);
						Response.End();
					}

					break;	
				}
			}
		}
		//---------------------------------------------------------------------------
	}
}
