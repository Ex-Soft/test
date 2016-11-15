using Microsoft.Framework.Configuration;
using NUnit.Framework;

namespace WebApp.Demo.Common
{
    public class GenericBuilder
    {
        private IConfigurationRoot _configurationRoot;

        public IConfigurationRoot Settings()
        {
            if (_configurationRoot == null)
            {
                var builder = new ConfigurationBuilder()
                            .AddJsonFile("json/settings.json");

                _configurationRoot = builder.Build();
            }

            return _configurationRoot;
        }

        public string this[string key]
        {
            get
            {
                var value = Settings()[key];

                return value;
            }
        }
    }

    [TestFixture]
    public class GenericBuilderTest
    {
        GenericBuilder _genericBuilder;

        [SetUp]
        public void Setup()
        {
            _genericBuilder = new GenericBuilder();
        }

        [Test]
        public void Given_When_Then()
        {
            var value = _genericBuilder["greeting"];

            Assert.IsNotEmpty(value);
        }
    }
}
