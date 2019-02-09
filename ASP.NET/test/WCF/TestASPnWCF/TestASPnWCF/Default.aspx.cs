using System;
using System.Diagnostics;
using TestASPnWCF.TestASPnWCFService;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnDoWorkClick(object sender, EventArgs e)
    {
        try
        {
            var client = new TestServiceClient();
            client.Open();
            client.DoWork();
            client.Close();
        }
        catch (Exception eException)
        {
            Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message)? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
        }
    }
}
