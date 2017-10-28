//#define TEST_XML
//#define TEST_REF
//#define TEST_TYPE_CONVERTER
//#define TEST_ROUND
//#define TEST__FUNC__
//#define TEST_REGEX
//#define TEST_FILE_ATTRIBUTE
//#define TEST_RANDOM
//#define TEST_WIN_API
//#define TEST_DATE_TIME
//#define TEST_STRING
//#define TEST_PATH
//#define TEST_FILES
#define TEST_ENCODING
//#define TEST_STRING_BUILDER
//#define TEST_ARRAY
//#define TEST_EXCEPTION
//#define TEST_ENUM
//#define TEST_CONVERT
//#define TEST_TYPES
//#define SELFASSEMBLY

//#define TRIAL
//#define RELEASE

using System;
#if TEST_ARRAY
	using System.Collections;
#endif
#if TEST_STRING
	using System.Configuration;
#endif
#if TEST_CONVERT
	using System.Globalization;
#endif

using System.IO;
using System.Reflection;
using System.Diagnostics;

#if TEST_ENCODING || TEST_WIN_API || TEST__FUNC__
using System.Text;
#endif

#if TEST_WIN_API
	using System.Runtime.InteropServices;
#endif

#if TEST_DATE_TIME
	using System.Threading;
	using System.Globalization;
#endif

#if TEST_REGEX
	using System.Text.RegularExpressions;
#endif

#if TEST_TYPE_CONVERTER
	using System.ComponentModel;
#endif

#if TEST_XML
	using System.Xml;
#endif

#if TEST_REF
	using System.Runtime.Serialization.Formatters.Binary;
#endif

delegate void MyEventHandler();

class CPoint
{
    public int
        x,
        y;

    public CPoint() : this(int.MinValue, int.MinValue)
    {}

    public CPoint(CPoint aObj) : this(aObj.x, aObj.y)
    {}

    public CPoint(int aX, int aY)
    {
        x = aX;
        y = aY;
    }
}

#if TEST_REF
class ClassOfCPoint
{
	public CPoint
		p;

	public string
		s;

	public ClassOfCPoint():this(null,string.Empty)
	{}

	public ClassOfCPoint(ClassOfCPoint aObj):this(aObj.p,aObj.s)
	{}

	public ClassOfCPoint(CPoint aP,string aS)
	{
		p=aP;
		s=aS;
	}
}
#endif

struct SPoint
{
    public int
        x,
        y;

    public SPoint(SPoint obj) : this(obj.x, obj.y)
    {}

    public SPoint(int _x_, int _y_)
    {
        x = _x_;
        y = _y_;
    }
}

class MyEvent
{
    public event MyEventHandler
      SomeEvent;

    public void OnSameEvent()
    {
        if (SomeEvent != null)
            SomeEvent();
    }
}

class X
{
    public void Xhandler()
    {
        Console.WriteLine("Событие, полученное объектом X");
    }
}

class Y
{
    public void Yhandler()
    {
        Console.WriteLine("Событие, полученное объектом Y");
    }
}

delegate string strMod(string str);
delegate void strMod_(ref string str);

class DelegateTest
{
    public static string replaceSpaces(string a)
    {
        Console.WriteLine("replaceSpaces(string)");
        return (a.Replace(' ', '-'));
    }

    public static string removeSpaces(string a)
    {
        string
          temp = "";

        Console.WriteLine("removeSpaces(string)");
        for (int i = 0; i < a.Length; ++i)
        {
            if (a[i] != ' ')
                temp += a[i];
        }

        return (temp);
    }

    public static string reverce(string a)
    {
        string
            temp = "";

        Console.WriteLine("reverce(string)");
        for (int i = a.Length - 1; i >= 0; --i)
        {
            temp += a[i];
        }

        return (temp);
    }
}

class StringOps
{
    public static void replaceSpaces(ref string a)
    {
        Console.WriteLine("replaceSpaces(string)");
        a = a.Replace(' ', '-');
    }

    public static void removeSpaces(ref string a)
    {
        string
            temp = "";

        Console.WriteLine("removeSpaces(string)");
        for (int i = 0; i < a.Length; ++i)
        {
            if (a[i] != ' ')
                temp += a[i];
        }

        a = temp;
    }

    public static void reverce(ref string a)
    {
        string
            temp = "";

        Console.WriteLine("reverce(string)");
        for (int i = a.Length - 1; i >= 0; --i)
        {
            temp += a[i];
        }

        a = temp;
    }
}

class Cons
{
    public static int
      alpha;

    public int
      beta;

    static Cons()
    {
        alpha = 99;
        Console.WriteLine("static Cons()");
    }

    public Cons()
    {
        beta = 100;
        Console.WriteLine("Cons()");
    }
}

class MyClassWithFactory
{
    int
      a,
      b;

    static public MyClassWithFactory factory(int i, int j)
    {
        MyClassWithFactory
          t = new MyClassWithFactory();

        t.a = i;
        t.b = j;

        return (t);
    }

    public void show()
    {
        Console.WriteLine("a и b: " + a + " " + b);
    }
}

class XYCoord
{
    public int
      x,
      y;

    public XYCoord() : this(0, 0)
    {
        Console.WriteLine("XYCoord()");
    }

    public XYCoord(XYCoord obj) : this(obj.x, obj.y)
    {
        Console.WriteLine("XYCoord(XYCoord)");
    }

    public XYCoord(int x, int y)
    {
        Console.WriteLine("XYCoord(int, int)");
        this.x = x;
        this.y = y;
    }
}

class Test
{
    [Obsolete("Лучше использовать метод myMeth2", false /*true*/)]
    public static int myMeth(int a, int b)
    {
        return (a / b);
    }

    public static int myMeth2(int a, int b)
    {
        return (b == 0 ? 0 : a / b);
    }

    [Conditional("TRIAL")]
    public void trial()
    {
        Console.WriteLine("Пробная версия, не для распространения");
    }

    [Conditional("RELEASE")]
    public void release()
    {
        Console.WriteLine("Окончательная версия");
    }
}

class A
{
}

class B : A
{
}

[AttributeUsage(AttributeTargets.All)]
class RemarkAttribute : Attribute
{
    string
        pri_remark;

    int
        pri_priority;

    public string
        supplement;


    public RemarkAttribute(string str)
    {
        pri_remark = str;
        supplement = "Данные отсутствуют";
    }

    public string remark
    {
        get
        {
            return (pri_remark);
        }
    }

    public int priority
    {
        get
        {
            return (pri_priority);
        }
        set
        {
            pri_priority = value;
        }
    }
}

[RemarkAttribute("Этот класс использует атрибут",
                 supplement = "Это дополнительная информация",
                 priority = 10)]
class MyClass
{
    int
        x,
        y,
        fI,
        fJ;

    public MyClass(int i)
    {
        Console.WriteLine("MyClass(int)");
        x = y = i;
        show();
    }

    public MyClass(int i, int j)
    {
        Console.WriteLine("MyClass(int, int)");
        x = i;
        y = j;
        show();
    }

    public int I
    {
        get
        {
            return (fI);
        }
        set
        {
            if (fI != value)
                fI = value;
        }
    }

    public int J
    {
        get
        {
            return (fJ);
        }
        set
        {
            if (fJ != value)
                fJ = value;
        }
    }

    public int sum()
    {
        return (x + y);
    }

    public bool isBetween(int i)
    {
        if (x < i && i < y)
            return (true);
        else
            return (false);
    }

    public void set(int a, int b)
    {
        Console.Write("set(int, int) ");
        x = a;
        y = b;
        show();
    }

    public void set(double a, double b)
    {
        Console.Write("set(double, double) ");
        x = (int)a;
        y = (int)b;
        show();
    }

    public void show()
    {
        Console.WriteLine("x: {0}, y: {1}", x, y);
    }
}

public class AA
{

}

public class BB
{
    AA F()
    {
        AA
            a = new AA();

        return (a);
    }

    internal AA G()
    {
        AA
            a = new AA();

        return (a);
    }

    public AA H()
    {
        AA
            a = new AA();

        return (a);
    }
}

class MainClass
{
    static void handler()
    {
        Console.WriteLine("Событие, полученное классом MainClass");
    }

    #if TEST_WIN_API
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern int GetShortPathName(
			[MarshalAs(UnmanagedType.LPTStr)]
			string path,
			[MarshalAs(UnmanagedType.LPTStr)]
			StringBuilder shortPath,
			int shortPathLength);
    #endif

    #if TEST_CONVERT
		static void DecimalParse(NumberStyles styles, IFormatProvider provider)
		{
			string[ ] decimalFormats = { "9876543210.9876543210",
										 "9876543210,9876543210",
										 "(9876543210,9876543210)",
										 "9,876,543,210,987,654.3210",
										 "9.876.543.210.987.654,3210",
										 "98_7654_3210_9876,543210" };
            
			foreach (string decimalString in decimalFormats)
			{
				decimal
					decimalNumber;

				Console.Write("Parse of {0,-29}",String.Format("\"{0}\"",decimalString));

				try
				{
					if(provider==null)
						if(styles<0)
							decimalNumber=Decimal.Parse(decimalString);
						else
							decimalNumber=Decimal.Parse(decimalString,styles);
					else 
						if(styles<0)
							decimalNumber=Decimal.Parse(decimalString,provider);
						else
							decimalNumber=Decimal.Parse(decimalString,styles,provider);
                
					Console.WriteLine("succeeded: {0}",decimalNumber);
				}
				catch(Exception ex)
				{
					Console.WriteLine("failed: {0}",ex.Message);
				}
			}
		}
    #endif

