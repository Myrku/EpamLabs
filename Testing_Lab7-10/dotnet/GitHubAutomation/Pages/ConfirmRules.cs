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
    class ConfirmRules
    {
        private IWebDriver browser;

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:form1:conf")]
        private IWebElement confirmation_of_compliance_with_the_rules { get; set; }

        public ConfirmRules(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
            Logger.Log.Debug("ConfirmRules init");
        }
        public InformationPage Confirm()
        {
            confirmation_of_compliance_with_the_rules.Click();
            Logger.Log.Debug("Confirmation of compliance with the rules click");
            return new InformationPage(browser);
        }
    }
}
