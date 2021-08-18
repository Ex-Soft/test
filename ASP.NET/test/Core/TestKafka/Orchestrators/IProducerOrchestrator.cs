using System.Threading.Tasks;
using org.example;

namespace TestKafka.Orchestrators
{
    public interface IProducerOrchestrator
    {
        Task Produce(TestTypes testTypes);
    }
}
