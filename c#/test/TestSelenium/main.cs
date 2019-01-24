//#define TEST_CODEMIRROR

using OpenQA.Selenium;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                #if TEST_CODEMIRROR
                    webDriver = WebDriverFactory.CreateChromeDriver("http://localhost/JavaScript/test/codemirror/TestCodeMirror.html");

                    IWebElement codeMirror;

                    if ((codeMirror = webDriver.FindElement(By.XPath("//div[contains(@class, 'CodeMirror') and contains(@class, 'CodeMirror-wrap')]"))) != null)
                    {
                        var js = (IJavaScriptExecutor)webDriver;
                        var cmValue = (string)js.ExecuteScript("return arguments[0].CodeMirror.getValue();", codeMirror);
                        Debug.WriteLine(cmValue);

                        js.ExecuteScript("arguments[0].CodeMirror.setValue(arguments[1]);", codeMirror, "arguments[0].CodeMirror.setValue(arguments[1]);");
                    }
                #else
                    webDriver = WebDriverFactory.CreateChromeDriver("http://localhost/html/TestXPath.html");

                    MainPage mainPage = new MainPage(webDriver);

                    IWebElement
                        root = MainPageSelectors.RootSelector.ElementExists().Invoke(webDriver),
                        div,
                        divDiv,
                        input;

                    string
                        tmpString;

                    if ((div = MainPageSelectors.ByIdSelector("div111").ElementExists().Invoke(webDriver)) != null)
                    {
                        divDiv = div.FindElement(By.XPath("./parent::*"));
                        tmpString = divDiv.GetAttribute("id");

                        divDiv = div.FindElement(By.XPath(".."));
                        tmpString = divDiv.GetAttribute("id");
                    }

                    if (root != null)
                    {
                        foreach (IWebElement node in root.AsDepthFirst() /*AsDepthFirst(root)*/)
                        {
                            var text = node.Text;
                            int index;

                            if ((index = text.IndexOf("\r\n")) != -1)
                                text = text.Substring(0, index);

                            Debug.WriteLine(text);
                        }
                        Debug.WriteLine(new string('-', 10));

                        var nodes = root.FindElements(By.XPath("./li"));

                        foreach(IWebElement node in nodes)
                        {
                            var toggler = node.FindElement(By.XPath("./span[contains(@class, 'node-toggler')]"));
                            if (toggler != null)
                            {
                                var nodeNode = node.FindElement(By.XPath("./ul[contains(@class, 'tree-node')]"));
                                var parent1 = toggler.FindElement(By.XPath("./parent::*"));
                                var parent2 = toggler.FindElement(By.XPath(".."));

                                var sibling = toggler.FindElement(By.XPath("./following-sibling::ul"));
                            }
                        }

                        foreach(IWebElement node in root.AsBreadthFirst() /*AsBreadthFirst(root)*/)
                        {
                            var text = node.Text;
                            int index;

                            if ((index = text.IndexOf("\r\n")) != -1)
                                text = text.Substring(0, index);

                            Debug.WriteLine(text);
                        }
                    }

                    if ((div = MainPageSelectors.ByIdSelector("div1").ElementExists().Invoke(webDriver)) != null)
                    {
                        var children = div.FindElements(By.XPath("./div"));

                        input = MainPageSelectors.InputSelector.ElementExists().Invoke(webDriver);
                        if (input != null)
                        {
                            input.SendKeys("blah-blah-blah");
                        }
                    }

                    if ((div = MainPageSelectors.ByIdSelector("div121").ElementExists().Invoke(webDriver)) != null)
                    {
                        if ((input = div.GetWebElement(By.XPath("./input[@type = 'text']"))) != null)
                        {
                            tmpString = input.GetAttribute("class");
                        }
                    }
                #endif
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

        public static IEnumerable<IWebElement> AsDepthFirst(IWebElement node)
        {
            foreach (var childNode in node.FindElements(By.XPath("./li")))
            {
                yield return childNode;

                IWebElement innerNode = null;

                try
                {
                    innerNode = childNode.FindElement(By.XPath("./ul"));
                }
                catch (NoSuchElementException)
                {}

                if (innerNode != null)
                    foreach (var childChildNode in innerNode.AsDepthFirst())
                        yield return childChildNode;
            }
        }

        public static IEnumerable<IWebElement> AsBreadthFirst(IWebElement node)
        {
            var q = new Queue<IWebElement>();

            foreach(var childNode in node.FindElements(By.XPath("./li")))
                q.Enqueue(childNode);

            while (q.Any())
            {
                var current = q.Dequeue();
                var currentText = current.Text;
                if (current != null)
                {
                    try
                    {
                        var innerNode = current.FindElement(By.XPath("./ul"));
                        if (innerNode != null)
                            foreach (var childNode in innerNode.FindElements(By.XPath("./li")))
                                q.Enqueue(childNode);
                    }
                    catch (NoSuchElementException)
                    {}

                    yield return current;
                }
            }
        }
    }

    public static class IWebElementExtensions
    {
        public static IEnumerable<IWebElement> AsDepthFirst(this IWebElement node)
        {
            foreach (var childNode in node.FindElements(By.XPath("./li")))
            {
                yield return childNode;

                IWebElement innerNode = null;

                try
                {
                    innerNode = childNode.FindElement(By.XPath("./ul"));
                }
                catch (NoSuchElementException)
                {}

                if (innerNode != null)
                    foreach(var childChildNode in innerNode.AsDepthFirst())
                        yield return childChildNode;
            }
        }

        public static IEnumerable<IWebElement> AsBreadthFirst(this IWebElement node)
        {
            var q = new Queue<IWebElement>();

            foreach (var childNode in node.FindElements(By.XPath("./li")))
                q.Enqueue(childNode);

            while (q.Any())
            {
                var current = q.Dequeue();
                var currentText = current.Text;
                if (current != null)
                {
                    try
                    {
                        var innerNode = current.FindElement(By.XPath("./ul"));
                        if (innerNode != null)
                            foreach (var childNode in innerNode.FindElements(By.XPath("./li")))
                                q.Enqueue(childNode);
                    }
                    catch (NoSuchElementException)
                    { }

                    yield return current;
                }
            }
        }
    }
}
