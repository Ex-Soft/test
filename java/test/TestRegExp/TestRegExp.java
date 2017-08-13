import java.util.regex.*;

public class TestRegExp
{
	public static void main(String[] args)
	{
		String
			InputStr="abc 22-1-2000 zxc";
			
		Pattern
			// p=Pattern.compile("\\d{1,2}[.\\-/]\\d{1,2}[.\\-/]\\d{4}");
			p=Pattern.compile("\\d{1,2}[-./]\\d{1,2}[-./]\\d{4}");
			
		Matcher
			m=p.matcher(InputStr);
			
		while(m.find())
			System.out.println(m.group());
	}
}
