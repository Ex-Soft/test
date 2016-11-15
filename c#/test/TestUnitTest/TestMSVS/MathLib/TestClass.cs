namespace MathLib
{
	public class TestClass
	{
		public int mul(int x, int y)
		{
			return x * y;
		}

		public int div(int x, int y)
		{
			return y != 0 ? x / y : int.MaxValue;
		}
	}
}
