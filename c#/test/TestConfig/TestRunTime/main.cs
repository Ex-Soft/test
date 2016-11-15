using System;
using System.Configuration;
using System.IO;

namespace TestRunTime
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ShowConnectionStrings();
                ShowAppSettings();

                string
                    originalAppConfig = AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString(),
                    currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location,
                    fullFileName;

                if (currentDirectory.IndexOf("bin") != -1)
                    currentDirectory = currentDirectory.Substring(0,
                        currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                fullFileName = args.Length == 0 || !File.Exists(args[0])
                    ? Path.Combine(currentDirectory, "AddApp.config")
                    : args[0];

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.File = fullFileName;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                ConfigurationManager.AppSettings["keyAAA"] = string.Format("_{0}_", ConfigurationManager.AppSettings["keyAAA"]);
                //ConfigurationManager.AppSettings.Add("keyCCC", "CCC");

                ShowConnectionStrings();
                ShowAppSettings();
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            Console.ReadLine();
        }

        static void ShowConnectionStrings()
        {
            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
                Console.WriteLine(connectionString.Name);            
        }

        static void ShowAppSettings()
        {
            foreach (string key in ConfigurationManager.AppSettings)
                Console.WriteLine("key=\"{0}\" value = \"{1}\"", key, ConfigurationManager.AppSettings[key]);
        }
    }
}
