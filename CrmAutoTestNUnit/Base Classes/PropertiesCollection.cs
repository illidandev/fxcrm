﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using CrmAutoTestNUnit.Base_Classes;
using OpenQA.Selenium.Support.Extensions;
using CrmAutoTestNUnit.PageObjects;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Events;
using System.Drawing.Imaging;
using CrmAutoTestNUnit.Helpers;

namespace CrmAutoTestNUnit
{
    //enum PropertyType
    //{
    //    Id,
    //    Name,
    //    CssName,
    //    ClassName,
    //    Xpath
    //}


    [TestFixture]
    public class PropertiesCollection : GetSreenShot
    {
        //Auto-implemented property
        public static IWebDriver driver;
        protected TestsConfiguration _config = null;
        protected PagesManager _pages = null;
        public static ReportingTasks _reportingTasks;

        protected string browserName;
        protected string user;
        public PropertiesCollection(string user, string browserName)
        {
            this.browserName = browserName;
            this.user = user;
        }

        [OneTimeSetUp]
        protected void StartReport()
        {
            _config = TestsConfiguration.Instance;
            ExtentReports extentReports = ReportingManager.Instance;
            _reportingTasks = new ReportingTasks(extentReports);
        }

        [SetUp]
        public void SetUp()
        {
                                                  //Init test Name to log
            _reportingTasks.InitializeTest();
            var Description = TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString() ?? string.Empty;
            _reportingTasks.Log(Status.Info, "<h4> Tests' steps description  </h4>"+Description + "<br>");
                                                         //Init Web driver  
            driver = WebDriverFactory.GetWebDriver(browserName);
            _reportingTasks.Log(Status.Debug, "<b>Tests are executed in " + browserName);
            EventFiringWebDriver firingDriver = new EventFiringWebDriver(driver);
            firingDriver.ExceptionThrown += FiringDriver_TakeScreenshotOnException;
            firingDriver.ElementClicked += FiringDriver_Cliked;
            firingDriver.Navigated += FiringDriver_Navigate;
            driver = firingDriver;
            driver.Manage().Timeouts().ImplicitWait = _config.ImplicitlyWait;
            driver.Manage().Timeouts().PageLoad = _config.PageLoadWait;
                                    //init Page Manager 
            _pages = new PagesManager(driver);
                                //Checking user authorization 
            IsLogin(user);
        }


        [OneTimeTearDown]
        protected void TearDown()
        {
            _reportingTasks.SaveReport();
        }


        public void IsLogin(String user)
        {        
                      // go to Sign In Page
            _reportingTasks.CreateNode("User Authorization action");
            Goto(_config.PlmUrl);
            SeleniumGetMethod.WaitForPageLoad(driver);
            var pagelogin = _pages.GetPage<LoginPageObjects>();
            pagelogin.Login(user, _config.Password);
            SeleniumGetMethod.WaitForPageLoad(driver);
                            // in case of failed login 
            if (driver.Url.IndexOf("ModuleItems", StringComparison.OrdinalIgnoreCase) == -1)
            {
                SeleniumGetMethod.WaitForPageLoad(driver);
                            // go to Login page
                driver.Navigate().GoToUrl(_config.PlmUrlDef);
                var logPage = _pages.GetPage<LoginPageObjects>();
                pagelogin.Login(user, _config.Password);
                _reportingTasks.Log(Status.Info, user + " Login in the system once again");
                SeleniumGetMethod.WaitForPageLoad(driver);
            }
        }



        public static void Goto(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static string Title
        {
            get { return driver.Title; }
        }


        public static IWebDriver getDriver
        {
            get { return driver; }
        }


        private static void FiringDriver_TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            _reportingTasks.LogAddScrren(driver, "Event exception" + timestamp);
        }

        private static void FiringDriver_Cliked(object sender, WebElementEventArgs e)
        {

            try
            {
                //var elem = e.Element.GetAttribute("Id");
                var elemTag = e.Element.TagName;
                var elemText = e.Element.Text;
                _reportingTasks.Log(Status.Pass, "User clicks element, tag's name is: " + "<b>"+elemTag+"</b>" + ", innerText is : " + "<b>"+elemText+"</b>");
            }
            catch (StaleElementReferenceException ex)
            {

            }
            catch (NoSuchWindowException ew)
            {

            }
            catch (ArgumentException arg)
            {

            }

        }


        private static void FiringDriver_Navigate(object sender, WebDriverNavigationEventArgs e)
        {
            _reportingTasks.Log(Status.Info, "Navigate to URL "+ e.Driver.Url);

            if(driver.Url.IndexOf("/CustomError.aspx", StringComparison.OrdinalIgnoreCase) != -1)
            {
                _reportingTasks.Log(Status.Error, "Found OOPs page!!!");
            }
        }

        [TearDown]
        public void Cleanup()
        {
            _reportingTasks.FinalizeTest(driver);
            driver.Quit();
            driver.Dispose();
        }
    }

}
