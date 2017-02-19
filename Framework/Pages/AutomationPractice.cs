using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Pages
{
    public class astroAssignment
    {
        public void GotoAstroMyPage()
        {
            Browser.Goto(".my");
            if (Browser.Exists(By.Id("continue")))
            {
                IWebElement anchor = Browser.Driver.FindElement(By.Id("continue"));
                anchor.Click();               
            }                       
        }

        public bool IsAtMyPage()
        {
            return (Browser.Title.Contains("Astro"));
        }
    }
}