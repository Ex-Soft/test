using OpenQA.Selenium;

namespace TestSeleniumCore.Extensions
{
    public static class WebElementExtensions
    {
        public static IWebElement GetWebElement(this IWebElement webElement, By selector)
        {
            IWebElement result;

            try
            {
                result = webElement.FindElement(selector);
            }
            catch (NoSuchElementException)
            {
                result = null;
            }

            return result;
        }
    }
}
