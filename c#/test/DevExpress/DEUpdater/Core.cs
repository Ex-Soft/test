using System;
using System.Collections.Generic;
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
                string path;

                if ((path = Path.GetDirectoryName(fileName)).Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}")
                    || path.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}")
                    || path.Contains($"{Path.DirectorySeparatorChar}.vs{Path.DirectorySeparatorChar}"))
                    continue;

                WriteLine(fileName);

                string content;
                if (Array.IndexOf(appConfig.FileExtensions, Path.GetExtension(fileName)) == -1
                    || string.IsNullOrWhiteSpace(content = UpdateFileContent(fileName, appConfig))
                    || !ResetReadOnlyAttribute(fileName))
                    continue;

                WriteFileContent(fileName, content);
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
    }
}
