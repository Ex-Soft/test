using System.IO;
using DEUpdater.Config;

using static System.Console;

namespace DEUpdater
{
    public enum ReturnValue
    {
        Ok,
        SourceDirectoryUndefined,
        SourceDirectoryDoesntExist,
        VersionUndefined,
        VersionInvalid,
        UnknownError
    }

    class Program
    {
        static int Main(string[] args)
        {
            var returnValue = (int)ReturnValue.Ok;
            var appConfig = new AppConfig();

            appConfig.Load();

            if (args.Length > 0)
            {
                if ((returnValue = (int)ParseCmdLine(args, appConfig)) == (int)ReturnValue.Ok)
                    returnValue = (int)Core.Execute(appConfig);
                else
                {
                    var errorMessage = string.Empty;

                    switch ((ReturnValue)returnValue)
                    {
                        case ReturnValue.SourceDirectoryUndefined: errorMessage = "Source directory is undefined"; break;
                        case ReturnValue.SourceDirectoryDoesntExist: errorMessage = "Source directory doesn't exist"; break;
                        case ReturnValue.VersionUndefined: errorMessage = "Version is undefined"; break;
                        case ReturnValue.VersionInvalid: errorMessage = "Invalid version"; break;
                    }

                    if (!string.IsNullOrWhiteSpace(errorMessage))
                        WriteLine(errorMessage);
                }
            }
            else
                ShowHelp();

            return returnValue;
        }

        private static void ShowHelp()
        {
            WriteLine("Usage: DEUpdater <path> <version>");
            WriteLine("\tpath: source directory");
            WriteLine("\tversion: full version");
        }

        private static ReturnValue ParseCmdLine(string[] args, AppConfig appConfig)
        {
            string tmpString;

            if (args.Length == 0 || string.IsNullOrWhiteSpace(tmpString = args[0]))
                return ReturnValue.SourceDirectoryUndefined;

            if (!Directory.Exists(tmpString))
                return ReturnValue.SourceDirectoryDoesntExist;

            appConfig.SourceDirectory = tmpString;

            if (args.Length == 1 || string.IsNullOrWhiteSpace(tmpString = args[1]))
                return ReturnValue.VersionUndefined;

            if (!appConfig.FullVersionPattern.IsMatch(tmpString))
                return ReturnValue.VersionInvalid;

            appConfig.FullVersion = tmpString;

            return ReturnValue.Ok;
        }
    }
}
