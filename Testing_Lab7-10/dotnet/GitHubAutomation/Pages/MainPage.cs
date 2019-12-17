using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Services;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    class MainPage
    {
        private static ILog Log = LogManager.GetLogger("LOGGER");
        private IWebDriver browser;

        [FindsBy(How = How.XPath, Using = "//*[@id='main_menu']/div/table/tbody/tr/td[3]/a/em/u/b")]
        private IWebElement ticketsButton { get; set; }

        public MainPage(IWebDriver browser)
        {
            Logger.InitLogger();
            this.browser = browser;
            PageFactory.InitElements(browser, this);
            Logger.Log.Debug("MainPage init");
        }
        public TicketsPage ClickTicketsButton()
        {
            ticketsButton.Click();
            Logger.Log.Debug("ClickTicketsButton");
            return new TicketsPage(browser);
        }
    }
}
