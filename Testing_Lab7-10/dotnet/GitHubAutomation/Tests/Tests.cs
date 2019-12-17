using Framework.Models;
using Framework.Pages;
using Framework.Services;
using log4net;
using NUnit.Framework;

namespace Framework.Tests
{
    class Tests : TestConfig
    {
        private static ILog Log = LogManager.GetLogger("LOGGER");
        [Test]
        [Category("SearchTest")]
        public void IdenticalStations()
        {
            //Тест кейс 1: Ввод одинаковых городов для отправления и прибытия
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            TrainSelectionPage trainSelection = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
            .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCity, new Route().DepartureCity, new Route().DateDeparture);
            Assert.AreEqual("Станции отправления и назначения не должны совпадать", trainSelection.GetError());
            Logger.Log.Debug("Test complete successfully");
        }

        [Test]
        [Category("DataTest")]
        public void WithoutStations()
        {
            //Тест кейс 2: Покупка билета без указания станции отправления и прибытия
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            TrainSelectionPage trainSelection = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
            .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCityEmpty, new Route().ArrivalCityEmpty, new Route().DateDeparture);
            Assert.AreEqual("Не задана станция прибытия", trainSelection.GetError());
            Logger.Log.Debug("Test complete successfully");
        }

        [Test]
        [Category("DateTest")]
        public void BuyingTicketWithoutCustomerInformation()
        {
            //Тест кейс 3: Покупка билета без указания данных о покупателе
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            InformationPage informationPage = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
            .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCity, new Route().ArrivalCity, new Route().DateDeparture)
            .SelectTrain().SelectRailwayCar().InputLoginInformation(new User().Login, new User().Password).Confirm()
            .InputCustomerInformation(new Customer().surname, new Customer().name, new Customer().passport);
            Assert.AreEqual("Номер документа не соответствует формату: с 3 по 9 символы должн быть цифры", informationPage.GetErrorBuyingTicket());
            Logger.Log.Debug("Test complete successfully");
        }

        [Test]
        [Category("DataTest")]
        public void InvalidPassportNumber()
        {
            //Тест кейс 4: Указание неверного номера пасспорта
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            InformationPage informationPage = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
            .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCity, new Route().ArrivalCity, new Route().DateDeparture)
            .SelectTrain().SelectRailwayCar().InputLoginInformation(new User().Login, new User().Password).Confirm()
            .InputCustomerInformation(new CustomerEmpty().surname, new CustomerEmpty().name, new CustomerEmpty().passport);
            Assert.AreEqual("Данное поле обязательно для ввода", informationPage.GetErrorInvalidPassport());
            Logger.Log.Debug("Test complete successfully");
        }

        [Test]
        [Category("DataTest")]
        public void InvalidCardInfo()
        {
            //Тест кейс 5: Покупка билета с указанием неверных дыных карты для оплаты
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            CardPage cardPage = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
            .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCity, new Route().ArrivalCity, new Route().DateDeparture)
            .SelectTrain().SelectRailwayCar().InputLoginInformation(new User().Login, new User().Password).Confirm()
            .InputCustomerInformationWithMoveToNextPage(new CustomerEmpty().surname, new CustomerEmpty().name, new CustomerEmpty().passport, new Customer().place)
            .ClickContinue().ChoicePaymentSystemAndContinue().InputData(new Card().invP1, new Card().invP2, new Card().invP3,
            new Card().invP4, new Card().month, new Card().year, new Card().owner, new Card().code);
            Assert.AreEqual("Проверьте параметры кредитной карты.", cardPage.GetError());
            Logger.Log.Debug("Test complete successfully");
        }

        [Test]
        [Category("DataTest")]
        public void BuyingTicketWithoutPlace()
        {
            //Тест кейс 6: Покупка билета без указания посадочного места
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            CheckOrderPage checkOrderPage = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
            .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCity, new Route().ArrivalCity, new Route().DateDeparture)
            .SelectTrain().SelectRailwayCar().InputLoginInformation(new User().Login, new User().Password).Confirm()
            .InputCustomerInformationWithMoveToNextPage(new Customer().surname, new Customer().name, new Customer().passport, new Customer().place);
            Assert.AreNotEqual(string.Empty, checkOrderPage.GetPlace());
            Logger.Log.Debug("Test complete successfully");
        }

        [Test]
        [Category("DataTest")]
        public void InputPastDate()
        {
            //Тест кейс 7: Выбор даты которая уже прошла
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            TrainSelectionPage trainSelectionPage = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
            .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCity, new Route().ArrivalCity, new Route().PastDate);
            Assert.AreEqual("Введенная дата меньше сегодняшней", trainSelectionPage.GetError());
            Logger.Log.Debug("Test complete successfully");
        }

        [Test]
        [Category("DataTest")]
        public void ByuingTicketWithSelectPlace()
        {
            //Тест кейс 8: Покупка билета с указанием посадочного места
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            CheckOrderPage checkOrderPage = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
            .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCity, new Route().ArrivalCity, new Route().DateDeparture)
            .SelectTrain().SelectRailwayCar().InputLoginInformation(new User().Login, new User().Password).Confirm()
            .InputCustomerInformationWithMoveToNextPage(new Customer().surname, new Customer().name, new Customer().passport, new Customer().place);
            Assert.AreEqual(new Customer().place, checkOrderPage.GetPlace());
            Logger.Log.Debug("Test complete successfully");
        }

        [Test]
        [Category("DataTest")]
        public void CheckInputDataAndTicketData()
        {
            //ест кейс 9: Проверка на соответствие введенных данных и данных в билете 
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            CheckOrderPage checkOrderPage = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
            .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCity, new Route().ArrivalCity, new Route().DateDeparture)
            .SelectTrain().SelectRailwayCar().InputLoginInformation(new User().Login, new User().Password).Confirm()
            .InputCustomerInformationWithMoveToNextPage(new Customer().surname, new Customer().name, new Customer().passport, new Customer().place);
            Assert.AreEqual(new Customer().place, checkOrderPage.GetPlace());
            Assert.IsTrue(checkOrderPage.GetFIO().Contains(new Customer().surname + new Customer().name));
            Logger.Log.Debug("Test complete successfully");
        }

        [Test]
        [Category("DataTest")]
        public void BuyingTicket()
        {
            //Тест кейс 10: Покупка билетов
            Logger.InitLogger();
            Browser.Navigate().GoToUrl(@"https://www.rw.by/");
            Logger.Log.Debug("Go to url https://www.rw.by/");

            CardPage cardPage = new MainPage(Browser).ClickTicketsButton().ClickBuyingTicketsButtons()
                .ClickRouteSelectionButton().InputStationsAndClickSearch(new Route().DepartureCity, new Route().ArrivalCity, new Route().DateDeparture)
                .SelectTrain().SelectRailwayCar().InputLoginInformation(new User().Login, new User().Password).Confirm()
                .InputCustomerInformationWithMoveToNextPage(new CustomerEmpty().surname, new CustomerEmpty().name, new CustomerEmpty().passport, new Customer().place)
                .ClickContinue().ChoicePaymentSystemAndContinue().InputData(new Card().p1, new Card().p2, new Card().p3,
                new Card().p4, new Card().month, new Card().year, new Card().owner, new Card().code);

            Logger.Log.Debug("Test complete successfully");
        }
    }
}
