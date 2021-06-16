using System;
using System.Threading.Tasks;

namespace MultiTypesWinFormsApp.Consumer
{
    public interface IKafkaConsumer : IDisposable
    {
        Task Consume();
        void Configure(KafkaConsumerConfiguration consumerConfig);
    }
}
