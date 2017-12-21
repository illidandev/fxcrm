﻿using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using CrmAutoTestNUnit.PageObjects;
using CrmAutoTestNUnit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmAutoTestNUnit.Helpers;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using CrmAutoTestNUnit.TestsInputData;
using CrmAutoTestNUnit.Base_Classes;
using OpenQA.Selenium.Interactions;
using CrmAutoTestNUnit.PageObjects.Clients;
using System.Threading;
using System.Reflection;
using System.Net;
using Newtonsoft.Json;
using System.Web;

namespace CrmAutoTestNUnit.Test
{
    [TestFixture("Chrome","egor.t")]
    public class Clients : PropertiesCollection
    {
        public Clients(string browserName, string user) : base(browserName, user) { }


        [Test,Category("Check Sort")]
        //[Ignore("Ignore a fixture")]
        public void TryCheckSortClients()
        {
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            pageAccounts.OpenAccountTab();
                pageAccounts.CheckSort();
            pageAccounts.OpenLeadTab();
                pageAccounts.CheckSort();
            pageAccounts.OpenTradeAccountsTab();
                pageAccounts.CheckSort();
        }

        [Test, Category("Check Search")]
        //[Repeat(3)]
        public void TryCheckSearchClients()
        {
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
                    //inside accounts
                pageAccounts.CheckSearch(); 
            pageAccounts.OpenLeadTab();
                pageAccounts.CheckSearch();
            pageAccounts.OpenTradeAccountsTab();
                pageAccounts.CheckSearch();
        }


        [Test, Category("Check PAGING")]
        public void TryCheckPaging()
        {
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            pageAccounts.OpenLeadTab();
            //inside leads
            pageAccounts.CheckPagingInStyleFolder();
        }


        [Test, Category("PopUpDetector")]
        [Ignore("Ignore a fixture")]
        public void PopUpDetectorCheck()
        {
            Thread.Sleep(3000);
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            WindowsMessages messages = new WindowsMessages();
            pageAccounts.BtnNew.Click();
                messages.IsPopUpVisible(pageAccounts.PopUpDetector);
            pageAccounts.BtnCloseCross.Click();
                messages.IsPopUpVisible(pageAccounts.PopUpDetector);
            pageAccounts.BtnNew.Click();
                messages.IsPopUpVisible(pageAccounts.PopUpDetector);
            pageAccounts.BtnCloseCross.Click();
                messages.IsPopUpVisible(pageAccounts.PopUpDetector);
        }



        [Test, Category("Check tabs switching")]
        public void CheckTabsSwitch()
        {
         
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            pageAccounts.ClientsOpenSubTab();
            pageAccounts.ActivitiesOpenSubTab();
            pageAccounts.ReportsOpenSubTab();
            pageAccounts.SettingsOpenSubTab();
            
        }



        [Test, Category("Check Lead Folder")]
         //[Repeat(5)]
        public void CheckLeadFolder()
        {
         
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            pageAccounts.OpenLeadTab();
            pageAccounts.CreateNewAccount("lead");
            Thread.Sleep(3000);
        }





        [Test, Category("Check Account Folder")]
       // [Repeat(3)]
        public void CheckAccountFolder()
        {
          
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            pageAccounts.OpenAccountTab();
            // pageAccounts.CreateValidAcc();
            pageAccounts.CreateNewAccount("account");
            Thread.Sleep(3000);
        }


        [Test, Category("Check Account Folder")]
        public void CreateAccOrLeadUniversal()
        {
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            //Thread.Sleep(3000);
            //pageAccounts.OpenLeadTab();
            //pageAccounts.CreateValAccOrLead("lead");
            Thread.Sleep(3000);
            pageAccounts.OpenAccountTab();
            pageAccounts.CreateValAccOrLead("account");
        }




    }
}