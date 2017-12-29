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
