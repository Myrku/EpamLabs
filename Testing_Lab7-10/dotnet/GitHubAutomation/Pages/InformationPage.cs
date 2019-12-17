using Framework.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    class InformationPage
    {
        private IWebDriver browser;

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:pass:tableEx1:0:lastname")]
        private IWebElement surnameInput { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:pass:tableEx1:0:name")]
        private IWebElement nameInput { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:pass:tableEx1:0:docNum")]
        private IWebElement passportNumberInput { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:pass:conf")]
        private IWebElement validationInput { get; set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:pass:tableEx1:0:ns_Z7_9HD6HG80NGMO80ABJ9NPD12001_j_id382307458_16c98699")]
        public IWebElement Error_Invalid_Passport_Number_Test { get; private set; }

        [FindsBy(How = How.Id, Using = "viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:pass:tableEx1:0:ns_Z7_9HD6HG80NGMO80ABJ9NPD12001_j_id382307458_16c98699")]
        public IWebElement Error_Buying_A_Ticket_Without_Specifying_Customer_Information_Test { get; private set; }

        //[FindsBy(How = How.Id, Using = "lnk_36_3_")]
        //public IWebElement Place { get; private set; }

        public InformationPage(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
            Logger.Log.Debug("InformationPage init");
        }
        public InformationPage InputCustomerInformation(string Surname, string Name, string PassportNumber)
        {
            surnameInput.SendKeys(Surname);
            nameInput.SendKeys(Name);
            passportNumberInput.SendKeys(PassportNumber);
            validationInput.Click();
            Logger.Log.Debug("Input customer info: " + Surname + " " + Name + " " + PassportNumber);
            return this;
        }
        public InformationPage SelectPlace(string place)
        {
            IWebElement Place = browser.FindElement(By.Id("lnk_" + place));
            Place.Click();
            Logger.Log.Debug("Select place "+place);
            return this;
        }
        public CheckOrderPage InputCustomerInformationWithMoveToNextPage(string Surname, string Name, string PassportNumber, string place)
        {
            surnameInput.SendKeys(Surname);
            nameInput.SendKeys(Name);
            passportNumberInput.SendKeys(PassportNumber);
            IWebElement Place = browser.FindElement(By.Id("lnk_" +place));
            Place.Click();
            validationInput.Click();
            Logger.Log.Debug("Input customer info: " + Surname + " " + Name + " " + PassportNumber +", place " + Place + " and move to next page");
            return new CheckOrderPage(browser);
        }
        public string GetErrorInvalidPassport()
        {
            Logger.Log.Debug("GetErrorInvalidPassport");
            return Error_Invalid_Passport_Number_Test.Text;
        }
        public string GetErrorBuyingTicket()
        {
            Logger.Log.Debug("GetErrorBuyingTicket");
            return Error_Buying_A_Ticket_Without_Specifying_Customer_Information_Test.Text;
        }

    }
}
