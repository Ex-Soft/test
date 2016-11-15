#define TEST_DE_SETTINGS
//#define TEST_XLS_AKA_XML

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TestLINQ2XML
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (currentDirectory.IndexOf("bin") != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            string
                //fileName = currentDirectory + "test.xml",
                //fileName = currentDirectory + "50-3.xls",
                //fileName = currentDirectory + "100.xls",
                fileName = currentDirectory + "DESettingsWithSummary.xml",
                regexPattern = "^\\d+$";

            if (!File.Exists(fileName))
                return;

            try
            {
                XElement xElement;
                IEnumerable<XElement> childList;
                long tmpLong;

                #if TEST_XLS_AKA_XML
                    xElement = XElement.Load(fileName);
                    XNamespace ns = "urn:schemas-microsoft-com:office:spreadsheet";

                    string
                        IicColumnName = "Открытый номер карты",
                        PhoneColumnName = "Телефон";

                    var positions = xElement.Elements(ns + "Worksheet").Elements(ns + "Table").Elements(ns + "Row")
                        .Where(row =>
                            row.Elements(ns + "Cell").Any(cell => cell.Elements(ns + "Data").FirstOrDefault() != null && cell.Elements(ns + "Data").FirstOrDefault().Value == IicColumnName)
                            && row.Elements(ns + "Cell").Any(cell => cell.Elements(ns + "Data").FirstOrDefault() != null && cell.Elements(ns + "Data").FirstOrDefault().Value == PhoneColumnName))
                        .SelectMany(row => row.Elements(ns + "Cell").Where(cell => cell.Elements(ns + "Data").FirstOrDefault() != null && (cell.Elements(ns + "Data").FirstOrDefault().Value == IicColumnName || cell.Elements(ns + "Data").FirstOrDefault().Value == PhoneColumnName)).Select(cell => new { ColumnName = cell.Elements(ns + "Data").FirstOrDefault().Value, Position = cell.NodesBeforeSelf().Count() }))
                        .ToDictionary(item => item.ColumnName);

                    var headerRow = xElement.Elements(ns + "Worksheet").Elements(ns + "Table").Elements(ns + "Row")
                        .Where(row => 
                            row.Elements(ns + "Cell").Any(cell => cell.Elements(ns + "Data").FirstOrDefault() != null && cell.Elements(ns + "Data").FirstOrDefault().Value == "Открытый номер карты")
                            && row.Elements(ns + "Cell").Any(cell => cell.Elements(ns + "Data").FirstOrDefault() != null && cell.Elements(ns + "Data").FirstOrDefault().Value == "Телефон"))
                        .ToList();

                    int
                        posIic = 0,
                        posPhone = 0,
                        maxPos = 0;

                    if (headerRow.Count > 0)
                    {
                        foreach (var cell in headerRow.Elements(ns + "Cell"))
                        {
                            var data = cell.Elements(ns + "Data").FirstOrDefault();

                            if (data == null || (data.Value != "Открытый номер карты" && data.Value != "Телефон"))
                                continue;

                            if(data.Value == "Открытый номер карты")
                                posIic = cell.NodesBeforeSelf().Count();

                            if (data.Value == "Телефон")
                                posPhone = cell.NodesBeforeSelf().Count();
                        }
                    }

                    maxPos = posIic >= posPhone ? posIic : posPhone;

                    var rows = xElement.Elements(ns + "Worksheet").Elements(ns + "Table").Elements(ns + "Row")
                        .Where(row => 
                            row.Elements(ns + "Cell").Count() >= maxPos
                            && row.Elements(ns + "Cell").ElementAt(posIic).Elements(ns + "Data").FirstOrDefault() != null
                            && row.Elements(ns + "Cell").ElementAt(posPhone).Elements(ns + "Data").FirstOrDefault() != null
                            && Regex.IsMatch(row.Elements(ns + "Cell").ElementAt(posIic).Elements(ns + "Data").FirstOrDefault().Value, regexPattern)
                            && Regex.IsMatch(row.Elements(ns + "Cell").ElementAt(posPhone).Elements(ns + "Data").FirstOrDefault().Value, regexPattern)
                        )
                        .Select(row => new { ICC = row.Elements(ns + "Cell").ElementAt(posIic).Elements(ns + "Data").FirstOrDefault().Value, Phone = row.Elements(ns + "Cell").ElementAt(posPhone).Elements(ns + "Data").FirstOrDefault().Value })
                        .ToList();

                    var list = xElement.Elements(ns + "Worksheet").Elements(ns + "Table").Elements(ns + "Row")
                                .Where(row =>
                                    row.Elements(ns + "Cell").FirstOrDefault(cell => (string)cell.Attribute(ns + "Index") == "5") != null
                                    && row.Elements(ns + "Cell").FirstOrDefault(cell => (string)cell.Attribute(ns + "Index") == "18") != null
                                    && row.Elements(ns + "Cell").FirstOrDefault(cell => (string)cell.Attribute(ns + "Index") == "5").Elements(ns + "Data").FirstOrDefault() != null
                                    && row.Elements(ns + "Cell").FirstOrDefault(cell => (string)cell.Attribute(ns + "Index") == "18").Elements(ns + "Data").FirstOrDefault() != null
                                    && Regex.IsMatch(row.Elements(ns + "Cell").FirstOrDefault(cell => (string)cell.Attribute(ns + "Index") == "5").Elements(ns + "Data").FirstOrDefault().Value, regexPattern)
                                    && Regex.IsMatch(row.Elements(ns + "Cell").FirstOrDefault(cell => (string)cell.Attribute(ns + "Index") == "18").Elements(ns + "Data").FirstOrDefault().Value, regexPattern)
                                )
                                .Select(row => new { ICC = row.Elements(ns + "Cell").FirstOrDefault(cell => (string)cell.Attribute(ns + "Index") == "5").Elements(ns + "Data").FirstOrDefault().Value, Phone = row.Elements(ns + "Cell").FirstOrDefault(cell => (string)cell.Attribute(ns + "Index") == "18").Elements(ns + "Data").FirstOrDefault().Value }).ToList();

                    foreach (var item in list)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    Console.WriteLine();

                    childList = from el in xElement.Elements() select el;
                    foreach (var _xElement_ in childList)
                    {
                        Console.WriteLine(_xElement_.ToString());
                    }
                    Console.WriteLine();

                    childList = from el in xElement.Elements(ns + "Worksheet") select el;
                    foreach (var _xElement_ in childList)
                    {
                        Console.WriteLine(_xElement_.ToString());
                    }
                    Console.WriteLine();

                    childList = from el in xElement.Elements(ns + "Worksheet").Elements(ns + "Table") select el;
                    foreach (var _xElement_ in childList)
                    {
                        Console.WriteLine(_xElement_.ToString());
                    }
                    Console.WriteLine();

                    childList = from el in xElement.Elements(ns + "Worksheet").Elements(ns + "Table").Elements(ns + "Row") select el;
                    foreach (var _xElement_ in childList)
                    {
                        Console.WriteLine(_xElement_.ToString());
                    }
                    Console.WriteLine();

                    childList = from row in xElement.Elements(ns + "Worksheet").Elements(ns + "Table").Elements(ns + "Row")
                                where
                                (
                                    from cell in row.Elements(ns + "Cell")
                                    where
                                        (string)cell.Attribute(ns + "Index") == "5"
                                    select cell
                                ).Any()
                                select row;
                    foreach (var _xElement_ in childList)
                    {
                        Console.WriteLine(_xElement_.ToString());
                    }
                    Console.WriteLine();
                #endif

                xElement = XElement.Load(fileName);
                childList = from el in xElement.Elements() select el;

                #if TEST_DE_SETTINGS
                    var summaries = xElement.Elements("property").FirstOrDefault(p => p.Attribute("name").Value == "Columns").Elements().Where(c => c.Elements().FirstOrDefault(e => e.Attribute("name").Value == "Summary") != null).Select(s => s.Elements().FirstOrDefault(e => e.Attribute("name").Value == "Summary")).ToArray();
                    foreach(var summary in summaries)
                        summary.Remove();

                    if (File.Exists(fileName = Path.Combine(Path.GetDirectoryName(fileName) ,Path.GetFileNameWithoutExtension(fileName) + ".out.xml")))
                        File.Delete(fileName);

                    xElement.Save(fileName);
                #endif

                foreach (var _xElement_ in childList)
                {
                    Console.WriteLine(_xElement_.ToString());
                }
                Console.WriteLine();

                childList = from el in xElement.Elements("rows") select el;
                foreach (var _xElement_ in childList)
                {
                    Console.WriteLine(_xElement_.ToString());
                }
                Console.WriteLine();
                
                childList = from el in xElement.Elements("rows").Elements("row") select el;
                foreach (var _xElement_ in childList)
                {
                    Console.WriteLine(_xElement_.ToString());
                }
                Console.WriteLine();

                childList = from el in xElement.Descendants("row") select el;
                foreach (var _xElement_ in childList)
                {
                    Console.WriteLine(_xElement_.ToString());
                }
                Console.WriteLine();

                childList = from row in xElement.Elements("rows").Elements("row")
                            where
                            (
                                from cell in row.Elements("cell")
                                where
                                    (string)cell.Attribute("index") == "0"
                                select cell
                            ).Any()
                            &&
                            (
                                from cell in row.Elements("cell")
                                where
                                    (string)cell.Attribute("index") == "1"
                                select cell
                            ).Any()
                            select row;
                foreach (var _xElement_ in childList)
                {
                    Console.WriteLine(_xElement_.ToString());
                }
                Console.WriteLine();

                var t = childList.Select(r => new { c0 = r.Elements("cell").FirstOrDefault(c => (string)c.Attribute("index") == "0").Value, c1 = r.Elements("cell").FirstOrDefault(c => (string)c.Attribute("index") == "1").Value });

                foreach (var v in t)
                {
                    Console.WriteLine(v);
                }
                Console.WriteLine();

                var tt =
                    xElement.Elements("rows")
                            .Elements("row")
                            .Where(
                                row =>
                                    row.Elements("cell").FirstOrDefault(cell => (string)cell.Attribute("index") == "0") != null
                                    && row.Elements("cell").FirstOrDefault(cell => (string)cell.Attribute("index") == "1") != null)
                            .Select(r => new { c0 = r.Elements("cell").FirstOrDefault(c => (string)c.Attribute("index") == "0").Value, c1 = r.Elements("cell").FirstOrDefault(c => (string)c.Attribute("index") == "1").Value });

                foreach (var vv in tt)
                {
                    Console.WriteLine(vv);
                }
                Console.WriteLine();

                foreach (var vvv in tt.Where(r => !string.IsNullOrWhiteSpace(r.c0) && !string.IsNullOrWhiteSpace(r.c1) && long.TryParse(r.c0, out tmpLong) && long.TryParse(r.c1, out tmpLong)))
                {
                    Console.WriteLine(vvv);
                }
                Console.WriteLine();

                childList = from row in xElement.Elements("rows").Elements("row")
                            where
                            (
                                from cell in row.Elements("cell")
                                where
                                    (string)cell.Attribute("index") == "0"
                                    || (string)cell.Attribute("index") == "1"
                                select cell
                            ).Count() == 2
                            select row;
                foreach (var _xElement_ in childList)
                {
                    Console.WriteLine(_xElement_.ToString());
                }
                Console.WriteLine();

                XDocument xDocument = XDocument.Load(fileName);

                childList = from el in xDocument.Elements() select el;
                foreach (var _xElement_ in childList)
                {
                    Console.WriteLine(_xElement_.ToString());
                }
                Console.WriteLine();
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
