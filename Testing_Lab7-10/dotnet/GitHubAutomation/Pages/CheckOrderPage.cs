using Framework.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    class CheckOrderPage
    {
        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:confirm:confbut")]
        private IWebElement continueBtn { get; set; }

        [FindsBy(How = How.Id, Using = "lnk")]
        private IWebElement place { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:ns_Z7_9HD6HG80NGMO80ABJ9NPD12001_j_id1331390934_4f5b6a1b:0:ns_Z7_9HD6HG80NGMO80ABJ9NPD12001_j_id1331390934_4f5b6d30")]
        private IWebElement FIO { get; set; }



        private IWebDriver browser;

        public CheckOrderPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            this.browser = browser;
            Logger.Log.Debug("CheckOrderPage init");
        }
        public ConfirmOrderPage ClickContinue()
        {
            continueBtn.Click();
            Logger.Log.Debug("ClickContinue on ConfirmOrderPage");
            return new ConfirmOrderPage(browser);
        }

        public string GetPlace()
        {
            Logger.Log.Debug("GetPlace");
            return place.Text;
        }

        public string GetFIO()
        {
            Logger.Log.Debug("GetFIO");
            return FIO.Text;
        }
    }
}
