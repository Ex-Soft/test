using System;
using System.Web.UI;
using System.Collections.Specialized;

namespace Wintellect
{
    public class AutoCounter:Control,IPostBackDataHandler,IPostBackEventHandler
    {
        public event EventHandler Decrement;
        public event EventHandler Increment;
        public event EventHandler CountChanged;

        public int Count
        {
            get
            {
                int count = 0;
                if (ViewState["Count"] != null)
                    count = (int) ViewState["Count"];
                return count;
            }
            set { ViewState["Count"] = value; }
        }

        public bool LoadPostData (string postDataKey,
            NameValueCollection postCollection)
        {
            int temp = Count;
            try {
                Count = Convert.ToInt32 (postCollection[postDataKey]);
            }
            catch (FormatException) {
                Count = 0;
            }
            return (temp != Count);
        } 

        public void RaisePostDataChangedEvent ()
        {
            if (CountChanged != null)
                CountChanged (this, new EventArgs ());
        }

        public void RaisePostBackEvent (string eventArgument)
        {
            if (eventArgument == "dec") {
                Count--;
                if (Decrement != null)
                    Decrement (this, new EventArgs ());
            }
            else if (eventArgument == "inc") {
                Count++;
                if (Increment != null)
                    Increment (this, new EventArgs ());
            }
        }

        protected override void Render (HtmlTextWriter writer)
        {
            // Output an <a> tag
            writer.WriteBeginTag ("a");
            writer.WriteAttribute ("href", "javascript:" +
                Page.GetPostBackEventReference (this, "dec"));
            writer.Write (HtmlTextWriter.TagRightChar);

            // Output a less-than sign
            writer.Write ("&lt;");

            // Output a </a> tag
            writer.WriteEndTag ("a");

            // Output an <input> tag
            writer.Write (" ");
            writer.WriteBeginTag ("input");
            writer.WriteAttribute ("type", "text");
            writer.WriteAttribute ("name", UniqueID);
            if (ID != null)
                writer.WriteAttribute ("id", ClientID);
            writer.WriteAttribute ("value", Count.ToString ());
            writer.WriteAttribute ("size", "3");
            writer.Write (HtmlTextWriter.TagRightChar);
            writer.Write (" ");

            // Output another <a> tag
            writer.WriteBeginTag ("a");
            writer.WriteAttribute ("href", "javascript:" +
                Page.GetPostBackEventReference (this, "inc"));
            writer.Write (HtmlTextWriter.TagRightChar);

            // Output a greater-than sign
            writer.Write ("&gt;");

            // Output a </a> tag
            writer.WriteEndTag ("a");
        }
    }

    public class MyLinkButton:Control,IPostBackEventHandler
    {
        string MyText = "";
        public event EventHandler Click;

        public string Text
        {
            get { return MyText; }
            set { MyText = value; }
        }

        public void RaisePostBackEvent (string eventArgument)
        {
            if (Click != null)
                Click (this, new EventArgs ());
        }

        protected override void Render (HtmlTextWriter writer)
        {
            // Output an <a> tag
            writer.WriteBeginTag ("a");
            if (ID != null)
                writer.WriteAttribute ("id", ClientID);
            writer.WriteAttribute ("href", "javascript:" +
                Page.GetPostBackEventReference (this));
            writer.Write (HtmlTextWriter.TagRightChar);

            // Output the text bracketed by <a> and </a> tags
            if (Text.Length > 0)
                writer.Write (Text);

            // Output a </a> tag
            writer.WriteEndTag ("a");
        }
    }

   public class MyTextBoxFullAdvanced:Control, IPostBackDataHandler
   {
      bool
        MyAutoPostBack=false;

      public event EventHandler
        TextChanged;

      public string Text
      {
         get
           {
              string
                text=(string)ViewState["MyText"];

              return((text==null) ? "" : text);
           }

         set
           {
              ViewState["MyText"]=value;
           }
      }

      public bool AutoPostBack
      {
         get
           {
              return(MyAutoPostBack);
           }

         set
           {
              MyAutoPostBack=value;
           }
      }

      public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
      {
         string
           temp=Text;

         Text=postCollection[postDataKey];

         return(temp!=Text);
      }

      public void RaisePostDataChangedEvent()
      {
         if(TextChanged!=null)
           TextChanged(this,new EventArgs());
      }

      protected override void Render(HtmlTextWriter writer)
      {
         writer.WriteBeginTag("input");
         writer.WriteAttribute("type","text");
         writer.WriteAttribute("name",UniqueID);

         if(ID!=null)
           writer.WriteAttribute("id",ClientID);

         if(Text.Length>0)
           writer.WriteAttribute("value",Text);

         if(AutoPostBack)
           writer.WriteAttribute("onchange", "javascript:"+Page.GetPostBackEventReference(this));

         writer.Write(HtmlTextWriter.TagRightChar);
      }
   }

   public class MyTextBoxAdvanced:Control, IPostBackDataHandler
   {
      public event EventHandler TextChanged;

      public string Text
      {
         get
           {
              string
                text=(string)ViewState["MyText"];

              return((text==null) ? "" : text);
           }

         set
           {
              ViewState["MyText"]=value;
           }
      }

      public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
      {
         string
           temp=Text;

         Text=postCollection[postDataKey];

         return(temp!=Text);
      }

      public void RaisePostDataChangedEvent()
      {
         if(TextChanged!=null)
           TextChanged(this,new EventArgs());
      }

      protected override void Render(HtmlTextWriter writer)
      {
         writer.WriteBeginTag("input");
         writer.WriteAttribute("type","text");
         writer.WriteAttribute("name",UniqueID);

         if(ID!=null)
           writer.WriteAttribute("id",ClientID);

         if(Text.Length>0)
           writer.WriteAttribute("value",Text);

         writer.Write(HtmlTextWriter.TagRightChar);
      }
   }

   public class MyTextBox:Control, IPostBackDataHandler
   {
      string
        MyText="";

      public string Text
      {
         get
           {
              return(MyText);
           }

         set
           {
              if(MyText.CompareTo(value)!=0)
                MyText=value;
           }
      }

      public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
      {
         string
           NewText=postCollection[postDataKey];

         if(Text!=NewText)
           Text=NewText;

         return(false);
      }

      public void RaisePostDataChangedEvent()
      {
      }

      protected override void Render(HtmlTextWriter writer)
      {
         writer.WriteBeginTag("input");
         writer.WriteAttribute("type","text");
         writer.WriteAttribute("name",UniqueID);

         if(ID!=null)
           writer.WriteAttribute("id",ClientID);

         if(Text.Length>0)
           writer.WriteAttribute("value",Text);

         writer.Write(HtmlTextWriter.TagRightChar);
      }
   }

   public class Hello:Control
   {
      string
        MyName="";

      public string Name
      {
         get
           {
              return(MyName);
           }

         set
           {
              if(MyName.CompareTo(value)!=0)
                MyName=value;
           }
      }

      protected override void Render(HtmlTextWriter writer)
      {
         string
           OutputStr="<h1>Hello";

         if(MyName.Length>0)
           {
              OutputStr+=", "+Name;
           }
         OutputStr+="</h1>";
         writer.Write(OutputStr);
      }
   }
}