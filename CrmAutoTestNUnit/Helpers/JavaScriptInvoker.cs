using System;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;

namespace CrmAutoTestNUnit.Helpers
{
    public static class JavaScriptInvoker
    {
       
       public static void  ClickInModal(string replaceWithPar, string replaceWithChild)
        
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\clickInModal.js");
            string path = new Uri(path2).LocalPath;


            string jsString = File.ReadAllText(path);
            //jsString.Replace("par", replaceWithPar);
            //jsString.Replace("child", replaceWithChild);
            executor.ExecuteScript(jsString);
        }

        public static void ScrollToElement(string replaceWith)
        {

            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\scrollToElement.js");
            string path = new Uri(path2).LocalPath;


            string jsString = File.ReadAllText(path);
            executor.ExecuteScript(jsString.Replace("@", replaceWith));
        }

        public static void ScrollToBottom(string replaceWith)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\scrollDown.js");
            string path = new Uri(path2).LocalPath;

            string jsString = File.ReadAllText(path);
            executor.ExecuteScript(jsString.Replace("@", replaceWith));

        }


        public static void ScrollToTop(string replaceWith)
        {
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\scrollUp.js");
            string path = new Uri(path2).LocalPath;

            string jsString = File.ReadAllText(path);
            executor1.ExecuteScript(jsString.Replace("@", replaceWith));

        }


        public static void SetCurDate(string replaceWith)
        {
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\elemSetValue.js");
            string path = new Uri(path2).LocalPath;

            string jsString = File.ReadAllText(path);
            executor1.ExecuteScript(jsString.Replace("@", replaceWith));

        }

        public static int ReadHttpResponseJSon(string replaceWith)
        {
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\readJsonItemsCount.js");
            string path = new Uri(path2).LocalPath;

            string jsString = File.ReadAllText(path);
            string toEx = jsString.Replace("@", replaceWith);
            var readyState = executor1.ExecuteScript(toEx);
            Console.WriteLine(readyState);
            Console.WriteLine("");
            PropertiesCollection._reportingTasks.Log(Status.Info, "There are items  " + readyState);
            return Convert.ToInt32(readyState);
        }


    }


}
