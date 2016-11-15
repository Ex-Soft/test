using System;
using System.Reflection;
[assembly:AssemblyKeyFile ("KeyFile.snk")]
[assembly:AssemblyVersion ("1.0.0.0")]

public class ComplexMath
{
	public int Square(int a)
	{
		return(a*a);
	}
}