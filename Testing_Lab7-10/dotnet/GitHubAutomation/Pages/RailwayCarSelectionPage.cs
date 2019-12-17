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
    class RailwayCarSelectionPage
    {
        private IWebDriver browser;

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:tableEx1:1:ns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_j_id1067828791_3fa5cde2:0:button1")]
        private IWebElement railwayCar { get; set; }

        public RailwayCarSelectionPage(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
            Logger.Log.Debug("RailwayCarSelectionPage init");
        }
        public LoginPage SelectRailwayCar()
        {
            railwayCar.Click();
            Logger.Log.Debug("SelectRailwayCar");
            return new LoginPage(browser);
        }
    }
}
