using System;
using System.IO;
using Framework.Driver;
using Framework.Services;
using log4net;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Framework.Tests
{
    public class TestConfig
    {
        private static ILog Log = LogManager.GetLogger("LOGGER");
        protected IWebDriver Browser { get; set; }


        [SetUp]
        public void Setter()
        {
            Browser = DriverSingleton.GetDriver();
            Logger.InitLogger();
            Logger.Log.Debug("Browser init");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Browser.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
                Logger.Log.Error(TestContext.CurrentContext.Result.Message);
            }
            DriverSingleton.CloseDriver();
        }
    }
}
