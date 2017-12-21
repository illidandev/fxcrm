using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace CrmAutoTestNUnit.Base_Classes
{

    public class GetSreenShot
    {
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }
        public static  string Capture(IWebDriver driver ,string sreenName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.IndexOf("bin"))+ ("Reports\\Screens\\"+ sreenName+GetRandomNumber(1, 10)+".png");
            string projectPth = new Uri(actualPath).LocalPath;
            screenshot.SaveAsFile(projectPth, ScreenshotImageFormat.Png);
            return projectPth;
        }
        public static IWebElement HighlightJavascript(IWebDriver driver, string elem, SelectType typeElem)
        {

            IWebElement elemcolor = null;
            switch (typeElem)
            {
                
                case SelectType.Id:

                    elemcolor = driver.FindElement(By.Id(elem));
                    break;

                case SelectType.ClassName:

                    elemcolor = driver.FindElement(By.ClassName(elem));
                    break;

                case SelectType.CssSelector:

                    elemcolor = driver.FindElement(By.CssSelector(elem));
                    break;

                case SelectType.Name:

                    elemcolor = driver.FindElement(By.Name(elem));
                    break;
                case SelectType.Xpath:

                    elemcolor = driver.FindElement(By.XPath(elem));
                    break;

                case SelectType.LinkText:

                    elemcolor = driver.FindElement(By.LinkText(elem));
                    break;

                case SelectType.PartialLinkText:

                    elemcolor = driver.FindElement(By.PartialLinkText(elem));
                    break;
                case SelectType.TagName:

                    elemcolor = driver.FindElement(By.TagName(elem));
                    break;
            }
            var javaScriptDriver = (IJavaScriptExecutor)driver;
            //string highlightJavascript = @"arguments[0].style.border='3px solid red'";
            string highlightJavascript = @"arguments[0].style.border='5px outset blue'";
            javaScriptDriver.ExecuteScript(highlightJavascript, elemcolor);
            return elemcolor;
        }

        public static string GetElementScreenShort(IWebDriver driver, string elementVal, string sreenName,SelectType type)
        {

            var element = HighlightJavascript(driver, elementVal, type);

            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.IndexOf("bin")) + ("Reports\\Screens\\" + sreenName + GetRandomNumber(1, 10) + ".png");
            string projectPth = new Uri(actualPath).LocalPath;
            var img = Image.FromStream(new MemoryStream(sc.AsByteArray)) as Bitmap;
            /*var imgnew =*/ img.Clone(new Rectangle(element.Location, element.Size), img.PixelFormat);
            img.Save(projectPth, ImageFormat.Png);
            return projectPth;
        }


    }
}
