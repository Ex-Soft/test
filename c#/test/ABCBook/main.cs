#define TEST_CONVERT
//#define TEST_STRING
//#define TEST_XML
//#define TEST_MIN_MAX
//#define TEST_NULLABLE_TYPES
//#define TEST_LIST

using System;
#if TEST_LIST || TEST_MIN_MAX
	using System.Collections.Generic;
#endif
using System.Configuration;
#if TEST_CONVERT
    using System.Globalization;
#endif
using System.IO;
using System.Reflection;
#if TEST_XML
	using System.Xml;
#endif

namespace ABCBook
{
    class ClassMain
	{
		#if TEST_MIN_MAX
		static T? Max<T>(IEnumerable<T> values)
			where T : struct, IComparable<T>
		{
			return MinMaxImpl(values, delegate(T left, T right)
				{ return right.CompareTo(left); });
		}

		static T? Min<T>(IEnumerable<T> values)
			where T : struct, IComparable<T>
		{
			return MinMaxImpl(values, delegate(T left, T right)
				{ return left.CompareTo(right); });
		}

		static T? MinMaxImpl<T>(IEnumerable<T> values, Comparison<T> comparison)
			where T : struct, IComparable<T>
		{
			T? v = null;

			foreach (T value in values)
				if (v == null || comparison(v.Value, value) > 0)
					v = value;

			return v;
		}
		#endif

