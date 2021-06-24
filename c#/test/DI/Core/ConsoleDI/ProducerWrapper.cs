using System;

namespace ConsoleDI
{
    public class ProducerWrapper<T> where T : ISpecificRecord, new()
    {
        private readonly Func<IProducer<T>> _producerFactory;

        public ProducerWrapper(Func<IProducer<T>> producerFactory)
        {
            _producerFactory = producerFactory;
        }

        public bool Produce(IBusinessEvent<T> concreteRecord)
        {
            IProducer<T> producer = _producerFactory();
            return producer.Produce(concreteRecord);
        }
    }
}
