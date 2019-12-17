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
    class TrainSelectionPage
    {
        private IWebDriver browser;

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form2:tableEx1:1:rowSelect1:0")]
        private IWebElement train { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:message2")]
        private IWebElement errorMessage { get; set; }


        public TrainSelectionPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            this.browser = browser;
            Logger.Log.Debug("TrainSelectionPage init");
        }
        public RailwayCarSelectionPage SelectTrain()
        {
            train.Click();
            Logger.Log.Debug("Select train");
            return new RailwayCarSelectionPage(browser);
        }

        public string GetError()
        {
            Logger.Log.Debug("Get error train selection");
            return errorMessage.Text;
        }

    }
}