		public static int Main(string[] args)
        {
            int
                Result = 0;

			StreamWriter
				fstr_out = null;

			try
			{
				try
				{
					string
						tmpString = "log.log";

					int
						i,
                        tmpInt;

					decimal
						tmpDecimal;

					double
						tmpDouble;

				    object
				        tmpObject;

					fstr_out = new StreamWriter(tmpString, false, System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush = true;

					string
						StartupPath = Assembly.GetExecutingAssembly().Location,
						Root = Path.GetPathRoot(StartupPath);

					Configuration
						cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

					AppSettingsSection
						appCfg = cfg.AppSettings;

					//cfg = ConfigurationManager.OpenExeConfiguration(System.AppDomain.CurrentDomain.BaseDirectory[0]+":\\Soft.src\\C#\\ReadFile\\bin\\Debug\\ReadFile.exe");
					cfg = ConfigurationManager.OpenExeConfiguration(Root + "Soft.src\\C#\\ReadFile\\bin\\Debug\\ReadFile.exe");
					appCfg = cfg.AppSettings;

					cfg = ConfigurationManager.OpenMachineConfiguration();
					appCfg = cfg.AppSettings;

					#if TEST_XML
						try
						{
							XmlDocument
								doc = new XmlDocument();

							XmlNode
								node = doc.CreateXmlDeclaration("1.0", "windows-1251", null),
								nnode;

							doc.AppendChild(node);

							XmlProcessingInstruction
								_pi_ = doc.CreateProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"data.xsl\"");

							doc.AppendChild(_pi_);

							node = doc.CreateElement("contract");
							node.Attributes.Append(doc.CreateAttribute("xmlns"));
							node.Attributes["xmlns"].Value = "http://localhost/contract";
							node.Attributes.Append(doc.CreateAttribute("xmlns:othersperson"));
							node.Attributes["xmlns:othersperson"].Value = "http://localhost/othersperson";
							doc.AppendChild(node);

							node = doc.CreateElement("contragent");
							node.AppendChild(doc.CreateTextNode("Иванов Иван Иванович"));
							doc.DocumentElement.AppendChild(node);

							node = doc.CreateElement("date");
							node.AppendChild(doc.CreateTextNode("2009.03.11"));
							doc.DocumentElement.AppendChild(node);

							node = doc.CreateElement("no");
							node.AppendChild(doc.CreateTextNode("13"));
							doc.DocumentElement.AppendChild(node);

							node = doc.CreateElement("othersperson:othersperson");

							nnode = doc.CreateElement("othersperson:contragent");
							nnode.Attributes.Append(doc.CreateAttribute("othersperson:date"));
							nnode.Attributes["othersperson:date"].Value = "1870.04.22";
							nnode.AppendChild(doc.CreateTextNode("Ленин Владимир Ильич"));
							node.AppendChild(nnode);

							nnode = doc.CreateElement("othersperson:contragent");
							nnode.Attributes.Append(doc.CreateAttribute("othersperson:date"));
							nnode.Attributes["othersperson:date"].Value = "1878.12.18";
							nnode.AppendChild(doc.CreateTextNode("Сталин Иосиф Виссарионович"));
							node.AppendChild(nnode);

							nnode = doc.CreateElement("othersperson:contragent");
							nnode.Attributes.Append(doc.CreateAttribute("othersperson:date"));
							nnode.Attributes["othersperson:date"].Value = "1894.04.17";
							nnode.AppendChild(doc.CreateTextNode("Хрущев Никита Сергеевич"));
							node.AppendChild(nnode);

							doc.DocumentElement.AppendChild(node);

							tmpString = "data.xml";
							if (File.Exists(tmpString))
								File.Delete(tmpString);

							doc.Save(tmpString);
						}
						catch (Exception eException)
						{
							throw (new Exception(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace));
						}
					#endif

					#if TEST_LIST
						int[]
							arr = { 15, 13, 12, 11, 10, 7, 6, 5, 4, 3, 2, 1 };

						List<int>
							full=new List<int>();

						for(i=arr.Min(); i<arr.Max(); ++i) // FW 3.0 ???
							full.Add(i);

						int[]
							nonExists = full.Except(arr).ToArray(); // FW 3.0 ???
					#endif

					#if TEST_NULLABLE_TYPES
					int?
						i_nullable = null,
						y_nullable;

					tmpString = i_nullable.HasValue.ToString().ToLower(); // false
					//tmpString = y_nullable.HasValue.ToString().ToLower(); // Error: Use of unassigned local variable 'y_nullable'

					i = i_nullable ?? int.MinValue; // int.MinValue
					i = i_nullable ?? default(int); // 0
					i = i_nullable.GetValueOrDefault(); // 0
					if (i_nullable.HasValue)
						i = i_nullable.Value;

					//i = y_nullable ?? int.MinValue; // Error: Use of unassigned local variable 'y_nullable'
					//i = y_nullable ?? default(int); // Error: Use of unassigned local variable 'y_nullable'
					//i = y_nullable.GetValueOrDefault(); // Error: Use of unassigned local variable 'y_nullable'

					i_nullable = 123456789;
					tmpString = i_nullable.HasValue.ToString().ToLower(); // true
					i = i_nullable ?? int.MinValue;
					i = i_nullable ?? default(int);
					i = i_nullable.GetValueOrDefault();
					if (i_nullable.HasValue)
						i = i_nullable.Value;

				    i_nullable = null;
				    i = 10;
				    tmpInt = i + i_nullable ?? 0;
				    tmpInt = i_nullable ?? 0 + i;
                    tmpInt = i + (i_nullable ?? 0);
                    tmpInt = (i_nullable ?? 0) + i;
				    tmpObject = i + i_nullable;
                    #endif

					#if TEST_MIN_MAX
					int[] values = new int[] { 12, 3, 54, 234, 654, 3 };

					tmpString=(Max(values) == 654).ToString();
					tmpString=(Min(values) == 3).ToString();
					tmpString=(Min(new int[] { }) == null).ToString();
					#endif

					#if TEST_STRING
						i = 5;
						tmpString = i+".ToString(\"##0\")="+i.ToString("##0");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpString = "("+i+"/(double)25).ToString(\"#%\")="+(i / (double)25).ToString("#%");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpDecimal = 0.88m;
						tmpString = tmpDecimal + ".ToString(\"#.00\")=" + tmpDecimal.ToString("#.00");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpString = tmpDecimal + ".ToString(\"#0.00\")=" + tmpDecimal.ToString("#0.00");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpDecimal = 88m;
						tmpString = tmpDecimal + ".ToString(\"#.00\")=" + tmpDecimal.ToString("#.00");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpDecimal = 1.5m;
						tmpString = tmpDecimal + ".ToString(\"p\")=" + tmpDecimal.ToString("p");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpString = tmpDecimal + ".ToString(\"#p\")=" + tmpDecimal.ToString("#p");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpString = tmpDecimal + ".ToString(\"#%\")=" + tmpDecimal.ToString("#%");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpString = tmpDecimal + ".ToString(\"#.00%\")=" + tmpDecimal.ToString("#.00%");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpDouble = 88;
						tmpString = tmpDouble + ".ToString(\"#.00\")=" + tmpDouble.ToString("#.00");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpDouble = 1.5;
						tmpString = tmpDouble + ".ToString(\"p\")=" + tmpDouble.ToString("p");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpString = tmpDouble + ".ToString(\"#p\")=" + tmpDouble.ToString("#p");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpString = tmpDouble + ".ToString(\"#%\")=" + tmpDouble.ToString("#%");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);

						tmpString = tmpDouble + ".ToString(\"#.00%\")=" + tmpDouble.ToString("#.00%");
						Console.WriteLine(tmpString);
						fstr_out.WriteLine(tmpString);
					#endif

                    #if TEST_CONVERT
                    try
                    {
                        NumberFormatInfo
                            nfi = new NumberFormatInfo();

                        nfi.NumberDecimalSeparator = ".";
                        Console.WriteLine(decimal.TryParse("107.880", NumberStyles.Number, nfi, out tmpDecimal) ? "oB!" : "Tampax");
                        Console.WriteLine(tmpString = 107.880.ToString(nfi));
                    }
                    catch (Exception eException)
                    {
                        Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message);
                    }
                    #endif
				}
				catch (Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}
			}
			finally
			{
				if (fstr_out != null)
					fstr_out.Close();
			}

        	return (Result);
        }
    }
}
