using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AnyTest
{
	/// <summary>
	/// Summary description for DynamicCheckBox.
	/// </summary>
	public class DynamicCheckBox : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton SwitchDIVOn;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton SwitchDIVOff;
		protected System.Web.UI.WebControls.RadioButtonList SwitchDIV2;
		protected System.Web.UI.WebControls.DropDownList DDLSwitch;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divT;
		protected System.Web.UI.WebControls.Literal VehicleTypes;
		protected System.Web.UI.WebControls.Literal VehicleTypesS;
		protected System.Web.UI.HtmlControls.HtmlTable TableRadio;
		protected System.Web.UI.WebControls.Label ParagraphRequest;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder4CheckBoxDynamicServer;
		
		protected string
			Signature="CheckBox",
			SignatureRadio="DynamicRadio",
			SignatureText="DynamicText",
			SignatureCheckBox="DynamicCheckBox";

		private void Page_Init(object sender, System.EventArgs e)
		{
			if(IsPostBack)
			{
				string
					Value;

				byte[]
					BinaryData=null;

				char[]
					CharData=null;
				
				if(Request.Params.GetValues("__VIEWSTATE")!=null)
				{
					Value=Request.Params.GetValues("__VIEWSTATE")[0];
					try
					{
						BinaryData=Convert.FromBase64String(Value);
						CharData=new char[BinaryData.Length];
						for(int i=0; i<BinaryData.Length; ++i)
							CharData[i]=Convert.ToChar(BinaryData[i]);
						Value=new string(CharData);
					}
					catch(ArgumentNullException) 
					{
						Value="Base 64 string is null.";
					}
					catch(System.FormatException) 
					{
						Value="Base 64 string length is not 4 or is not an even multiple of 4.";
					}
				}

				if(Request.Params.GetValues(SignatureRadio)!=null)
				{
					HtmlTableRow
						oRow;

					HtmlTableCell
						oCell;

					HtmlInputRadioButton
						tmpHtmlInputRadioButton;

					HtmlInputText
						tmpHtmlInputText;

					HtmlInputCheckBox
						tmpHtmlInputCheckBox;

					oRow=new HtmlTableRow();
					TableRadio.Rows.Add(oRow);

					oCell=new HtmlTableCell();
					tmpHtmlInputRadioButton=new HtmlInputRadioButton();
					tmpHtmlInputRadioButton.ID=SignatureRadio+"1";
					tmpHtmlInputRadioButton.Name=SignatureRadio;
					tmpHtmlInputRadioButton.Value=SignatureRadio+"1";
					tmpHtmlInputRadioButton.Init+=new EventHandler(tmpHtmlInputRadioButton_Init);
					tmpHtmlInputRadioButton.Load+=new EventHandler(tmpHtmlInputRadioButton_Load);
					tmpHtmlInputRadioButton.DataBinding+=new EventHandler(tmpHtmlInputRadioButton_DataBinding);
					tmpHtmlInputRadioButton.Disposed+=new EventHandler(tmpHtmlInputRadioButton_Disposed);
					tmpHtmlInputRadioButton.PreRender+=new EventHandler(tmpHtmlInputRadioButton_PreRender);
					tmpHtmlInputRadioButton.ServerChange+=new EventHandler(tmpHtmlInputRadioButton_ServerChange);
					tmpHtmlInputRadioButton.Unload+=new EventHandler(tmpHtmlInputRadioButton_Unload);
					oCell.Controls.Add(tmpHtmlInputRadioButton);
					oRow.Cells.Add(oCell);

					oCell=new HtmlTableCell();
					tmpHtmlInputRadioButton=new HtmlInputRadioButton();
					tmpHtmlInputRadioButton.ID=SignatureRadio+"2";
					tmpHtmlInputRadioButton.Name=SignatureRadio;
					tmpHtmlInputRadioButton.Value=SignatureRadio+"2";
					tmpHtmlInputRadioButton.Init+=new EventHandler(tmpHtmlInputRadioButton_Init);
					tmpHtmlInputRadioButton.Load+=new EventHandler(tmpHtmlInputRadioButton_Load);
					tmpHtmlInputRadioButton.DataBinding+=new EventHandler(tmpHtmlInputRadioButton_DataBinding);
					tmpHtmlInputRadioButton.Disposed+=new EventHandler(tmpHtmlInputRadioButton_Disposed);
					tmpHtmlInputRadioButton.PreRender+=new EventHandler(tmpHtmlInputRadioButton_PreRender);
					tmpHtmlInputRadioButton.ServerChange+=new EventHandler(tmpHtmlInputRadioButton_ServerChange);
					tmpHtmlInputRadioButton.Unload+=new EventHandler(tmpHtmlInputRadioButton_Unload);
					oCell.Controls.Add(tmpHtmlInputRadioButton);
					oRow.Cells.Add(oCell);

					oCell=new HtmlTableCell();
					tmpHtmlInputText=new HtmlInputText();
					tmpHtmlInputText.ID=SignatureText;
					oCell.Controls.Add(tmpHtmlInputText);
					oRow.Cells.Add(oCell);

					oCell=new HtmlTableCell();
					tmpHtmlInputCheckBox=new HtmlInputCheckBox();
					tmpHtmlInputCheckBox.ID=SignatureCheckBox;
					oCell.Controls.Add(tmpHtmlInputCheckBox);
					oRow.Cells.Add(oCell);
				}

				string
					r=string.Empty;

				if(ViewState["SwitchDIV"]!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=ViewState["SwitchDIV"];
				}
				if(ViewState["SwitchDIVOn"]!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=ViewState["SwitchDIV"];
				}
				if(ViewState["SwitchDIVOff"]!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=ViewState["SwitchDIV"];
				}
			}

			CheckBox
				tmpCheckBox=new CheckBox();

			tmpCheckBox.ID="CheckBoxDynamicServerPageInit";
			tmpCheckBox.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
			PlaceHolder4CheckBoxDynamicServer.Controls.Add(tmpCheckBox);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			ListItem
				tmpListItem;

			if(!IsPostBack)
			{
				tmpListItem=new ListItem("Text #1","1");
				DDLSwitch.Items.Add(tmpListItem);
				tmpListItem=new ListItem("Text #2","2");
				DDLSwitch.Items.Add(tmpListItem);
				tmpListItem=new ListItem("Text #3","3");
				DDLSwitch.Items.Add(tmpListItem);

				tmpListItem=new ListItem();
				DDLSwitch.Items.Insert(0,tmpListItem);
			}
			else
			{
				if((tmpListItem=DDLSwitch.Items.FindByValue(string.Empty))!=null)
					DDLSwitch.Items.Remove(tmpListItem);
			}

			if(!IsPostBack)
			{
				VehicleTypes.Text=MakeCheckBox(null,false);
				VehicleTypesS.Text=MakeCheckBox(null,true);
			}
			else
			{
				string[]
					array1,
					array2;

				string
					val;

				int
					i,
					ii;

				ParagraphRequest.Text="Request.Params.Count: \""+Request.Params.Count+"\"<br>";
				array1=Request.Params.AllKeys;
				for(i=0; i<array1.Length; ++i)
				{
					ParagraphRequest.Text+="Key ["+Convert.ToString(i)+"]="+Server.HtmlEncode(array1[i])+"<br>";
					array2=Request.Params.GetValues(array1[i]);
					for(ii=0; ii<array2.Length; ++ii)
						ParagraphRequest.Text+="Value ["+Convert.ToString(ii)+"]="+Server.HtmlEncode(array2[ii])+"<br>";
				}
				ParagraphRequest.Text+="<br>";

				array2=Request.Params.GetValues("SwitchDIV");
				if(array2!=null)
				{
					val=Server.HtmlEncode(array2[0]);
					switch(val.ToLower())
					{
						case "on" :
						{
							val="block";

							break;
						}
						case "off" :
						{
							val="none";

							break;
						}
					}
					divT.Style["display"]=val;
				}

				ArrayList
					Checked=new ArrayList();

				for(char c='A'; c<'F'; ++c)
				{
					array2=Request.Params.GetValues("CheckBox"+c);
					if(array2==null)
						continue;

					val=Server.HtmlEncode(array2[0]);
					if(val.ToLower()=="on")
						Checked.Add(c);
				}
				VehicleTypes.Text=MakeCheckBox(Checked,false);

				array2=Request.Params.GetValues("DDLSwitch");
				if(array2!=null)
				{
					val=Server.HtmlEncode(array2[0]);
					ParagraphRequest.Text+="DDLSwitch.value=\""+val+"\"<br>";
				}
				ParagraphRequest.Text+="<br>";

				HtmlInputRadioButton
					tmpHtmlInputRadioButton;

				HtmlInputText
					tmpHtmlInputText;

				HtmlInputCheckBox
					tmpHtmlInputCheckBox;

				string
					r=string.Empty;

				if((tmpHtmlInputRadioButton=FindControl(SignatureRadio+"1") as HtmlInputRadioButton)!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=SignatureRadio+"1.Checked="+tmpHtmlInputRadioButton.Checked.ToString();
				}
				if((tmpHtmlInputRadioButton=FindControl(SignatureRadio+"2") as HtmlInputRadioButton)!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=SignatureRadio+"2.Checked="+tmpHtmlInputRadioButton.Checked.ToString();
				}
				if((tmpHtmlInputText=FindControl(SignatureText) as HtmlInputText)!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=SignatureText+".Value="+tmpHtmlInputText.Value;
				}
				if((tmpHtmlInputCheckBox=FindControl(SignatureCheckBox) as HtmlInputCheckBox)!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=SignatureCheckBox+".Checked="+tmpHtmlInputCheckBox.Checked.ToString();
				}

				if(ViewState["SwitchDIV"]!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=ViewState["SwitchDIV"];
				}
				if(ViewState["SwitchDIVOn"]!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=ViewState["SwitchDIV"];
				}
				if(ViewState["SwitchDIVOff"]!=null)
				{
					if(r!=string.Empty)
						r+=Environment.NewLine;
					r+=ViewState["SwitchDIV"];
				}

				ParagraphRequest.Text+="Request.Form.Count: \""+Request.Form.Count+"\"<br>";
				array1=Request.Form.AllKeys;
				for(i=0; i<array1.Length; ++i)
				{
					ParagraphRequest.Text+="Key ["+Convert.ToString(i)+"]="+Server.HtmlEncode(array1[i])+"<br>";
					array2=Request.Form.GetValues(array1[i]);
					for(ii=0; ii<array2.Length; ++ii)
						ParagraphRequest.Text+="Value ["+Convert.ToString(ii)+"]="+Server.HtmlEncode(array2[ii])+"<br>";
				}
				ParagraphRequest.Text+="<br>";

				NameObjectCollectionBase.KeysCollection
					inpt=Request.Form.Keys;

				for(i=0; i<inpt.Count; ++i)
				{
					ParagraphRequest.Text+=inpt[i]+"<br>";
				}
				ParagraphRequest.Text+="<br>";
			}

			CheckBox
				tmpCheckBox=new CheckBox();

			tmpCheckBox.ID="CheckBoxDynamicServerPageLoad";
			tmpCheckBox.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
			PlaceHolder4CheckBoxDynamicServer.Controls.Add(tmpCheckBox);
		}

		private string MakeCheckBox(ArrayList Checked, bool RunAtServer)
		{
			string
				Str="";

			for(char i='A'; i<'F'; ++i)
			{
				Str+="<td><input id=\""+Signature+(RunAtServer ? "S" : "")+i+"\" name=\""+Signature+(RunAtServer ? "S" : "")+i+"\" type=\"checkbox\" onclick=\"CategoryChange('"+Signature+(RunAtServer ? "S" : "")+i+"')\" title=\""+i+"\"";
				if(Checked!=null)
					foreach(char c in Checked)
						if(c==i)
							Str+=" checked";
				if(RunAtServer)
					Str+=" runat=\"server\"";
				Str+=">&nbsp;"+i+"&nbsp;</td>";
			}

			return(Str);
		}
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
			this.DDLSwitch.Load += new System.EventHandler(this.DDLSwitch_Load);
			this.DDLSwitch.DataBinding += new System.EventHandler(this.DDLSwitch_DataBinding);
			this.DDLSwitch.Unload += new System.EventHandler(this.DDLSwitch_Unload);
			this.DDLSwitch.PreRender += new System.EventHandler(this.DDLSwitch_PreRender);
			this.DDLSwitch.Init += new System.EventHandler(this.DDLSwitch_Init);
			this.DDLSwitch.Disposed += new System.EventHandler(this.DDLSwitch_Disposed);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void DDLSwitch_DataBinding(object sender, System.EventArgs e)
		{
			//
		}

		private void DDLSwitch_Disposed(object sender, System.EventArgs e)
		{
			//
		}

		private void DDLSwitch_Init(object sender, System.EventArgs e)
		{
			//
		}

		private void DDLSwitch_Load(object sender, System.EventArgs e)
		{
			//
		}

		private void DDLSwitch_PreRender(object sender, System.EventArgs e)
		{
			//
		}

		private void DDLSwitch_Unload(object sender, System.EventArgs e)
		{
			//
		}

		private void tmpHtmlInputRadioButton_Init(object sender, EventArgs e)
		{
			//
		}

		private void tmpHtmlInputRadioButton_Load(object sender, EventArgs e)
		{
			HtmlInputRadioButton
				tmpHtmlInputRadioButton;

			if((tmpHtmlInputRadioButton=sender as HtmlInputRadioButton)==null)
				return;

			string[]
				Value;

			if((Value=Request.Params.GetValues(tmpHtmlInputRadioButton.Name))!=null
				&& Value.Length!=0
				&& Server.HtmlEncode(Value[0])==tmpHtmlInputRadioButton.ID
				&& !tmpHtmlInputRadioButton.Checked)
			tmpHtmlInputRadioButton.Checked=true;
		}

		private void tmpHtmlInputRadioButton_DataBinding(object sender, EventArgs e)
		{
			//
		}

		private void tmpHtmlInputRadioButton_Disposed(object sender, EventArgs e)
		{
			//
		}

		private void tmpHtmlInputRadioButton_PreRender(object sender, EventArgs e)
		{
			//
		}

		private void tmpHtmlInputRadioButton_ServerChange(object sender, EventArgs e)
		{
			//
		}

		private void tmpHtmlInputRadioButton_Unload(object sender, EventArgs e)
		{
			//
		}

		private void CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox
				tmpCheckBox;

			if((tmpCheckBox=sender as CheckBox)==null)
				return;

			string
				tmpString=tmpCheckBox.Checked.ToString().ToLower();
		}

		protected override void LoadViewState(object savedState)
		{
			base.LoadViewState(savedState);
		}
	}
}
