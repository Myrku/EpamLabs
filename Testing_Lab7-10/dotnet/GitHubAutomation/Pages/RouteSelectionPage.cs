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
    class RouteSelectionPage
    {
        private IWebDriver browser;

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:textDepStat")]
        private IWebElement departureStationInput { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:textArrStat")]
        private IWebElement arrivalStationInput { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:dob")]
        private IWebElement dateDeparture { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:buttonSearch")]
        private IWebElement buttonSearch { get; set; }

        public RouteSelectionPage(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
            Logger.Log.Debug("RouteSelectionPage init");

        }
        public TrainSelectionPage InputStationsAndClickSearch(string DepartureStation, string ArrivalStation, string date)
        {
            departureStationInput.SendKeys(DepartureStation);
            arrivalStationInput.SendKeys(ArrivalStation);
            dateDeparture.Clear();
            dateDeparture.SendKeys(date.ToString());
            buttonSearch.Click();
            Logger.Log.Debug("Input stations " + DepartureStation + "-" + ArrivalStation + " and click search");
            return new TrainSelectionPage(browser);
        }
    }
}