    #if TEST_ENUM
		enum TestEnum
		{
			Zero,
			First=0x1,
			Second=0x2,
			Third=0x4
		};
    #endif

    #if TEST__FUNC__
        static void Test__FUNC__Method(string Param1, string Param2)
        {
            StackTrace
                s = new StackTrace(0),
                st = new StackTrace(true);

            MethodBase
                mb = st.GetFrame(0).GetMethod();

            Type
                t = mb.ReflectedType;

            string
                typename = t.Name;

            ParameterInfo[]
                parameterInfo = mb.GetParameters();

            StringBuilder
                sb = new StringBuilder();

            sb.Append(mb.Name);
            sb.Append("(");

            try
            {
                if (parameterInfo.Length != 0)
                {
                    for (int i = 0; i < parameterInfo.Length; ++i)
                    {
                        sb.Append(parameterInfo[i].Name);
                        sb.Append("=");
                        sb.Append(",");
                    }
                    sb.Length--;
                }
            }
            catch
            {
                ;
            }

            sb.Append(")");
            Console.WriteLine(sb.ToString(), typename/*, TraceEventType.Information*/);
            Console.WriteLine(s.GetFrame(0).GetMethod().Name);
        }
    #endif

    public static int Main(string[] argv)
    {
        string
            tmpString;

        double
            tmpDouble;

        decimal
            tmpDecimal;

        int
            tmpInt;

        const int
                  CountFillChar = 60;

        const char
                  FillChar = '=';

        int
            BitValue = 107,
            BitFlag = 8;

        BitValue ^= BitFlag;

        bool
            tmpBool = false;

        tmpBool |= 5 == 5;

        #if TEST_XML
			try
			{
				XmlDocument
					doc=new XmlDocument();

				XmlNode
					node=doc.CreateXmlDeclaration("1.0","windows-1251",null),
					nnode;

				doc.AppendChild(node);

				XmlProcessingInstruction
					_pi_ = doc.CreateProcessingInstruction("xml-stylesheet","type=\"text/xsl\" href=\"data.xsl\"");

				doc.AppendChild(_pi_);
				
				node=doc.CreateElement("contract");
				node.Attributes.Append(doc.CreateAttribute("xmlns"));
				node.Attributes["xmlns"].Value="http://localhost/contract";
				node.Attributes.Append(doc.CreateAttribute("xmlns:othersperson"));
				node.Attributes["xmlns:othersperson"].Value="http://localhost/othersperson";
				doc.AppendChild(node);

				node=doc.CreateElement("contragent");
				node.AppendChild(doc.CreateTextNode("Иванов Иван Иванович"));
				doc.DocumentElement.AppendChild(node);

				node=doc.CreateElement("date");
				node.AppendChild(doc.CreateTextNode("2009.03.11"));
				doc.DocumentElement.AppendChild(node);

				node=doc.CreateElement("no");
				node.AppendChild(doc.CreateTextNode("13"));
				doc.DocumentElement.AppendChild(node);

				node=doc.CreateElement("othersperson:othersperson");

				nnode=doc.CreateElement("othersperson:contragent");
				nnode.Attributes.Append(doc.CreateAttribute("othersperson:date"));
				nnode.Attributes["othersperson:date"].Value="1870.04.22";
				nnode.AppendChild(doc.CreateTextNode("Ленин Владимир Ильич"));
				node.AppendChild(nnode);

				nnode=doc.CreateElement("othersperson:contragent");
				nnode.Attributes.Append(doc.CreateAttribute("othersperson:date"));
				nnode.Attributes["othersperson:date"].Value="1878.12.18";
				nnode.AppendChild(doc.CreateTextNode("Сталин Иосиф Виссарионович"));
				node.AppendChild(nnode);

				nnode=doc.CreateElement("othersperson:contragent");
				nnode.Attributes.Append(doc.CreateAttribute("othersperson:date"));
				nnode.Attributes["othersperson:date"].Value="1894.04.17";
				nnode.AppendChild(doc.CreateTextNode("Хрущев Никита Сергеевич"));
				node.AppendChild(nnode);

				doc.DocumentElement.AppendChild(node);

				tmpString="data.xml";
				if(File.Exists(tmpString))
					File.Delete(tmpString);

				doc.Save(tmpString);
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}
        #endif

        #if TEST_REF
			CPoint
				x2=null,
				x1=new CPoint();

			x2=x1;
			x1=null;

			if(x2!=null)
				x2.x=x2.y=1;

			ClassOfCPoint[]
				ClassOfCPoints={new ClassOfCPoint(new CPoint(1,1),"1"), 
								new ClassOfCPoint(new CPoint(20,20),"20"),
								new ClassOfCPoint(new CPoint(300,300),"300")};

			foreach(ClassOfCPoint cocp in ClassOfCPoints)
			{
				Console.WriteLine("x="+cocp.p.x+" y="+cocp.p.y);
				TestRef(ref cocp.p,true,false);
				Console.WriteLine("x="+cocp.p.x+" y="+cocp.p.y);
			}

			foreach(ClassOfCPoint cocp in ClassOfCPoints)
				Console.WriteLine("x="+cocp.p.x+" y="+cocp.p.y);

			for(int i=0; i<ClassOfCPoints.Length; ++i)
			{
				Console.WriteLine("x="+ClassOfCPoints[i].p.x+" y="+ClassOfCPoints[i].p.y);
				TestRef(ref ClassOfCPoints[i].p,true,false);
				Console.WriteLine("x="+ClassOfCPoints[i].p.x+" y="+ClassOfCPoints[i].p.y);
			}
        #endif

        #if TEST_TYPE_CONVERTER
			Console.WriteLine()};
			Console.WriteLine("TEST_TYPE_CONVERTER");
			Console.WriteLine(new string(FillChar,CountFillChar));

			Type
				type1=typeof(Int16),
				type2=typeof(Int32);

			TypeConverter
				tc=TypeDescriptor.GetConverter(type2);

			tmpString="Int32 "+(!tc.CanConvertTo(type1) ? "!" : string.Empty)+"CanConvertTo(Int16)";
			Console.WriteLine(tmpString);

			tc=TypeDescriptor.GetConverter(type1);
			tmpString="Int16 "+(!tc.CanConvertTo(type2) ? "!" : string.Empty)+"CanConvertTo(Int32)";
			Console.WriteLine(tmpString);

			type1=typeof(Double);
			tc=TypeDescriptor.GetConverter(type2);
			tmpString="Int32 "+(!tc.CanConvertTo(type1) ? "!" : string.Empty)+"CanConvertTo(Double)";
			Console.WriteLine(tmpString);

			tc=TypeDescriptor.GetConverter(type1);
			tmpString="Double "+(!tc.CanConvertTo(type2) ? "!" : string.Empty)+"CanConvertTo(Int32)";
			Console.WriteLine(tmpString);

			Console.WriteLine(new string(FillChar,CountFillChar));
			Console.WriteLine();
        #endif

        #if TEST_ROUND
			int
				aDigit=-1;

			tmpDecimal=1.45m;
			tmpDouble = aDigit!=0 ? Math.Pow(10,-aDigit) : 1;
			tmpDecimal*=(decimal)tmpDouble;
			tmpInt=tmpDecimal<0 ? (int)(tmpDecimal-0.5m) : (int)(tmpDecimal+0.5m);
			tmpDecimal=tmpInt/(decimal)tmpDouble;
			tmpDecimal=Math.Round(1.45m,1);
        #endif

        #if TEST__FUNC__
            Test__FUNC__Method("Param1", "Param2");
        #endif

        #if TEST_REGEX
			Regex
				r;

			Match
				match;

			tmpString="\\.";
			tmpString=Regex.IsMatch("12345.678",tmpString,RegexOptions.IgnoreCase).ToString().ToLower();
			tmpString="\\.";
			tmpString=Regex.IsMatch("12345678",tmpString,RegexOptions.IgnoreCase).ToString().ToLower();

			tmpString="123456.789";
			//tmpString="123456,789";
			//tmpString="123456-789";
			r=new Regex("[.,-]");
			if(r.IsMatch(tmpString))
			{
				match=r.Match(tmpString);
				while(match.Success)
				{
					tmpString=match.Index.ToString();
					match=match.NextMatch();
				}
			}

			tmpString="<span id=\"Span1\"></span><span id=\"Span22\"></span><span id=\"Span333\"></span>";

			r=new Regex("<span.*?>",RegexOptions.IgnoreCase);
			tmpString="Smth One car Smth Red car Smth Blue car";
			r=new Regex(@"(\w+)\s+(car)",RegexOptions.IgnoreCase);
			r=new Regex(@"((\w+\s+)car)",RegexOptions.IgnoreCase);
			match=r.Match(tmpString);

