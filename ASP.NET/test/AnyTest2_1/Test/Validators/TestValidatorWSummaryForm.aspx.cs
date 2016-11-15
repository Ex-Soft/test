using System;

namespace AnyTest2_1
{
    public partial class TestValidatorWSummaryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelInfo.Text = DateTime.Now + " IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\"";
            LabelTextBox2.Text = "\"" + TextBox2.Text.Trim() + "\"";
            RequiredFieldValidatorTextBox3.Enabled = CheckBoxIsValidateTextBox3.Checked;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			System.IO.StringWriter
				stringWriter=new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter
                htmlWriter = new System.Web.UI.HtmlTextWriter(stringWriter);

			base.Render(htmlWriter);

			string
                Signature="function WebForm_OnSubmit() {",
				html=stringWriter.ToString();

			int
				Pos;
            
			if((Pos=html.IndexOf(Signature))>=0)
                html = html.Insert(Pos + Signature.Length, "\r\nif(!document.getElementById(\""+CheckBoxIsValidateTextBox3.ID+"\").checked){alert(\"WebForm_OnSubmit\"); return(true);}");

			writer.Write(html);
		}
    }
}