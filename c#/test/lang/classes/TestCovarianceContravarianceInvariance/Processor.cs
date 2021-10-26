using static System.Console;

namespace TestCovarianceContravarianceInvariance
{
    public interface IBase {}
    public class A : IBase {}
    public class B : IBase {}

    public interface IProcessor
    {
        void Process(object obj);
    }

    public interface IProcessor<in T> : IProcessor
        where T : IBase
    {
        void Process(T obj);
    }

    public class Processor<T> : IProcessor<T>
        where T : IBase
    {
        public void Process(object obj)
        {
            Process((T)obj);
        }

        public void Process(T obj)
        {
            var thisType = GetType();
            var objType = obj.GetType();
            WriteLine($"{thisType.Name}{(thisType.IsGenericType ? $"<{thisType.GenericTypeArguments[0].Name}>" : string.Empty)}({objType.Name}{(objType.IsGenericType ? $"<{objType.GenericTypeArguments[0].Name}>" : string.Empty)})");
        }
    }

    public class Worker
    {
        public static void Process(IBase obj)
        {
            IProcessor processor;
            IProcessor<A> processorA = new Processor<A>();
            IProcessor<B> processorB = new Processor<B>();

            switch (obj)
            {
                case A a:
                {
                    processor = processorA;
                    processor.Process(obj);
                    processorA.Process(a);
                    break;
                }
                case B b:
                {
                    processor = processorB;
                    processor.Process(obj);
                    processorB.Process(b);
                    break;
                }
            }
        }

        public static void DoIt()
        {
            Process(new A());
            Process(new B());
        }
    }
}