			CaptureCollection
				capturecollection;

			GroupCollection
				groupcollection;

			while(match.Success)
			{
				capturecollection=match.Captures;
				Console.WriteLine("Match.Captures -> CaptureCollection.Count: "+capturecollection.Count);
				for(int i=0; i<capturecollection.Count; ++i)
				{
					Console.WriteLine("Capture.Index: "+capturecollection[i].Index);
					Console.WriteLine("Capture.Length: "+capturecollection[i].Length);
					Console.WriteLine("Capture.Value: "+capturecollection[i].Value);
				}
				
				groupcollection=match.Groups;
				Console.WriteLine("Match.Groups -> GroupCollection.Count: "+groupcollection.Count);
				for(int i=0; i<groupcollection.Count; ++i)
				{
					Console.WriteLine("Capture.Index: "+groupcollection[i].Index);
					Console.WriteLine("Capture.Length: "+groupcollection[i].Length);
					Console.WriteLine("Capture.Value: "+groupcollection[i].Value);
					Console.WriteLine("Capture.Success: "+groupcollection[i].Success);

					capturecollection=groupcollection[i].Captures;
					Console.WriteLine("\tMatch.Captures -> CaptureCollection.Count: "+capturecollection.Count);
					for(int _ii_=0; _ii_<capturecollection.Count; ++_ii_)
					{
						Console.WriteLine("\tCapture.Index: "+capturecollection[_ii_].Index);
						Console.WriteLine("\tCapture.Length: "+capturecollection[_ii_].Length);
						Console.WriteLine("\tCapture.Value: "+capturecollection[_ii_].Value);
					}
				}
				Console.WriteLine("Match.Index: "+match.Index);
				Console.WriteLine("Match.Length: "+match.Length);
				Console.WriteLine("Match.Value: "+match.Value);
				Console.WriteLine();
				match=match.NextMatch();
			}

			MatchCollection
				matchcollection=r.Matches(tmpString);

			Console.WriteLine("MatchCollection.Count: "+matchcollection.Count);

			tmpString="<html><head><title>bla-bla-bla</title></head><body></body></html>";
			r=new Regex("<title>.*</title>");
			tmpString=r.Replace(tmpString,"<TITLE>BLA-BLA-BLA</TITLE>");
        #endif

        #if TEST_FILE_ATTRIBUTE
			//tmpString="E:\\Soft.src\\ASP.NET\\.svn";
			//tmpString="E:\\Soft.src\\ASP.NET\\bill\\.svn";
			tmpString="E:\\Soft.src\\ASP.NET\\bill\\blanks\\.svn";

			FileAttributes
				fa=File.GetAttributes(tmpString);

			tmpString=string.Empty;

			if((fa & FileAttributes.Directory)!=0)
			{
				if(tmpString!=string.Empty)
					tmpString+=" ";
				tmpString+="Directory";
			}
			if((fa & FileAttributes.Hidden)!=0)
			{
				if(tmpString!=string.Empty)
					tmpString+=" ";
				tmpString+="Hidden";

				fa&=~FileAttributes.Hidden;
				File.SetAttributes("E:\\Soft.src\\ASP.NET\\bill\\blanks\\.svn",fa);
			}
			if((fa & FileAttributes.System)!=0)
			{
				if(tmpString!=string.Empty)
					tmpString+=" ";
				tmpString+="System";
			}
			if((fa & FileAttributes.ReadOnly)!=0)
			{
				if(tmpString!=string.Empty)
					tmpString+=" ";
				tmpString+="ReadOnly";
			}
			if((fa & FileAttributes.Archive)!=0)
			{
				if(tmpString!=string.Empty)
					tmpString+=" ";
				tmpString+="Archive";
			}
        #endif

        #if TEST_RANDOM
			Random
				Rnd=new Random(unchecked((int)DateTime.Now.Ticks));

			int
				Max=1,
				RndV;

			for(int i=0; i<100; ++i)
			{
				RndV=Rnd.Next(Max);
				Console.Write(RndV);
				if(RndV==Max)
					Console.Write("!!!");
				Console.WriteLine();
			}
        #endif

        #if TEST_WIN_API
			StringBuilder
				shortNameBuffer=new StringBuilder();

