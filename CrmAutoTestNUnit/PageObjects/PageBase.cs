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
using System.Threading;

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



        //-----------------------SEARCH FORM FIELDS----------------------------------------------------------
        [FindsBy(How = How.CssSelector, Using = "[name*=_condition]")]
        public IList<IWebElement> SearchFormInputs { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".jsgrid-filter-row select")]
        public IList<IWebElement> SearchFormDropDowns { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[name*=Date]")]
        public IList<IWebElement> SearchFormCreatedDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.calendar.left input")]
        public IWebElement CalendarBoxFrom { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.calendar.right input")]
        public IWebElement CalendarBoxTo { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.daterangepicker_input > input")]
        public IList<IWebElement> CalendarBoxFromTo { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.applyBtn.btn.btn-sm.btn-success")]
        public IList<IWebElement> BtnApply { get; set; }

        [FindsBy(How = How.CssSelector, Using = "i[title]")]
        public IWebElement xClearAllFilters { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.jsgrid-button.jsgrid-search-button")]
        public IWebElement BtnSearch { get; set; }

        //---------------------------------------------------------------------------------

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

        [FindsBy(How = How.CssSelector, Using = "div.modal-body > form > div.general-error")]
        public IWebElement PosibleBadReqCreatTrAcc { get; set; }
        

                [FindsBy(How = How.CssSelector, Using = "#create-filter-link")]
                public IWebElement CreateFiltA { get; set; }

                [FindsBy(How = How.CssSelector, Using = "div.item.choosen-columns select[name]")]
                public IList<IWebElement> FiltersDrls { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.button.button2")]
        public virtual IWebElement BtnCancel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[for*= TransactionTy]")]
        public virtual IWebElement TransactTypeLabel { get; set; }
        

        string recordsFound = "div.jsgrid-items-counter > span";
        string dropdownSelectPerPage = "select[class*=records-list]";
        string pagesaQua = "#jsGrid > div.jsgrid-pager-container > div";
        string tableRecords = "div.jsgrid-grid-body > table > tbody > tr";
        string nextPge = "span.jsgrid-pager-nav-button.next > a";
        string prevPage = "span.jsgrid-pager-nav-button.prev> a";
        string lastPage = "span.jsgrid-pager-nav-button.last> a";
        string firstPage = "span.jsgrid-pager-nav-button.first> a";




        public PagingData ClientsPaging
        {
            get
            {
                PagingData parametes = new PagingData();
                parametes.recordsFound = recordsFound;
                parametes.dropdownSelectPerPage = dropdownSelectPerPage;
                parametes.pagesQua = pagesaQua;
                parametes.nextPage = nextPge;
                parametes.prevPage = prevPage;
                parametes.lastPage = lastPage;
                parametes.firstPage = firstPage;
                parametes.tableRecors = tableRecords;
                return parametes;
            }
        }



        public void PagingTest()
        {
            Paging paging = new Paging();
            //string url = "http://crm.staging.fxtoptech.com/api/moduleitems/3?filterId=5";   //for lead json
            //paging.ItemsFound(url);    
            paging.CheckPaging(ClientsPaging);
        }





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




        public virtual void CheckSort()
        {
            IList<IWebElement> gridHeaders = driver.FindElements(By.CssSelector("tr.jsgrid-header-row > th[class*=sortable]> div > div.text-ellipsis > span"));
                            //ASC
            for (int i = 0; i < gridHeaders.Count; i++)
            {
                SeleniumGetMethod.WaitForElement(driver, gridHeaders[i]);
                gridHeaders[i].Click();
                SeleniumGetMethod.WaitForPageLoad(driver);
                SeleniumGetMethod.WaitForElement(driver, gridHeaders[i]);
                Thread.Sleep(2000);
                        //DESC
                gridHeaders[i].Click();
                SeleniumGetMethod.WaitForPageLoad(driver);
                SeleniumGetMethod.WaitForElement(driver, gridHeaders[i]);
                Thread.Sleep(2000);
                var text = gridHeaders[i].GetAttribute("textContent");
                PropertiesCollection._reportingTasks.Log(Status.Info, "Sort by column" + " " + (i + 1) + " column name is " + text);
            }
        }

            //for future testing
        public void CheckFilters()
        {
            CreateFiltA.Click();
            Thread.Sleep(3000);
            for (int i = 0; i < FiltersDrls.Count; i++)
            {
                var allFlters = driver.FindElements(By.CssSelector("div.item.choosen-columns select[name]"));
                if (SeleniumGetMethod.GetQuantityOfOptionsInDropDown(allFlters[i]) < 2)   break;
                SeleniumSetMethods.SelectDropDown(allFlters[i],i+1);
                Thread.Sleep(2000);
            }
            BtnCancel.Click();
            Thread.Sleep(2000);
        }


        public virtual void CheckSearch() 
        {
            foreach (var drl in SearchFormDropDowns)
            {
                SeleniumSetMethods.SelectDropDown(drl, 1);
                SeleniumGetMethod.WaitForPageLoad(driver);
                Thread.Sleep(2000);
            }
            foreach (var field in SearchFormInputs)
            {
                field.SendKeys(Helpers.Randomizer.String(7));
            }     
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(3000);
            for (int i = 0; i < SearchFormCreatedDate.Count; i++)
            {
                SeleniumGetMethod.WaitForElement(driver, SearchFormCreatedDate[i]);
                SearchFormCreatedDate[i].Click();
                try
                {
                    foreach (var date in CalendarBoxFromTo)
                    {
                        if (date.Displayed)
                        {
                            date.Clear();
                            date.SendKeys(WindowsMessages.GetCurDate(1));
                            SeleniumGetMethod.WaitForPageLoad(driver);
                        }
                    }
                    if (BtnApply[i].Displayed)
                    {
                        SeleniumGetMethod.WaitForElement(driver, BtnApply[i]);
                        BtnApply[i].Click();
                        SeleniumGetMethod.WaitForPageLoad(driver);
                        Thread.Sleep(1000);
                        SeleniumGetMethod.WaitForPageLoad(driver);
                    }
                }
                catch (Exception msg)
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, "Can't manipulate calendarboxes..<br>" + msg.ToString());
                }
            }
            Thread.Sleep(2000);
            BtnSearch.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
            try
            {
                xClearAllFilters.Click();
                Thread.Sleep(2000);
            }
            catch (Exception msg)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "Can't set null filters uisng x(cross) link...<br>" + msg.ToString());
            }
            SeleniumGetMethod.WaitForPageLoad(driver);
        }
    }
}
