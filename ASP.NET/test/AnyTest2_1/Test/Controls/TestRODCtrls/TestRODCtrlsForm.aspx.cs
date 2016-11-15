using System;
using System.Collections.Specialized;

namespace AnyTest2_1
{
	public partial class TestRODCtrlsForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				TextBoxReadOnly.Text = "TextBoxReadOnly.Text";
				TextBoxDisabled.Text = "TextBoxDisabled.Text";
				TextBoxReadOnlyDisabled.Text = "TextBoxReadOnlyDisabled.Text";
				TextBoxOrdinary.Text = "TextBoxOrdinary.Text";
			}
			else
			{
				string
					vPath = "~/controls/images/wall.gif",
					tmpString;

				tmpString = Context.Request.CurrentExecutionFilePath;
				tmpString = System.Web.VirtualPathUtility.GetDirectory(vPath);
				tmpString = System.Web.VirtualPathUtility.ToAbsolute(vPath);

				string[]
					array1 = Request.Form.AllKeys;

				LabelAllKeys.Text = string.Empty;
				LabelValue.Text = string.Empty;
				for (int i = 0; i < array1.Length; ++i)
				{
					if (LabelAllKeys.Text != string.Empty)
						LabelAllKeys.Text += "<br>";
					LabelAllKeys.Text += "Key [" + i + "]=" + array1[i];

					string[]
						array2;

					tmpString = string.Empty;
					if((array2 = Request.Form.GetValues(array1[i]))!=null)
						for(int j=0; j<array2.Length; ++j)
						{
							if(tmpString!=string.Empty)
								tmpString += "<br>";
							tmpString += "\"" + array2[j] + "\"";
						}

					if(LabelValue.Text!=string.Empty)
						LabelValue.Text += "<br>";
					LabelValue.Text += "\"" + array1[i] + "\"=" + tmpString;
				}

				NameObjectCollectionBase.KeysCollection
					input = Request.Form.Keys;

				LabelKeys.Text = string.Empty;
				for (int i = 0; i < input.Count; ++i)
				{
					if (LabelKeys.Text != string.Empty)
						LabelKeys.Text += "<br>";
					LabelKeys.Text += input[i];
				}

				tmpString = "TextBoxReadOnly.Text=\"" + TextBoxReadOnly.Text + "\"<br>";
				tmpString += " TextBoxDisabled.Text=\"" + TextBoxDisabled.Text + "\"<br>";
				tmpString += " TextBoxReadOnlyDisabled.Text=\"" + TextBoxReadOnlyDisabled.Text + "\"<br>";
				tmpString += " TextBoxOrdinary.Text=\"" + TextBoxOrdinary.Text + "\"";

				LabelText.Text = tmpString;
			}
		}
	}
}
