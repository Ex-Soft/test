using System;
 
public class HelloWorld
{
	static public void Main (string[] args)
	{
		Console.WriteLine ("Hello Mono World");

		for (var i = 0; i < args.Length; ++i)
			Console.WriteLine("Arg[{0}]=\"{1}\"", i, args[i]);
	}
}
