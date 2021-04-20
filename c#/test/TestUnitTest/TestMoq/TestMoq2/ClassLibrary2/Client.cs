using System;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Client : IClient
    {
        private readonly IServer _server;

        public Client(IServer server)
        {
            _server = server;
        }

        public async Task<string> GetAsync(int millisecondsDelay)
        {
            var result = await _server.GetAsync(millisecondsDelay);
            return result;
        }
    }
}
