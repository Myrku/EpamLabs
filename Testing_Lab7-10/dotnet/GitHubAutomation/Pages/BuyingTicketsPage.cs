using Framework.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    class BuyingTicketsPage
    {
        private IWebDriver browser;

        [FindsBy(How = How.XPath, Using = "//div[@class='tabs']/div/div/div/a")]
         private IWebElement routeSelectionButton { get; set; }

        public BuyingTicketsPage(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
            Logger.Log.Debug("BuyingTicketsPage init");
        }
        public RouteSelectionPage ClickRouteSelectionButton()
        {
            routeSelectionButton.Click();
            Logger.Log.Debug("Click routeSelectionButton");
            return new RouteSelectionPage(browser);
        }
    }
}
