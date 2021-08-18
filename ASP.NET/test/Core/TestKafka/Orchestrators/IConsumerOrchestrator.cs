using org.example;

namespace TestKafka.Orchestrators
{
    public interface IConsumerOrchestrator
    {
        TestTypes Consume();
    }
}
