using System.Threading.Tasks;

namespace ClassLibrary2
{
    public interface IClient
    {
        Task<string> GetAsync(int millisecondsDelay);
    }
}
