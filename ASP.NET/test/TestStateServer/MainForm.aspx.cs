using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestStateServer
{
	public class MainForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBoxTime;
		protected System.Web.UI.WebControls.TextBox TextBoxSubmit;
		protected System.Web.UI.WebControls.Button ButtonSubmit;

		[Serializable]
		class MainFormSessionData
		{
			private DateTime
				FtmpDateTime;

			private int
				FtmpInt;

			public DateTime tmpDateTime
			{
				get
				{
					return(FtmpDateTime);
				}
				set
				{
					if(FtmpDateTime!=value)
						FtmpDateTime=value;
				}
			}

			public int tmpInt
			{
				get
				{
					return(FtmpInt);
				}
				set
				{
					if(FtmpInt!=value)
						FtmpInt=value;
				}
			}

			public MainFormSessionData():this(DateTime.MinValue,int.MinValue)
			{}

			public MainFormSessionData(MainFormSessionData aObj):this(aObj.tmpDateTime,aObj.tmpInt)
			{}

			public MainFormSessionData(DateTime aDateTime, int aInt)
			{
				tmpDateTime=aDateTime;
				tmpInt=aInt;
			}
		}

		string
			MainFormSessionDataSignature="MainFormSessionData",
			DateTimeFormat="HH:mm:ss.fffffff";

		MainFormSessionData
			vMainFormSessionData;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if((vMainFormSessionData=Session[MainFormSessionDataSignature] as MainFormSessionData)==null)
			{
				Session[MainFormSessionDataSignature]=vMainFormSessionData=new MainFormSessionData(DateTime.Now,0);
			}

			if(!IsPostBack)
				ButtonSubmit_Click(null,EventArgs.Empty);
			else
				vMainFormSessionData.tmpInt++;
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
			this.ButtonSubmit.Click += new EventHandler(ButtonSubmit_Click);
		}
		#endregion

		private void ButtonSubmit_Click(object sender, EventArgs e)
		{
			TextBoxTime.Text=vMainFormSessionData.tmpDateTime.ToString(DateTimeFormat);
			TextBoxSubmit.Text=vMainFormSessionData.tmpInt.ToString();

			string
				FileName=Server.MapPath(null)+Path.DirectorySeparatorChar+"data";

			if(!Directory.Exists(FileName))
				Directory.CreateDirectory(FileName);

			FileName=FileName+Path.DirectorySeparatorChar+Session.SessionID+".dat";

			FileStream
				flStream=new FileStream(FileName,FileMode.OpenOrCreate,FileAccess.Write);

			try
			{
				BinaryFormatter
					binFormatter=new BinaryFormatter();

				binFormatter.Serialize(flStream,vMainFormSessionData);
			}
			finally
			{
				flStream.Close();
			}

			MainFormSessionData
				tmpMainFormSessionData=new MainFormSessionData();

			flStream = new FileStream(FileName,FileMode.Open,FileAccess.Read);
			try
			{
				BinaryFormatter binFormatter = new BinaryFormatter();
				tmpMainFormSessionData=(MainFormSessionData)binFormatter.Deserialize(flStream);
			}
			finally
			{
				flStream.Close();
			}

			if(tmpMainFormSessionData.tmpDateTime!=vMainFormSessionData.tmpDateTime)
				tmpMainFormSessionData.tmpDateTime=vMainFormSessionData.tmpDateTime;
		}
	}
}