			try
			{
				bool
					BufferSizeOk;

				int
					bufferSize,
					result;

				do
				{
					bufferSize=shortNameBuffer.Capacity;
					if((result=GetShortPathName("E:\\Soft.src\\ASP.NET\\Bill\\ImportPaymentProcessAdditionalForm.aspx.cs",shortNameBuffer,bufferSize))==0)
						throw(new Exception("kernel32.GetShortPathName() error (ErrorCode: "+result+")"));

					if(!(BufferSizeOk = bufferSize>=result))
						shortNameBuffer.Capacity=result;
				}while(!BufferSizeOk);
			}
			catch(Exception eException)
			{
				throw(new Exception("kernel32.GetShortPathName() error "+eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}
        #endif

        #if TEST_STRING
			tmpString=ConfigurationSettings.AppSettings["AbsentKey"];
			if(tmpString==string.Empty)
				tmpString="string.Empty";
			if(tmpString=="Smth")
				tmpString=string.Empty;
			if(ConfigurationSettings.AppSettings["AbsentKey"]=="Smth")
				tmpString=string.Empty;

			tmpString="0123456789";
			tmpInt=7;
			tmpString = tmpString.Length<=tmpInt ? tmpString : tmpString.Substring(0,tmpInt);

			tmpString="00000980   30001226501301366";

			for(int i_i=0; i_i<tmpString.Length; ++i_i)
				Console.Write(tmpString[i_i]);
			Console.WriteLine();

			foreach(char c_c in tmpString)
				Console.Write(c_c);
			Console.WriteLine();

			int
				PosBegin=tmpString.IndexOf("2"),
				PosEnd=tmpString.LastIndexOf("2");

			PosBegin=11;
			PosEnd=16;

			tmpString=tmpString.Substring(PosBegin,PosEnd-PosBegin+1);
			PosBegin=tmpString.IndexOf("2");
			PosEnd=tmpString.LastIndexOf("2");

			int
				FormatInt=1;

			tmpString=FormatInt.ToString("D2");
			tmpString=FormatInt.ToString("#,###");
			tmpString=FormatInt.ToString("{0:#,###0}");
			tmpString=string.Format("#,###",FormatInt);
			tmpString=string.Format("{0:#,###0}",FormatInt);
			FormatInt=0x0fffffff;
			tmpString=FormatInt.ToString("d");
			tmpString=FormatInt.ToString("D");
			tmpString=FormatInt.ToString("n");
			tmpString=FormatInt.ToString("N");
			tmpString=FormatInt.ToString("g");
			tmpString=FormatInt.ToString("G");
			tmpString=FormatInt.ToString("#,###");
			tmpString=FormatInt.ToString("{0:#,###0}");
			tmpString=string.Format("#,###",FormatInt);
			tmpString=string.Format("{0:#,###0}",FormatInt);

			tmpDecimal=0.88m;
			tmpString=tmpDecimal.ToString("#.00");
			tmpString=tmpDecimal.ToString("#0.00");

			tmpDecimal=88m;
			tmpString=tmpDecimal.ToString("#.00");

			tmpDecimal=1.5m;
			//tmpString=tmpDecimal.ToString("p");
			tmpString=tmpDecimal.ToString("#%");

			tmpDouble=1.5;
			//tmpString=tmpDouble.ToString("p");
			tmpString=tmpDouble.ToString("#.00%");

			tmpDecimal=8123456789.2225m;
			tmpString=tmpDecimal.ToString();
			tmpString=tmpDecimal.ToString("F");
			tmpString=tmpDecimal.ToString("F6");
			tmpString=Convert.ToString(tmpDecimal);
			tmpDecimal=0.0000002225m;
			tmpString=tmpDecimal.ToString();
			tmpString=tmpDecimal.ToString("F");
			tmpString=tmpDecimal.ToString("F6");
			tmpString=Convert.ToString(tmpDecimal);

			tmpDouble=8123456789.2225;
			tmpString=tmpDouble.ToString();
			tmpString=tmpDouble.ToString("F");
			tmpString=tmpDouble.ToString("F6");
			tmpString=Convert.ToString(tmpDouble);
			tmpDouble=0.00002225;
			tmpString=tmpDouble.ToString();
			tmpString=tmpDouble.ToString("F");
			tmpString=tmpDouble.ToString("F6");
			tmpString=Convert.ToString(tmpDouble);

			tmpString="1234567890";
			PosBegin=tmpString.IndexOf("5"); // 4
			tmpString=tmpString.Substring(0,PosBegin); // "1234"

			tmpString="0123 567 9";
			FormatInt=0;
			while(FormatInt<tmpString.Length)
			{
				if(tmpString[FormatInt]=='\x20')
					tmpString=tmpString.Substring(0,FormatInt)+tmpString.Substring(FormatInt+1);
				else
					++FormatInt;
			}

			tmpString="0123789";
			tmpString.Insert(4,"456"); // tmpString == "0123789"
			tmpString=tmpString.Insert(4,"456"); // tmpString == "0123456789"
			tmpString="-";
			tmpString.Substring(1); // tmpString == "-"
			tmpString.Remove(0,1); // tmpString == "-"
			tmpString=tmpString.Remove(0,1); // tmpString == string.Empty
			// || 
			// tmpString=tmpString.Substring(1); // tmpString == string.Empty
			if(tmpString!=string.Empty)
				tmpString+=tmpString;

			tmpString="йцукенгшщзхъ";
			tmpString=tmpString.ToUpper();
			tmpString="фывапролджэ";
			tmpString=tmpString.ToUpper();
			tmpString="ячсмитьбю";
			tmpString=tmpString.ToUpper();
			tmpString="ёґіїє";
			tmpString=tmpString.ToUpper();

			tmpString="один два три четыре";

			char[]
				CharArray=tmpString.ToCharArray();

			for(int i=0; i<CharArray.Length; ++i)
			{
				int
					code=CharArray[i];

				tmpString+="%u"+code.ToString("x");
			}
        #endif

        #if TEST_DATE_TIME
			DateTime
				vDateTime=DateTime.MinValue,
				vDate=vDateTime.Date;

			TimeSpan
				vTime=vDateTime.TimeOfDay;

			tmpString=vDateTime.ToLongDateString()+" "+vDateTime.ToLongTimeString();
			tmpString=vDateTime.ToString("MMMM");
			tmpString=vDate.ToLongDateString()+" "+vDate.ToLongTimeString();
			tmpString=vTime.ToString();

			vDateTime=new DateTime(2006,5,31);
			vTime=new TimeSpan(13,13,13);
			tmpString=vDateTime.ToLongDateString()+" "+vDateTime.ToLongTimeString();
			tmpString=vTime.ToString();

			vDateTime=vDateTime+vTime;
			vDate=vDateTime.Date;
			vTime=vDateTime.TimeOfDay;

			tmpString=vDateTime.ToLongDateString()+" "+vDateTime.ToLongTimeString();
			tmpString=vDate.ToLongDateString()+" "+vDate.ToLongTimeString();
			tmpString=vTime.ToString();

			vDateTime=new DateTime(0L);
			tmpString=vDateTime.ToLongDateString()+" "+vDateTime.ToLongTimeString();
		
			vTime=new TimeSpan(0L);
			tmpString=vTime.ToString();

			vTime=new TimeSpan(864000000000L*13);
			tmpString=vTime.ToString();

			vTime=new TimeSpan(1,2,3);
			vDateTime=new DateTime(0L);
			vDateTime+=vTime;
			tmpString=vDateTime.ToLongDateString()+" "+vDateTime.ToLongTimeString();

			vDateTime=Convert.ToDateTime(null);

			vTime=DateTime.Now.TimeOfDay;

			Thread.Sleep(500);

			TimeSpan
				vTime2=DateTime.Now.TimeOfDay,
				vTimeDiff;

			if((vTimeDiff=vTime.Subtract(vTime2))>TimeSpan.Zero)
				Console.WriteLine("vTime.Subtract(vTime2)="+vTimeDiff.ToString());
			if(vTimeDiff<TimeSpan.Zero)
				Console.WriteLine("vTime.Subtract(vTime2)="+vTimeDiff.ToString());
			if(-vTimeDiff>TimeSpan.Zero)
				Console.WriteLine("vTime.Subtract(vTime2)="+vTimeDiff.ToString());
			if((vTimeDiff=vTime2.Subtract(vTime))>TimeSpan.Zero)
				Console.WriteLine("vTime2.Subtract(vTime)="+vTimeDiff.ToString());

			DateTime
				d=new DateTime(2005,1,1),
				dd=new DateTime(2005,1,2);

			vTimeDiff=dd.Subtract(d);
			Console.WriteLine("d={0} dd={1} Days dd-d={2}",d,dd,vTimeDiff.Days);

			dd=new DateTime(2005,1,31);
			vTimeDiff=dd.Subtract(d);
			Console.WriteLine("d={0} dd={1} Days dd-d={2}",d,dd,vTimeDiff.Days);

			dd=new DateTime(2005,2,1);
			vTimeDiff=dd.Subtract(d);
			Console.WriteLine("d={0} dd={1} Days dd-d={2}",d,dd,vTimeDiff.Days);

			dd=new DateTime(2005,12,31);
			vTimeDiff=dd.Subtract(d);
			Console.WriteLine("d={0} dd={1} Days dd-d={2}",d,dd,vTimeDiff.Days);

			dd=new DateTime(2006,3,1);
			vTimeDiff=dd.Subtract(d);
			Console.WriteLine("d={0} dd={1} Days dd-d={2}",d,dd,vTimeDiff.Days);

			dd=new DateTime(2007,3,1);
			vTimeDiff=dd.Subtract(d);
			Console.WriteLine("d={0} dd={1} Days dd-d={2}",d,dd,vTimeDiff.Days);

			dd=new DateTime(2008,3,1);
			vTimeDiff=dd.Subtract(d);
			Console.WriteLine("d={0} dd={1} Days dd-d={2}",d,dd,vTimeDiff.Days);
			Console.WriteLine("d={0} dd={1} TotalDays dd-d={2}",d,dd,vTimeDiff.TotalDays);

			vDateTime=DateTime.Today;
			tmpString=vDateTime.ToLongDateString()+" "+vDateTime.ToLongTimeString();

			tmpString=DateTime.IsLeapYear(1900) ? "oB!" : "Tampax";
			dd=new DateTime(1900,2,28);
			dd=dd.AddDays(1);
			tmpString=dd.ToString("dd.MM.yyyy");
			tmpString=dd.ToString("#yyyy/MM/dd#");
			tmpString=dd.ToString(CultureInfo.InvariantCulture);
        #endif

        #if TEST_PATH
			string
				MustDiePath="E:\\Soft.src\\C#\\ReadFile\\ini\\DbfFile.ini",
				NixPath="E:/Soft.src/C#/ReadFile/ini/DbfFile.ini";

			tmpString=Path.GetDirectoryName(MustDiePath);
			tmpString=Path.GetDirectoryName(NixPath);

			if(Path.IsPathRooted(MustDiePath))
				tmpString=Path.GetPathRoot(MustDiePath);

			MustDiePath+="\\";
			tmpString=MustDiePath.EndsWith(Path.DirectorySeparatorChar.ToString()).ToString();

			Console.WriteLine("Path.AltDirectorySeparatorChar={0}",Path.AltDirectorySeparatorChar);
			Console.WriteLine("Path.DirectorySeparatorChar={0}",Path.DirectorySeparatorChar);
			Console.WriteLine("Path.PathSeparator={0}",Path.PathSeparator);
			Console.WriteLine("Path.VolumeSeparatorChar={0}",Path.VolumeSeparatorChar);

			Console.Write("Path.InvalidPathChars=");
			foreach (char c in Path.InvalidPathChars)
				Console.Write(c);
			Console.WriteLine();

			Console.WriteLine("System.IO.Directory.GetCurrentDirectory(): \":"+Directory.GetCurrentDirectory()+"\"");
			Console.WriteLine();

			tmpString=Directory.GetCurrentDirectory();
			if(Path.IsPathRooted(tmpString))
			{
				tmpString+=Path.DirectorySeparatorChar+".."+Path.DirectorySeparatorChar+".."+Path.DirectorySeparatorChar+"main.cs";
				if(File.Exists(tmpString))
					tmpString=Path.GetFullPath(tmpString);
			}
			tmpString="bin\\debug\\*.*";
			MustDiePath=Path.GetDirectoryName(tmpString);
			NixPath=Path.GetFileName(tmpString);
			if(!Path.IsPathRooted(MustDiePath))
			{
				MustDiePath=Directory.GetCurrentDirectory()+"\\..\\..\\"+MustDiePath;
				MustDiePath=Path.GetFullPath(MustDiePath);
			}

			string[]
				dir=Directory.GetFiles(MustDiePath,NixPath);

			foreach(string _s_ in dir)
				Console.WriteLine(_s_);

			NixPath="E:\\CD\\2006071409420440_1.jpg";
			tmpString=File.GetCreationTime(NixPath).ToString();
			tmpString=File.GetCreationTimeUtc(NixPath).ToString();
			tmpString=File.GetLastAccessTime(NixPath).ToString();
			tmpString=File.GetLastAccessTimeUtc(NixPath).ToString();
			tmpString=File.GetLastWriteTime(NixPath).ToString();
			tmpString=File.GetLastWriteTimeUtc(NixPath).ToString();
        #endif

        #if TEST_ENCODING
			string
				unicodeString="This string contains the unicode character Pi(\u03a0)";

			System.Text.Encoding
				ascii=System.Text.Encoding.ASCII,
				unicode=System.Text.Encoding.Unicode;

			byte[]
				unicodeBytes=unicode.GetBytes(unicodeString);

			byte[]
				asciiBytes=System.Text.Encoding.Convert(unicode,ascii,unicodeBytes);
	            
			char[]
				asciiChars=new char[ascii.GetCharCount(asciiBytes,0,asciiBytes.Length)];

			ascii.GetChars(asciiBytes,0,asciiBytes.Length,asciiChars,0);
			
			string
				asciiString=new string(asciiChars);

			Console.WriteLine("Original string: {0}", unicodeString);
			Console.WriteLine("Ascii converted string: {0}", asciiString);

			byte[]
				cp866Bytes={0x89,0xae,0xa1,0xa0,0xad,0xeb,0xa9,0x20,0xa2,0x20,0xe0,0xae,0xe2};

			asciiBytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(866),System.Text.Encoding.Default,cp866Bytes);
			asciiChars=new char[System.Text.Encoding.Default.GetCharCount(asciiBytes,0,asciiBytes.Length)];
			System.Text.Encoding.Default.GetChars(asciiBytes,0,asciiBytes.Length,asciiChars,0);
			asciiString=new string(asciiChars);
			Console.WriteLine(asciiString);

			asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
			cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);

