using Microsoft.AspNetCore.Mvc;
using org.example;
using TestKafka.Orchestrators;

namespace TestKafka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerOrchestrator _consumerOrchestrator;

        public ConsumerController(IConsumerOrchestrator consumerOrchestrator)
        {
            _consumerOrchestrator = consumerOrchestrator;
        }

        [HttpGet]
        public ActionResult<TestTypes> Get() => Ok(_consumerOrchestrator.Consume());
    }
}
