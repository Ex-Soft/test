using System;

class MyApp
{
	static void Main()
	{
		SimpleMath
			simple=new SimpleMath();

		int
			sum=simple.Add(2,2);

		Console.WriteLine("2 + 2 = {0}",sum);

		ComplexMath complex=new ComplexMath();
		int square=complex.Square(3);
		Console.WriteLine("3 squared = {0}",square);
	}
}