﻿using NUnit.Framework;
using AutomationFrameWork.Driver;
using AutomationFrameWork.ActionsKeys;
using System.Collections.Generic;
using System;
using AutomationTesting.POM.HomePage;

namespace AutomationTesting.Feature.Login_Mail_Parallel
{

    [TestFixture(DriverType.Chrome)]
    [TestFixture(DriverType.InternetExplore)]
    [TestFixture(DriverType.Firefox)]
    [TestFixture(DriverType.EmulationiPad)]
    [TestFixture(DriverType.EmulationiPhone6)]
    [Parallelizable(ParallelScope.Self)]
    class TestParalell
    {

        DriverType driver;
        public TestParalell (DriverType type)
        {
            driver = type;
        }
        [SetUp]
        public void SetUp ()
        {
            DriverFactory.Instance.StartDriver(driver);
        }
        [Test]
        [Category("LoginMail")]
        public void LoginMailSucessfullyParalell ()
        {
            LoginPage.Instance.Navigate("https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifier");
            LoginPage.Instance.EnterUserName("specflowdemo@gmail.com");
            LoginPage.Instance.ClickNext();
            LoginPage.Instance.EnterPass("0934058877");
            LoginPage.Instance.ClickSignIn();
            LoginPage.Instance.Verify().ValidateLoginSucesfully("specflowdemo@gmail.com");
        }
        [Test, TestCaseSource("GetTestData")]
        [Category("SearchGoogle")]
        public void TestDataDriven (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
        }
        [TearDown]
        public void TearDown ()
        {
            DriverFactory.Instance.CloseDriver();
        }

        private static IEnumerable<String> GetTestData ()
        {
            String[] data = { "Samsung Galaxy Note 5", "Apple iPhone 6+", "QA Automation", "Selenium and Nunit", "FaceBook" };
            foreach (String temp in data)
            {
                yield return temp;
            }
        }
    }
}