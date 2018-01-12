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

namespace CrmAutoTestNUnit
{
    public class LoginPageObjects : PageBase
    {

        public LoginPageObjects(PagesManager factory) : base(factory) { }

        [FindsBy(How = How.CssSelector, Using = "#sign-up-in")]
        public IWebElement LaunchIn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name=UserName]")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name=Password]")]
        public IWebElement UserPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.form-group.mt30 >a[class*=button]")]
        public IWebElement btnLogin { get; set; }


        public void  Login(String userName,String password)
        {
            SeleniumGetMethod.WaitForPageLoad(driver);
            new WebDriverWait(driver,TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible((By.CssSelector("input[name=UserName]"))));
                    //Enter UserName and Password to launch intoSystem
            UserName.EnterText(userName);
            UserPassword.EnterText(password);
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable((By.CssSelector("div.form-group.mt30 >a[class*=button]"))));
            btnLogin.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
                        //waiting to ensure that we can obtain current url properly
            Thread.Sleep(5000);
                             //check correct login  
            string currentUrl = driver.Url;      
            Console.WriteLine(currentUrl);
            bool isLoginSuccesful = currentUrl.Contains("ModuleItems");
            Assert.IsTrue(isLoginSuccesful);
            if(isLoginSuccesful)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "<b>LOGIN SUCCESSFUL</b> ");
            }
        }
    }
}
