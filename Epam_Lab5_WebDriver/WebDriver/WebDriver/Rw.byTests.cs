using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab5_WebDriver
{
    [TestClass]
    public class Rw_by_Tests
    {
        IWebDriver Browser;

        [TestMethod]
        public void Buying_a_ticket_without_specifying_the_station_of_departure_and_arrival()
        {
            //Тест кейс 2: Покупка билета без указания станции отправления и прибытия
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl("http://rw.by");
            Browser.FindElement(By.XPath("//*[@id='main_menu']/div/table/tbody/tr/td[3]/a/em/u/b")).Click();
            Browser.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div[3]/div[2]/div[2]/div/ul/li[2]/a/img")).Click();
            Browser.FindElement(By.XPath("/html/body/div/div[2]/div[1]/div[1]/div/div/a")).Click();
            Browser.FindElement(By.Id("viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:buttonSearch")).Click();

            Assert.AreEqual("Не задана станция отправления", 
                Browser.FindElement(By.Id("viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:message1")).Text);

            Assert.AreEqual("Не задана станция прибытия",
                Browser.FindElement(By.Id("viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:message2")).Text);
            Browser.Quit();
        }
        [TestMethod]
        public void Enter_the_same_cities_for_departure_and_arrival()
        {
            //Тест кейс 1: Ввод одинаковых городов для отправления и прибытия
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl("http://rw.by");
            Browser.FindElement(By.XPath("//*[@id='main_menu']/div/table/tbody/tr/td[3]/a/em/u/b")).Click();
            Browser.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div[3]/div[2]/div[2]/div/ul/li[2]/a/img")).Click();
            Browser.FindElement(By.XPath("/html/body/div/div[2]/div[1]/div[1]/div/div/a")).Click();
            Browser.FindElement(By.Id("viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:textDepStat")).SendKeys("ГОМЕЛЬ");
            Browser.FindElement(By.Id("viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:textArrStat")).SendKeys("ГОМЕЛЬ");
            Browser.FindElement(By.Id("viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:buttonSearch")).Click();
            Browser.FindElement(By.Id("viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:buttonSearch")).Click();

            Assert.AreEqual("Станции отправления и назначения не должны совпадать", 
                Browser.FindElement(By.Id("viewns_Z7_9HD6HG80NOK1E0ABJMNO3H30S1_:form1:message2")).Text);

            Browser.Quit();
        }
    }
}

