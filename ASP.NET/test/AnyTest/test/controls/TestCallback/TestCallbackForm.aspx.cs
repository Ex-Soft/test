using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnyTest
{
    public partial class TestCallbackForm : Page, ICallbackEventHandler
    {
        int
            cbCount = 0;

        public void RaiseCallbackEvent(String eventArgument)
        {
            cbCount = Convert.ToInt32(eventArgument) + 1;
        }

        public string GetCallbackResult()
        {
            return cbCount.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Form["__EVENTVALIDATION"]!=null)
            {
                string
                    value = Convert.ToBase64String(Encoding.UTF8.GetBytes(Request.Form["__EVENTVALIDATION"]));
            }

            StringBuilder
                sb = new StringBuilder();

            sb.Append("No page postbacks have occurred.");
            if (Page.IsPostBack)
            {
                sb.Append("A page postback has occurred.");
            }

            MyLabel.Text = sb.ToString();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager
                cs = Page.ClientScript;

            // Define one of the callback script's context.
            // The callback script will be defined in a script block on the page.
            StringBuilder context1 = new StringBuilder();
            context1.Append("function ReceiveServerData1(arg, context)");
            context1.Append("{");
            context1.Append("Message1.innerText =  arg;");
            context1.Append("value1 = arg;");
            context1.Append("alert(typeof(context));");
            context1.Append("}");

            // Define callback references.
            String cbReference1 = cs.GetCallbackEventReference(this, "arg", "ReceiveServerData1", context1.ToString());
            String cbReference2 = cs.GetCallbackEventReference("'" + Page.UniqueID + "'", "arg", "ReceiveServerData2", "", "ProcessCallBackError", false);
            String callbackScript1 = "function CallTheServer1(arg, context) {\r\n" + cbReference1 + ";\r\n }";
            String callbackScript2 = "function CallTheServer2(arg, context) {\r\n" + cbReference2 + ";\r\n }";

            // Register script blocks will perform call to the server.
            cs.RegisterClientScriptBlock(this.GetType(), "CallTheServer1", callbackScript1, true);
            cs.RegisterClientScriptBlock(this.GetType(), "CallTheServer2", callbackScript2, true);
        }

        protected void OnServerValidateListBox(object source, ServerValidateEventArgs args)
        {
            CustomValidator
                cv = source as CustomValidator;

            args.IsValid = !string.IsNullOrEmpty(args.Value);
        }

        protected void OnServerValidateTextBox(object source, ServerValidateEventArgs args)
        {
            CustomValidator
                cv = source as CustomValidator;

            args.IsValid = !string.IsNullOrEmpty(args.Value);
        }

        protected void OnClickSubmit(object source, EventArgs args)
        {
            LabelInfo.Text = Page.IsValid.ToString().ToLower();
        }
    }
}
