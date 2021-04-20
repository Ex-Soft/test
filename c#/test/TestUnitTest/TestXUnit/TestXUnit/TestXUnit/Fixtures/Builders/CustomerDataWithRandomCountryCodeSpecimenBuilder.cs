using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;
using ClassLibrary;

namespace TestXUnit.Fixtures.Builders
{
    public class CustomerDataWithRandomCountryCodeSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            PropertyInfo propertyInfo = request as PropertyInfo;
            if (propertyInfo == null)
            {
                return new NoSpecimen();
            }

            if (propertyInfo.Name != "Addresses" || propertyInfo.PropertyType != typeof(List<Address>))
            {
                return new NoSpecimen();
            }

            List<Address> addresses = new Fixture().CreateMany<Address>(5).ToList();
            
            for (int i = 0; i < addresses.Count; ++i)
            {
                addresses[i].CountryCode = i % 2 == 0 ? "US" : "CA";
            }

            return addresses;
        }
    }
}
