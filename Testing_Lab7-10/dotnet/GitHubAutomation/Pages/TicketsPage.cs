using Framework.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class TicketsPage
    {
        private IWebDriver browser;

        [FindsBy(How = How.XPath, Using = "//ul[@class='index-teasers']/li[2]/a")]
        private IWebElement buyingTicketsButton { get; set; }
        public TicketsPage(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
            Logger.Log.Debug("TicketsPage init");
        }
        public BuyingTicketsPage ClickBuyingTicketsButtons()
        {
            buyingTicketsButton.Click();
            Logger.Log.Debug("Click buying ticket");
            return new BuyingTicketsPage(browser);
        }
    }
}
