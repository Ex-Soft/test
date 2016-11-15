using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class LoginEventArgs
{
   private bool
     LoginValid;
          
   public LoginEventArgs(bool IsValid)
   {
      LoginValid=IsValid;
   }

   public bool IsValid
   {
      get
        {
           return(LoginValid);
        }
   }
}

public class LoginBase:UserControl
{
   protected HtmlTable
     LoginControlTable;

   protected TextBox
     LoginControlUserName,
     LoginControlPassword;

   public string BackColor
   {
      get
      {
         return(LoginControlTable.BgColor);
      }
     
      set
      {
         if(LoginControlTable.BgColor.CompareTo(value)!=0)
           LoginControlTable.BgColor=value;
      }
   }

   public string UserName
   {
      get
      {
         return(LoginControlUserName.Text);
      }
     
      set
      {
         if(LoginControlUserName.Text.CompareTo(value)!=0)
           LoginControlUserName.Text=value;
      }
   }

   public string Password
   {
      get
      {
         return(LoginControlPassword.Text);
      }
     
      set
      {
         if(LoginControlPassword.Text.CompareTo(value)!=0)
           LoginControlPassword.Text=value;
      }
   }

   public delegate void LoginEventHandler(Object sender, LoginEventArgs e);

   public event LoginEventHandler LoginControlLogin;

   public void LoginControlLinkButtonOnClick(Object sender, EventArgs e)
   {
      if(LoginControlLogin!=null)
        {
           bool
             IsValid=UserName.ToLower()=="bill"
                     && Password.ToLower()=="fucking";

           LoginControlLogin(this,new LoginEventArgs(IsValid));
        }
   }
}