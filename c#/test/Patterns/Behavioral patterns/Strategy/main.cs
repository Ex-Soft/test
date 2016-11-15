using System;

namespace Strategy
{
    public interface IStrategy
    {
        void Algorithm();
    }

    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("ConcreteStrategy1.Algorithm()");
        }
    }

    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("ConcreteStrategy2.Algorithm()");
        }
    }

    public class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteOperation()
        {
            _strategy.Algorithm();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new ConcreteStrategy1());
            context.ExecuteOperation();
            context.SetStrategy(new ConcreteStrategy2());
            context.ExecuteOperation();

            Console.ReadLine();
        }
    }
}
