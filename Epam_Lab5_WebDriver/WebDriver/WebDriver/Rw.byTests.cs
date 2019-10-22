using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebDriver
{
    [TestClass]
    public class Rw_by_Tests
    {
        //IWebDriver Browser;
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("http://google.com");

            Thread.Sleep(5000);

            //Browser.Quit();

        }
    }
}
