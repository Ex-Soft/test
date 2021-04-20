using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.Mapping;
using WebApi.Models;
using Xunit;

namespace WebApi.Tests
{
    public class HomeControllerTests
    {
        private readonly IMapper _mapper;
        
        public HomeControllerTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Class1Profile>();
                cfg.AddProfile<Class2Profile>();
            });

            _mapper = new Mapper(config);
        }

        [Fact]
        [Trait("UnitTestTarget", "HomeController")]
        public async void TestClass1()
        {
            // Arrange
            Class1Request request = new Class1Request { P1 = "P1 (test)" };

            // Act
            HomeController controller = CreateController();
            var response = await controller.TestClass1(request);

            // Assert
            Class1Response class1Response = Assert.IsType<Class1Response>(((ObjectResult)response.Result).Value);
            Assert.Equal("P1 (test)", class1Response.P1);
            Assert.Equal("P2 (request)", class1Response.P2);
            Assert.Equal("P3 (dto)", class1Response.P3);
            Assert.Equal("P4 (response)", class1Response.P4);
        }

        [Fact]
        [Trait("UnitTestTarget", "HomeController")]
        public async void TestClass2()
        {
            // Arrange
            Class2Request request = new Class2Request { P1 = "P1 (test)" };

            // Act
            HomeController controller = CreateController();
            var response = await controller.TestClass2(request);

            // Assert
            Class2Response class2Response = Assert.IsType<Class2Response>(((ObjectResult)response.Result).Value);
            Assert.Equal("P1 (test)", class2Response.P1);
            Assert.Equal("P2 (request)", class2Response.P2);
            Assert.Equal("P3 (dto)", class2Response.P3);
            Assert.Equal("P4 (response)", class2Response.P4);
        }

        private HomeController CreateController()
        {
            return new HomeController(_mapper);
        }
    }
}
