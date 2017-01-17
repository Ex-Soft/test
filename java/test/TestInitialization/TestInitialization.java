public class TestInitialization
{
	public static void main(String[] args)
	{
		int
			arr[] = new int[10],
			idx;

		arr[idx=3] = foo(idx);
//		arr[idx] = foo(idx=3); // TestInitialization.java:10: variable idx might not have been initialized
//		    ^

		for(int i=0; i<arr.length; ++i)
			System.out.format("[%d]=%d%n", i, arr[i]);
	}

	public static int foo(int param)
	{
		System.out.format("foo(%d)%n",  param);
		return param;
	}
}
