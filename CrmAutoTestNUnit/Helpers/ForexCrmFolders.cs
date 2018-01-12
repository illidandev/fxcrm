using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal;
using CrmAutoTestNUnit.PageObjects;
using OpenQA.Selenium.Interactions;


namespace CrmAutoTestNUnit.Helpers
{
    public class ForexCrmFolders
    {
        public  void OpenTargetSubfolder(IWebElement folderToOpen, IList<IWebElement> folderItems, int indexItemToOpen)
        {
            SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
            //(new Actions(PropertiesCollection.driver)).MoveToElement(folderToOpen).Perform();
            folderToOpen.Click();
            SeleniumGetMethod.WaitForElement(PropertiesCollection.driver, folderItems.Last());
            PropertiesCollection._reportingTasks.Log(Status.Info, "<b> Folder to open:  </b>:  " + "<h5>" + folderToOpen.Text + " ---> " + folderItems[indexItemToOpen].Text+ "</h5>");
            folderItems[indexItemToOpen].Click();
            SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
            Thread.Sleep(2000);
        }

    }

}
