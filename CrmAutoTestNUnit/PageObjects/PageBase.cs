using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using AventStack.ExtentReports;
using CrmAutoTestNUnit.Base_Classes;
using CrmAutoTestNUnit.Helpers;

namespace CrmAutoTestNUnit.PageObjects
{
    public class PageBase
    {
        //protected ExtentTest Test => _pagesFactory.Test;
        protected IWebDriver driver => _pagesFactory.driver;
        protected readonly PagesManager _pagesFactory;
        protected readonly string _windowHandle;
        public PageBase(PagesManager factory) : this(factory, factory.driver.CurrentWindowHandle) { }
        public PageBase(PagesManager factory, string windowHandle)
        {
            _pagesFactory = factory;
            _windowHandle = windowHandle;
            PageFactory.InitElements(driver, this);
            if (windowHandle != driver.CurrentWindowHandle) driver.SwitchTo().Window(windowHandle);
        }
        public string WindowHandle => _windowHandle;




        [FindsBy(How = How.CssSelector, Using = "#navbar > ul.nav.navbar-nav.main-nav > li> a > span")]
        public IList<IWebElement> LinksPanel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul.nav.navbar-nav.main-nav > li:nth-child(1) ul li a")]
        public IList<IWebElement> SubFolderItemsClients { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul.nav.navbar-nav.main-nav > li:nth-child(2) ul li a")]
        public IList<IWebElement> SubFolderItemsActivities { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul.nav.navbar-nav.main-nav > li:nth-child(3) ul li a")]
        public IList<IWebElement> SubFolderItemsReports { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul.nav.navbar-nav.main-nav > li:nth-child(4) ul li a")]
        public IList<IWebElement> SubFolderItemsSettings { get; set; }


        [FindsBy(How = How.CssSelector, Using = "div.navbar-header > h1 > a > img")]
        public IWebElement ImgMainPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".modal-content")]
        public IWebElement PopUpDetector { get; set; }





        ForexCrmFolders el = new ForexCrmFolders();
        public void ClientsOpenSubTab()
        {
            for (int i = 0; i < SubFolderItemsClients.Count; i++)
            {
                el.OpenTargetSubfolder(LinksPanel[0], SubFolderItemsClients, i);
            }
        }

        public void ActivitiesOpenSubTab()
        {

            for (int i = 0; i < SubFolderItemsActivities.Count; i++)
            {
                el.OpenTargetSubfolder(LinksPanel[1], SubFolderItemsActivities, i);
            }
        }

        public void ReportsOpenSubTab()
        {
            for (int i = 0; i < SubFolderItemsReports.Count; i++)
            {
                el.OpenTargetSubfolder(LinksPanel[2], SubFolderItemsReports, i);
            }
        }

        public void SettingsOpenSubTab()
        {
            for (int i = 0; i < SubFolderItemsSettings.Count; i++)
            {
                el.OpenTargetSubfolder(LinksPanel[3], SubFolderItemsSettings, i);
            }
        }


             //special for paging test!!!!!!!!!!!!!!!!!!!!!
        public void SettingsOpenSubTabInstruments()
        {
         el.OpenTargetSubfolder(LinksPanel[3], SubFolderItemsSettings, 4); 
        }

    }
}
