#define TEST_INTERFACE_WITH_GENERIC

using System;

namespace InterfaceGeneric
{
	#if TEST_INTERFACE_WITH_GENERIC
	public interface ICommonRun
	{
		void Run();
	}

	public class Class1 : ICommonRun
	{
		public void Run()
		{
			Console.WriteLine("Class1::Run()");
		}
	}

	public class Class2 : ICommonRun
	{
		public void Run()
		{
			Console.WriteLine("Class2::Run()");
		}
	}

	public interface ICommonRunRun
	{
		void RunRun();
	}

	public class Common<T> : ICommonRunRun where T : ICommonRun, new()
	{
		ICommonRun
			tmp = new T();

		public void RunRun()
		{
			tmp.Run();
		}
	}
	#endif

    /*    
    public class BasicMathWrong<T>
    {
        public T Add(T left, T right)
        {
            return (left + right); // Operator '+' cannot be applied to operands of type 'T' and 'T'
        }

        public T Subtract(T left, T right)
        {
            return (left - right); // Operator '-' cannot be applied to operands of type 'T' and 'T'
        }

        public T Multiply(T left, T right)
        {
            return (left * right); // Operator '*' cannot be applied to operands of type 'T' and 'T'
        }

        public T Divide(T left, T right)
        {
            return (left / right); // Operator '/' cannot be applied to operands of type 'T' and 'T'
        }
    }
    */

    public interface IBinaryOperations<T>
    {
        T Add(T left, T right);
        T Subtract(T left, T right);
        T Multiply(T left, T right);
        T Divide(T left, T right);
    }

    public class BasicMath : IBinaryOperations<int>, IBinaryOperations<double>, IBinaryOperations<decimal>
    {
        public int Add(int left, int right)
        {
            return(left+right);
        }

        public int Subtract(int left, int right)
        {
            return(left-right);
        }

        public int Multiply(int left, int right)
        {
            return(left*right);
        }

        public int Divide(int left, int right)
        {
            return(left/right);
        }

        public double Add(double left, double right)
        {
            return (left + right);
        }

        public double Subtract(double left, double right)
        {
            return (left - right);
        }

        public double Multiply(double left, double right)
        {
            return (left * right);
        }

        public double Divide(double left, double right)
        {
            return (left / right);
        }

        public decimal Add(decimal left, decimal right)
        {
            return (left + right);
        }

        public decimal Subtract(decimal left, decimal right)
        {
            return (left - right);
        }

        public decimal Multiply(decimal left, decimal right)
        {
            return (left * right);
        }

        public decimal Divide(decimal left, decimal right)
        {
            return (left / right);
        }
    }

    class Program
    {
        static void Main()
        {
			#if TEST_INTERFACE_WITH_GENERIC
        	Common<Class1>
        		c1=new Common<Class1>();

			Common<Class2>
				c2=new Common<Class2>();

			c1.RunRun();
			c2.RunRun();

        	ICommonRunRun
        		c12;

        	c12 = new Common<Class1>();
			c12.RunRun();
        	c12 = new Common<Class2>();
			c12.RunRun();
			#endif

            BasicMath
                a=new BasicMath();

            a.Add(1, 1);
            a.Subtract(1, 1);
            a.Multiply(1, 1);
            a.Divide(1, 1);

            a.Add(1.1, 1.1);
            a.Subtract(1.1, 1.1);
            a.Multiply(1.1, 1.1);
            a.Divide(1.1, 1.1);

            a.Add(1.1m, 1.1m);
            a.Subtract(1.1m, 1.1m);
            a.Multiply(1.1m, 1.1m);
            a.Divide(1.1m, 1.1m);
        }
    }
}