			char[]
				cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
			
			System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);

			string
				cp866String=new string(cp866Chars);

			
			Byte[]
				bytes;

			String
				chars="UTF8 Encoding Example Йобаный в рот";
        
			System.Text.UTF8Encoding
				_utf8_ = new System.Text.UTF8Encoding();
        
			bytes=_utf8_.GetBytes(chars);
        
			Console.WriteLine("{0} bytes used to encode string.",bytes.Length);

			Console.Write("Encoded bytes: ");
			foreach(Byte _b_ in bytes) 
			{
				Console.Write("[{0}]",_b_);
			}
			Console.WriteLine();

			unicodeString="\u043E\u0434\u0438\u043D\u0020\u0434\u0432\u0430\u0020\u0442\u0440\u0438";

			unicodeBytes=System.Text.Encoding.Unicode.GetBytes(unicodeString);
			asciiBytes=System.Text.Encoding.Convert(System.Text.Encoding.Unicode,System.Text.Encoding.ASCII,unicodeBytes);
			asciiChars=new char[System.Text.Encoding.ASCII.GetCharCount(asciiBytes,0,asciiBytes.Length)];
			System.Text.Encoding.ASCII.GetChars(asciiBytes,0,asciiBytes.Length,asciiChars,0);
			asciiString=new string(asciiChars);
			Console.WriteLine("Original string: {0}", unicodeString);
			Console.WriteLine("Ascii converted string: {0}", asciiString);

			unicodeBytes=System.Text.Encoding.Unicode.GetBytes(unicodeString);
			asciiBytes=System.Text.Encoding.Convert(System.Text.Encoding.Unicode,System.Text.Encoding.GetEncoding(1251),unicodeBytes);
			asciiChars=new char[System.Text.Encoding.GetEncoding(1251).GetCharCount(asciiBytes,0,asciiBytes.Length)];
			System.Text.Encoding.GetEncoding(1251).GetChars(asciiBytes,0,asciiBytes.Length,asciiChars,0);
			asciiString=new string(asciiChars);
			Console.WriteLine("Original string: {0}", unicodeString);
			Console.WriteLine("Ascii converted string: {0}", asciiString);

			unicodeBytes=System.Text.Encoding.UTF8.GetBytes(unicodeString);
			asciiBytes=System.Text.Encoding.Convert(System.Text.Encoding.UTF8,System.Text.Encoding.GetEncoding(1251),unicodeBytes);
			asciiChars=new char[System.Text.Encoding.GetEncoding(1251).GetCharCount(asciiBytes,0,asciiBytes.Length)];
			System.Text.Encoding.GetEncoding(1251).GetChars(asciiBytes,0,asciiBytes.Length,asciiChars,0);
			asciiString=new string(asciiChars);
			Console.WriteLine("Original string: {0}", unicodeString);
			Console.WriteLine("Ascii converted string: {0}", asciiString);

			asciiBytes=Encoding.GetEncoding(1251).GetBytes(unicodeString);
			asciiChars=new char[Encoding.UTF8.GetDecoder().GetCharCount(asciiBytes,0,asciiBytes.Length)];
			Encoding.UTF8.GetDecoder().GetChars(asciiBytes,0,asciiBytes.Length,asciiChars,0);

			asciiBytes=Encoding.UTF8.GetBytes(unicodeString);
			asciiChars=new char[Encoding.GetEncoding(1251).GetDecoder().GetCharCount(asciiBytes,0,asciiBytes.Length)];
			Encoding.GetEncoding(1251).GetDecoder().GetChars(asciiBytes,0,asciiBytes.Length,asciiChars,0);

			tmpString=Encoding.UTF8.GetString(Encoding.GetEncoding(1251).GetBytes(unicodeString));
			tmpString=Encoding.GetEncoding(1251).GetString(Encoding.UTF8.GetBytes(unicodeString));
        #endif

        #if TEST_STRING_BUILDER
			StringBuilder
				sb=new StringBuilder();

			sb.Append("qwertyuiop");
			sb.Append(Environment.NewLine);
			sb.Append('A');
			sb.Append(Environment.NewLine);
			sb.Append("asdfghjkl");

			sb.Length=0;
			sb.Append("QWERTYUIOP");
			sb.Append(Environment.NewLine);
			sb.Append('a');
			sb.Append(Environment.NewLine);
			sb.Append("ASDFGHJKL");

			tmpString="0123456789";
			tmpString=tmpString.Substring(3,8-3);

			sb=new StringBuilder("1st");
			sb.Append(Environment.NewLine);
			sb.Append("2nd");

			tmpString=sb.ToString();
			Console.WriteLine(Object.ReferenceEquals(sb.ToString(), sb.ToString()));

			Type
				sbType=typeof(StringBuilder);

			FieldInfo
				sbField=sbType.GetField("m_StringValue",BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.IgnoreCase),
				sbThread=sbType.GetField("m_currentThread",BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.IgnoreCase);

			MethodInfo
				sbMethod1=sbType.GetMethod("InternalGetCurrentThread",BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.IgnoreCase);

			sb=new StringBuilder("text");
			Console.WriteLine(sbThread.GetValue(sb));
			Console.WriteLine(sbMethod1.Invoke(sb,new object[0]));
		
			PropertyInfo
				strArrLengProp=typeof(string).GetProperty("ArrayLength",BindingFlags.NonPublic|BindingFlags.Instance | BindingFlags.IgnoreCase);

			Console.WriteLine(((string)sbField.GetValue(sb)).Length);
			Console.WriteLine(strArrLengProp.GetValue(sbField.GetValue(sb),null));

			object
				str1=sbField.GetValue(sb),
				str2=sbField.GetValue(sb);

			string
				StrNew1 = sb.ToString(),
				StrNew2 = sb.ToString();

			str1=sbField.GetValue(sb);
			str2=sbField.GetValue(sb);

			sb.Append("1");
			Console.WriteLine(sbThread.GetValue(sb));
			Console.WriteLine(sbMethod1.Invoke(sb,new object[0]));

			Console.WriteLine(ReferenceEquals(StrNew1,StrNew2)); 
        #endif

        #if TEST_ARRAY
			object[,]
				ArrayOfSmth={	{"1st",1},
								{"2nd",2},
								{"3rd",3}
							};

			int
				MinI=ArrayOfSmth.GetLowerBound(0),
				MaxI=ArrayOfSmth.GetUpperBound(0),
				MinJ=ArrayOfSmth.GetLowerBound(1),
				MaxJ=ArrayOfSmth.GetUpperBound(1),
				_IDX_=-1; // Array.BinarySearch(ArrayOfSmth,"2nd");
		
			if(_IDX_!=-1)
				Console.WriteLine(_IDX_);

			for(int _II_=MinI; _II_<=MaxI; ++_II_)
			{
				tmpString=string.Empty;
				for(int _JJ_=MinJ; _JJ_<=MaxJ; ++_JJ_)
				{
					if(tmpString!=string.Empty)
						tmpString+="\t";
					tmpString+=ArrayOfSmth[_II_,_JJ_].ToString();
				}
				if(tmpString!=string.Empty)
					Console.WriteLine(tmpString);
			}

			int[]
				destArray;

			ArrayList
				srcArray=new ArrayList();

			srcArray.Add(0);
			srcArray.Add(1);
			srcArray.Add(2);
			srcArray.Add(3);
			srcArray.Add(4);
			srcArray.Add(5);

			destArray=(int[])Array.CreateInstance(typeof(int),srcArray.Count);
			srcArray.CopyTo(destArray);

			tmpString=string.Empty;
			for(int __i__=0; __i__<destArray.Length; ++__i__)
			{
				if(tmpString!=string.Empty)
					tmpString+=" ";
				tmpString+=destArray[__i__];
			}

			srcArray=new ArrayList();
			srcArray.Add(3);
			srcArray.Insert(0,0);
			srcArray.Insert(1,1);
			srcArray.Insert(2,2);
			if(4<=srcArray.Count)
				srcArray.Insert(4,4);
			try
			{
				srcArray.Insert(10,10);
			}
			catch(Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace);
			}
			
			for(int __i__=0; __i__<srcArray.Count; ++__i__)
				if((int)srcArray[__i__]==0)
				{
					srcArray.Insert(++__i__,10);
					srcArray.Insert(++__i__,11);
					srcArray.Insert(++__i__,12);
				}
			for(int __i__=0; __i__<srcArray.Count; ++__i__)
				if((int)srcArray[__i__]==11)
					srcArray.RemoveAt(__i__--);

			int[]
				ArrayOfInt={5, 3, 7, 9};

			tmpString=ArrayOfInt.ToString();
			Console.WriteLine(tmpString);
        #endif

        #if TEST_EXCEPTION
			try
			{
				try
				{
					tmpString=Convert.ToString(1/Convert.ToByte("0"));
					throw(new Exception("Message"));
				}
				catch(Exception eException)
				{
					Type
						tmpType=eException.GetType();
					
					tmpString=tmpType.Name; // "DivideByZeroException"

					throw; //(new Exception(eException.ToString()));
				}
			}
			catch(Exception eException)
			{
				tmpString="Message=\""+eException.Message+"\"";
				tmpString+="\nSource=\""+eException.Source+"\"";
				tmpString+="\nStackTrace=\""+eException.StackTrace+"\"";
				tmpString+="\nTargetSite=\""+eException.TargetSite+"\"";
				tmpString+="\nHelpLink=\""+eException.HelpLink+"\"";
				tmpString+="\nToString()=\""+eException.ToString()+"\"";

				Console.WriteLine(tmpString);
			}
        #endif

        #if TEST_ENUM
			TestEnum
				enumVar;

			enumVar=TestEnum.First;
			tmpString=enumVar.ToString();
			tmpString+=" "+(int)enumVar;

			enumVar=TestEnum.Zero;
			enumVar|=TestEnum.First;
			enumVar|=TestEnum.Second;
			tmpString=enumVar.ToString();
			tmpString+=" "+(int)enumVar;

			tmpString=string.Empty;
			if((enumVar&TestEnum.First)!=0)
			{
				if(tmpString!=string.Empty)
					tmpString+=" ";
				tmpString+="Contains "+TestEnum.First;
			}
			if((enumVar&TestEnum.Second)!=0)
			{
				if(tmpString!=string.Empty)
					tmpString+=" ";
				tmpString+="Contains "+TestEnum.Second;
			}
			if((enumVar&TestEnum.Third)!=0)
			{
				if(tmpString!=string.Empty)
					tmpString+=" ";
				tmpString+="Contains "+TestEnum.Third;
			}
        #endif

        #if TEST_CONVERT
			try
			{
				tmpDecimal=Convert.ToDecimal("123-456");

				tmpDouble=13.596;
				tmpString=Convert.ToString(tmpDouble);
				tmpDouble=Convert.ToDouble(tmpString);

				tmpString="15.396";
				tmpDouble=Convert.ToDouble(tmpString);
				tmpString=Convert.ToString(tmpDouble);

				tmpDecimal=13.596m;
				tmpString=Convert.ToString(tmpDecimal);
				tmpDecimal=Convert.ToDecimal(tmpString);

				tmpString="15.396";
				tmpDecimal=Convert.ToDecimal(tmpString);
				tmpString=Convert.ToString(tmpDecimal);
			
				Console.WriteLine("This example of");
				Console.WriteLine("\tDecimal.Parse( String )");
				Console.WriteLine("\tDecimal.Parse( String, NumberStyles )");
				Console.WriteLine("\tDecimal.Parse( String, IFormatProvider )");
				Console.WriteLine("\tDecimal.Parse( String, NumberStyles, IFormatProvider )");
				Console.WriteLine("generates the following output when run in the [{0}] culture.",CultureInfo.CurrentCulture.Name);
				Console.WriteLine("Several string representations of Decimal values are parsed." );

				Console.WriteLine();
				Console.WriteLine("NumberStyles and IFormatProvider are not used; current culture is [{0}]:", CultureInfo.CurrentCulture.Name);
				DecimalParse((NumberStyles)(-1),null);

				Console.WriteLine();
				Console.WriteLine("NumberStyles.Currency is used; IFormatProvider is not used:");
				DecimalParse(NumberStyles.Currency,null);
            
				string
					cultureName = CultureInfo.CurrentCulture.Name.Substring(0,2)=="nl" ? "en-US" : "nl-NL";

				CultureInfo
					culture=new CultureInfo(cultureName);
            
				Console.WriteLine();
				Console.WriteLine("NumberStyles is not used; [{0}] culture IFormatProvider is used:", culture.Name);
				DecimalParse((NumberStyles)(-1),culture);
            
				NumberFormatInfo
					numInfo=culture.NumberFormat;

				numInfo.NumberGroupSizes=new int[ ]{4};
				numInfo.NumberGroupSeparator="_";
            
				Console.WriteLine();
				Console.WriteLine("NumberStyles.Currency is used, group size = 4, separator = \"_\":");
				DecimalParse(NumberStyles.Currency, numInfo );
				Console.ReadLine();
			}
			catch (OverflowException eException)
			{
				Console.WriteLine("OverflowException (Message: \""+eException.Message+"\")");
			}
			catch (FormatException eException) 
			{
				Console.WriteLine("FormatException (Message: \""+eException.Message+"\")");
			}
			catch (ArgumentNullException eException) 
			{
				Console.WriteLine("ArgumentNullException (Message: \""+eException.Message+"\")");
			}
        #endif

        #if TEST_TYPES
			long
				tmpLong;

			ulong
				tmpULong;

			tmpLong=0xFFFFEFD6L;

			unchecked
			{
				tmpLong=(long)0xFFFFFFFFFFFFEFD6L;
				tmpULong=0xFFFFFFFFFFFFEFD6L;
			}
			if(tmpULong!=(ulong)tmpLong)
				tmpULong=(ulong)tmpLong;

			tmpLong=unchecked((long)0xFFFFFFFFFFFFEFD6L);
			if(tmpULong!=(ulong)tmpLong)
				tmpULong=(ulong)tmpLong;

			short
				tmpShort=-10;

			tmpLong=tmpShort;

			tmpDouble=13;
			tmpDecimal=(decimal)tmpDouble;
			tmpString=String.Format("double={0:###,###,###,###.######} decimal={1:###,###,###,###.######}",tmpDouble,tmpDecimal);
			
			tmpDouble=(double)tmpDecimal;
			tmpString+="\n"+String.Format("double={0:###,###,###,###.######} decimal={1:###,###,###,###.######}",tmpDouble,tmpDecimal);

			tmpDouble=13.596;
			tmpDecimal=(decimal)tmpDouble;
			tmpString=String.Format("double={0:###,###,###,###.######} decimal={1:###,###,###,###.######}",tmpDouble,tmpDecimal);
			
			tmpDouble=(double)tmpDecimal;
			tmpString+="\n"+String.Format("double={0:###,###,###,###.######} decimal={1:###,###,###,###.######}",tmpDouble,tmpDecimal);

			tmpDecimal=13;	
			tmpDouble=(double)tmpDecimal;
			tmpString=String.Format("double={0:###,###,###,###.######} decimal={1:###,###,###,###.######}",tmpDouble,tmpDecimal);
			
			tmpDecimal=(decimal)tmpDouble;
			tmpString+="\n"+String.Format("double={0:###,###,###,###.######} decimal={1:###,###,###,###.######}",tmpDouble,tmpDecimal);

			tmpDecimal=13.596m;	
			tmpDouble=(double)tmpDecimal;
			tmpString=String.Format("double={0:###,###,###,###.######} decimal={1:###,###,###,###.######}",tmpDouble,tmpDecimal);
			
			tmpDecimal=(decimal)tmpDouble;
			tmpString+="\n"+String.Format("double={0:###,###,###,###.######} decimal={1:###,###,###,###.######}",tmpDouble,tmpDecimal);

			object
				objectA,
				objectB;

			tmpDecimal=13m;

			objectA=tmpDecimal;
			objectB=tmpDecimal;

			tmpString = objectA==objectB ? "==" : "!=";
			tmpString = objectA.Equals(objectB) ? "Equals" : "!Equals";

			tmpInt=13;
			objectB=tmpInt;

			tmpString = objectA==objectB ? "==" : "!=";
			tmpString = objectA.Equals(objectB) ? "Equals" : "!Equals";
        #endif

        Console.WriteLine();

        tmpDouble = double.NaN;
        if (tmpDouble != double.NaN)
            Console.WriteLine("tmpDouble!=double.NaN");
        if (double.IsNaN(tmpDouble))
            Console.WriteLine("double.IsNaN(tmpDouble)");

        int
            VictimRightShift = 0x0ffff;

        VictimRightShift >>= 1;
        VictimRightShift >>= 3;

        int[]
            arr1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
            arr2 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            arr = null;

        arr = arr1;
        tmpString = arr.Length.ToString();
        arr = arr2;
        tmpString = arr.Length.ToString();

        Console.WriteLine();

        CPoint
            cp1 = new CPoint();

        cp1.x = 1;
        cp1.y = 2;

        CPoint
            cp2 = cp1;

        cp2.x = 3;
        cp2.y = 4;
        Console.WriteLine("cp1=({0},{1})", cp1.x, cp1.y);
        Console.WriteLine("cp2=({0},{1})", cp2.x, cp2.y);

        SPoint
            sp1 = new SPoint();

        sp1.x = 1;
        sp1.y = 2;

        SPoint
            sp2 = sp1;

        sp2.x = 3;
        sp2.y = 4;
        Console.WriteLine("sp1=({0},{1})", sp1.x, sp1.y);
        Console.WriteLine("sp2=({0},{1})", sp2.x, sp2.y);
        Console.WriteLine();

        MyEvent
          evt = new MyEvent();

        evt.SomeEvent += new MyEventHandler(handler);
        evt.OnSameEvent();

        X
         xOb = new X();

        Y
         yOb = new Y();

        evt.SomeEvent += new MyEventHandler(xOb.Xhandler);
        evt.SomeEvent += new MyEventHandler(yOb.Yhandler);
        evt.OnSameEvent();
        Console.WriteLine();

        evt.SomeEvent -= new MyEventHandler(xOb.Xhandler);
        evt.OnSameEvent();

        Console.WriteLine();

        Test
          objTest = new Test();

        objTest.trial();
        objTest.release();
        Console.WriteLine("4 / 3 is " + Test.myMeth(4, 3));
        Console.WriteLine();

        Type
            t;

        int
          x;

        #if SELFASSEMBLY
			Assembly
				asm=Assembly.LoadFrom("E:\\Soft.src\\Test\\C#\\ABCBook\\obj\\Debug\\ABCBook.exe");
		                          
			Type[]
				alltypes=asm.GetTypes();

			x=-1;
			for(int i=0; i<alltypes.Length; ++i)
			{
				Console.WriteLine("Обнаружено: "+alltypes[i].Name);
				if(alltypes[i].Name.CompareTo("MyClass")==0)
				x=i;
			}
			Console.WriteLine();
		
			if(x!=-1)
				t=alltypes[x];
			else
				return(-1);
        #else
            t = typeof(MyClass);
        #endif

        Console.WriteLine("Аттрибуты в " + t.Name + ": ");

        object[]
          attribs = t.GetCustomAttributes(false);

        foreach (object o in attribs)
        {
            Console.WriteLine(o);
        }
        Console.WriteLine();
        Console.WriteLine("RemarkAttribute:");

        Type
          tRemAtt = typeof(RemarkAttribute);

        RemarkAttribute
          ra = (RemarkAttribute)Attribute.GetCustomAttribute(t, tRemAtt);

        Console.WriteLine("Remark: " + ra.remark);
        Console.WriteLine("Supplement: " + ra.supplement);
        Console.WriteLine("Priority: " + ra.priority);
        Console.WriteLine();

        FieldInfo[]
            fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        Console.WriteLine("Анализ Field, определенных в " + t.Name);
        foreach (FieldInfo f in fi)
        {
            Console.Write("   " + f.Name);
            Console.WriteLine();
        }
        Console.WriteLine();

        PropertyInfo[]
            pi_ = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        Console.WriteLine("Анализ Property, определенных в " + t.Name);
        foreach (PropertyInfo p_ in pi_)
        {
            Console.Write("   " + p_.Name);
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.WriteLine("Анализ методов, определенных в " + t.Name);
        Console.WriteLine();

        ConstructorInfo[]
          ci = t.GetConstructors();

        ParameterInfo[]
          pi;

        Console.WriteLine("Имеются следующие конструкторы: ");
        foreach (ConstructorInfo c in ci)
        {
            Console.Write("   " + t.Name + "(");
            pi = c.GetParameters();
            for (int i = 0; i < pi.Length; ++i)
            {
                Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                if (i + 1 < pi.Length)
                    Console.Write(", ");
            }
            Console.WriteLine(")");
        }
        Console.WriteLine();

        Console.WriteLine("Поддерживаемые методы:");

        MethodInfo[]
          mi;

        //mi=t.GetMethods();
        mi = t.GetMethods(BindingFlags.DeclaredOnly
                        | BindingFlags.Instance
                        | BindingFlags.Public);

        foreach (MethodInfo m in mi)
        {
            Console.Write("   " + m.ReturnType.Name + " " + m.Name + "(");
            pi = m.GetParameters();

            for (int i = 0; i < pi.Length; ++i)
            {
                Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                if (i + 1 < pi.Length)
                    Console.Write(", ");
            }
            Console.WriteLine(")");
        }
        Console.WriteLine();

        for (x = 0; x < ci.Length; ++x)
        {
            pi = ci[x].GetParameters();
            if (pi.Length == 2)
                break;
        }

        if (x == ci.Length)
        {
            Console.WriteLine("Подходящий конструктор не найден");
            return (-1);
        }
        else
            Console.WriteLine("Найден конструктор с двумя параметрами\n");

        object[]
          argv_;

        argv_ = new object[2];
        argv_[0] = 100;
        argv_[1] = 200;

        object
          reflectObj_ = ci[x].Invoke(argv_);

        MyClass
          reflectObj = new MyClass(10, 20);

        Console.WriteLine();
        Console.WriteLine("Вызов методов, определенных в " + t.Name);
        Console.WriteLine();

        mi = t.GetMethods(BindingFlags.DeclaredOnly
                        | BindingFlags.Instance
                        | BindingFlags.Public);

        int
          val;

        foreach (MethodInfo m in mi)
        {
            Console.WriteLine(m.Name);
            pi = m.GetParameters();
            if (m.Name.CompareTo("set") == 0
               && pi[0].ParameterType == typeof(int)
              )
            {
                argv_ = new object[2];
                try
                {
                    argv_[0] = 9;
                    argv_[1] = 18;
                    m.Invoke(reflectObj, argv_);
                }
                catch (TargetException eException)
                {
                    Console.WriteLine("Message: " + eException.Message + "\nSource: " + eException.Source + "\nStackTrace: " + eException.StackTrace + "\nTargetSite: " + eException.TargetSite);
                }
                argv_[0] = 90;
                argv_[1] = 180;
                m.Invoke(reflectObj_, argv_);
            }
            else if (m.Name.CompareTo("set") == 0
                && pi[0].ParameterType == typeof(double)
                )
            {
                argv_ = new object[2];
                try
                {
                    argv_[0] = 1.12;
                    argv_[1] = 23.4;
                    m.Invoke(reflectObj, argv_);
                }
                catch (TargetException eException)
                {
                    Console.WriteLine("Message: " + eException.Message + "\nSource: " + eException.Source + "\nStackTrace: " + eException.StackTrace + "\nTargetSite: " + eException.TargetSite);
                }
                argv_[0] = 10.12;
                argv_[1] = 230.4;
                m.Invoke(reflectObj_, argv_);
            }
            else if (m.Name.CompareTo("sum") == 0)
            {
                try
                {
                    val = (int)m.Invoke(reflectObj, null);
                    Console.WriteLine("Результат вызова метода sum равен " + val);
                }
                catch (TargetException eException)
                {
                    Console.WriteLine("Message: " + eException.Message + "\nSource: " + eException.Source + "\nStackTrace: " + eException.StackTrace + "\nTargetSite: " + eException.TargetSite);
                }
                val = (int)m.Invoke(reflectObj_, null);
                Console.WriteLine("Результат вызова метода sum равен " + val);
            }
            else if (m.Name.CompareTo("isBetween") == 0)
            {
                argv_ = new object[1];
                try
                {
                    argv_[0] = 14;
                    if ((bool)m.Invoke(reflectObj, argv_))
                        Console.WriteLine("{0} находится между x и y", argv_[0]);
                }
                catch (TargetException eException)
                {
                    Console.WriteLine("Message: " + eException.Message + "\nSource: " + eException.Source + "\nStackTrace: " + eException.StackTrace + "\nTargetSite: " + eException.TargetSite);
                }
                argv_[0] = 140;
                if ((bool)m.Invoke(reflectObj_, argv_))
                    Console.WriteLine("{0} находится между x и y", argv_[0]);
            }
            else if (m.Name.CompareTo("show") == 0)
            {
                try
                {
                    m.Invoke(reflectObj, null);
                }
                catch (TargetException eException)
                {
                    Console.WriteLine("Message: " + eException.Message + "\nSource: " + eException.Source + "\nStackTrace: " + eException.StackTrace + "\nTargetSite: " + eException.TargetSite);
                }
                m.Invoke(reflectObj_, null);
            }

            Console.WriteLine();
        }

        A
         a = new A();
        B
         b = new B();

        Console.WriteLine();
        if (a is A)
            Console.WriteLine("Объект a имеет тип A");

        if (b is A)
            Console.WriteLine("Объект b совместим с типом A, поскольку его тип выведен из типа A");

        if (a is B)
            Console.WriteLine("Этот текст не буден отображен, поскольку объект a не выведен из класса B");

        if (b is B)
            Console.WriteLine("Объект b имеет тип B");

        if (a is object)
            Console.WriteLine("a -- объект");

        if (a is B)
            b = (B)a;
        else
            b = null;

        if (b == null)
            Console.WriteLine("Операция приведения типов b=(B)a НЕ РАЗРЕШЕНА");
        else
            Console.WriteLine("Операция приведения типов b=(B)a разрешена");

        b = a as B;
        if (b == null)
            Console.WriteLine("Операция приведения типов b=(B)a НЕ РАЗРЕШЕНА");
        else
            Console.WriteLine("Операция приведения типов b=(B)a разрешена");

        t = typeof(StreamReader);

        Console.WriteLine();
        Console.WriteLine(t.FullName);
        if (t.IsClass)
            Console.WriteLine("Это класс");
        if (t.IsAbstract)
            Console.WriteLine("Это абстрактный класс");
        else
            Console.WriteLine("Это конкретный класс");

        Console.WriteLine();
        Console.WriteLine("argc={0}", argv.Length);
        for (int i = 0; i < argv.Length; ++i)
            Console.WriteLine("argv[{0}]=\"" + argv[i] + "\"", i);

        int
          sum = 0;

        int[]
          nums = new int[10];

        for (int i = 0; i < 10; ++i)
            nums[i] = i;

        Console.WriteLine();
        foreach (int xx in nums)
        {
            Console.WriteLine(xx);
            sum += xx;
        }
        Console.WriteLine(sum);

        Console.WriteLine();
        Console.WriteLine("Простая C#-программа ;)");

        Console.WriteLine();

        XYCoord
          t1 = new XYCoord(),
          t2 = new XYCoord(8, 9),
          t3 = new XYCoord(t2);

        int
          ii,
          jj;

        Console.WriteLine();
        for (ii = 0, jj = 10; ii < 10; ++ii, --jj)
        {
            MyClassWithFactory
              ob = MyClassWithFactory.factory(ii, jj);

            ob.show();
        }

        Console.WriteLine();

        Cons
          obCons = new Cons();

        Console.WriteLine("Cons.alpha: " + Cons.alpha);
        Console.WriteLine("obCons.beta: " + obCons.beta);

        Console.WriteLine();

        strMod
          strOp = new strMod(DelegateTest.replaceSpaces);

        string
          s;

        s = strOp("Это просто тест");
        Console.WriteLine("s=" + s);

        strOp = new strMod(DelegateTest.removeSpaces);
        s = strOp("Это просто тест");
        Console.WriteLine("s=" + s);

        strOp = new strMod(DelegateTest.reverce);
        s = strOp("Это просто тест");
        Console.WriteLine("s=" + s);

        Console.WriteLine();

        strMod_
          strOp_,
          replaceSp = new strMod_(StringOps.replaceSpaces),
          removeSp = new strMod_(StringOps.removeSpaces),
          reverceStr = new strMod_(StringOps.reverce);

        s = "Это просто тест";
        strOp_ = replaceSp;
        strOp_ += reverceStr;
        strOp_(ref s);
        Console.WriteLine("s=" + s);

        s = "Это просто тест";
        strOp_ -= replaceSp;
        strOp_ += removeSp;
        strOp_(ref s);
        Console.WriteLine("s=" + s);

        #if TEST_FILES
			string
				FileName=Directory.GetCurrentDirectory();

			FileName=FileName.Substring(0,FileName.LastIndexOf("bin",FileName.Length-1))+"input1251.txt";
			
			FileStream
				f_inp=new FileStream(FileName,FileMode.Open,FileAccess.Read);

			StreamReader
				sr=new StreamReader(f_inp,System.Text.Encoding.GetEncoding(1251));

			Console.WriteLine();
			while((s=sr.ReadLine())!=null)
				Console.WriteLine(s);

			sr.Close();
			if(f_inp.CanRead)
				f_inp.Close();

			FileName=Directory.GetCurrentDirectory();
			FileName=FileName.Substring(0,FileName.LastIndexOf("bin",FileName.Length-1))+"input866.txt";
			
			f_inp=new FileStream(FileName,FileMode.Open,FileAccess.Read);
			sr=new StreamReader(f_inp,System.Text.Encoding.GetEncoding(866));

			Console.WriteLine();
			while((s=sr.ReadLine())!=null)
				Console.WriteLine(s);

			sr.Close();
			if(f_inp.CanRead)
				f_inp.Close();

			f_inp=new FileStream(FileName,FileMode.Open,FileAccess.Read);
			sr=new StreamReader(f_inp);

			byte[]
				UTF8Bytes,
				ASCIIBytes;

			char[]
				ASCIIChars;

			Console.WriteLine();
			while((s=sr.ReadLine())!=null)
			{
				//System.Text.UTF8Encoding
					//utf8=new System.Text.UTF8Encoding();

				//UTF8Bytes=utf8.GetBytes(s);
				//ASCIIBytes=System.Text.Encoding.Convert(utf8,System.Text.Encoding.Default,UTF8Bytes);
				//ASCIIChars=new char[System.Text.Encoding.Default.GetCharCount(ASCIIBytes,0,ASCIIBytes.Length)];
				//System.Text.Encoding.Default.GetChars(ASCIIBytes,0,ASCIIBytes.Length,ASCIIChars,0);
				//s=new string(ASCIIChars);
				s=MyConvert(s,System.Text.Encoding.GetEncoding(65001),System.Text.Encoding.Default);
				//s=System.Text.Encoding.GetEncoding(65001).GetString(System.Text.Encoding.Default.GetBytes(s));
				Console.WriteLine(s);
			}

			sr.Close();
			if(f_inp.CanRead)
				f_inp.Close();

			CompareFileByContent(Directory.GetCurrentDirectory()+"\\..\\..\\bin1.bin",Directory.GetCurrentDirectory()+"\\..\\..\\bin2.bin");
        #endif

        Console.ReadLine();

        return (0);
    }

    static string MyConvert(string value, System.Text.Encoding src, System.Text.Encoding dest)
    {
        System.Text.Decoder
            dec = src.GetDecoder();

        byte[]
            ba = dest.GetBytes(value);

        int
            len = dec.GetCharCount(ba, 0, ba.Length);

        char[]
            ca = new char[len];

        dec.GetChars(ba, 0, ba.Length, ca, 0);

        return (new string(ca));
    }

    #if TEST_FILES
	    private static bool CompareFileByContent(string FileName1, string FileName2)
	    {
		    bool
			    Result=true;

		    byte[]
			    Buff1=null,
			    Buff2=null;

		    BinaryReader
			    InputFile1=null,
			    InputFile2=null;

		    try
		    {
			    try
			    {
				    int
					    BuffSize1=10,
					    BuffSize2=BuffSize1,
					    minBuffSize;

				    while(Buff1==null && BuffSize1!=0)
				    {
					    try
					    {
						    Buff1=new byte[BuffSize1];
					    }
					    catch(OutOfMemoryException)
					    {
						    BuffSize1>>=1;
					    }
				    }
				    if(Buff1==null && BuffSize1==0)
					    throw(new Exception("Insufficient memory"));

				    while(Buff2==null && BuffSize2!=0)
				    {
					    try
					    {
						    Buff2=new byte[BuffSize2];
					    }
					    catch(OutOfMemoryException)
					    {
						    BuffSize2>>=1;
					    }
				    }
				    if(Buff2==null && BuffSize2==0)
					    throw(new Exception("Insufficient memory"));

				    minBuffSize = BuffSize1<BuffSize2 ? BuffSize1 : BuffSize2;

				    InputFile1=new BinaryReader(new FileStream(FileName1,FileMode.Open,FileAccess.Read));
				    if(InputFile1==null || InputFile1.BaseStream==null || !InputFile1.BaseStream.CanRead)
					    throw(new Exception("Can't open file \""+FileName1+"\""));
				    InputFile2=new BinaryReader(new FileStream(FileName2,FileMode.Open,FileAccess.Read));
				    if(InputFile2==null || InputFile2.BaseStream==null || !InputFile2.BaseStream.CanRead)
					    throw(new Exception("Can't open file \""+FileName2+"\""));

				    int
					    i,
					    ReadCount;

				    Result = InputFile1.BaseStream.Length == InputFile2.BaseStream.Length;
				    while(Result && InputFile1.BaseStream.Position<InputFile1.BaseStream.Length)
				    {
					    Array.Clear(Buff1,0,minBuffSize);
					    Array.Clear(Buff2,0,minBuffSize);
					    if(Result=!((ReadCount=InputFile1.Read(Buff1,0,minBuffSize))!=InputFile2.Read(Buff2,0,minBuffSize)))
						    for(i=0; i<ReadCount; ++i)
							    if(Buff1[i]!=Buff2[i])
							    {
								    Result=false;
								    break;
							    }
				    }
			    }
			    catch(Exception eException)
			    {
				    throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			    }
		    }
		    finally
		    {
			    if(InputFile1!=null)
				    InputFile1.Close();
			    if(InputFile2!=null)
				    InputFile2.Close();
		    }

		    return(Result);
	    }
	    //---------------------------------------------------------------------------
    #endif

    #if TEST_REF
		static void TestRef(ref CPoint p, bool IsSerialize, bool IsDeserialize)
		{
			FileStream
				fs;

			BinaryFormatter
				bf=new BinaryFormatter();

			if(IsSerialize)
			{
				fs=new FileStream("CPoint.bin",FileMode.Create);
				bf.Serialize(fs, p);
				fs.Close();
			}

			if(IsDeserialize)
			{
				fs = new FileStream("CPoint.bin",FileMode.Open);
				p=(CPoint)bf.Deserialize(fs);
				fs.Close();
			}
			else
			{
				int
					x=p.x,
					y=p.y;

				p=new CPoint(x*2,y*2);
			}
		}
    #endif
}