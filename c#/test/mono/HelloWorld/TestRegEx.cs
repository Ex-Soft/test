using System;
using System.Text.RegularExpressions;
 
public class HelloWorld
{
	static public void Main ()
	{
		string
			str = "cn=1",
			tmpString;

		Regex
			regex = new Regex(@"(?<=cn=)\d+");

		Match
			match = regex.Match(str);

		tmpString = match.Success ? match.Value.Trim() : string.Empty;
		Console.WriteLine(tmpString);

		str = "<ul><p>one</p><p>two</p></ul><ul><p>three</p></ul>";
		regex = new Regex(@"(?<=<ul>)<p>.*?<\/p>(?=<\/ul>)");
		tmpString = regex.Replace(str, "");
		Console.WriteLine(tmpString);

		regex = new Regex(@"(?<=<ul>)<p>.*?<\/p>(?=<\/ul>)");
		tmpString = regex.Replace(str, "");
		Console.WriteLine(tmpString);
	}
}
