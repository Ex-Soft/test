using System.Diagnostics;

namespace ConsoleDIHost
{
    public interface ICaller
    {}
    
    public class Caller : ICaller
    {
        private readonly IParam1 _param1;
        private readonly IParam3 _param3;
        private readonly IParam2 _param2;

        public Caller() : this(null, null, null)
        {
            Debug.WriteLine("Caller()");
        }

        public Caller(IParam1 param1) : this(param1, null, null)
        {
            Debug.WriteLine("Caller(IParam1)");
        }

        public Caller(IParam1 param1, IParam2 param2) : this(param1, param2, null)
        {
            Debug.WriteLine("Caller(IParam1, IParam2)");
        }

        public Caller(IParam1 param1, IParam2 param2, IParam3 param3)
        {
            Debug.WriteLine("Caller(IParam1, IParam2, IParam3)");

            _param1 = param1;
            _param2 = param2;
            _param3 = param3;
        }
    }
}
