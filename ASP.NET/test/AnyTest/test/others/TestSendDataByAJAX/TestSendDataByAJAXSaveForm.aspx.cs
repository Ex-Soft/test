using System;
using System.Text;
using System.Web;

namespace AnyTest
{
	public class TestSendDataByAJAXSaveForm : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string[]
				array1,
				array2;

			int
				i,
				ii;

			string
				tmpString,
				tmptmpString=ResolveUrl("~/ajax.js");

			tmpString=string.Empty;
			if((array1=Request.Params.AllKeys)!=null)
			{
				for(i=0; i<array1.Length; ++i)
				{
					if((array2=Request.Form.GetValues(array1[i]))!=null)
					{
						tmpString+="Key ["+Convert.ToString(i)+"]="+array1[i]+Environment.NewLine;
					
						for(ii=0; ii<array2.Length; ++ii)
						{
							tmpString+="Value ["+Convert.ToString(ii)+"]="+array2[ii]+Environment.NewLine;

							tmptmpString=Server.HtmlEncode(array2[ii]);
							tmptmpString=Server.HtmlDecode(array2[ii]);

							tmptmpString=Server.UrlEncode(array2[ii]);
							tmptmpString=Server.UrlDecode(array2[ii]);

							tmptmpString=HttpUtility.HtmlEncode(array2[ii]);
							tmptmpString=HttpUtility.HtmlDecode(array2[ii]);

							tmptmpString=HttpUtility.UrlEncode(array2[ii]);
							tmptmpString=HttpUtility.UrlDecode(array2[ii]);

							tmptmpString=UTF8ToCP1251(array2[ii]);
							tmptmpString=ConvertFromTo(array2[ii],Encoding.UTF8,Encoding.GetEncoding(1251));
						}
					}
				}
			}

			tmpString=string.Empty;
			if((array1=Request.Form.AllKeys)!=null)
			{
				for(i=0; i<array1.Length; ++i)
				{
					if((array2=Request.Form.GetValues(array1[i]))!=null)
					{
						tmpString+="Key ["+Convert.ToString(i)+"]="+array1[i]+Environment.NewLine;
					
						for(ii=0; ii<array2.Length; ++ii)
						{
							tmpString+="Value ["+Convert.ToString(ii)+"]="+array2[ii]+Environment.NewLine;
							tmptmpString=UTF8ToCP1251(array2[ii]);
							tmptmpString=ConvertFromTo(array2[ii],Encoding.UTF8,Encoding.GetEncoding(1251));
						}
					}
				}
			}

			Response.StatusCode=333;
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
		}
		#endregion

		string UTF8ToCP1251(string value)
		{
			Log.Log.WriteToLog("value=\""+value+"\"",true);

			byte[]
				UTF8Bytes=System.Text.Encoding.UTF8.GetBytes(value),
				CP1251Bytes=System.Text.Encoding.Convert(System.Text.Encoding.UTF8,System.Text.Encoding.GetEncoding(1251),UTF8Bytes);

			char[]
				CP1251Chars=new char[System.Text.Encoding.GetEncoding(1251).GetCharCount(CP1251Bytes,0,CP1251Bytes.Length)];

			System.Text.Encoding.GetEncoding(1251).GetChars(CP1251Bytes,0,CP1251Bytes.Length,CP1251Chars,0);

			string
				tmpString=new string(CP1251Chars);

			Log.Log.WriteToLog("tmpString# 1 =\""+tmpString+"\"",true);
			//return(tmpString);
			
			byte[]
				ba=Encoding.GetEncoding(1251).GetBytes(value);

			char[]
				ca=new char[Encoding.UTF8.GetDecoder().GetCharCount(ba,0,ba.Length)];

			Encoding.UTF8.GetDecoder().GetChars(ba,0,ba.Length,ca,0);
			tmpString=new string(ca);
			Log.Log.WriteToLog("tmpString# 2 =\""+tmpString+"\"",true);

			return(tmpString);
		}
		//---------------------------------------------------------------------------

		string ConvertFromTo(string value, Encoding src, Encoding trg)
		{
			Decoder
				dec=src.GetDecoder();

			byte[]
				ba=trg.GetBytes(value);

			char[]
				ca=new char[dec.GetCharCount(ba,0,ba.Length)];

			dec.GetChars(ba,0,ba.Length,ca,0);

			return(new string(ca));
		}
		//---------------------------------------------------------------------------
	}
}