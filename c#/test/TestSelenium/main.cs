using OpenQA.Selenium;
using TestSelenium.ElementSelectors;
using TestSelenium.Extensions;
using TestSelenium.Pages;

namespace TestSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = null;

            try
            {
                webDriver = WebDriverFactory.CreateChromeDriver("http://localhost/html/TestXPath.html");

                MainPage mainPage = new MainPage(webDriver);

                IWebElement
                    div = MainPageSelectors.ByIdSelector("div1").ElementExists().Invoke(webDriver),
                    input;

                if (div != null)
                {
                    var children = div.FindElements(By.XPath("./div"));

                    input = MainPageSelectors.InputSelector.ElementExists().Invoke(webDriver);
                    if (input != null)
                    {
                        input.SendKeys("blah-blah-blah");
                    }
                }
            }
            finally
            {
                if (webDriver != null)
                {
                    webDriver.Quit();
                    webDriver.Dispose();
                    webDriver = null;
                }
            }
        }
    }
}
