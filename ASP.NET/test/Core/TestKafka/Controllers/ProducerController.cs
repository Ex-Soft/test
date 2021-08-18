using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using org.example;
using TestKafka.Orchestrators;

namespace TestKafka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : Controller
    {
        private readonly IProducerOrchestrator _producerOrchestrator;

        public ProducerController(IProducerOrchestrator producerOrchestrator)
        {
            _producerOrchestrator = producerOrchestrator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TestTypes testTypes)
        {
            await _producerOrchestrator.Produce(testTypes);
            return Ok();
        }
    }
}
