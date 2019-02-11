using System.ServiceModel.Activation;

namespace TestASPnWCFService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TestService : ITestService
    {
        public void DoWork()
        {
        }
    }
}