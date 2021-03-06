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
using CrmAutoTestNUnit.Base_Classes;
using OpenQA.Selenium.Interactions;
using CrmAutoTestNUnit.PageObjects.Clients;
using System.Threading;
using System.Reflection;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using CrmAutoTestNUnit.DB_connectors;

namespace CrmAutoTestNUnit.Test
{
    [TestFixture("egor.t","Chrome")]
    public class Clients : PropertiesCollection
    {
        public Clients(string browserName, string user) : base(browserName, user) { }

        ConnectToDb db = new ConnectToDb();
        ForexCrmFolders el = new ForexCrmFolders();


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
        //[Ignore("Ignore a fixture")]
        public void CheckSearchClientsAllSubFolders()
        {
         
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            var pageBase = _pages.GetPage<PageBase>();
            for (int i = 0; i < pageAccounts.SubFolderItemsClients.Count; i++)
            {
                el.OpenTargetSubfolder(pageAccounts.LinksPanel[0], pageAccounts.SubFolderItemsClients, i);
                pageAccounts.CheckSearch();
                pageBase.CheckSearch();
            }

        }


        [Test, Category("Check PAGING")]
        //[Repeat(3)]
        [Ignore("Ignore a fixture")]
        public void TryCheckPaging()
        {
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            pageAccounts.OpenLeadTab();
                        //pageAccounts.SettingsOpenSubTabInstruments();
            //inside leads
            pageAccounts.PagingTest();
            //pageAccounts.OpenAccountTab();
            //pageAccounts.PagingTest();
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
        //[Ignore("Ignore a fixture")]
        public void CheckTabsSwitch()
        {
         
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            pageAccounts.ClientsOpenSubTab();
            pageAccounts.ActivitiesOpenSubTab();
            pageAccounts.ReportsOpenSubTab();
            pageAccounts.SettingsOpenSubTab();
            
        }



        [Test, Category("Check Lead Folder")]
        //[Ignore("Ignore a fixture")]
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
            //pageAccounts.CreateValidAcc();
            pageAccounts.CreateNewAccount("account");
            Thread.Sleep(3000);
        }



        [Test, Category("Check Account Folder")]
       // [Ignore("Ignore a fixture")]
        public void CreateAccAndLeadEmailFollow()
        {
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            Thread.Sleep(3000);
            pageAccounts.OpenLeadTab();
            pageAccounts.CreateValAccOrLead("lead");
            Thread.Sleep(3000);
            pageAccounts.OpenAccountTab();
            pageAccounts.CreateValAccOrLead("account", true);
            /*_reportingTasks.Log(Status.Info, "HERE IS THE LAST CHECK )");
            pageAccounts.OpenAccountTab();
            pageAccounts.CreateValAccOrLead("account");*/
        }

        [Test, Category("Check Account Lead Mark Info")]
       // [Ignore("Ignore a fixture")]
        public void CheckMarkInfoLeadAcc()
        {
            var pageAccounts = _pages.GetPage<PageObjectAccounts>();
            pageAccounts.LeadAndAccMarkInfoEqual();
        }


        [Test, Category("DB")]
        [Ignore("Ignore a fixture")]
        public void CheckDbConnetection()
        { 
            db.ConnectToDbTest();

            
        }



      



    }
}
