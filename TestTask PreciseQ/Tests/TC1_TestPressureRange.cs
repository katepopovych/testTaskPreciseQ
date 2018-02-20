﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace TestTask_PreciseQ.Tests
{
    public class TC1_TestPressureRange
    {
        private IWebDriver _driver;
        LandingPageService landingPageService; 

        [SetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            landingPageService = new LandingPageService(_driver);
        }

        [TestCase]
        public void TestPressureRange()
        {
            string testDay = "Воскресенье";
            string testPlace = "Драгобрат";

            _driver.Navigate().GoToUrl("https://sinoptik.ua/");
            landingPageService.SearchForCity(testPlace);
            landingPageService.ClickTab(testDay);
            landingPageService.CheckTabIsOpened(testDay);
            Assert.IsTrue(landingPageService.VerifyPressureInRange(600,700));
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}