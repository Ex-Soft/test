namespace Log
{
	public class Log
	{
		public static void WriteToLog(string WriteString, bool Append)
		{
			WriteString=WriteString.Trim();

			if(WriteString==string.Empty)
				return;

			string
				CurrDir = System.Web.HttpContext.Current!=null ? System.Web.HttpContext.Current.Server.MapPath(null) : System.IO.Directory.GetCurrentDirectory();

			System.IO.StreamWriter
				OutputFile=new System.IO.StreamWriter(CurrDir+"\\Log.log",Append,System.Text.Encoding.GetEncoding(1251));

			if(OutputFile!=null && OutputFile.BaseStream!=null && OutputFile.BaseStream.CanWrite)
			{
				if(!OutputFile.AutoFlush)
					OutputFile.AutoFlush=true;

				if(Append && OutputFile.BaseStream.Position!=0)
					OutputFile.Write(System.Environment.NewLine);

				OutputFile.Write(System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fffffff tt")+'\t'+WriteString);
			}

			if(OutputFile!=null)
				OutputFile.Close();
		}
	}
}