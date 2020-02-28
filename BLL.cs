using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using WDSE;
using System.IO;
using System.Drawing;
using DZ_TA5.PageObjects;

namespace DZ_TA5
{
    public class BLL
    {
        private IWebDriver driver;
        public BLL(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public void SearchInGoogle()
        {
            Google google = new Google(driver);
            google.GoToUrl();
            google.FillSearchInput();
            google.FindConsist();
        }
    }
}