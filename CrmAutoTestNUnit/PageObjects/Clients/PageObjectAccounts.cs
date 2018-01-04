using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmAutoTestNUnit.PageObjects;
using CrmAutoTestNUnit.Helpers;
using CrmAutoTestNUnit.Base_Classes;
using CrmAutoTestNUnit;
using System.IO;
using CrmAutoTestNUnit.DB_connectors;
using System.Reflection;
using static CrmAutoTestNUnit.Helpers.Paging;

namespace CrmAutoTestNUnit.PageObjects.Clients
{
    public class PageObjectAccounts : PageBase
    {

        /*search form country dropdown*/
        /*td:nth-child(5) > div > div > div > div > ul li a*/

        public PageObjectAccounts(PagesManager factory) : base(factory) { }
        public PageObjectAccounts(PagesManager factory, string windowHandle): base(factory, windowHandle){ }

        [FindsBy(How = How.CssSelector, Using = "a.link-user")]
        public IWebElement BtnNew { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.button.submit-button")]
        public IWebElement BtnSave { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.button.button2")]
        public IWebElement BtnCancel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.modal-header > button[class=close]")]
        public IWebElement BtnCloseCross { get; set; }

            /*-------------------------------------CREATE ACC FEILDS-------------------------------------*/
            [FindsBy(How = How.CssSelector, Using = "div.items.form-horizontal [name=FirstName]")]
            public IWebElement UserFirstName { get; set; }

            [FindsBy(How = How.CssSelector, Using = "div.items.form-horizontal [name=LastName]")]
            public IWebElement UserLastName { get; set; }

            [FindsBy(How = How.CssSelector, Using = "div.items.form-horizontal [name=Email]")]
            public IWebElement UserEmail { get; set; }
            [FindsBy(How = How.CssSelector, Using = ".modal-body form > div.general-error")]
            public IWebElement ExisEmailValid { get; set; }

            [FindsBy(How = How.CssSelector, Using = "div[id*=Cont] a[href*=mail] span")]
            public IWebElement emailToStore { get; set; }
        
            [FindsBy(How = How.CssSelector, Using = "div.items.form-horizontal [name=Phone]")]
            public IWebElement UserPhone { get; set; }

            [FindsBy(How = How.CssSelector, Using = "div.items.form-horizontal [name=Password]")]
            public IWebElement UserPassword { get; set; }

            [FindsBy(How = How.CssSelector, Using = "div.items.form-horizontal select[name=Country]")]
            public IWebElement UserCountry { get; set; }
            [FindsBy(How = How.CssSelector, Using = "div.items.form-horizontal select[name=Country] [class*=flag]")]
            public IList<IWebElement> AllCountriesList { get; set; }

            [FindsBy(How = How.CssSelector, Using = "div.items.form-horizontal select[name*=Group]")]
            public IWebElement UserGroup { get; set; }


        /*----------------------------------------------------------------------------------------*/

        [FindsBy(How = How.CssSelector, Using = "input[aria-required],.modal-body select")]
        public IList<IWebElement> CreateAccAllFields { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label.input-validation-error")]
        public IList<IWebElement> AllValidators { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label.input-validation-error:not([style]), label.input-validation-error[style*=block]")]
        public IList<IWebElement>VisibleValidators { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.account-main-details > h2")]
        public IWebElement FirstLastNameInsideAccount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.jsgrid-grid-body > table tr > td:nth-child(2) a > span")]
        public IList<IWebElement> AccountsInTheGrid { get; set; }

        /*------------------------------------------------------SEARCH FORM FIELDS CLIENTS----------------------------------------------*/

        //inTo PageBase
        /*
        [FindsBy(How = How.CssSelector, Using = "[name*=_condition]")]
        public IList<IWebElement> SearchFormInputs { get; set; }  
        [FindsBy(How = How.CssSelector, Using = ".jsgrid-filter-row select")]
        public IList<IWebElement> SearchFormDropDowns { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[name*=Date]")]
        public IWebElement SearchFormCreatedDate { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div.calendar.left input")]
        public IWebElement CalendarBoxFrom { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div.calendar.right input")]
        public IWebElement CalendarBoxTo { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div.daterangepicker_input > input")]
        public IList<IWebElement> CalendarBoxFromTo { get; set; }
        [FindsBy(How = How.CssSelector, Using = "button.applyBtn.btn.btn-sm.btn-success")]
        public IWebElement BtnApply { get; set; }
        [FindsBy(How = How.CssSelector, Using = "i[title]")]
        public IWebElement xClearAllFilters { get; set; }
         [FindsBy(How = How.CssSelector, Using = "input.jsgrid-button.jsgrid-search-button")]
        public IWebElement BtnSearch { get; set; }
             */


        [FindsBy(How = How.CssSelector, Using = "td:nth-child(5) > div > div > div > button")]
        public IWebElement DrlCountryExpander { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".jsgrid-filter-row select[name=Country]")]
        public IWebElement DrlCountryInSearchWithPostBack { get; set; }
        [FindsBy(How = How.CssSelector, Using = "td:nth-child(5) > div > div > i")]
        public IWebElement DrlCountryClear { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#JColResizer0 > tbody > tr.jsgrid-filter-row > td > div > div > in")]
        public IList<IWebElement> AllCrossesClearFilters { get; set; }
        
       
        [FindsBy(How = How.CssSelector, Using = ".jsgrid-filter-row select[name*=Status]")]
        public IWebElement DrlStatusInSearchWithPostBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".jsgrid-filter-row select[name*=Owner]")]
        public IWebElement DrlOwnerInSearchWithPostBack { get; set; }
        

       

        /*-------------------EDIT ACCOUNT INSIDE---------------------------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "[id*='1_Container'] a[class*=edit]")]
        public IWebElement PencilEditGeneralInfo { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name=FirstName]")]
        public IWebElement EditFirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name=LastName]")]
        public IWebElement EditLastName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name=Email]")]
        public IWebElement EditEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name=Phone]")]
        public IWebElement EditPhone { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name*=Status]")]
        public IWebElement EditStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name=OwnerId]")]
        public IWebElement EditOwner { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name*=Birth]")]
        public IWebElement EdiDateOfBirth { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id*='1_Container'] div>a[class*=submit-button]")]
        public IWebElement ApplyChanges { get; set; }

                //if lead//
        [FindsBy(How = How.CssSelector, Using ="div[class=value] a[href*=LE]")]
        public IWebElement BackIntoLead { get; set; }
        

        /*----------------------------------------COMMENTS IN ACCOUNT-----------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "div[id='2_Container'] div.box-heading > div > a:nth-child(1)")]
        public IWebElement BtnAddComments { get; set; }

        [FindsBy(How = How.CssSelector, Using = "textarea[name=CommentText]")]
        public IWebElement TextAreaForComments { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#addNewComment a.btn-type02.submit-button")]
        public IWebElement AddCommentsSubmitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.comments > div > div.comments-list > div")]
        public IList<IWebElement> AddedComments { get; set; }

        /*----------------------------------------ACTIONS IN ACCOUNT-----------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "#sidebar > div > ul:nth-child(2) > li:nth-child(1) > a")]
        public IWebElement BtnTPAccountCreate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name*=Group]")]
        public IWebElement SelectGroupTPAccount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#sidebar > div > ul:nth-child(2) > li:nth-child(2) > a")]
        public IWebElement BtnChangePassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name=NewPassword]")]
        public IWebElement InputNewPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#changePasswordConfirmation a")]
        public IWebElement ChangePasConfirmAlert { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class=value] a[href*=ACC]")]
        public IWebElement BackToAccLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[data-field=Password]")]
        public IWebElement GenInfoPassword { get; set; }


        /*----------------------------------------MARKETING INFO AND ADDRESS IN ACCOUNT-----------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "div[id*='3_Container'] a[class*=edit]")]
        public IWebElement MarkInfoPencil { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='3_Container'] input:not([placeholder])")]
        public IList<IWebElement> MarkInfoAllInputs { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='3_Container'] select")]
        public IWebElement MarkInfoCountryDrl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id='3_Container'] a[class*=submit-button]")]
        public IWebElement MarkInfoBtnApply { get; set; }
       
        [FindsBy(How = How.CssSelector, Using = "div[id*='4_Container'] a[class*=edit]")]
        public IWebElement AddressPencil { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='4_Container'] input:not([placeholder]),div[id*='4_Container'] textarea:not([placeholder])")]
        public IList<IWebElement> AddressAllInputs { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='4_Container'] select")]
        public IWebElement AddressCountryDrl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id='4_Container'] a[class*=submit-button]")]
        public IWebElement AddressBtnApply { get; set; }

        /*----------------------------------------ADDITIONAL INFO IN ACCOUNT-----------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "div[id*='6_Container'] a[class*=edit]")]
        public IWebElement AddInfoPencil { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id='6_Container'] span[class]")]
        public IList<IWebElement> AddInfoAllCheckBoxes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id='6_Container'] textarea, div[id='6_Container'] input[type='text]")]
        public IWebElement AddInfoDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id='6_Container'] a[class*=submit-button]")]
        public IWebElement AddInfoBtnApply { get; set; }

        /*----------------------------------------DOCUMENTS INFO IN ACCOUNT-----------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "#navPanel > li:nth-child(1) > a")]
        public IWebElement ExpandDocuments { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#documents a.ico-add.ico-sz3")]
        public IWebElement PlusAddDocuments { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name*=Type]")]
        public IWebElement DocTypeDrl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#fileupload div[class=dropzone] a input")]
        public IWebElement BrowseFiles { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#collapseDocuments table > tbody > tr > td:nth-child(1)")]
        public IList<IWebElement> QuantityOfUploadedFiles { get; set; }

        /*----------------------------------------TRADE ACCOUNTS INFO IN ACCOUNT-----------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "#navPanel > li:nth-child(3) > a")]
        public IWebElement ExpandTradeAccounts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#tradeAccounts a.ico-add.ico-sz3")]
        public IWebElement PlusAddTradeAcc { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#createTradeAccount a.button.submit-button")]
        public IWebElement BtnSaveTPAccount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#collapseTradeAccounts table > tbody > tr > td:nth-child(1)")]
        public IList<IWebElement> QuantityOfTradeAccounts { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#collapseTradeAccounts tr:nth-child(2) > td:nth-child(14) > a")]
        [FindsBy(How = How.CssSelector, Using = "a.custom-close:first-child")]
        public IWebElement CrossDeleteTradeAccount { get; set; }

        /*----------------------------------------TASKS IN ACCOUNT-----------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "#navPanel > li a[href*=task]")]
        public IWebElement ExpandTasksAccounts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#tasks a.ico-add.ico-sz3")]
        public IWebElement PlusTask { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name=UserId]")]
        public IWebElement TaskOwnerDrl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name=Type]")]
        public IWebElement TaskTypeDrl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name=Status]")]
        public IWebElement TaskStatusDrl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name=Date]")]
        public IWebElement TaskDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#popup-field-control > div textarea[name=Description]")]
        public IWebElement TaskDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.daterangepicker.dropdown-menu.ltr.single.opensright.show-calendar button.applyBtn.btn.btn-sm.btn-success")]
        public IWebElement TaskDateApplyBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#collapseTasks a > span")]
        public IWebElement TaskCreatedOpen { get; set; }

        /*----------------------------------------FINANCIAL TRANSACTIONS IN ACCOUNT-----------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "#navPanel > li:nth-child(5) > a")]
        public IWebElement ExpandFinanceTransAccounts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mtTransactions a.ico-add.ico-sz3")]
        public IWebElement PlusFinTransaction { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name*=TradeAcc]")]
        public IWebElement TransAccDrl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name=Equity]")]
        public IWebElement TransAmount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name=TransactionType]")]
        public IWebElement TransTypeDrl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[name=TransactionApproval]")]
        public IWebElement TransTrApprovalDrl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "head > title")]
        public IWebElement TransPageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td:nth-child(4) a[href]")]
        public IWebElement BackToTpAcc { get; set; }



        /*string recordsFound = "div.jsgrid-items-counter > span";
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
            //paging.SelectPerPage(StyleFolderPaging, driver.FindElement(By.CssSelector(StyleFolderPaging.dropdownSelectPerPage)));
            //Thread.Sleep(2000);
            //paging.GetPagesQuantity(StyleFolderPaging);
            paging.CheckPaging(ClientsPaging);
        }*/




        public string digits = "123", symbols = "!@#$%^&*()_+", letters = "abcdefghijklmopqrstuvwxyz", rusLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public string email, usFnameCheck, usLnameCheck;
        ConnectToDb db = new ConnectToDb();

        
        int accountsAfterCreation, accountsBeforeCreation;

        WindowsMessages popUp = new WindowsMessages();
        ForexCrmFolders el = new ForexCrmFolders();


                //check folder swithing
        public void OpenAccountTab()
        {
            el.OpenTargetSubfolder(LinksPanel[0], SubFolderItemsClients, 1);
        }

        public void OpenLeadTab()
        {
            el.OpenTargetSubfolder(LinksPanel[0], SubFolderItemsClients, 0);
        }

        public void OpenTradeAccountsTab()
        {
            el.OpenTargetSubfolder(LinksPanel[0], SubFolderItemsClients, 2);
        }

       


       // virtual in page base
        public override void CheckSearch()
        {
            //need gett quantity of dropDowns
            foreach(var drl in SearchFormDropDowns)
            {
                SeleniumSetMethods.SelectDropDown(drl, 1);
                SeleniumGetMethod.WaitForPageLoad(driver);
                Thread.Sleep(2000);
            }
            foreach (var field in SearchFormInputs)
            {
                field.SendKeys(Helpers.Randomizer.String(7));
            }
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
            xClearAllFilters.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
        }


                 // virtual in page base
        public override void  CheckSort()
        {
            IList<IWebElement> gridHeaders = driver.FindElements(By.CssSelector("tr.jsgrid-header-row > th[class*=sortable]> div > div.text-ellipsis > span"));
                            //ASC
            for (int i = 0; i < gridHeaders.Count; i++)
            {
                gridHeaders[i].Click();
                SeleniumGetMethod.WaitForPageLoad(driver);
                Thread.Sleep(2000);
                var curUrl = driver.Url;
                Console.WriteLine(curUrl);
                             //DESC
                gridHeaders[i].Click();
                SeleniumGetMethod.WaitForPageLoad(driver);
                Thread.Sleep(2000);
                var text = gridHeaders[i].GetAttribute("textContent");
                curUrl = driver.Url;
                Console.WriteLine(curUrl);
                Console.WriteLine("Sort by column" + " " + (i + 1) + " column name is  " + text);
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

         
        public void CreateValAccOrLead(string leadOrAcc, bool checkIsEmailFollows = false) //additional function
        {
            BtnNew.Click();
            Thread.Sleep(3000);
            UserFirstName.SendKeys("userFUniv" + Helpers.Randomizer.String(5));
            UserLastName.SendKeys("userLUniv" + Helpers.Randomizer.String(5));
            if (leadOrAcc == "account" && email !=null && email !="")
            {
                UserEmail.SendKeys(email);
            }
            else
            {
                UserEmail.SendKeys("test" + Helpers.Randomizer.String(5, letters) + "@" + Helpers.Randomizer.String(2, letters) + "." + Helpers.Randomizer.String(2, letters));
                PropertiesCollection._reportingTasks.Log(Status.Info, "Cant check with the same emails");
            }
            UserPhone.SendKeys(Helpers.Randomizer.String(7, digits));
            SeleniumSetMethods.SelectDropDown(UserCountry, Helpers.Randomizer.Number(1, AllCountriesList.Count - 1));
            if (leadOrAcc == "account")
            {
                UserPassword.SendKeys(Helpers.Randomizer.String(5, letters));
                try
                {
                    SeleniumSetMethods.SelectDropDown(UserGroup, Helpers.Randomizer.Number(1, 2));
                }
                catch
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, "there is no group when you create acc");
                }
            }
            SeleniumGetMethod.WaitForElement(driver, BtnSave);           
            BtnSave.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            SeleniumGetMethod.WaitForElement(driver, BtnAddComments);
            if (leadOrAcc == "account" && checkIsEmailFollows == true)
            {
                try
                {
                    Assert.AreEqual(email, emailToStore.Text);
                    PropertiesCollection._reportingTasks.Log(Status.Info, "Here is email var " + email);
                    PropertiesCollection._reportingTasks.Log(Status.Info, "Here is email to store value  " + emailToStore.Text);
                }
                catch
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, "Something wrong with checking following email");
                }
            }
            if (leadOrAcc == "lead")
            {
                email = emailToStore.Text;
            }
            PropertiesCollection._reportingTasks.Log(Status.Info, leadOrAcc + "email is " + email);
            PropertiesCollection._reportingTasks.Log(Status.Info, leadOrAcc + " has been created");
        }


        public void CreateValidAcc() //additional function
        {
            BtnNew.Click();
            foreach(var i in CreateAccAllFields)
            {
                SeleniumGetMethod.WaitForElement(driver, i);
            }
            UserFirstName.SendKeys("userFirstName" + Helpers.Randomizer.String(5));
            UserLastName.SendKeys("userLastName" + Helpers.Randomizer.String(5));
            //UserEmail.SendKeys("test" + Helpers.Randomizer.String(5, letters) + "@" + Helpers.Randomizer.String(2, letters) + "." + Helpers.Randomizer.String(2, letters));
            Thread.Sleep(2000);
            UserEmail.SendKeys(email);
            Thread.Sleep(2000);
            UserPassword.SendKeys(Helpers.Randomizer.String(5, letters));
            UserPhone.SendKeys(Helpers.Randomizer.String(7, digits));
            SeleniumSetMethods.SelectDropDown(UserCountry, Helpers.Randomizer.Number(5, 15));
            try
            {
                SeleniumSetMethods.SelectDropDown(UserGroup, Helpers.Randomizer.Number(1, 2));
            }
            catch
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "there is no group when you create acc");
            }
            BtnSave.Click();
            Thread.Sleep(3000);
            SeleniumGetMethod.WaitForPageLoad(driver);
            SeleniumGetMethod.WaitForElement(driver,PencilEditGeneralInfo);
            string curUrl = driver.Url;
            string[] curUrlParsed = curUrl.Split('=');
            string acId = curUrlParsed.Last();
            try
            {
                {
                    Assert.IsTrue(acId.Contains("ACC"));
                    PropertiesCollection._reportingTasks.Log(Status.Info, "Account has been created");
                }
            }
            catch (Exception)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "Can't check are is user log in");
            }
            Console.WriteLine("Accont email is "+ email);
            Console.WriteLine("Accont has been created");
        }


        

        public void CreateNewAccount(string leadOrAcc)
        {
            
            /*-------------------------------------CHECK WITH  EMPTY FIELDS-------------------------------------*/
            BtnNew.Click();
            int allContries = AllCountriesList.Count - 1;
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable(BtnSave));
            BtnSave.Click();
            Thread.Sleep(2000);
            if (leadOrAcc == "account") 
            {
                try
                {
                    Assert.IsTrue(AllValidators.Count == 7 & VisibleValidators.Count == 7);
                }
                catch
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, " Can't count validators using assert.. ");
                }
            }
            Assert.IsTrue(popUp.IsPopUpVisible(PopUpDetector));
            /*foreach (var valid in AllValidators)
            {
                Console.WriteLine(valid.GetAttribute("textContent"));
            }
            Console.WriteLine("");*/
            /*-------------------------------------USING TEXTS - invalid email/phone/pasword-------------------------------------*/
            for (int i = 0; i < CreateAccAllFields.Count; i++)
            {
                if (CreateAccAllFields[i].TagName == "input")
                {
                    CreateAccAllFields[i].SendKeys(Helpers.Randomizer.String(4, letters));
                }
                if (CreateAccAllFields[i].TagName == "select")
                {
                    SeleniumSetMethods.SelectDropDown(CreateAccAllFields[i],1);
                }
                Thread.Sleep(1000);
            }
            BtnSave.Click();
            Thread.Sleep(2000);
            if (leadOrAcc == "account")
            {
                try
                {
                    Assert.IsTrue(VisibleValidators.Count == 3);
                }
                catch
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, " Can't count validators using assert.. ");
                }
            }
            Assert.IsTrue(popUp.IsPopUpVisible(PopUpDetector));
           /* foreach (var valid in VisibleValidators)
            {
                Console.WriteLine(valid.GetAttribute("textContent"));
            }
            Console.WriteLine("");*/
            /*-------------------------------------USING WRONG DATA FOR email/phone/pasword-------------------------------------*/
            UserEmail.Clear();
            UserPhone.Clear();
            if (leadOrAcc == "account")
            {
                UserPassword.Clear();
            }
            UserEmail.SendKeys(Helpers.Randomizer.String(7));
            UserPhone.SendKeys(Helpers.Randomizer.String(21, digits));
            if (leadOrAcc == "account")
            {
                UserPassword.SendKeys(Helpers.Randomizer.String(21, symbols));
            }
            BtnSave.Click();
            Thread.Sleep(2000);
            if (leadOrAcc == "account")
            {
                try
                {
                    Assert.IsTrue(VisibleValidators.Count == 3);
                }
                catch
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, " Can't count validators using assert.. ");
                }
            }
            Assert.IsTrue(popUp.IsPopUpVisible(PopUpDetector));
            /*foreach (var valid in VisibleValidators)
            {
                Console.WriteLine(valid.GetAttribute("textContent"));
            }
            Console.WriteLine("");*/
            /*-------------------------------------CANCEL BUTTON POPUP CHECK THAT FEILDS ARE EMPTY -------------------------------------*/
            BtnCancel.Click();
            Thread.Sleep(2000);
            Assert.IsFalse(popUp.IsPopUpVisible(PopUpDetector));
            BtnNew.Click();
            Thread.Sleep(2000);
            foreach (var field in CreateAccAllFields)
            {
                if (field.GetAttribute("value") != "")
                {
                    PropertiesCollection._reportingTasks.Log(Status.Warning, "There is a bug. Value of field " + " " + field.GetAttribute("name") + " is " + field.GetAttribute("value"));
                }
                if (field.TagName == "input")
                {
                    field.SendKeys(Helpers.Randomizer.String(4, letters));
                }
                if (field.TagName == "select")
                {
                    SeleniumSetMethods.SelectDropDown(field,1);
                }
                Thread.Sleep(1000);
            }
            /*-------------------------------------CLOSE BUTTON POPUP CHECK THAT FIELDS ARE EMPTY -------------------------------------*/
            BtnCloseCross.Click();
            Thread.Sleep(2000);
            Assert.IsFalse(popUp.IsPopUpVisible(PopUpDetector));
            BtnNew.Click();
            Thread.Sleep(2000);
            foreach (var field in CreateAccAllFields)
            {
                if (field.GetAttribute("value") != "")
                {
                    PropertiesCollection._reportingTasks.Log(Status.Warning, "There is a bug. Value of field " + " " + field.GetAttribute("name") + " is " + field.GetAttribute("value"));
                }
                if (field.TagName == "input")
                {
                    field.SendKeys(Helpers.Randomizer.String(4, letters));
                }
                if (field.TagName == "select")
                {
                    SeleniumSetMethods.SelectDropDown(field,1);
                }
                Thread.Sleep(1000);
            }
            /*-------------------------------------CHECK CREATE VALID ACCOUNT-------------------------------------*/
            BtnCloseCross.Click();

            /*if (leadOrAcc == "lead")
            {
               accountsBeforeCreation = JavaScriptInvoker.ReadHttpResponseJSon("http://crm.staging.fxtoptech.com/api/moduleitems/3?filterId=5");
            }
            if (leadOrAcc == "account")
            {
                accountsBeforeCreation =JavaScriptInvoker.ReadHttpResponseJSon("http://crm.staging.fxtoptech.com/api/moduleitems/1?filterId=1200");
            }     */
            try
            {
                accountsBeforeCreation = db.ConnectToDbTest();
            }
            catch
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, " Can't connet to db....");
            }
            //int accountsBeforeCreation = AccountsInTheGrid.Count;
            //new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable(BtnNew));
            Thread.Sleep(2000);
            BtnNew.Click();
            Thread.Sleep(2000);
            UserFirstName.SendKeys("userFirstName" +Helpers.Randomizer.String(5));
            UserLastName.SendKeys("userLastName" + Helpers.Randomizer.String(5));
            UserEmail.SendKeys("test" +Helpers.Randomizer.String(5,letters) +"@" +Helpers.Randomizer.String(2,letters) +"." + Helpers.Randomizer.String(2,letters));
            UserPhone.SendKeys(Helpers.Randomizer.String(7, digits));
            if (leadOrAcc == "account")
            {
                UserPassword.SendKeys(Helpers.Randomizer.String(5, letters));
                SeleniumSetMethods.SelectDropDown(UserGroup,1);
            }
            SeleniumSetMethods.SelectDropDown(UserCountry, Helpers.Randomizer.Number(1, allContries)); 

            usFnameCheck = UserFirstName.GetAttribute("value");
            usLnameCheck = UserLastName.GetAttribute("value");            
         
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable(BtnSave));
            BtnSave.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(3000);
            string firstAndLast = FirstLastNameInsideAccount.Text;
            string[] firstAndLastParsed =  firstAndLast.Split(' ');

            string curUrl = driver.Url;
            string[] curUrlParsed = curUrl.Split('=');

            string fName = firstAndLastParsed.First();
            string lName = firstAndLastParsed.Last();
            string acId = curUrlParsed.Last();
            try
            {
                Assert.IsTrue(usFnameCheck == fName);
                Assert.IsTrue(usLnameCheck == lName);
                if (leadOrAcc == "account")
                {
                    Assert.IsTrue(acId.Contains("ACC"));
                }
                if (leadOrAcc == "lead")
                {
                    Assert.IsTrue(acId.Contains("LE"));
                }
            }
            catch (Exception)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "Can't check are is user log in");
            }

            CheckAccountEditGenInfo(leadOrAcc);  //check edit gen info
            email = emailToStore.Text;      
            CheckAccountComments();              //check comments
            CheckAccountActions(leadOrAcc);      //check create tp acc
            CheckAccountMarkInfoAdress();       //check acc marketing and address
            CheckAccountAddInfo();              //check add info
            if (leadOrAcc == "account")
            {
                CheckAccountDocuments();
                CheckAccountTradeAcc();
                CheckAccountFinTrans();
            }
            CheckAccountTasks(leadOrAcc);
            Thread.Sleep(3000);
            ImgMainPage.Click();
            if (leadOrAcc == "lead")
            {
                ForexCrmFolders el = new ForexCrmFolders();
                el.OpenTargetSubfolder(LinksPanel[0], SubFolderItemsClients, 0);
            }
            Thread.Sleep(3000);
            /*if (leadOrAcc == "lead")
            {
                accountsAfterCreation = JavaScriptInvoker.ReadHttpResponseJSon("http://crm.staging.fxtoptech.com/api/moduleitems/3?filterId=5");
            }
            if (leadOrAcc == "account")
            {
                accountsAfterCreation = JavaScriptInvoker.ReadHttpResponseJSon("http://crm.staging.fxtoptech.com/api/moduleitems/1?filterId=1200");
            }*/
            try
            {
                accountsAfterCreation = db.ConnectToDbTest();
            }
            catch
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, " Can't connet to db....");
            }

            PropertiesCollection._reportingTasks.Log(Status.Info, "There were " + accountsBeforeCreation + " account before.<br> Now there are " + accountsAfterCreation + " accounts");

            try
            {
                Assert.IsTrue(accountsAfterCreation - accountsBeforeCreation == 1);
            }
            catch (Exception)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "Something wrong with checking quantity of users");
            }
            /*-------------------------------------CHECK CREATE ACCOUNT WITH EXISTING EMAIL-------------------------------------*/
            if (leadOrAcc == "account")
            {
                ImgMainPage.Click();
                Thread.Sleep(2000);
                BtnNew.Click();
                Thread.Sleep(2000);
                UserFirstName.SendKeys("userFirstName" + Helpers.Randomizer.String(5));
                UserLastName.SendKeys("userLastName" + Helpers.Randomizer.String(5));
                UserEmail.SendKeys(email);
                UserPhone.SendKeys(Helpers.Randomizer.String(7, digits));
                UserPassword.SendKeys(Helpers.Randomizer.String(5, letters));
                SeleniumSetMethods.SelectDropDown(UserCountry, Helpers.Randomizer.Number(1, allContries));
                try
                {
                    SeleniumSetMethods.SelectDropDown(UserGroup, 1);
                }
                catch (Exception)
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, "there is no user group drop down");
                }
                BtnSave.Click();
                Thread.Sleep(2000);
                try
                {
                    Assert.IsTrue(SeleniumGetMethod.IsElementExists(driver, ExisEmailValid)); 
                }
                catch (Exception)
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, "Something wrong with emails duplicates testing");
                }
            }

        }



        public void CheckAccountEditGenInfo(string leadOrAcc)
        {
            PencilEditGeneralInfo.Click();
            EditFirstName.Clear();
            EditFirstName.SendKeys("userFirstEdit" + Helpers.Randomizer.String(5));
            EditLastName.Clear();
            EditLastName.SendKeys("userLastEdit" + Helpers.Randomizer.String(5));
            EditPhone.Clear();
            EditPhone.SendKeys(Helpers.Randomizer.String(7, digits));
            EditEmail.Clear();
            EditEmail.SendKeys("test" + Helpers.Randomizer.String(5, letters) + "@" + Helpers.Randomizer.String(2, letters) + "." + Helpers.Randomizer.String(2, letters));
            SeleniumSetMethods.SelectDropDown(EditStatus, Helpers.Randomizer.Number(1, 2));
            SeleniumSetMethods.SelectDropDown(EditOwner, Helpers.Randomizer.Number(1, 2));
            if (leadOrAcc == "account")
            {
                EdiDateOfBirth.SendKeys(WindowsMessages.GetCurDate(1));
            }
            ApplyChanges.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(3000);
        }


        public void CheckAccountComments()
        {
            Thread.Sleep(2000);
            BtnAddComments.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            TextAreaForComments.SendKeys(Helpers.Randomizer.String(5,rusLetters)+Helpers.Randomizer.String(5,letters)+Helpers.Randomizer.String(2,symbols)+Helpers.Randomizer.String(2, digits)+Helpers.Randomizer.StringArabic());
            Thread.Sleep(2000);
            AddCommentsSubmitButton.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
            if (AddedComments.Count == 1)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "There are " + AddedComments.Count + " added comments.<br> Works OK");
            }
            else
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "There are " + AddedComments.Count + " added comments.<br> Something wrong...");
            }
        }

        public void CheckAccountActions(string leadOrAcc)
        {
            Thread.Sleep(2000);
                    //create tp account
            BtnTPAccountCreate.Click();
            int allGroups = SeleniumGetMethod.GetQuantityOfOptionsInDropDown(SelectGroupTPAccount);
            SeleniumGetMethod.WaitForElement(driver, SelectGroupTPAccount);
            SeleniumSetMethods.SelectDropDown(SelectGroupTPAccount, Helpers.Randomizer.Number(1,allGroups));
            BtnSave.Click();
            Thread.Sleep(3000);
            if (leadOrAcc == "lead")
            {
                BackIntoLead.Click();
            }
            if (leadOrAcc == "account")
            {
                        //change password
                BackToAccLink.Click();
                SeleniumGetMethod.WaitForPageLoad(driver);
                Thread.Sleep(2000);
                string oldPass = GenInfoPassword.Text;
                PropertiesCollection._reportingTasks.Log(Status.Info, "Old password " + oldPass);

                BtnChangePassword.Click();
                Thread.Sleep(2000);
                InputNewPassword.SendKeys(Helpers.Randomizer.String(3, rusLetters) + Helpers.Randomizer.String(3, letters) + Helpers.Randomizer.String(2, symbols) + Helpers.Randomizer.String(2, digits));
                BtnSave.Click();
                SeleniumGetMethod.WaitForPageLoad(driver);
                Thread.Sleep(2000);
                if (ChangePasConfirmAlert != null)
                {
                    ChangePasConfirmAlert.Click();
                    SeleniumGetMethod.WaitForPageLoad(driver);
                }
                string newPass = GenInfoPassword.Text;
                PropertiesCollection._reportingTasks.Log(Status.Info, "New password " + newPass);
                try
                {
                    Assert.IsTrue(oldPass != newPass);
                }
                catch (Exception)
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, "Something wrong with password changes");
                }
            } 
        }



        public void CheckAccountMarkInfoAdress()
        {
            Thread.Sleep(2000);
            MarkInfoPencil.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            foreach(var input in MarkInfoAllInputs)
            {
                input.SendKeys(Helpers.Randomizer.String(5, letters)+Helpers.Randomizer.String(3,digits));
                Thread.Sleep(1000);
            }
            int all = SeleniumGetMethod.GetQuantityOfOptionsInDropDown(MarkInfoCountryDrl);
            SeleniumSetMethods.SelectDropDown(MarkInfoCountryDrl, Helpers.Randomizer.Number(1, all));
            MarkInfoBtnApply.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
            AddressPencil.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            foreach (var input in AddressAllInputs)
            {
                input.SendKeys(Helpers.Randomizer.String(5, letters) + Helpers.Randomizer.String(3, digits));
                Thread.Sleep(1000);
            }
            SeleniumSetMethods.SelectDropDown(AddressCountryDrl,Helpers.Randomizer.Number(1, all));
            AddressBtnApply.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
        }


        public void CheckAccountAddInfo()
        {
            Thread.Sleep(2000);
            AddInfoPencil.Click();
            Thread.Sleep(2000);
            SeleniumGetMethod.WaitForPageLoad(driver);
            foreach(var checkbox in AddInfoAllCheckBoxes)
            {
                checkbox.Click();
                Thread.Sleep(1000);
            }
            AddInfoDescription.SendKeys(Helpers.Randomizer.String(5, rusLetters) + Helpers.Randomizer.String(5, letters) + Helpers.Randomizer.String(2, symbols) + Helpers.Randomizer.String(2, digits) + Helpers.Randomizer.StringArabic());
            AddInfoBtnApply.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
        }

        public void CheckAccountDocuments()
        {
            Thread.Sleep(2000);
            BackToAccLink.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            ExpandDocuments.Click();
            Thread.Sleep(2000);
            PlusAddDocuments.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
            int allAllOptions = SeleniumGetMethod.GetQuantityOfOptionsInDropDown(DocTypeDrl);
            SeleniumSetMethods.SelectDropDown(DocTypeDrl, Helpers.Randomizer.Number(1,allAllOptions));
            Thread.Sleep(3000);

            FileUploader.UploadFile(BrowseFiles, BtnSave, TestsConfiguration.Instance.FileUploadPathSeveral,0);
            BtnCancel.Click();
            SeleniumGetMethod.WaitForPageLoad(driver); 
            PropertiesCollection._reportingTasks.Log(Status.Info, "There are " + QuantityOfUploadedFiles.Count + " uploaded files");
            try
            {
                Assert.IsTrue(QuantityOfUploadedFiles.Count == 3);
            }
            catch (Exception)
            {
                PropertiesCollection._reportingTasks.Log(Status.Warning, "Something wrong with quantity of files");
            }
        }



        public void CheckAccountTradeAcc()
        {
            Thread.Sleep(2000);
            int counter = 1;
            do
            {
                ExpandTradeAccounts.Click();
                Thread.Sleep(2000);
                PlusAddTradeAcc.Click();
                SeleniumGetMethod.WaitForPageLoad(driver);
                Thread.Sleep(2000);
                int allAllOptions = SeleniumGetMethod.GetQuantityOfOptionsInDropDown(SelectGroupTPAccount);
                SeleniumSetMethods.SelectDropDown(SelectGroupTPAccount, Helpers.Randomizer.Number(1, allAllOptions));
                Thread.Sleep(3000);
                BtnSaveTPAccount.Click();
                SeleniumGetMethod.WaitForPageLoad(driver);
                new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class=value] a[href*=ACC]")));
                BackToAccLink.Click();
                SeleniumGetMethod.WaitForPageLoad(driver);
                Thread.Sleep(2000);
                counter++;
            }
            while (counter <= 3);
            ExpandTradeAccounts.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(3000);
            try
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "There are " + QuantityOfTradeAccounts.Count + " trade accounts");
                Assert.IsTrue(QuantityOfTradeAccounts.Count == 3);
            }
            catch (Exception)
            {
                PropertiesCollection._reportingTasks.Log(Status.Warning, "Something wrong with quantity of files");
            }
            CrossDeleteTradeAccount.Click();
            BtnSave.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(3000);
            try
            {
                Assert.IsTrue(QuantityOfTradeAccounts.Count == 2);
                PropertiesCollection._reportingTasks.Log(Status.Info, "There are " + QuantityOfTradeAccounts.Count + " trade accounts");
            }
            catch (Exception)
            {
                PropertiesCollection._reportingTasks.Log(Status.Warning, "Something wrong with quantity of files");
            }
        }
        
        public void CheckAccountTasks(string leadOrAcc)
        { 
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class=value] a[href*=ACC]")));
            if (leadOrAcc == "lead")
            {
                BackIntoLead.Click();
            }
            if (leadOrAcc == "account")
            {
                BackToAccLink.Click();
            }
            SeleniumGetMethod.WaitForPageLoad(driver);
            ExpandTasksAccounts.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
            PlusTask.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);

            int allOwners = SeleniumGetMethod.GetQuantityOfOptionsInDropDown(TaskOwnerDrl);
            int allTypes = SeleniumGetMethod.GetQuantityOfOptionsInDropDown(TaskTypeDrl);
            int allStatuses = SeleniumGetMethod.GetQuantityOfOptionsInDropDown(TaskStatusDrl);

            SeleniumSetMethods.SelectDropDown(TaskOwnerDrl, 1);
            SeleniumSetMethods.SelectDropDown(TaskTypeDrl, 1);
            SeleniumSetMethods.SelectDropDown(TaskStatusDrl, 1);
            Thread.Sleep(3000);
            //using js
            JavaScriptInvoker.SetCurDate(WindowsMessages.GetCurDate(1));
            Thread.Sleep(3000);
            //TaskDate.EnterText(WindowsMessages.GetCurDate(1));
            //TaskDateApplyBtn.Click();
            TaskDescription.SendKeys(Helpers.Randomizer.String(7));
            BtnSave.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
            TaskCreatedOpen.Click();
            Thread.Sleep(5000);
                    //edit task 
            SeleniumSetMethods.SelectDropDown(TaskOwnerDrl, allOwners-1);
            SeleniumSetMethods.SelectDropDown(TaskTypeDrl, allTypes-1);
            SeleniumSetMethods.SelectDropDown(TaskStatusDrl, allStatuses-1);
            Thread.Sleep(3000);
            JavaScriptInvoker.SetCurDate(WindowsMessages.GetUsTomorrowDate());
            //TaskDate.Clear();
            //TaskDate.EnterText(WindowsMessages.GetUsTomorrowDate());
            //TaskDateApplyBtn.Click();
            Thread.Sleep(3000);
            TaskDescription.Clear();
            TaskDescription.SendKeys(Helpers.Randomizer.String(7));
            BtnSave.Click();
            Thread.Sleep(2000);
        }

        public void CheckAccountFinTrans()
        {
            Thread.Sleep(2000);
            BackToAccLink.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
            ExpandFinanceTransAccounts.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
            PlusFinTransaction.Click();
            Thread.Sleep(2000);
            SeleniumSetMethods.SelectDropDown(TransAccDrl,1);
            TransAmount.SendKeys("500");
            SeleniumSetMethods.SelectDropDown(TransTypeDrl, 1);
            Thread.Sleep(2000);
            SeleniumSetMethods.SelectDropDown(TransTrApprovalDrl,1);
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.button.submit-button")));
            BtnSave.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
            string pageTitle = TransPageTitle.GetAttribute("innerText");
            try
            {
                Assert.IsTrue(pageTitle == "Monetary Transaction");
                PropertiesCollection._reportingTasks.Log(Status.Info, "Page title is " + pageTitle);
            }
            catch (Exception)
            {
                PropertiesCollection._reportingTasks.Log(Status.Warning, "Something wrong with transactions");
            }
            BackToTpAcc.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            BackToAccLink.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
        }

        public void LeadAndAccMarkInfoEqual()
        {
            OpenLeadTab();
            CreateValAccOrLead("lead");
            CheckAccountMarkInfoAdress();

            IList<IWebElement> markInfoFealds = driver.FindElements(By.CssSelector("div[id*='3_Container'] td > div.value > div > div"));
            List<string> markInfoLeadFealdsText = new List<string>();
            foreach (var el in markInfoFealds)
            {
                markInfoLeadFealdsText.Add(el.Text);
            }
            
            BtnTPAccountCreate.Click();
            SeleniumGetMethod.WaitForElement(driver, SelectGroupTPAccount);
            SeleniumSetMethods.SelectDropDown(SelectGroupTPAccount,1);
            BtnSave.Click();
            Thread.Sleep(2000);
            SeleniumGetMethod.WaitForPageLoad(driver);
            SeleniumGetMethod.WaitForElement(driver,BackToAccLink);

            markInfoFealds = driver.FindElements(By.CssSelector("div[id*='3_Container'] td > div.value > div > div"));
            List<string> markInfoAccFealdsText = new List<string>();
            foreach (var el in markInfoFealds)
            {
                markInfoAccFealdsText.Add(el.Text);
            }

             /*// different order in lead and acc
             for (int i = 0; i < markInfoAccFealdsText.Count; i++)
            {
                Console.WriteLine(markInfoLeadFealdsText[i] + " equal " + " " + markInfoAccFealdsText[i]);
            }
            Console.WriteLine("");*/

            markInfoAccFealdsText.Sort();
            markInfoLeadFealdsText.Sort();
            for (int i = 0; i < markInfoAccFealdsText.Count; i++)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "<b>field from lead</b> " + markInfoLeadFealdsText[i] + " <br><b>field from acc</b> " + " " + markInfoAccFealdsText[i]);
            }
            try
            {
                for (int i = 0; i < markInfoAccFealdsText.Count; i++)
                {
                    Assert.AreEqual(markInfoLeadFealdsText[i], markInfoAccFealdsText[i]);
                }
            }
            catch
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "Something wrong with marketing info");
            }

            BackToAccLink.Click();
        }

    }
}

