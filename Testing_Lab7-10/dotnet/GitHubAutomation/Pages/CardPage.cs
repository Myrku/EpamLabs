using Framework.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    class CardPage
    {
        [FindsBy(How = How.Id, Using = "g1")]
        private IWebElement cardPart1 { get; set; }

        [FindsBy(How = How.Id, Using = "g2")]
        private IWebElement cardPart2 { get; set; }

        [FindsBy(How = How.Id, Using = "g3")]
        private IWebElement cardPart3 { get; set; }

        [FindsBy(How = How.Id, Using = "g4")]
        private IWebElement cardPart4 { get; set; }

        [FindsBy(How = How.Id, Using = "ExpireMonth")]
        private IWebElement monthCard { get; set; }

        [FindsBy(How = How.Id, Using = "ExpireYear")]
        private IWebElement yearCard { get; set; }

        [FindsBy(How = How.Id, Using = "Cardholder")]
        private IWebElement cardOwner { get; set; }

        [FindsBy(How = How.Id, Using = "CVC2")]
        private IWebElement cardCode { get; set; }

        [FindsBy(How = How.Id, Using = "button_pay")]
        private IWebElement confirmPayBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "red2")]
        private IWebElement errorMessage { get; set; }

        private IWebDriver browser;

        public CardPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            Logger.Log.Debug("CardPage init");
            this.browser = browser;
        }

        public CardPage InputData(string p1, string p2, string p3, string p4, string month, string year, string owner, string code)
        {
            cardPart1.SendKeys(p1);
            cardPart2.SendKeys(p2);
            cardPart3.SendKeys(p3);
            cardPart4.SendKeys(p4);
            monthCard.SendKeys(month);
            yearCard.SendKeys(year);
            cardOwner.SendKeys(owner);
            cardCode.SendKeys(code);
            Logger.Log.Debug("Введены данные: " + p1 + "-" + p2 + "-" + p3 + "-" + "p4" + ":" + code + " " + month + "/" + year + " " + owner);
            return this;
        }

        public CardPage ConfirmPay()
        {
            confirmPayBtn.Click();
            Logger.Log.Debug("Click ConfirmPay");
            return this;
        }

        public string GetError()
        {
            Logger.Log.Debug("Get error CardPage");
            return errorMessage.Text;
        }
    }
}
