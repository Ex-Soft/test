using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using DEUpdater.Config;

using static System.Console;

namespace DEUpdater
{
    public static class Core
    {
        public static ReturnValue Execute(AppConfig appConfig)
        {
            var result = ReturnValue.Ok;

            var fileNames = GetFiles(appConfig.SourceDirectory, "*.*", SearchOption.AllDirectories);
            foreach (var fileName in fileNames)
            {
                WriteLine(fileName);

                string content;
                if (Array.IndexOf(appConfig.FileExtensions, Path.GetExtension(fileName)) == -1
                    || string.IsNullOrWhiteSpace(content = UpdateFileContent(fileName, appConfig))
                    || !ResetReadOnlyAttribute(fileName)
                    || !WriteFileContent(fileName, content)
                    || !appConfig.Checkin
                    || string.IsNullOrWhiteSpace(appConfig.Tf))
                    continue;

                if (!Checkin(appConfig.Tf, fileName))
                    appConfig.Checkin = false;
            }

            return result;
        }

        private static IEnumerable<string> GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            string[] result;

            try
            {
                result = Directory.GetFiles(path, searchPattern, searchOption);
            }
            catch (Exception e)
            {
                result = new string[0];
                WriteLine(e.Message);
            }

            return result;
        }

        private static string UpdateFileContent(string fileName, AppConfig appConfig)
        {
            string content;

            try
            {
                content = File.ReadAllText(fileName);
            }
            catch (Exception e)
            {
                content = null;
                WriteLine(e.Message);
            }

            if (string.IsNullOrWhiteSpace(content))
                return null;

            var isModified = false;

            foreach (var pattern in appConfig.Patterns)
            {
                var version = pattern.IsMajorVersion ? appConfig.MajorVersion : appConfig.FullVersion;
                var match = pattern.Expression.Match(content);

                if (!match.Success || match.Value == version)
                    continue;

                isModified = true;

                content = pattern.Expression.Replace(content, version);
            }

            return isModified ? content : null;
        }

        private static bool ResetReadOnlyAttribute(string fileName)
        {
            bool result;

            try
            {
                var fileAttributes = File.GetAttributes(fileName);
                if ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    File.SetAttributes(fileName, fileAttributes & ~FileAttributes.ReadOnly);
                result = true;
            }
            catch (Exception e)
            {
                result = false;
                WriteLine(e.Message);
            }            

            return result;
        }

        private static bool WriteFileContent(string fileName, string content)
        {
            bool result;

            try
            {
                File.WriteAllText(fileName, content, Encoding.UTF8);
                result = true;
            }
            catch (Exception e)
            {
                result = false;
                WriteLine(e.Message);
            }

            return result;
        }

        private static bool Checkin(string tf, string fileName)
        {
            bool result;

            try
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = tf,
                    Arguments = $"checkout \"{fileName}\"",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                };

                var exitCode = 1;

                using (var process = Process.Start(processStartInfo))
                {
                    if (process != null)
                    {
                        process.WaitForExit();
                        exitCode = process.ExitCode;
                    }
                }

                result = exitCode == 0;
            }
            catch (Exception e)
            {
                result = false;
                WriteLine(e.Message);
            }

            return result;
        }
    }
}
