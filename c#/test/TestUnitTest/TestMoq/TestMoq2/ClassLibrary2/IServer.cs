using System.Threading.Tasks;

namespace ClassLibrary2
{
    public interface IServer
    {
        Task<string> GetAsync(int millisecondsDelay);
    }
}
