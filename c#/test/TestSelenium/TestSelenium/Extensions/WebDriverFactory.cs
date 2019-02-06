using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace TestSelenium.Extensions
{
    static class WebDriverFactory
    {
        private static string AssemblyLocationDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static IWebDriver CreateChromeDriver(string url)
        {
            return new ChromeDriver(AssemblyLocationDirectory) { Url = url };
        }

        public static IWebDriver CreateEdgeDriver(string url)
        {
            var edgeOptions = new EdgeOptions {AcceptInsecureCertificates = true};
            var edgeDriver = new EdgeDriver(AssemblyLocationDirectory, edgeOptions, TimeSpan.FromMinutes(3));
            edgeDriver.Url = url;
            if (edgeDriver.Title.Contains("Certificate error"))
            {
                edgeDriver.ExecuteScript("javascript:document.getElementById(\'invalidcert_continue\').click()");
            }

            return edgeDriver;
        }
    }
}
