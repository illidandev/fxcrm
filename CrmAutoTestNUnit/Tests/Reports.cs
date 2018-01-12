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
using System.Threading;
using System.Reflection;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using CrmAutoTestNUnit.DB_connectors;

namespace CrmAutoTestNUnit.Tests
{
    [TestFixture("egor.t", "Chrome")]
    public class Reports:PropertiesCollection
    {
        public Reports(string browserName, string user) : base(browserName, user) { }

        ForexCrmFolders el = new ForexCrmFolders();




        [Test, Category("Check Sort")]
        public void CheckSortReportsAllSubFolders()
        {
            var pageBase = _pages.GetPage<PageBase>();
            for (int i = 0; i < pageBase.SubFolderItemsReports.Count; i++)
            {
                el.OpenTargetSubfolder(pageBase.LinksPanel[2], pageBase.SubFolderItemsReports, i);
                pageBase.CheckSort();
            }
        }


        [Test, Category("Check Search")]
        public void CheckSearchSettingsAllSubFolders()
        {
            var pageBase = _pages.GetPage<PageBase>();
            for (int i = 0; i < pageBase.SubFolderItemsReports.Count; i++)
            {
                el.OpenTargetSubfolder(pageBase.LinksPanel[2], pageBase.SubFolderItemsReports, i);
                pageBase.CheckSearch();
              
            }
        }
    }
}
