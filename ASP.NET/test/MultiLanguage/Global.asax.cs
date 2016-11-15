using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Threading;

namespace MultiLanguage 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			// this.Application.Add("AvailableLanguages", this.localizationsData.GetLanguages());
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			/*
			string
				_sUserLanguage;

			bool
				_bLanguageCookieExist = false;
   
			// �������� ������� cookie ������ ����� �������������
			if(this.Request.Cookies["Language"]==null)
			{
				Hashtable
					_languageHashtable=(Hashtable)this.Application["AvailableLanguages"];
      
				// �������� ������� ����� �� ��������� �������� ������� ����� 
				// �������������� ������
				if(_languageHashtable[this.Request.UserLanguages[0].Substring(0,2)]!=null)
				{
					_sUserLanguage=this.Request.UserLanguages[0].Substring(0,2);
				}
				else
				{
					// ���� ���� �� ��������� ����������, �������� ����������� �� ����������
					_sUserLanguage="en";
				}
			}
			else
			{
				_sUserLanguage=this.Request.Cookies["Language"].Value;
				_bLanguageCookieExist=true;
			}
   
			// ����� �������� ��� �������� ������ ������� ������������ 
			Thread.CurrentThread
				.CurrentCulture   = CultureInfo.CreateSpecificCulture(_sUserLanguage);

			// ����� ��������, ������������ ResourceManager  ��� ������
			// �������������� ��������
			Thread.CurrentThread.CurrentUICulture=CultureInfo.CreateSpecificCulture(_sUserLanguage);

			// ����� ��������� �������� ������ �� ������ ������������         
			this.Response.ContentEncoding=Encoding.GetEncoding(Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage);
   
			if(!_bLanguageCookieExist)
			{
				// ����� �������� cookie, �������� ����� ����� �������������
				this.Response.Cookies["Language"].Value=Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
				this.Response.Cookies["Language"].Expires=DateTime.Now.AddYears(5);
			}
			*/
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

