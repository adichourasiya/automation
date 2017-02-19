using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Framework
{
    public static class Browser
    {
        private static IWebDriver _webDriver = new FirefoxDriver();

        private static string _baseUrl = "http://astro.com";

        public static ISearchContext Driver
        {
            get { return _webDriver; } 
        }

        public static string Title { get { return _webDriver.Title; } }

        public static void Goto(string url)
        {
            _webDriver.Navigate().GoToUrl(_baseUrl + url);
        }

        public static void Initialize()
        {
            Goto(".my");
        }

        public static void Close()
        {
            _webDriver.Close();
        }

        public static IJavaScriptExecutor Scripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }

        public static bool Exists(By by)
        {
            if (Driver.FindElements(by).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}