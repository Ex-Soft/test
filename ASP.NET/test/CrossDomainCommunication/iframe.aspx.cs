using System;

public partial class iframe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var frameNoStr = Request.QueryString.Get("frameNo");
        if (frameNoStr != null)
        {
            int frameNo;

            if (int.TryParse(frameNoStr, out frameNo))
                labelFrameNo.Text = frameNo.ToString();
        }

        Response.Headers["Access-Control-Allow-Headers"] = "access-control-allow-headers,access-control-allow-methods,access-control-allow-origin";
        Response.Headers["Access-Control-Allow-Methods"] = "POST, GET, OPTIONS, DELETE";
        //Response.Headers["Access-Control-Allow-Origin"] ="*";
        Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:22763";
    }
}