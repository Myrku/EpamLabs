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
    class ConfirmOrderPage
    {
        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:confirm:form1:2:paymentSystem:0")]
        private IWebElement paymentSystem { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:confirm:ns_Z7_9HD6HG80NGMO80ABJ9NPD12001_j_id1989596659_7696dfdb")]
        private IWebElement payBtn { get; set; }


        private IWebDriver browser;

        public ConfirmOrderPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            this.browser = browser;
            Logger.Log.Debug("ConfirmOrderPage init");
        }
        public CardPage ChoicePaymentSystemAndContinue()
        {
            paymentSystem.Click();
            payBtn.Click();
            Logger.Log.Debug("ChoicePaymentSystemAndContinue click");
            return new CardPage(browser);
        }

    }
}
