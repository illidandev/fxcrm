using AventStack.ExtentReports;
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
using CrmAutoTestNUnit.PageObjects.Activities;
using System.Threading;
using System.Reflection;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using CrmAutoTestNUnit.DB_connectors;
namespace CrmAutoTestNUnit.Tests
{
    [TestFixture("egor.t", "Chrome")]
    public class Activities:PropertiesCollection
    {
        public Activities(string browserName, string user) : base(browserName, user) { }

        ConnectToDb db = new ConnectToDb();
        ForexCrmFolders el = new ForexCrmFolders();

        [Test, Category("Check Sort")]
        public void GoThroughAllSubFolders()
        {
            var pageActivities = _pages.GetPage<PageObjectActivities>();
            pageActivities.ActivitiesOpenSubTab();   

        }



        [Test, Category("Check Search")]
        public void CheckSearchActivitiesAllSubFolders()
        {
            var pageActivities = _pages.GetPage<PageObjectActivities>();
            for (int i = 0; i < pageActivities.SubFolderItemsActivities.Count; i++)
            {
                el.OpenTargetSubfolder(pageActivities.LinksPanel[1], pageActivities.SubFolderItemsActivities, i);
                pageActivities.CheckSearch();
            }
        }


    }
}
