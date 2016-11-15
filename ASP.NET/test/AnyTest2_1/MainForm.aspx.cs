using System;

namespace AnyTest2_1
{
    public partial class MainForm : System.Web.UI.Page
    {
		public const string
			StrBeginJS = "\n<script type=\"text/javascript\">\n<!--\n",
			StrEndJS = "\n// -->\n</script>";

    	protected bool
    		SmthBool=true;

        protected void Page_Load(object sender, EventArgs e)
        {
			if(!IsPostBack)
			{
				string
					LogFileName = LogII.LogII.MakeLogFileName();

				LogII.LogII.MakeFile(LogFileName, LogFileName, true);

				LogFileName = LogII.LogII.MakeLogFileName("");
				LogII.LogII.MakeFile(LogFileName, LogFileName, true);

				LogFileName = LogII.LogII.MakeLogFileName("Transaction");
				LogII.LogII.MakeFile(LogFileName, LogFileName, true);
			}
        }

        public static string SmthStaticMethod(object Param)
        {
            return "From SmthStaticMethod(): "+Param;
        }
    }
}
