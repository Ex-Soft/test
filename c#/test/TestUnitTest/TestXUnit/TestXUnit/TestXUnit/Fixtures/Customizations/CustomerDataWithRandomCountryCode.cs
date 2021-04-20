using AutoFixture;
using TestXUnit.Fixtures.Builders;

namespace TestXUnit.Fixtures.Customizations
{
    public class CustomerDataWithRandomCountryCode : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new CustomerDataWithRandomCountryCodeSpecimenBuilder());
        }
    }
}
