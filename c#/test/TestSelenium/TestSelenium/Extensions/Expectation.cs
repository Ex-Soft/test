using System;
using OpenQA.Selenium;

namespace TestSelenium.Extensions
{
    public static class Expectation
    {
        public static Func<ISearchContext, IWebElement> ElementExists(this By locator)
        {
            return context =>
            {
                try
                {
                    return context.FindElement(locator);
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            };
        }
    }
}
