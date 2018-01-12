using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;
using System.IO;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Reflection;
using System.Threading;

namespace CrmAutoTestNUnit.Helpers
{
    class FileUploader
    {
        public static void UploadFile(IWebElement webElement, IWebElement saveButton, string filePath, int isSingle)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.IndexOf("bin"));
            string projectPth = new Uri(actualPath).LocalPath;

            if (isSingle == 1 && !File.Exists(projectPth + filePath))
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "file not exists" + projectPth + filePath);

                return;
            }
            else
            {
                if (!webElement.Displayed && !webElement.Enabled)
                {
                    throw new Exception("Button to click isn't visible or/and enable");
                }
                else
                {
                    webElement.Click();
                    Thread.Sleep(3000);
                    SendKeys.SendWait(projectPth + filePath);
                    Thread.Sleep(3000);
                    SendKeys.SendWait(@"{Enter}");
                    Thread.Sleep(3000);
                    saveButton.Click();
                    //because there is exception in log ((
                    /*if (!WindowsMessages.IsAlertPresent())
                    {
                        saveButton.Click();
                    }*/

                }
            }
            Thread.Sleep(3000);
        }


        public static void DownLoadFile(IWebElement webElement, IWebElement webElement2)
        {
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Downloads\\");
            string path = new Uri(path2).LocalPath;
            string[] filePaths = Directory.GetFiles(path);
            var quantityFilesBefore = filePaths.Count();
            webElement.Click();
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable((By.Id(webElement2.GetAttribute("Id")))));
            webElement2.Click();
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable((By.Id(webElement.GetAttribute("Id")))));
            var quantityFilesAfter = Directory.GetFiles(path).Count();
            Assert.IsTrue(quantityFilesAfter > quantityFilesBefore, "Yes, downloading works");
            PropertiesCollection._reportingTasks.Log(Status.Info, "Files founded BEFORE: " + quantityFilesBefore.ToString() + "<br>" + " Files founded AFTER : " + quantityFilesAfter.ToString());
        }

        
    }
}
