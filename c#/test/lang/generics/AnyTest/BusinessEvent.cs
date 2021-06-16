using System;

namespace AnyTest
{
    public interface ISpecificRecord
    {}

    public class SpecificRecord : ISpecificRecord
    {}

    public interface IBusinessEvent<out T> where T : ISpecificRecord
    {
        T Value { get; }
    }
    public class BusinessEvent<T> : IBusinessEvent<T> where T : ISpecificRecord
    {
        public T Value { get; set; }
    }

    public interface IBusinessEventSource<T>
    {
        IConsumer<T> Consumer { get; set; }
        Func<T, IBusinessEvent<ISpecificRecord>> Converter { get; set; }
    }

    public class BusinessEventSource<T> : IBusinessEventSource<T>
    {
        private IConsumer<T> _consumer;

        public IConsumer<T> Consumer
        {
            get => _consumer;
            set
            {
                _consumer = value;
                _consumer.Foo = Processor;
            }
        }

        public Func<T, IBusinessEvent<ISpecificRecord>> Converter { get; set; } = null;

        public void Processor(T value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            IBusinessEvent<ISpecificRecord> businessEvent;
            if (Converter != null)
            {
                businessEvent = Converter(value);
            }
            else
            {
                businessEvent = value as IBusinessEvent<ISpecificRecord>;
            }
            System.Diagnostics.Debug.WriteLine(businessEvent);
        }
    }

    public class ConsumerResult<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    public interface IConsumer<T>
    {
        Action<T> Foo { get; set; }
    }

    public class Consumer1<T> : IConsumer<T>
        where T : ConsumerResult<string, ISpecificRecord>
    {
        public Action<T> Foo { get; set; }
    }

    public class Consumer2<T> : IConsumer<T>
        where T : IBusinessEvent<ISpecificRecord>
    {
        public Action<T> Foo { get; set; }
    }

    public class BusinessEventSourceRunner
    {
        public static void Run()
        {
            IBusinessEventSource<ConsumerResult<string, ISpecificRecord>> source1 = new BusinessEventSource<ConsumerResult<string, ISpecificRecord>>();
            source1.Consumer = new Consumer1<ConsumerResult<string, ISpecificRecord>>();
            source1.Converter = Converter1;
            source1.Consumer.Foo(new ConsumerResult<string, ISpecificRecord>());

            IBusinessEventSource<IBusinessEvent<ISpecificRecord>> source2 = new BusinessEventSource<IBusinessEvent<ISpecificRecord>>();
            source2.Consumer = new Consumer2<IBusinessEvent<ISpecificRecord>>();
            source2.Consumer.Foo(new BusinessEvent<ISpecificRecord>());
        }

        public static IBusinessEvent<ISpecificRecord> Converter1(ConsumerResult<string, ISpecificRecord> value)
        {
            return new BusinessEvent<ISpecificRecord>();
        }
    }
}
