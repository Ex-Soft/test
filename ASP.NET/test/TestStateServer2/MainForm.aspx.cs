using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestStateServer2
{
	public partial class MainForm : System.Web.UI.Page
	{
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
					return (FtmpDateTime);
				}
				set
				{
					if (FtmpDateTime != value)
						FtmpDateTime = value;
				}
			}

			public int tmpInt
			{
				get
				{
					return (FtmpInt);
				}
				set
				{
					if (FtmpInt != value)
						FtmpInt = value;
				}
			}

			public MainFormSessionData()
				: this(DateTime.MinValue, int.MinValue)
			{ }

			public MainFormSessionData(MainFormSessionData aObj)
				: this(aObj.tmpDateTime, aObj.tmpInt)
			{ }

			public MainFormSessionData(DateTime aDateTime, int aInt)
			{
				tmpDateTime = aDateTime;
				tmpInt = aInt;
			}
		}

		string
			MainFormSessionDataSignature = "MainFormSessionData",
			DateTimeFormat = "HH:mm:ss.fffffff";

		MainFormSessionData
			vMainFormSessionData;

		protected void Page_Load(object sender, EventArgs e)
		{
			if ((vMainFormSessionData = Session[MainFormSessionDataSignature] as MainFormSessionData) == null)
			{
				Session[MainFormSessionDataSignature] = vMainFormSessionData = new MainFormSessionData(DateTime.Now, 0);
			}

			if (!IsPostBack)
				ButtonSubmit_Click(null, EventArgs.Empty);
			else
				vMainFormSessionData.tmpInt++;
		}

		protected void ButtonSubmit_Click(object sender, EventArgs e)
		{
			TextBoxTime.Text = vMainFormSessionData.tmpDateTime.ToString(DateTimeFormat);
			TextBoxSubmit.Text = vMainFormSessionData.tmpInt.ToString();

			string
				FileName = Server.MapPath(null) + Path.DirectorySeparatorChar + "data";

			if (!Directory.Exists(FileName))
				Directory.CreateDirectory(FileName);

			FileName = FileName + Path.DirectorySeparatorChar + Session.SessionID + ".dat";

			FileStream
				flStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);

			try
			{
				BinaryFormatter
					binFormatter = new BinaryFormatter();

				binFormatter.Serialize(flStream, vMainFormSessionData);
			}
			finally
			{
				flStream.Close();
			}

			MainFormSessionData
				tmpMainFormSessionData = new MainFormSessionData();

			flStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
			try
			{
				BinaryFormatter binFormatter = new BinaryFormatter();
				tmpMainFormSessionData = (MainFormSessionData)binFormatter.Deserialize(flStream);
			}
			finally
			{
				flStream.Close();
			}

			if (tmpMainFormSessionData.tmpDateTime != vMainFormSessionData.tmpDateTime)
				tmpMainFormSessionData.tmpDateTime = vMainFormSessionData.tmpDateTime;
		}
	}
}
