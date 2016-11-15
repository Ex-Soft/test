#define SHOW_REQUEST

using System;

namespace AnyTest
{
	/// <summary>
	/// Summary description for PageEvents.
	/// </summary>
	public class PageEvents : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl Container;
		protected System.Web.UI.HtmlControls.HtmlGenericControl ContainerServer;
		protected System.Web.UI.WebControls.Label ParagraphRequest;
	
		protected string
			DynamicInput1Id="Input1",
			DynamicInput2Id="Input2Server";

		private string
			ViewStateTestSignature="ViewStateTest";

		private bool
			ViewStateTestVar=false;

		private void Page_Init(object sender, System.EventArgs e)
		{
			if(ViewState[ViewStateTestSignature]!=null)
				ViewStateTestVar=(bool)ViewState[ViewStateTestSignature];

			if(IsPostBack)
			{
				string[]
					array=Request.Params.GetValues(DynamicInput1Id);

				if(array!=null && array.Length>=1)
				{
					string
						val=Server.HtmlEncode(array[0]);

					if(val!=string.Empty)
						val=string.Empty;
				}

				AddCtrl();

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
						if(Value!=string.Empty)
							Value=string.Empty;
					}
					catch(OutOfMemoryException)
					{
						Value="Insufficient memory.";
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
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			System.Web.UI.HtmlControls.HtmlInputText
				tmpInput;

			string
				val;

			tmpInput=new System.Web.UI.HtmlControls.HtmlInputText();
			val=tmpInput.Value;
			if(val!=string.Empty)
				val=string.Empty;
			tmpInput.ID=DynamicInput2Id;
			val=tmpInput.Value;
			if(val!=string.Empty)
				val=string.Empty;
			tmpInput.EnableViewState=false;
			val=tmpInput.Value;
			if(val!=string.Empty)
				val=string.Empty;
			tmpInput.Value="From Server";
			val=tmpInput.Value;
			if(val!=string.Empty)
				val=string.Empty;

			tmpInput.Init+=new EventHandler(tmpInput_Init);
			tmpInput.Load+=new EventHandler(tmpInput_Load);
			tmpInput.Unload+=new EventHandler(tmpInput_Unload);

			ContainerServer.Controls.Add(tmpInput);
			val=tmpInput.Value;
			if(val!=string.Empty)
				val=string.Empty;

			if(ViewState[ViewStateTestSignature]!=null)
				ViewStateTestVar=(bool)ViewState[ViewStateTestSignature];
			else
				ViewState[ViewStateTestSignature]=!ViewStateTestVar;

			if(IsPostBack)
			{
				if((tmpInput=FindControl(DynamicInput1Id) as System.Web.UI.HtmlControls.HtmlInputText)!=null)
				{
					val=tmpInput.Value;
					if(val!=string.Empty)
						val=string.Empty;
				}

				#if(SHOW_REQUEST)
					string[]
						array1,
						array2;

					int
						i,
						ii;

					ParagraphRequest.Text="<br>";
					ParagraphRequest.Text+="Request.Params.Count: \""+Request.Params.Count+"\"<br>";
					array1=Request.Params.AllKeys;
					for(i=0; i<array1.Length; ++i)
					{
						ParagraphRequest.Text+="Key ["+Convert.ToString(i)+"]="+Server.HtmlEncode(array1[i])+"<br>";
						array2=Request.Params.GetValues(array1[i]);
						for(ii=0; ii<array2.Length; ++ii)
							ParagraphRequest.Text+="Value ["+Convert.ToString(ii)+"]="+Server.HtmlEncode(array2[ii])+"<br>";
					}
					ParagraphRequest.Text+="<br>"; 
				#endif

				if((tmpInput=FindControl(DynamicInput2Id) as System.Web.UI.HtmlControls.HtmlInputText)!=null)
				{
					val=tmpInput.Value;
					if(val!=string.Empty)
						val=string.Empty;
				}
				if(ViewState[DynamicInput2Id]!=null)
				{
					val=Convert.ToString(ViewState[DynamicInput2Id]);
					if(val!=string.Empty)
						val=string.Empty;
				}
			}
		}

		private void AddCtrl()
		{
			System.Web.UI.HtmlControls.HtmlInputText
				i=new System.Web.UI.HtmlControls.HtmlInputText();

			i.ID=DynamicInput1Id;
			i.Name=DynamicInput1Id;

			Container.Controls.Add(i);
		}

		protected override void LoadViewState(object savedState)
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
				catch(OutOfMemoryException)
				{
					Value="Insufficient memory.";
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

			base.LoadViewState(savedState);
		}

		private void tmpInput_Init(object sender, EventArgs e)
		{
			System.Web.UI.HtmlControls.HtmlInputText
				tmpHtmlInputText;

			if((tmpHtmlInputText=sender as System.Web.UI.HtmlControls.HtmlInputText)==null)
				return;

			string
				val=tmpHtmlInputText.Value;

			if(val!=string.Empty)
				val=string.Empty;
		}

		private void tmpInput_Load(object sender, EventArgs e)
		{
			System.Web.UI.HtmlControls.HtmlInputText
				tmpHtmlInputText;

			if((tmpHtmlInputText=sender as System.Web.UI.HtmlControls.HtmlInputText)==null)
				return;

			string
				val=tmpHtmlInputText.Value;

			if(val!=string.Empty)
				val=string.Empty;
		}

		private void tmpInput_Unload(object sender, EventArgs e)
		{
			System.Web.UI.HtmlControls.HtmlInputText
				tmpHtmlInputText;

			if((tmpHtmlInputText=sender as System.Web.UI.HtmlControls.HtmlInputText)==null)
				return;

			string
				val=tmpHtmlInputText.Value;

			if(val!=string.Empty)
				val=string.Empty;
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion
	}
}
