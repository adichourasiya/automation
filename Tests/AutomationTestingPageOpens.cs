using Framework;
using Framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net;

namespace Tests
{
    [TestClass]
    public class AutomationTestingPageOpens : TestBase
    {
        [TestMethod]
        public void VerifyPageLoad()
        {
            var time0 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;                  //start timer

            //STEP 1 - a - Load www.astro.com.my            
            Pages.launch.GotoAstroMyPage();
            Assert.IsTrue(Pages.launch.IsAtMyPage(), "Step 1 Failure : Could not reach to My Page");
            var time1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;                  //Step 1 complete

            /*STEP 2 - b - Verify the page loads within .1 seconds – capture failure; but go to next step
             *         c - Verify the page loads within 5 seconds  */
            long loadtime = (long)((IJavaScriptExecutor)Browser.Driver).ExecuteScript("return performance.timing.loadEventEnd - performance.timing.navigationStart; ");
            int pageLoadTime = (int)(loadtime) / 1000;
            if (pageLoadTime < 20)
            {
                if (pageLoadTime > 0.1)
                {
                    Console.WriteLine("Step 2 Warning : Page didn't load in 0.1 sec");
                }
            }
            else
            {
                Assert.Fail("Step 2 Failure : Page didn't load in 20 sec");
            }
            Console.WriteLine(("Note : Total Time for page load " + pageLoadTime + "sec."));
            var time2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;                   //Step 2 complete                    
        }

        //STEP 3 - d = Verify the page loads completely without error 
        [TestMethod]
        public void VerifyPageLinks()
        {
            Pages.launch.GotoAstroMyPage();
            Assert.IsTrue(Pages.launch.IsAtMyPage(), "Could not reach to My Page");
            if (!Browser.Exists(By.LinkText("Melayu")))
            { Assert.Fail("Page didn't load completely ; link in footer is missing."); }
            var time3 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;                   //Step 3 complete                    

        //STEP 4 - e = Ensure none of the links within this page results in a non 200 header response
        IList<IWebElement> links = Browser.Driver.FindElements(By.CssSelector("a"));
            Console.WriteLine("Total "+links.Count+" links found");
            for (int i = 0; i < links.Count; i++)
            {
                try
                {
                    string url = links[i].ToString();
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    request.Method = "GET";
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    response.Close();
                    bool rc = (response.StatusCode == HttpStatusCode.OK);
                }
                catch
                {
                    //Any exception will returns false.
                    
                }
            }

            //f = Ensure none of the links within this page results in a non 200 header response

        }
    }
}
