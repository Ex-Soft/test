using System;
using OpenQA.Selenium;

namespace TestSeleniumCore.ElementSelectors
{
    public static class MainPageSelectors
    {
        public static Func<string, By> ByIdSelector = id => By.XPath($"//*[@id='{id}']");
        public static By InputSelector = By.XPath("//input[@type='text']");
        public static By RootSelector = By.CssSelector(".component-content .tree-wrapper .tree-node.tree-root");
    }
}
