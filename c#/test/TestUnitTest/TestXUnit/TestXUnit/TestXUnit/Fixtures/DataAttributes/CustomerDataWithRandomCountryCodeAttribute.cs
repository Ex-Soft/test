using AutoFixture;
using AutoFixture.Xunit2;
using TestXUnit.Fixtures.Customizations;

namespace TestXUnit.Fixtures.DataAttributes
{
    public class CustomerDataWithRandomCountryCodeAttribute : AutoDataAttribute
    {
        public CustomerDataWithRandomCountryCodeAttribute() : base(() =>
            new Fixture()
                .Customize(new CustomerDataWithRandomCountryCode())
        )
        { }
    }
}
