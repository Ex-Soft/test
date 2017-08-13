public class HelloWorld
{
	public static void main(String[] args)
	{
		System.out.println("Hello, World.");

		for(int i=0; i<args.length; ++i)
			System.out.println("Arg["+i+"]=\""+args[i]+"\"");

		Object
			o=null;

		if(o==null)
		{
			System.out.println("o==null");
		}
		else
		{
			System.out.println("o!=null");
		}

		if(o!=null)
		{
			System.out.println("o!=null");
		}
		else
		{
			System.out.println("o==null");
		}

		System.out.println(o==null?"o==null":"o!=null");
		System.out.println(o!=null?"o!=null":"o==null");
	}
}
