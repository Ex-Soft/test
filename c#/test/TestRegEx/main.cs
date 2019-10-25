//#define TEST_XML

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace TestRegEx
{
    class MatchComparer : IEqualityComparer<Match>
    {
        public bool Equals(Match x, Match y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return x.Success && y.Success && x.Value == y.Value /*&& x.Groups.Count == 2 && x.Groups.Count == y.Groups.Count && x.Groups[1].Value == y.Groups[1].Value*/;
        }

        public int GetHashCode(Match obj)
        {
            return obj.Value.GetHashCode();
        }
    }

    class Program
    {
        static string TestMatchEvaluator(Match m)
        {
            var str = m.ToString();
            var idx = str.LastIndexOf("\\");

            return idx != -1 ? str.Substring(idx + 1) : str;
        }

        static void Main(string[] args)
        {
            string
                srcString,
                tmpString = string.Empty,
                tmpStringII,
                currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location,
                fileName;

            if (currentDirectory.IndexOf("bin") != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            Regex
                r,
                r1;

            Match
                match;

            MatchCollection
                matches;

            #if TEST_XML
                if (File.Exists(fileName = Path.Combine(currentDirectory, "Chicago2.Core.ch2res")))
                {
                    srcString = File.ReadAllText(fileName);
                    r = new Regex("(?<=<Object).*<Object.*</Object>(?=</Object>)", RegexOptions.Singleline);
                    match = r.Match(srcString);
                    if (match.Success)
                        tmpString = r.Replace(srcString, string.Empty);
                }
            #endif

            r = new Regex("(?<=(^|/))([a-zA-Z]{2}_[a-zA-Z]{2})(.*)");
            srcString = "se_sv/blah-blah-blah/blah-blah-blah";
            match = r.Match(srcString);
            srcString = "blah-blah-blah/se_sv/blah-blah-blah/blah-blah-blah";
            match = r.Match(srcString);

            r = new Regex("([a-zA-Z]{2}_[a-zA-Z]{2})(.*)");
            srcString = "se_sv/blah-blah-blah/blah-blah-blah";
            match = r.Match(srcString);
            srcString = "blah-blah-blah/se_sv/blah-blah-blah/blah-blah-blah";
            match = r.Match(srcString);

            r = new Regex("(?<=(^|/))[a-zA-Z]{2}_[a-zA-Z]{2}(?=($|/))");
            srcString = "blah/se_sv/blah";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);
            srcString = "se_sv/blah";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);
            srcString = "blah/se_sv";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            r = new Regex("(\\?)(.*)(tm=)(.*)");
            srcString = "html?fid=10&tm=20&id=30";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "$1${3}1");
            srcString = "html?tm=40&id=50";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "$1${3}2");
            srcString = "html?fid=60&tm=70";
            tmpString = r.Replace(srcString, "$1${3}3");
            srcString = "html?fid=10&id=30";
            match = r.Match(srcString);
            if (!match.Success)
                tmpString = Regex.Replace(srcString, "\\?.*", string.Empty);

            srcString = "b4 *{resource:TELEPHONENUMBER}* **{resource:ADDRESS}**\r\n*{resource:OPENINGHOURS}* *{resource:}* *{resource:TELEPHONENUMBER}* after";
            r = new Regex("(?:{resource:)([^}]+?)(?:})");
            match = r.Match(srcString);
            if (match.Success)
            {
                WriteGroup(match);
                tmpString = r.Replace(srcString, "blah-blah-blah");
            }

            matches = r.Matches(srcString);
            var _matches_ = matches.OfType<Match>().Distinct(new MatchComparer());

            foreach (Match _match_ in _matches_)
            {
                if (_match_.Groups.Count != 2)
                    continue;

                srcString = Regex.Replace(srcString, _match_.Groups[0].Value, _match_.Groups[1].Value);
            }

            srcString = "depAir=LHR/LGW/STN&startDate=2018-05-15&endDate=2018-05-22";
            r = new Regex("(?<=depAir=)(LHR|LGW)(?=[^a-zA-Z])");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "CPH");

            srcString = "depAir=LHR/LGW/STN&startDate=2018-05-15&endDate=2018-05-22";
            r = new Regex("(?<=201)8(?=-\\d\\d-\\d\\d)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "9");

            srcString = "https://www.emiratesholidays.com/gb_en/tours/wildlife-and-safari";
            r = new Regex("(?<=http.*\\/)gb_en(?=\\/)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "dk_da");

            srcString = "[1st] = '1st' Or [2nd] = '2nd' Or [3rd] = '3rd' Or [4th] = '4th'";
            r = new Regex("\\[[^\\[\\]]+?]");
            matches = r.Matches(srcString);
            if (matches.Count > 0)
                tmpString = matches[0].Value;

            srcString = ".[tableName]";
            r = new Regex("(?<=\\.\\[?)[^\\[\\]]+(?=]?)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            srcString = "{\"o\":{\"p1\":\"p1\",\"io\":{\"p1\":\"p1\"},\"p2\":\"p2\"},\"p1\":\"p1\"}";
            r = new Regex("(?<=\"o\"\\s*:\\s*\\{).*?(?=})");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;
            r = new Regex("(?<=\"p1\"\\s*:\\s*\").*?(?=\")");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;
            r = new Regex("(?<=\"o\":)[^{}]*(((?'Open'\\{)[^{}]*)+((?'Close-Open'\\})[^{}]*)+)*(?(Open)(?!))(,|})");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            srcString = "<Compile Include=\"FileName.cs\"/>";
            r = new Regex("<Compile.+?Include.*?=.*?\"FileName\\.cs\".*?/{0,1}>");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "FilePacket.ExternalFiles"; //.ExternalFiles
            r = new Regex("([^.]+)(?:\\.*[^.]*)");
            match = r.Match(srcString);
            if (match.Success)
                if (match.Groups.Count == 2)
                {
                    tmpString = match.Groups[0].Value;
                    tmpStringII = match.Groups[1].Value;
                }

            r = new Regex("(?<=\\))\\\\d\\+\\\\\\.\\\\d\\+(?=\\()");
            srcString = "(?<=DevExpress\\..+?\\.v\\d+\\.\\d+.*?,\\s*Version\\s*=\\s*)\\d+\\.\\d+\\.\\d+\\.\\d+(?=[,])";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);
            srcString = "(?<=DevExpress\\..+?\\.v)\\d+\\.\\d+(?=[.,\"])";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "<Reference Include=\"DevExpress.Data.v16.2, Version = 16.2.5.0, Culture = neutral, PublicKeyToken = b88d1754d700e49a, processorArchitecture = MSIL\">";
            r = new Regex("(?<=DevExpress\\..+?\\.v\\d+\\.\\d+.*?,\\s*Version\\s*=\\s*)\\d+\\.\\d+\\.\\d+\\.\\d+(?=[,])");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            r = new Regex("(?<=DevExpress\\..+?\\.v)\\d+\\.\\d+(?=[.,\"])");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);
            srcString = "<Reference Include=\"DevExpress.Data.v16.2\">";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);
            srcString = "<Reference Include=\"DevExpress.Map.v16.2.Core, Version = 16.2.5.0, Culture = neutral, PublicKeyToken = b88d1754d700e49a, processorArchitecture = MSIL\">";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);
            srcString = "..\\..\\..\\Common\\bin\\DevExpress\\DevExpress.Data.v16.2.dll";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);
            srcString = "..\\..\\..\\Common\\bin\\DevExpress\\DevExpress.Map.v16.2.Core.dll";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "/SuP:pOrT:";
            //r = new Regex("^[\\-/](.+:)"); // "/SuP:pOrT:"
            r = new Regex("^[\\-/](.+?:)"); // "/SuP:"
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "/SuPpOrT";
            r = new Regex("^[\\-/]([^:]+)(?=$)");
            match = r.Match(srcString);
            if (match.Success)
            {
                if (match.Groups.Count == 2)
                {
                    tmpString = match.Groups[0].Value;
                    tmpStringII = match.Groups[1].Value;
                }
                tmpString = r.Replace(srcString, string.Empty);
            }

            srcString = "<PreBuildEvent>\r\n    </PreBuildEvent>";
            r = new Regex("<PreBuildEvent>\\s*\\u000d\\u000a\\s*</PreBuildEvent>");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "<Object><Object></Object></Object><Object><Object></Object></Object><Object></Object><Object></Object>";
            //srcString = "<Object></Object><Object></Object><Object></Object><Object></Object>";
            r = new Regex("(?<=<Object).*<Object.*</Object>(?=</Object>)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "_{0}_";
            r = new Regex("\\{0}");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "<property name=\"Item5\" isnull=\"true\" iskey=\"true\"><property name=\"VisibleIndex\">1</property><property name=\"ColumnEditName\" /><property name=\"OptionsFilter\" isnull=\"true\" iskey=\"true\"><property name=\"AllowFilterModeChanging\">False</property></property><property name=\"Visible\">true</property><property name=\"CanHide\">true</property><property name=\"Name\">colName</property><property name=\"FieldName\">Name</property><property name=\"Summary\" iskey=\"true\" value=\"1\"><property name=\"Item1\" isnull=\"true\" iskey=\"true\"><property name=\"Tag\" isnull=\"true\" /><property name=\"SummaryType\">Count</property><property name=\"FieldName\">Name</property><property name=\"DisplayFormat\">{0}</property></property></property></property>";
            r = new Regex("<(property)\\sname\\s*=\\s*\"Summary\".*></\\1>");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "$photofile1;$photofile2;$photofile3";
            r = new Regex("(?<=\\$photo).+?(?=(;|$))");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "f");

			srcString = ";file1;file2;file3";
			//srcString = "file1;file2;file3";

			//r = new Regex("(?<=(^;|;)).+?(?=(;|$))");		// ";f;f;f" "file1;f;f"
			//r = new Regex("(?<=(;|^;)).+?(?=(;|$))");		// ";f;f;f" "file1;f;f"

			//r = new Regex("(?<=(;|^)).+?(?=(;|$))");		// "f;f;f" "f;f;f"
			r = new Regex("(?<=(^|;)).+?(?=(;|$))");		// "f;f;f" "f;f;f"
			
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "f");

            srcString = "Фото фасада ТТ: <br>Дата/время создания фото: 2015-09-24 17:54:53$photo\\\\i-nozhenko\\exchange\\TestImageI.jpg;Фейсинг ВОДКА  ИТОГО: 215 Фото фасада ТТ: <br>Дата/время создания фото: 2015-09-24 17:54:53$photo\\\\i-nozhenko\\exchange\\TestImageI.jpg;Фейсинг ВОДКА  ИТОГО: 215";
            r = new Regex("(?<=\\$photo).+?(?=;)");
            match = r.Match(srcString);
            if (match.Success)
            {
                tmpString = match.Value;
                tmpStringII = r.Replace(srcString, "PHOTO");
                tmpStringII = r.Replace(srcString, TestMatchEvaluator);
            }

            srcString = "\\\\i-nozhenko\\exchange\\TestImageIV.jpg";
            r = new Regex("(?<=\\\\?).+?$");
            match = r.Match(srcString);
            if (match.Success)
            {
                tmpString = match.Value;
                tmpStringII = r.Replace(srcString, "");
            }

            srcString = "\\\\i-nozhenko\\exchange\\TestImageIV.jpg";
            r = new Regex("^\\\\\\\\.+?\\\\");
            match = r.Match(srcString);
            if (match.Success)
            {
                tmpString = match.Value;
                tmpStringII = r.Replace(srcString, "http://");
            }

            srcString = "http://apihub.mtproject.ru/chicago/distributors/{nodeid}/routes/{idroute}/RouteId";
            r = new Regex("https?://.+?/");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            r = new Regex(string.Format("(?<={0}).+", tmpString));
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            //srcString = "1.123456789010000";
            srcString = "1.0000";
            r = new Regex("(?<=\\.\\d+)0+$");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "123456789012";
            r = new Regex("(?<=^.{4}).*?(?=.{4}$)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "...");

            srcString = "123456789012";
            r = new Regex("(?<=^\\d{4})\\d*?(?=\\d{4}$)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "...");

            r = new Regex("(?<==\\s*\"|').*(?=\"|')");
            srcString = " = \"d:\\soft.src\\c#\\test\\ADO.NET\\FB\\test.fdb\" # blah-blah-blah";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;
            srcString = " ='d:\\soft.src\\c#\\test\\ADO.NET\\FB\\test.fdb' # blah-blah-blah";
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            //srcString = "AttrValue01";
            srcString = "ABCdeFgh";
            r = new Regex(@"(\p{Ll})(\p{Lu})", RegexOptions.Compiled);
            match = r.Match(srcString);
            WriteGroup(match);
            if (match.Success)
            {
                tmpString = r.Replace(srcString, "$1 $2");
                r1 = new Regex(@"(\p{Lu}{2})(\p{Lu}\p{Ll}{2})", RegexOptions.Compiled);
                match = r1.Match(tmpString);
                tmpStringII = r1.Replace(tmpString, "$1 $2");
            }

            srcString = "ABCde";
            r = new Regex(@"(\p{Lu}{2})(\p{Lu}\p{Ll}{2})", RegexOptions.Compiled);
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "$1 $2");

            srcString = "The number of returned rows (0) does not equal the number of row keys in the query (1)";
            r = new Regex("^The number of returned rows \\(\\d+\\) does not equal the number of row keys in the query \\(\\d+\\)$");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = srcString;

            srcString = "{\"PhotoDrawTextResult\":0,\"isAllFileExist\":true}";
            r = new Regex(String.Format("(?:\\{{\"{0}Result\":)(.*)(?:,\"isAllFileExist\":)(.*)(?:\\}})", "PhotoDrawText"));
            match = r.Match(srcString);
            if (match.Success && match.Groups.Count > 2)
            {
                tmpString = match.Groups[1].Value;
                tmpStringII = match.Groups[2].Value;
            }

            srcString = "<div class=\"page_name fl_l ta_l\" dir=\"auto\">ФИО</div>";
            r = new Regex("(?<=<div.*>).*(?=</div>)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            srcString = "##########,0.000";
            r = new Regex("(#*),0\\.0*");
            match = r.Match(srcString);
            if (match.Success)
            {
                if (match.Groups.Count > 1)
                {
                    tmpString = match.Groups[1].Value;
                    if (tmpString.Length > 9)
                        tmpString = srcString.Replace(tmpString, new string('#', 8));
                }
            }

            srcString = "{\"AddResult\":5}";
            r = new Regex("(?<=\"AddResult\":).*(?=\\})");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            srcString = "2014-03-27_14-34-35.xml";
            r = new Regex("\\d{4}-\\d{2}-\\d{2}_\\d{2}-\\d{2}-\\d{2}\\.xml");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "blah-blah-blah (1, 2, 3)";
            r = new Regex("(?<=\\()(.*)(?=\\))");
            match = r.Match(srcString);
            if (match.Success)
                srcString = r.Replace(srcString, "$1, 4, 5");

            srcString = "user id=user;password=blah";
            r = new Regex("(?<=user id=)[^;]*");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "sa");

            r = new Regex("(?<=password=)[^;]*");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "123");

            srcString = "user id = user ; password   ='blah';";
            r = new Regex("(?<=user id\\s*=\\s*).*?(?=(;|$))");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "sa");

            srcString = "user id=user;password=blah";
            r = new Regex("(?<=user id=).*(?=;)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "sa");

            r = new Regex("(?<=password=).*(?=;?)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "123");

            srcString = " \t \r \r\n \n \n\r Line#1 \r\n \n\r \r \n  \t \r \r\n \n \n\r Line#2 \r\n \n\r \r \n  \t \r \r\n \n \n\r Line#3 \r\n \n\r \r \n ";
            r = new Regex("\\s+", RegexOptions.Multiline);
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, " ").Trim();

            srcString = " < \t \r \r\n \n \n\r Line#1 \r\n \n\r \r \n  \t \r \r\n \n \n\r Line#2 \r\n \n\r \r \n  \t \r \r\n \n \n\r Line#3 \r\n \n\r \r \n > ";
            r = new Regex(tmpStringII = "^\\s*<.+>\\s*$"); // false
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "").Trim();
            r = new Regex(tmpStringII, RegexOptions.Singleline); // true
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "").Trim();
            r = new Regex(tmpStringII = "(?<=^\\s*<).+(?=>\\s*$)");  // false
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "").Trim();
            r = new Regex(tmpStringII, RegexOptions.Singleline); // true
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "").Trim();

            r = new Regex("(?<=password\\s*?=\\s*?').*?(?='\\s*?(;|$))");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "123");

            srcString = "select * from SmthTable where SmthCondition";
            r = new Regex("(?<=whe re\\x20).*");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = srcString.Insert(match.Index, "AnotherCondition and ");

            srcString = "< \t BoDy \t contentEditable \t = \t true \t >";
            r = new Regex("(?<=<\\s*?BODY)\\s*?contentEditable\\s*?=\\s*?true\\s*?(?=>)", RegexOptions.IgnoreCase);
            if (r.IsMatch(srcString))
                tmpString = r.Replace(srcString, string.Empty);
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "Сохранить изменения в объекте \"Настройка атрибутов справочников ()\"?";
            r = new Regex("(?<=.*)\\x20\\(\\)(?=\\\")");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "##########,0.00;";
            r = new Regex("(?<=.*)\\..*(?=;)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, string.Empty);

            srcString = "Currency";
            r = new Regex("(?<=.*)y$");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = r.Replace(srcString, "ies");

            srcString = "12345";
            r = new Regex("^\\d+$");
            match = r.Match(srcString);

            srcString = "'{0},{False},{281474976710657}'";
            r = new Regex("(?<=\\{).*?(?=\\},?)", RegexOptions.Multiline);
            match = r.Match(srcString);
            while (match.Success)
            {
                tmpString = match.Value;
                match = match.NextMatch();
            }

            srcString = "Сет 1 (торговые точки)";
            r = new Regex(srcString);
            match = r.Match(srcString);
            r = new Regex("(\\(|\\))");
            match = r.Match(srcString);
            if (match.Success)
            {
                r = new Regex(r.Replace(srcString, "\x5c$1"));
                match = r.Match(srcString);
            }
            r = new Regex("(\\(|\\))");
            srcString = "Сет 1 (торговые точки)";
            tmpString = r.Replace(srcString, "\x5c$1");
            srcString = "Сет 1";
            tmpString = r.Replace(srcString, "\x5c$1");

            srcString = "-c:ru-RU";
            r = new Regex("-(.+?):(.+)");
            match = r.Match(srcString);
            if (match.Success)
            {
                if (match.Groups.Count > 2)
                {
                    tmpString = match.Groups[1].Value;
                    tmpStringII = match.Groups[2].Value;
                }
            }

            tmpString = "_protected";
            tmpStringII = ".zip";
            srcString = string.Format("aaa{0}{1}", tmpString, tmpStringII);
            r = new Regex(string.Format("^.+{0}\\{1}$", tmpString, tmpStringII), RegexOptions.IgnoreCase);
            match = r.Match(srcString);

            //srcString = @"~ # % & * { } \ : < > ? / + | """;
            srcString = @"c:\photo12\2014-08-27_2014-08-26_Павлова Елена Владимировна\ТП Синергия_000069822_1.xml";
            r = new Regex(@"[~#%&*{}\\:<>?/+|""]");
            match = r.Match(srcString);
            if (match.Success)
            {
                tmpString = r.Replace(srcString, "_");
                if(srcString.Length != tmpString.Length)
                    Console.WriteLine("!match");
            }

            srcString = "4others@mail.ru";
            r = new Regex(@"^((?>[a-zA-Z\d!#$%&'*+\-/=?^_`{|}~]+\x20*|""((?=[\x01-\x7f])[^""\\]|\\[\x01-\x7f])*""\x20*)*(?<angle><))?((?!\.)(?>\.?[a-zA-Z\d!#$%&'*+\-/=?^_`{|}~]+)+|""((?=[\x01-\x7f])[^""\\]|\\[\x01-\x7f])*"")@(((?!-)[a-zA-Z\d\-]+(?<!-)\.)+[a-zA-Z]{2,}|\[(((?(?<!\[)\.)(25[0-5]|2[0-4]\d|[01]?\d?\d)){4}|[a-zA-Z\d\-]*[a-zA-Z\d]:((?=[\x01-\x7f])[^\\\[\]]|\\[\x01-\x7f])+)\])(?(angle)>)$");
            match = r.Match(srcString);
            if(match.Success)
                Console.WriteLine(match.Value);

            srcString = "Store check_ 281475007545193 - 2014-03-27 - 14_34.xml";
            r = new Regex("(\\d+) - (\\d{4})-(\\d{2})-(\\d{2}) - (\\d{2})_(\\d{2})\\.xml");
            match = r.Match(srcString);
            if (match.Success)
            {
                if(match.Groups.Count > 6)
                    tmpString = string.Format("{0} {1}{2}{3} {4}:{5}", match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value, match.Groups[5].Value, match.Groups[6].Value);
            }

            srcString = "Basic bG9naW46MQ==";
            r = new Regex("(?<=Basic\\x20).+");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = Encoding.ASCII.GetString(Convert.FromBase64String(match.Value));

            srcString = "1234_56789.xml";
            r = new Regex("(\\d+?)_(\\d+?)\\.xml");
            match = r.Match(srcString);
            if (match.Success)
            {
                if (match.Groups.Count > 2)
                    tmpString = string.Format("{0}_{1}", match.Groups[1].Value, match.Groups[2].Value);
            }

            const string
                HtmlBodyBegin = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">\r\n<HTML><HEAD>\r\n<META content=\"text/html; charset=windows-1251\" http-equiv=Content-Type>\r\n<META name=GENERATOR content=\"MSHTML 10.00.9200.16660\"></HEAD>\r\n<BODY contentEditable=true>",
                HtmlBodyEnd = "</BODY></HTML>\r\n",
                ImgSrcBegin = "<P><IMG\\s*?src=\"",
                ImgSrcEnd = "\"></P>",
                DescriptionFormat = "\r\n<P>{0}</P>",
                ImageFormat = "\r\n<P><IMG \r\nsrc=\"{0}\"></P>";

            srcString = string.Format("{0}{1}{2}{3}", HtmlBodyBegin, string.Format(DescriptionFormat, "blah-blah-blah"), string.Format(ImageFormat, "blah-blah-blah"), HtmlBodyEnd);
            r = new Regex(string.Format("(?<={0}).*?(?={1})", HtmlBodyBegin, HtmlBodyEnd), RegexOptions.Singleline);
            match = r.Match(srcString);
            if (match.Success)
            {
                srcString = match.Value;
                r = new Regex(string.Format("(?<={0}).*?(?={1})", ImgSrcBegin, ImgSrcEnd));
                match = r.Match(srcString);
                if (match.Success)
                    srcString = srcString.Remove(match.Index - ImgSrcBegin.Length + 1, match.Length + ImgSrcBegin.Length + ImgSrcEnd.Length - 1 );
            }

            srcString = "Part1\\Part2";
            r = new Regex("[\\\\/?*[\\]]");
            match = r.Match(srcString);
            if (match.Success)
            {
                tmpString = match.Value;
                srcString = srcString.Substring(0, match.Index);
            }

            srcString = "111-11-11";
            r = new Regex("\\d{4}-\\d{2}-\\d{2}");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            srcString = "\\1blah-blah-blah\\2 \\3 blah-blah-blah \\4 \\123 blah-blah-blah \\321 \\ \\blah-blah-blah";
            tmpString = Regex.Escape(srcString);

            srcString = "\\1blah-blah-blah\\2 \\3 blah-blah-blah \\4 \\123 blah-blah-blah \\321 \\ \\blah-blah-blah";
            //srcString = tmpString;
            try
            {
                tmpString = Regex.Replace("blah-blah-blah", srcString, string.Empty, RegexOptions.IgnoreCase);
            }
            catch (ArgumentException e)
            {
                tmpString = string.Empty;
            }

            r = new Regex(@"\\(\d+?)");
            srcString = r.Replace(srcString, "\\\\$1");
            try
            {
                tmpString = Regex.Replace("blah-blah-blah", srcString, string.Empty, RegexOptions.IgnoreCase);
            }
            catch (ArgumentException e)
            {
                tmpString = string.Empty;
            }

            tmpString = "УЛ. ЛЕНИНА 68\\1";
            tmpString = r.Replace(tmpString, "\\\\$1");
            srcString = Regex.Replace("6586СРЕДНИЙ0, Алтайский край, Завьяловский р-н, Завьялово с, Яковлева ул, дом № 53, корпус 1", tmpString, "ЛЕНИНА", RegexOptions.IgnoreCase);

            srcString = "15.000.0000.000";
            r=new Regex(@"^\d*");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            r = new Regex(@"^(\d*)\..*$");
            match = r.Match(srcString);
            if (match.Success)
            {
                tmpString = match.Value;

                if (match.Groups.Count > 1)
                    tmpString = match.Groups[1].Value;
            }

            srcString = "<property name=\"Text\"></property>";
            r = new Regex("(?<=<property name=\"Text\">).*?(?=</property>)");
            match = r.Match(srcString);
            if (match.Success)
                tmpString = match.Value;

            tmpString = "Connection Timeout";
            r = new Regex(string.Format(@"(?<={0}=)\d*?(?=[^\d])", tmpString));
            srcString = string.Format("blah-blah-blah ; {0} =  1000  ; blah-blah-blah", tmpString);
            match = r.Match(srcString);
            if(match.Success)
                tmpString = r.Replace(srcString, "0001");

            srcString = "<ul><p>one</p><p>two</p></ul><ul><p>three</p></ul>";
            r = new Regex(@"(?<=<ul>)<p>.*?<\/p>(?=<\/ul>)");
            tmpString = r.Replace(srcString, "");

            r = new Regex(@"(?<=<ul>)<p>.*?(?=<\/ul>)");
            tmpString = r.Replace(srcString, string.Empty);

            tmpString = r.Replace(srcString, m =>
                                                 {
                                                     Regex
                                                         _r_ = new Regex(@"(<p>|<\/p>)");

                                                     return _r_.Replace(m.Value, string.Empty);
                                                 });

            r = new Regex(@"(?<=<ul>)(<p>)(.*?)(<\/p>)(?=<\/ul>)");
            match = r.Match(srcString);
            tmpString = r.Replace(srcString, string.Empty);

            srcString = "[не выбрано]";
            r = new Regex(@"\[?не выбрано\]?");
            match = r.Match(srcString);
            if(match.Success)
            {
                match = null;
                match = r.Match(srcString);
            }

            srcString = @"[{""BirthDate"":""\\/Date(1345667609687)\\/""},{""BirthDate"":""\\/Date(1345667609687)\\/""}]";
            r = new Regex(@"("")(\\\\)(\/Date\(\d+\))(\\\\)(\/"")");
            //match = r.Match(srcString);
            tmpString = r.Replace(srcString, @"$1\$3\$5");

            srcString = "Ext.define(\"AAA.BBB.CCC\", { \r\n requires \r\n : \r\n [ \r\n \"One\" , \r\n \"Two\" , \"Three\" , \"Four\" \r\n ] \r\n } );";
            r = new Regex("(requires\\s*?:\\s*?\\[)((\\s*?.*?\\s*?)*?)(?=])", RegexOptions.Multiline);
            match = r.Match(srcString);

            srcString = "{i:1; i:2; i   :   5741 ; }";
            r = new Regex("(?<=i\\s*:\\s*)\\d+(?=\\s*;\\s*})");
            match = r.Match(srcString);
            tmpString = match.Success ? match.Value.Trim() : string.Empty;

            srcString = " \t1\t2 3\t ";
            r = new Regex("[\t]");
            tmpString = r.Replace(srcString, "");

            try
            {
                srcString = null;
                r = new Regex("blah-blah-blah");
                match = r.Match(srcString);
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            srcString = "Line# 1\r\nLine# 2\r\nLine# 3";
            r=new Regex("^.*?$",RegexOptions.Multiline);
            match = r.Match(srcString);
            tmpString = match.Success ? match.Value.Trim() : string.Empty;
            srcString = "Line# 1";
            match = r.Match(srcString);
            tmpString = match.Success ? match.Value.Trim() : string.Empty;

            srcString = "<span><a href=\"http://nozhenko-s8k/DocNet/DnLists/WorkflowTasks/DispForm.aspx?ID=17\">Перейти до задачі.</a></span>";
            r = new Regex("(?<=<a href=\".*?\">).*?(?=</a>)");
            tmpString = r.Replace(srcString, "Забить на задачу.");

            r = new Regex(string.Format(@"(?<={0}\\){1}", "\\\\dsdsdsd".Replace("\\","\\\\"), "Test"), RegexOptions.IgnoreCase);

            srcString = "Received: from jira.softline.main (10.3.0.127) by CASHTX1.softline.main\r\n (10.3.7.33) with Microsoft SMTP Server id 14.1.218.12; Thu, 24 Nov 2011\r\n 13:06:04 +0200\r\nDate: Thu, 24 Nov 2011 13:06:04 +0200\r\nFrom: =?UTF-8?B?0JLQvtC70L7RiNC40L0g0J/QsNCy0LXQuyAoSklSQSk=?=\r\n\t<noreply@softline.kiev.ua>\r\nTo: <nozhenko@inbase.com.ua>\r\nMessage-ID: <1027660168.5721.1322132764306.JavaMail.www@jira.softline.main>\r\nIn-Reply-To: <620399879.5720.1322132764078.JavaMail.www@jira.softline.main>\r\nSubject: =?UTF-8?Q?[JIRA]_Assigned:_(TBADOCNET-52)_=D0=BD?=\r\n =?UTF-8?Q?=D0=B5=D0=BE=D0=B1=D1=85=D0=BE=D0=B4=D0=B8=D0=BC?=\r\n =?UTF-8?B?W0pJUkFdIFVwZGF0ZWQ6IChUQkFET0NORVQtOTMpIA==?=\r\n =?UTF-8?B?0JTQvtCx0LDQstC40YLRjCDQsiDQvdCw0YfQsNC7?=\r\n =?UTF-8?B?0YzQvdC+0LUg0LfQsNC/0L7Qu9C90LXQvdC40LUg?=\r\n =?UTF-8?B?0YHQv9GA0LDQstC+0YfQvdC40LrQsCAi0KHQvw==?=\r\n =?UTF-8?B?0YDQsNCy0L7Rh9C90LjQutC4IiDRgdGB0YvQu9C6?=\r\n =?UTF-8?B?0YMg0L3QsCDRgdC/0YDQsNCy0L7Rh9C90LjQuiA=?=\r\n =?UTF-8?B?ItCi0LjQv9GLINC+0LHRgNCw0YnQtdC90LjQuSI=?=\r\nMIME-Version: 1.0\r\nContent-Type: text/plain; charset=\"UTF-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\nPrecedence: bulk\r\nAuto-Submitted: auto-generated\r\nX-JIRA-FingerPrint: 295bf32b405fea2c10ac335661ebb519\r\nReturn-Path: noreply@softline.kiev.ua\r\nX-MS-Exchange-Organization-AuthSource: CASHTX1.softline.main\r\nX-MS-Exchange-Organization-AuthAs: Anonymous\r\n";
            r = new Regex("(?<=From:.*?<).*?(?=>)",RegexOptions.Singleline|RegexOptions.IgnoreCase);
            match = r.Match(srcString);
            tmpString = match.Success ? match.Value.Trim() : string.Empty;

            r = new Regex("(?<=^X-JIRA-FingerPrint:\\s).*?(?=$)", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            match = r.Match(srcString);
            tmpString = match.Success ? match.Value.Trim() : string.Empty;

            r = new Regex("(?<=^Subject:.*?)Assigned(?=.*?$)", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            match = r.Match(srcString);
            tmpString = match.Success ? match.Value.Trim() : string.Empty;

            srcString = "ClosingDocExecutorsDontExist(ClosingDocExecutorsDontExist) : Неможливо відправити чорнетку в обробку, тому що в маршруті документу не вказані наступні виконавці резолюції документу, що закривається: Дідіченко, Попович ";
            r = new Regex("(?<=[A-Za-z\\d()]+ : ).*");
            match = r.Match(srcString);
            tmpString = match.Success ? match.Value.Trim() : string.Empty;

            r = new Regex("([A-Za-z\\d() :]+)(.*)");
            match = r.Match(srcString);
            tmpString = match.Groups!=null && match.Groups.Count>2 ? match.Groups[2].Value.Trim() : string.Empty;
            WriteGroup(match);

            r = new Regex("Save\\(\\d+\\) finished");
            tmpString = "12121 Save(12345) finished 12121";
            match = r.Match(tmpString);

            r = new Regex("\\d+");
            tmpString = "InputFile";
            match = r.Match(tmpString);
            tmpString = "InputFile2011";
            match = r.Match(tmpString);
            if (match.Success)
                tmpString = match.Value;

            r = new Regex("(</[a-z]+>)");
            tmpString = "1<a>2<b>3</c>4</d>5 <e>6<f>7</g>8</h>9  <e></e>";
            match = r.Match(tmpString);
            WriteGroup(match);
            tmpString = r.Replace(tmpString, "$1!$2");

            r = new Regex("[\\D]");
            tmpString = "+380(67)123-45-67";
            tmpString = r.Replace(tmpString, "");

            tmpString = "\\.";
            tmpString = Regex.IsMatch("12345.678", tmpString, RegexOptions.IgnoreCase).ToString().ToLower();
            tmpString = "\\.";
            tmpString = Regex.IsMatch("12345678", tmpString, RegexOptions.IgnoreCase).ToString().ToLower();

            tmpString = "123456.789";
            //tmpString="123456,789";
            //tmpString="123456-789";
            r = new Regex("[.,-]");
            if (r.IsMatch(tmpString))
            {
                match = r.Match(tmpString);
                while (match.Success)
                {
                    tmpString = match.Index.ToString();
                    match = match.NextMatch();
                }
            }

            tmpString = "<span id=\"Span1\"></span><span id=\"Span22\"></span><span id=\"Span333\"></span>";

            r = new Regex("<span.*?>", RegexOptions.IgnoreCase);
            tmpString = "Smth One car Smth Red car Smth Blue car";
            r = new Regex(@"(\w+)\s+(car)", RegexOptions.IgnoreCase);
            r = new Regex(@"((\w+\s+)car)", RegexOptions.IgnoreCase);
            match = r.Match(tmpString);
            WriteGroup(match);

            MatchCollection
                matchcollection = r.Matches(tmpString);

            Console.WriteLine("MatchCollection.Count: " + matchcollection.Count);

            tmpString = "<html><head><title>bla-bla-bla</title></head><body></body></html>";
            r = new Regex("<title>.*</title>");
            tmpString = r.Replace(tmpString, "<TITLE>BLA-BLA-BLA</TITLE>");

            tmpString = "1st 2nd 3rd 4th";
            r = new Regex("\\s");
            tmpString = r.Replace(tmpString, "<br />");

            tmpString = "blah-blah-blah {0} blah-blah-blah {1} blah-blah-blah {2}{3}";
            //r = new Regex("{\\d+}");
            //r = new Regex("\\{\\d+\\}");
            //r = new Regex("\\x7b\\d+\\x7d");
            r = new Regex("\\u007b\\d+\\u007d");
            match = r.Match(tmpString);
            WriteGroup(match);

            tmpString = "<a id=\"SmthId\" href=\"blah-blah-blah\" class=\"SmthCSSClass\">blah-blah-blah</a> <a id=\"SmthId\" href=\"blah-blah-blah\" class=\"SmthCSSClass\">blah-blah-blah</a>";
            r = new Regex("(?<=href=['\"]).+?(?=['\"])");
            match = r.Match(tmpString);
            WriteGroup(match);

            tmpString = "sdfsd sdf \"P.P.U.H. \"COLD\" Sp.J.\" sdfsdfs sdfsd \"AAABBB\" sdfsdfsd";
            r = new Regex("(?<=\").*?\".+?\".*?(?=\")");
            //r = new Regex("(?<=\").*?(?=\")");
            match = r.Match(tmpString);
            WriteGroup(match);

            tmpString = "<b title=\"test\">test</b>";
            r = new Regex("(?<=>)test(?=<)");
            tmpString = r.Replace(tmpString, "");

            tmpString = "sadasdas123456789.12234455dasdasdas s9.12as s9as s9.as s.12as";
            r = new Regex("(?<=[\\D])\\d*?\\.\\d*?(?=[\\D])");
            match = r.Match(tmpString);
            WriteGroup(match);

            tmpString = "Внимание! Используйте следующие рекомендации Сайт - такой то, вариант такой то [5]";
            r = new Regex("(?<=\\[)\\d+?(?=\\])");
            match = r.Match(tmpString);
            WriteGroup(match);

            tmpString = "<a href=\"?tur=1111111111&hash=2222222222\"><img src=\"turing.inc.php?tur=40404040404040\" border=0></a><a href=\"?tur=3333333333&hash=4444444444\"><img src=\"turing.inc.php?tur=50505050505050\" border=0></a>";
            r = new Regex("<a href=\"\\?tur=(\\d+?)&hash=(\\d+?)\"><img src=\"turing.inc.php\\?tur=(\\d+?)\".*?></a>");
            match = r.Match(tmpString);
            WriteGroup(match);

            tmpString = "<html><div class=\"olol\">блаблабла</div><div class=\"olol\">блаблабла</div></html>";
            r = new Regex("(?<=<div.*?>)(.*?)(?=<\\/div>)", RegexOptions.IgnoreCase);
            tmpString = r.Replace(tmpString, /*"blah-blah-blah"*/ "$1<img src=\"http://www.sql.ru/forum/images/smoke.gif\">");

            tmpString = "<html><div class=\"olol\">блаблабла</div><div class=\"olol\">блаблабла</div></html>";
            r = new Regex("(<div.*?>)(.*?)(?=<\\/div>)", RegexOptions.IgnoreCase);
            tmpString = r.Replace(tmpString, /*"blah-blah-blah"*/ "$1$2<img src=\"http://www.sql.ru/forum/images/smoke.gif\">");
        }

        static void WriteGroup(Match match)
        {
            while (match.Success)
            {
                Console.WriteLine("Match.Index: " + match.Index);
                Console.WriteLine("Match.Length: " + match.Length);
                Console.WriteLine("Match.Value: " + match.Value);

                Console.WriteLine($"Match.Captures.Count: {match.Captures.Count}");
                for (int i = 0; i < match.Captures.Count; ++i)
                {
                    Console.WriteLine($"Match.Captures[{i}].Index: {match.Captures[i].Index}");
                    Console.WriteLine($"Match.Captures[{i}].Length: {match.Captures[i].Length}");
                    Console.WriteLine($"Match.Captures[{i}].Value: {match.Captures[i].Value}");
                }

                Console.WriteLine($"Match.Groups.Count: {match.Groups.Count}");
                for (int i = 0; i < match.Groups.Count; ++i)
                {
                    Console.WriteLine($"Match.Groups[{i}].Index: {match.Groups[i].Index}");
                    Console.WriteLine($"Match.Groups[{i}].Length: {match.Groups[i].Length}");
                    Console.WriteLine($"Match.Groups[{i}].Value: {match.Groups[i].Value}");
                    Console.WriteLine($"Match.Groups[{i}].Success: {match.Groups[i].Success}");

                    Console.WriteLine($"\tMatch.Groups[{i}].Captures.Count: {match.Groups[i].Captures.Count}");
                    for (int _ii_ = 0; _ii_ < match.Groups[i].Captures.Count; ++_ii_)
                    {
                        Console.WriteLine($"\tMatch.Groups[{i}].Captures[{_ii_}].Index: {match.Groups[i].Captures[_ii_].Index}");
                        Console.WriteLine($"\tMatch.Groups[{i}].Captures[{_ii_}].Length: {match.Groups[i].Captures[_ii_].Length}");
                        Console.WriteLine($"\tMatch.Groups[{i}].Captures[{_ii_}].Value: {match.Groups[i].Captures[_ii_].Value}");
                    }
                }
                Console.WriteLine();
                match = match.NextMatch();
            }
        }
    }
}
