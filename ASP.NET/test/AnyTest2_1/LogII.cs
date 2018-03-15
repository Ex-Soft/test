using System;
using System.IO;

namespace LogII
{
    public class LogII
    {
        public static string MakeLogFileName(string logFileNameSuffix = "")
        {
            DateTime
                NowDateTime = DateTime.Now;

            string
                DirName = System.Web.HttpContext.Current.Server.MapPath(null) + "\\log",
                LogFileName = NowDateTime.ToString("yy-MM-dd");

            if ((bool)System.Web.HttpContext.Current.Application["HourLogFile" + logFileNameSuffix])
                LogFileName += "_" + NowDateTime.Hour.ToString("D2") + "-00-00" + "_" + NowDateTime.AddHours((int)System.Web.HttpContext.Current.Application["DeltaHourLogFile" + logFileNameSuffix] - 1).Hour.ToString("D2") + "-59-59";

            if ((bool)System.Web.HttpContext.Current.Application["SessionLogFile" + logFileNameSuffix])
                LogFileName += "_" + System.Web.HttpContext.Current.Session.SessionID;

            if (!Directory.Exists(DirName))
                Directory.CreateDirectory(DirName);

            LogFileName = DirName + "\\" + LogFileName + ".log";
            System.Web.HttpContext.Current.Session["LogFileName" + logFileNameSuffix] = LogFileName;

            return (LogFileName);
        }

        public static void MakeFile(string FileName, string WriteString, bool Append)
        {
            if (FileName == null
                || WriteString == null
                || (FileName = FileName.Trim()) == string.Empty
                || WriteString.Trim() == string.Empty)
                return;

            StreamWriter
                OutputFile = null;

            lock (typeof(StreamWriter))
            {
                if ((OutputFile = new StreamWriter(FileName, Append, System.Text.Encoding.GetEncoding(1251))) != null && OutputFile.BaseStream != null && OutputFile.BaseStream.CanWrite)
                {
                    if (!OutputFile.AutoFlush)
                        OutputFile.AutoFlush = true;

                    if (Append && OutputFile.BaseStream.Position != 0)
                        OutputFile.Write(Environment.NewLine);

                    OutputFile.Write(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.ffff") + '\t' + WriteString);
                }

                if (OutputFile != null)
                    OutputFile.Close();
            }
        }
    }
}