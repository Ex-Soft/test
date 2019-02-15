using System.ServiceModel.Activation;

namespace TestASPnWCFService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TestService2 : ITestService2
    {
        public void DoWork()
        {
        }
    }
}