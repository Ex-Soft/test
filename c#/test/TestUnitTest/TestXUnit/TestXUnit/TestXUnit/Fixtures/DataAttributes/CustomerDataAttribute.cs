using AutoFixture;
using AutoFixture.Xunit2;
using TestXUnit.Fixtures.Customizations;

namespace TestXUnit.Fixtures.DataAttributes
{
    public class CustomerDataAttribute : AutoDataAttribute
    {
        public CustomerDataAttribute() : base(() =>
            new Fixture()
                .Customize(new CustomerDataWithFiveAddresses()))
        { }
    }
}
