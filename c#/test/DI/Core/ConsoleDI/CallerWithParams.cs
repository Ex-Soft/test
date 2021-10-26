using Microsoft.Extensions.Options;

namespace ConsoleDI
{
    public interface ICallerWithParams
    {
        Params Params { get; }
    }

    public class CallerWithParams : ICallerWithParams
    {
        private readonly Params _params;

        public CallerWithParams(IOptions<Params> @params)
        {
            _params = @params?.Value;
        }

        public Params Params => _params;
    }
}
