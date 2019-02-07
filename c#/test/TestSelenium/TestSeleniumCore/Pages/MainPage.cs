using OpenQA.Selenium;

namespace TestSeleniumCore.Pages
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
