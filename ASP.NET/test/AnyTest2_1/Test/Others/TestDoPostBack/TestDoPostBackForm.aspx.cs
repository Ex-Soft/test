using System;

namespace AnyTest2_1
{
    public partial class TestDoPostBackForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[]
                Keys,
                _Values_;

            string
                tmpString;

            LabelInfo.Text = "Request.Form.Count=" + Request.Form.Count + "<br />";
            Keys = Request.Form.AllKeys;
            for (int i = 0; i < Keys.Length; ++i)
            {
                LabelInfo.Text += "Key[" + i + "]=" + Keys[i] + "<br />";
                _Values_ = Request.Form.GetValues(Keys[i]);
                for (int j = 0; j < _Values_.Length; ++j)
                    LabelInfo.Text += "Value[" + j + "]=\"" + _Values_[j] + "\"<br />";
            }
            tmpString = Request.Form["__EVENTTARGET"];
            tmpString = Request.Form["__EVENTARGUMENT"];
        }

        protected void ButtonVictim_Click(object sender, EventArgs e)
        {

        }

        protected void CheckBoxVictim_Changed(object sender, EventArgs e)
        {

        }
    }
}
