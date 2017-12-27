using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace CrmAutoTestNUnit.Helpers
{
    public class Paging
    {

        public int ItemsFound(PagingData pagingData)
        {
            //int result = JavaScriptInvoker.ReadHttpResponseJSon(url);
            IWebElement itemsOnthePage = PropertiesCollection.driver.FindElement(By.CssSelector(pagingData.recordsFound));
            string itemsOnthePageText = itemsOnthePage.Text;
            string[] several = itemsOnthePageText.Split(' ');
            int value = Int32.Parse(several[0]);
            PropertiesCollection._reportingTasks.Log(Status.Info, "pages text : " + itemsOnthePageText);
            PropertiesCollection._reportingTasks.Log(Status.Info, "There are pages we have : " + value);
            Console.WriteLine(value);
            return value;
        }



        public int SelectPerPage(PagingData pagingData, IWebElement dropdownSelectPerPage)
        {
          
            int[] recOnPageArray = {20, 50, 100, 250};
            if (recOnPageArray[0] > ItemsFound(pagingData))
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "ITEMS FOUND LESS : " + ItemsFound(pagingData));
                return 0;
            }
            else
            {
                int i = 1;
                for (; i < recOnPageArray.Length; i++)
                {
                    if (recOnPageArray[i] >= ItemsFound(pagingData))
                    {
                        PropertiesCollection._reportingTasks.Log(Status.Info, "ITEMS FOUND OK : " + ItemsFound(pagingData));
                        break;
                    }
                }
                var selectElement = new SelectElement(dropdownSelectPerPage);
                SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                //selectElement.SelectByIndex(i - 1);
                selectElement.SelectByIndex(0);
                var valueSelected = selectElement.SelectedOption.Text;
                SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                PropertiesCollection._reportingTasks.Log(Status.Info, "Selected value...: " + valueSelected);
                Console.WriteLine("Selected value is " +valueSelected);
                return Int32.Parse(valueSelected);
            }
        }




        public int GetPagesQuantity(PagingData pagesQuantity)
        {

            SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
            IWebElement pagesaQua = PropertiesCollection.driver.FindElement(By.CssSelector(pagesQuantity.pagesQua));
            string textPages = pagesaQua.Text;
            string[] several = textPages.Split('f');
            int value = Int32.Parse(several[1]);
            PropertiesCollection._reportingTasks.Log(Status.Info, "pages text : " + textPages);
            PropertiesCollection._reportingTasks.Log(Status.Info, "There are pages we have : " + value);
            Console.WriteLine("Pages quantity is " + value);
            return value;
        }





        public string PageOfPagesLogic(PagingData pagesQuantity)
        {
           

            IWebElement pagesaQua = PropertiesCollection.driver.FindElement(By.CssSelector(pagesQuantity.pagesQua));
            string textPages = pagesaQua.Text;
            return textPages;
        }

        public int GetTableRecords(IList<IWebElement> rows)
        {
            int totalRows = rows.Count;
            PropertiesCollection._reportingTasks.Log(Status.Info, "There are rows in the grid...: " + totalRows);
            return totalRows;
        }






        public void CheckPaging(PagingData data)
        {

            IWebElement recordsFound = PropertiesCollection.driver.FindElement(By.CssSelector(data.recordsFound));
            IWebElement dropdownSelectPerPage = PropertiesCollection.driver.FindElement(By.CssSelector(data.dropdownSelectPerPage));
            IWebElement pagesaQua = PropertiesCollection.driver.FindElement(By.CssSelector(data.pagesQua));
                    //check logic
            int selectedValue = SelectPerPage(data, dropdownSelectPerPage);
            SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
            Thread.Sleep(2000);
            IList<IWebElement> tableRecors = PropertiesCollection.driver.FindElements(By.CssSelector(data.tableRecors));
            int records = GetTableRecords(tableRecors);
            PropertiesCollection._reportingTasks.Log(Status.Info, "Selected per page value : " + selectedValue + "<br>" + "There are records in the grid...: " + records);
            Assert.IsTrue(selectedValue == records, "Paging doesn't work properly!!!");

            int numberPages = GetPagesQuantity(data);
            /*string quatLabel = PageOfPagesLogic(data).ToString();
            Assert.IsTrue(quatLabel == $"1 of {numberPages}", "Paging doesn't work properly - smth wrong with label...");
            PropertiesCollection._reportingTasks.Log(Status.Info, "LABEL VALUE : " + quatLabel);*/

            if (numberPages == 1)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "There is only 1 page...");
            }

            if (1 < numberPages && numberPages <= 3)
            {
                for (int i = 1; i < numberPages; i++)
                {
                    IWebElement nextPge = PropertiesCollection.driver.FindElement(By.CssSelector(data.nextPage));
                    SeleniumGetMethod.WaitForElement(PropertiesCollection.driver, nextPge);
                    nextPge.Click();
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                    Thread.Sleep(2000);
                }
               /* quatLabel = PageOfPagesLogic(data).ToString();
                PropertiesCollection._reportingTasks.Log(Status.Info, "label LOOP value : " + quatLabel);
                Assert.IsTrue(quatLabel == $"{numberPages} of {numberPages}", "Paging doesn't work properly - smth wrong with label...loop..");*/
                for (int count = numberPages; count > 1; count--)
                {
                    IWebElement prevPage = PropertiesCollection.driver.FindElement(By.CssSelector(data.prevPage));
                    SeleniumGetMethod.WaitForElement(PropertiesCollection.driver, prevPage);
                    prevPage.Click();
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                    Thread.Sleep(2000);
                }
                /*quatLabel = PageOfPagesLogic(data).ToString();
                Assert.IsTrue(quatLabel == $"{1} of {numberPages}", "Paging doesn't work properly - smth wrong with label...loop..");
                PropertiesCollection._reportingTasks.Log(Status.Info, "label LOOP value : " + quatLabel);*/
            }
            //if (numberPages >= 3)
            if (numberPages > 3)
            {
                numberPages = 4;
                for (int i = 1; i < numberPages; i++)
                {
                    IWebElement nextPge = PropertiesCollection.driver.FindElement(By.CssSelector(data.nextPage));
                    nextPge.Click();
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                    Thread.Sleep(2000);
                }
                for (numberPages = 4; numberPages > 1; numberPages--)
                {
                    IWebElement prevPage = PropertiesCollection.driver.FindElement(By.CssSelector(data.prevPage));
                    SeleniumGetMethod.WaitForElement(PropertiesCollection.driver, prevPage);
                    prevPage.Click();
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                    Thread.Sleep(2000);
                }
            }
            IWebElement lastPage = PropertiesCollection.driver.FindElement(By.CssSelector(data.lastPage));
            SeleniumGetMethod.WaitForElement(PropertiesCollection.driver, lastPage);
            lastPage.Click();
            Thread.Sleep(2000);
            /*quatLabel = PageOfPagesLogic(data).ToString();
            Assert.IsTrue(quatLabel == $"{numberPages} of {numberPages}", "Paging doesn't work properly - smth wrong with label...");*/
            IWebElement firstPage = PropertiesCollection.driver.FindElement(By.CssSelector(data.firstPage));
            SeleniumGetMethod.WaitForElement(PropertiesCollection.driver, firstPage);
            firstPage.Click();
            /*quatLabel = PageOfPagesLogic(data).ToString();
            Assert.IsTrue(quatLabel == $"1 of {numberPages}", "Paging doesn't work properly - smth wrong with label...");*/
            SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
        }


    }

    public class PagingData
    {
        public string recordsFound { get; set; }
        public string dropdownSelectPerPage { get; set; }
        public string goButton { get; set; }
        public string pagesQua { get; set; }
        public string nextPage { get; set; }
        public string prevPage { get; set; }
        public string lastPage { get; set; }
        public string firstPage { get; set; }
        public string setGotoPage { get; set; }
        public string goToSkipPage { get; set; }
        public string tableRecors { get; set; }
    }

}



