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
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;



namespace CrmAutoTestNUnit.PageObjects.Activities
{
    public class PageObjectActivities: PageBase
    {
        public PageObjectActivities(PagesManager factory) : base(factory) { }
        public PageObjectActivities(PagesManager factory, string windowHandle): base(factory, windowHandle){ }


        /*----------------------------------------ACTIVITIES MONEY TRANSACTIONS-----------------------------------*/
        [FindsBy(How = How.CssSelector, Using = "[id='2_Container'] a[class*=ico-edit]")]
        public IList<IWebElement> PencilsCredCardAndWiretransferDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id='1_Container'] a[class*=ico-edit]")]
        public IWebElement PencilGenInfo { get; set; }



        [FindsBy(How = How.CssSelector, Using = "div[id*='2_Container'] input:not([placeholder]),div[id*='2_Container'] textarea:not([placeholder])")]
        public IList<IWebElement> AllInputsCredCardWiretransfer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='2_Container'] select")]
        public IList<IWebElement> AllDropDownsCredCardWiretransfer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id='2_Container'] a[class*=submit-button]")]
        public IList<IWebElement> BtnApplyFor2Forms { get; set; }



        public string digits = "1234567890", symbols = "!@#$%^&*()_+", letters = "abcdefghijklmopqrstuvwxyz", rusLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";







        public void TestMoneyTransaction()
        {
            Thread.Sleep(2000);

            foreach (var pencil in PencilsCredCardAndWiretransferDetails)
            {
                pencil.Click();
            }
            SeleniumGetMethod.WaitForPageLoad(driver);

            foreach (var input in AllInputsCredCardWiretransfer)
            {
                input.SendKeys(Helpers.Randomizer.String(5, letters) + Helpers.Randomizer.String(3, digits));
                Thread.Sleep(1000);
            }

            foreach (var drl in AllDropDownsCredCardWiretransfer)
            {
                SeleniumSetMethods.SelectDropDownRandom(drl);
                Thread.Sleep(1000);
            }

            foreach (var apply in BtnApplyFor2Forms)
            {
                apply.Click();
                Thread.Sleep(2000);
            }
            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(2000);
        }





                //virtual in PageBase
        /*public override void CheckSearch()
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

            SearchFormCreatedDate.Click();
            foreach (var date in CalendarBoxFromTo)
            {
                date.Clear();
                date.SendKeys(WindowsMessages.GetCurDate(1));
                SeleniumGetMethod.WaitForPageLoad(driver);
                Thread.Sleep(1000);
            }
            BtnApply.Click();

            SeleniumGetMethod.WaitForPageLoad(driver);
            Thread.Sleep(3000);
            xClearAllFilters.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
        }*/
    }
}
