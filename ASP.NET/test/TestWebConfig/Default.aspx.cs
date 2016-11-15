// http://www.codeproject.com/KB/aspnet/ConfigSections.aspx

using System;
using System.Web.Configuration;
using System.Collections;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace TestWebConfig
{
	public partial class MainForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string
					value,
					key;

				key="appSettingsSmthKey";
				if (!string.IsNullOrEmpty(value = WebConfigurationManager.AppSettings[key]))
					LabelAppSettings.Text = value;

				key="connectionStringsSmthName";
				if (!string.IsNullOrEmpty(value = WebConfigurationManager.ConnectionStrings[key].ConnectionString))
					LabelConnectionStrings.Text = value;

				Label
					tmpLabel;

				NameValueCollection
					nvc = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection("NameValueSection");

				tmpLabel = LabelNameValueSection;
				foreach(string k in nvc.Keys)
				{
					if (tmpLabel.Text != string.Empty)
						tmpLabel.Text += "<br/>";
					tmpLabel.Text += "\"" + k + "\"=\"" + nvc[k] + "\"";
				}

				Hashtable
					ht;

				ht = (Hashtable)System.Configuration.ConfigurationManager.GetSection("DictionarySection");
				tmpLabel = LabelDictionarySection;
				foreach (string k in ht.Keys)
				{
					if (tmpLabel.Text != string.Empty)
						tmpLabel.Text += "<br/>";
					tmpLabel.Text += "\"" + k + "\"=\"" + ht[k] + "\"";
				}

				ht = (Hashtable)System.Configuration.ConfigurationManager.GetSection("SingleTagSection");
				tmpLabel = LabelSingleTagSection;
				foreach (string k in ht.Keys)
				{
					if(tmpLabel.Text!=string.Empty)
						tmpLabel.Text+="<br/>";
					tmpLabel.Text += "\"" + k + "\"=\"" + ht[k] + "\"";
				}

				NameValueSection
					nvs = (NameValueSection)System.Configuration.ConfigurationManager.GetSection("MyConfigHandler");

				tmpLabel = LabelMyConfigHandler;
				tmpLabel.Text = "\"" + nvs.NVSparam1 + "\"<br/>\"" + nvs.NVSparam2 + "\"<br/>\"" + nvs.NVSparam3 + "\"";

				List<MyConfigHandlerAdvancedEntry>
					list = MyConfigHandlerAdvanced.MyConfigHandlerAdvancedEntries;

				tmpLabel = LabelMyConfigHandlerAdvanced;
				foreach(MyConfigHandlerAdvancedEntry entry in list)
				{
					if (tmpLabel.Text != string.Empty)
						tmpLabel.Text += "<br/>";
					tmpLabel.Text += "\"" + entry.MCHAparam1key + "\"&nbsp;\"" + entry.MCHAparam2key + "\"&nbsp;\"" + entry.MCHAparam3key + "\"";
				}
			}
		}
	}
}
