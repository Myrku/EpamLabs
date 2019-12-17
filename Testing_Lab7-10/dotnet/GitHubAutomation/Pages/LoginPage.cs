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
    class LoginPage
    {
        private IWebDriver browser;

        [FindsBy(How = How.Name, Using = "login")]
        private IWebElement loginInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "commandExButton")]
        private IWebElement buttonLogin { get; set; }

        public LoginPage(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
            Logger.Log.Debug("LoginPage init");

        }
        public ConfirmRules InputLoginInformation(string Login, string Password)
        {
            loginInput.SendKeys(Login);
            passwordInput.SendKeys(Password);
            buttonLogin.Click();
            Logger.Log.Debug("Input login information " + Login + "/" + Password);
            return new ConfirmRules(browser);
        }
    }
}
