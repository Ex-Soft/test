using System.Linq;
using AutoFixture;
using ClassLibrary;

namespace TestXUnit.Fixtures.Customizations
{
    public class CustomerDataWithFiveAddresses : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Address>(composer => composer
                .With(x => x.CountryCode, "CA")
            );

            fixture.Customize<Customer>(composer => composer
                .With(x => x.MiddleName, "MiddleName_MiddleName")
                .With(x => x.Addresses, fixture.CreateMany<Address>(5).ToList())
            );
        }
    }
}
