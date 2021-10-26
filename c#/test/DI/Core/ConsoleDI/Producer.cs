namespace ConsoleDI
{
    public interface ISpecificRecord
    {}

    public class ConcreteRecord1 : ISpecificRecord
    {}

    public class ConcreteRecord2 : ISpecificRecord
    {}

    public interface IBusinessEvent<out T> where T : ISpecificRecord
    {
        T Value { get; }
    }

    public class BusinessEvent<T> : IBusinessEvent<T> where T : ISpecificRecord
    {
        public T Value { get; set; }
    }

    public interface IProducer
    {
        void Configure();
        bool Produce(IBusinessEvent<ISpecificRecord> businessEvent);
    }

    public interface IProducer<in T> : IProducer where T : ISpecificRecord, new()
    {
        bool Produce(IBusinessEvent<T> businessEvent);
    }

    public class Producer<T> : IProducer<T> where T : ISpecificRecord, new()
    {
        public bool Produce(IBusinessEvent<ISpecificRecord> businessEvent)
        {
            if (businessEvent.Value is T)
            {
                return Produce((IBusinessEvent<T>)businessEvent);
            }

            return false;
        }

        public bool Produce(IBusinessEvent<T> businessEvent)
        {
            return true;
        }

        public void Configure()
        {}
    }
}
