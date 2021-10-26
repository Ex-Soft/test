using System;
using System.Threading.Tasks;
using Avro.Specific;

namespace MultiTypesWinFormsApp.Consumer
{
    public interface IConsumer : IDisposable
    {
        void SetProcessor(Action<ISpecificRecord> processor);
        void SetOnOk(Action<ISpecificRecord> onOk);
        void SetOnError(Action<ISpecificRecord> onError);
        void Configure(ConsumerConfiguration consumerConfig);
        Task Consume();
    }
}
