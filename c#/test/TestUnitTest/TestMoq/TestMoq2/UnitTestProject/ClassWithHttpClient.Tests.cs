// https://dev.to/gautemeekolsen/how-to-test-httpclient-with-moq-in-c-2ldp
// https://stackoverflow.com/questions/57091410/unable-to-mock-httpclient-postasync-in-unit-tests
// https://stackoverflow.com/questions/44715602/mock-httpclient-using-moq

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using KellermanSoftware.CompareNetObjects;

namespace UnitTestProject
{
    /*
    public class DelegatingHandlerStub : DelegatingHandler
    {
        private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handlerFunc;

        public DelegatingHandlerStub()
        {
            _handlerFunc = (request, cancellationToken) => Task.FromResult(request.CreateResponse(HttpStatusCode.OK));
        }

        public DelegatingHandlerStub(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handlerFunc)
        {
            _handlerFunc = handlerFunc;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _handlerFunc(request, cancellationToken);
        }
    }
    */

    public class ClassWithHttpClientWrapper : ClassWithHttpClient
    {
        public ClassWithHttpClientWrapper(string uri) : base(uri)
        {}

        public HttpClient Client
        {
            get => _client;
            set => _client = value;
        }

        public Uri Uri => _uri;
    }

    [TestClass]
    public class ClassWithHttpClientTests
    {
        [TestMethod]
        public async Task FooAsync()
        {
            // Arrange
            Mock<HttpMessageHandler> mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            ClassWithHttpClientWrapper sut = new ClassWithHttpClientWrapper("http://www.google.com/")
            {
                Client = new HttpClient(mockHttpMessageHandler.Object)
            };

            // Act
            await sut.FooAsync();

            // Assert
            mockHttpMessageHandler.Protected()
                .Verify<Task<HttpResponseMessage>>(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(p =>
                        new CompareLogic().Compare(new Uri("http://www.google.com/"), p.RequestUri).AreEqual
                        && p.Content.ReadAsStringAsync().Result == "{\"id\":1}"),
                    ItExpr.IsAny<CancellationToken>());
        }

        [TestMethod]
        public async Task FooAsyncThrowsException()
        {
            // Arrange
            Mock<HttpMessageHandler> mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            _ = mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new Exception("ExceptionMessage"));

            ClassWithHttpClientWrapper sut = new ClassWithHttpClientWrapper("http://www.google.com/")
            {
                Client = new HttpClient(mockHttpMessageHandler.Object)
            };

            // Act
            await sut.FooAsync();

            // Assert
            mockHttpMessageHandler.Protected()
                .Verify<Task<HttpResponseMessage>>(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(p =>
                        new CompareLogic().Compare(new Uri("http://www.google.com/"), p.RequestUri).AreEqual
                        && p.Content.ReadAsStringAsync().Result == "{\"id\":1}"),
                    ItExpr.IsAny<CancellationToken>());
        }

        /*
        [Fact]
        public async Task Log()
        {
            // Arrange
            const string expectedBaseLoggingUrl = "http://test-base-logging-url/";

            _ = _mockOptions.Setup(x => x.Value)
                .Returns(new AdjustmentAlertOptions
                {
                    AppId = "TestAppId",
                    BaseLoggingUrl = expectedBaseLoggingUrl
                });

            Task<string> content;

            Task<HttpResponseMessage> HandlerFunc(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                content = request.Content.ReadAsStringAsync();
                return Task.FromResult(request.CreateResponse(HttpStatusCode.OK));
            }

            DelegatingHandlerStub handlerStub = new DelegatingHandlerStub(HandlerFunc);

            SplunkLoggingServiceToTest sut = new SplunkLoggingServiceToTest(_mockOptions.Object)
            {
                Client = new HttpClient(handlerStub)
            };

            // Act
            await sut.Log("TestMessage", LogLevels.Warning, "TestLogType");
        }
        */
    }
}
