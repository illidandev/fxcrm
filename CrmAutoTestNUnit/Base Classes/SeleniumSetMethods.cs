using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;
using AventStack.ExtentReports;

namespace CrmAutoTestNUnit
{
    public enum SelectType
    {
        Id,
        Name,
        CssSelector,
        ClassName,
        Xpath,
        LinkText,
        PartialLinkText,
        TagName

    }
    public static class SeleniumSetMethods
    {
        //Enter Text
        /// <summary>
        /// Extended method for entered text in the control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element ,string value)
        {

            element.SendKeys(value);
        }
        //Click into a button, Checkbox,option link ect
        public static void Click(this IWebElement element)
        {
            element.Click();
        } 
        
        /// <summary>
        /// Selecting a drop down control
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element">value</param>
        /// <param name="value">text</param>
        /// <param name="elementtype">id or name</param>
        
        public static void SelectDropDown(this IWebElement element, int value)
        {

            new SelectElement(element).SelectByIndex(value);

        }

        public static void SelectDropDownRandom(IWebElement element)
        {
            int allOptions = SeleniumGetMethod.GetQuantityOfOptionsInDropDown(element);
            if(allOptions == 0)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "<b> There are no options in drop down list...</b>");
                return;
            }
            try
            {
                SelectDropDown(element, Helpers.Randomizer.Number(1, allOptions));
            }
            catch(Exception e)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "<b>Can't select default value from drop down list...</b><br>" + e.ToString());
            }

        }

       



        //Tables
        //Alerts
        //Pop up
        //Div
        //modal window
        //multi checkes
        //pop up

    }
}
