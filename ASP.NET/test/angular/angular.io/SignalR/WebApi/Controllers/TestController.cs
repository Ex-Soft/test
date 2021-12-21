using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TestController : ControllerBase
    {
        private readonly IHubContext<CustomHub> _customHub;
        // private readonly IHubContext<CustomHub, IClientInterface> _customHub;

        public TestController(
            IHubContext<CustomHub> customHub
            // IHubContext<CustomHub, IClientInterface> customHub
        )
        {
            _customHub = customHub;
        }

        [HttpGet("/send")]
        public async Task<IActionResult> SendData()
        {
            await _customHub.Clients.All.SendAsync("client_function_name", new Data(100, "Dummy Data"));
            return Ok();
        }
    }
}
