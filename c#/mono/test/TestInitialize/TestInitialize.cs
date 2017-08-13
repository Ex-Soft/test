using System;
 
public class TestInitialize
{
	public static void Main ()
	{
		int
			idx;

		int[]
			arr = new int[10];

		//arr[idx=3] = foo(idx); // TestInitialize.cs(13,34): error CS0165: Use of unassigned local variable `idx'
		arr[idx] = foo(idx=3); // [0]=3

		for(int i=0; i<arr.Length; ++i)
			Console.WriteLine("[{0}]={1}", i, arr[i]);
	}

	public static int foo(int param)
	{
		Console.WriteLine("foo({0})", param);
		return param;
	}
}
