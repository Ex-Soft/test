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
                webDriver = WebDriverFactory.CreateChromeDriver("http://localhost/html/TestXPath.html");

                MainPage mainPage = new MainPage(webDriver);

                IWebElement
                    root = MainPageSelectors.RootSelector.ElementExists().Invoke(webDriver),
                    div = MainPageSelectors.ByIdSelector("div1").ElementExists().Invoke(webDriver),
                    input;

                if (root != null)
                {
                    foreach (IWebElement node in root.AsDepthFirst())
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
                        }
                    }

                    foreach (IWebElement node in root.AsBreadthFirst() /*AsBreadthFirst(root)*/)
                    {
                        var text = node.Text;
                        int index;

                        if ((index = text.IndexOf("\r\n")) != -1)
                            text = text.Substring(0, index);

                        Debug.WriteLine(text);
                    }
                }

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
            var children = node.FindElements(By.XPath(node.TagName == "ul" ? "./li" : "./ul/li"));

            if (children != null && children.Count() > 0)
                yield return children[0];
            else
                yield return node;
            
            foreach (var node1 in children)
                foreach (var node2 in node1.AsDepthFirst())
                    yield return node2;
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
