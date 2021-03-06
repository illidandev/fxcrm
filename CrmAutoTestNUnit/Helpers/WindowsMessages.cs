﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using System.Threading;

namespace CrmAutoTestNUnit.Helpers
{
    public class WindowsMessages
    {
        public static bool IsAlertPresent()
        {
            try
            {
                PropertiesCollection.driver.SwitchTo().Alert().Accept();
                PropertiesCollection._reportingTasks.Log(Status.Info, "Alert exists");
                return true;
            }
            catch (NoAlertPresentException e)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "There is No Alert!<br>" + e.ToString());
                return false;
            }
        }

        public static string GetCurDate(int cultureYouNeed)
        {
            string cdate = "";
            CultureInfo culture;
            if (cultureYouNeed == 1)        //EN-US
            {
                culture = new CultureInfo("en-US");
                cdate = DateTime.Now.ToString("M/d/yyyy");
                //Console.WriteLine("Current date formant of {0} culture is  : {1}  today: {2}", culture.DisplayName, culture.DateTimeFormat.ShortDatePattern, cdate);
                return cdate;
            }
            if (cultureYouNeed == 2)        //GERMANY-TURKEY
            {
                culture = new CultureInfo("de-DE");
                cdate = DateTime.Now.ToString("dd.MM.yyyy");
                return cdate;
            }
            if (cultureYouNeed == 3)        //FRA-ITALY
            {
                culture = new CultureInfo("fr-FR");
                cdate = DateTime.Now.ToString("dd/MM/yyyy");
                return cdate;
            }
            if (cultureYouNeed == 4)        //CHINA
            {
                culture = new CultureInfo("zh-CHS");
                cdate = DateTime.Now.ToString("yyyy/M/d");
                return cdate;
            }
            else return DateTime.Now.ToString("M/d/yyyy");
        }


        public static string GetUsTomorrowDate()
        {
            var tomorrow = DateTime.Now.AddDays(1);
            string cdate = tomorrow.ToString("M/d/yyyy");
            //Console.WriteLine(cdate);
            return cdate;
        }


        public bool IsPopUpVisible(IWebElement element)
        {
            Thread.Sleep(3000);
            bool isPopUpVis = false;
            try
            {
                string Height = element.GetAttribute("offsetHeight");
                string Width = element.GetAttribute("offsetWidth");
                PropertiesCollection._reportingTasks.Log(Status.Info, "Pop Up height is " + Height + "<br>" + "Pop Up width is " + Width);
                if (Height != "0" & Width != "0" & Height != null & Width != null)
                {
                    isPopUpVis = true;
                }
                PropertiesCollection._reportingTasks.Log(Status.Info, isPopUpVis.ToString());
                return isPopUpVis;
            }
            catch(Exception msg)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "Can't check is pop up visible....<br>" + msg.ToString());
                PropertiesCollection._reportingTasks.Log(Status.Info, isPopUpVis.ToString());
                return isPopUpVis;
            }
        }
    }
}
