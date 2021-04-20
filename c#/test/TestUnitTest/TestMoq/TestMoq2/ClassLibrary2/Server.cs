using System.Reflection;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Server : IServer
    {
        public async Task<string> GetAsync(int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
            return $"{MethodBase.GetCurrentMethod().Name}()";
        }
    }
}
