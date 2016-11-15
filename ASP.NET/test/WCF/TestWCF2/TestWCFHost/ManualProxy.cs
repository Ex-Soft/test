using System;

namespace TestWCFHost
{
    public class ManualProxy : TestWCF.IServiceContract
    {
        private readonly TestWCF.IServiceContract
            _target;

        public static Func<object>
            TargetFactory;

        public ManualProxy()
        {
            _target = (TestWCF.IServiceContract)TargetFactory();
        }

        public string DoSmth(string inp)
        {
            return _target.DoSmth(inp);
        }

        public TestWCF.DataContract DoDmthWithClass(TestWCF.DataContract dataContract)
        {
            return _target.DoDmthWithClass(dataContract);
        }
    }
}
