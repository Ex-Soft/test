using OpenQA.Selenium;

namespace TestSelenium.Pages
{
    public class MainPage
    {
        private IWebDriver _webDriver;

        public MainPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
