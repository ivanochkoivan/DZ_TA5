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
        public void SearchInYahoo()
        {
            Yahoo yahoo = new Yahoo(driver);
            yahoo.GoToUrl();
            yahoo.FillSearchInput();
            yahoo.FindConsist();
        }
        public void SearchInBing()
        {
            Bing bing = new Bing(driver);
            bing.GoToUrl();
            bing.FillSearchInput();
            bing.FindConsist();
        }

        public void Screenshot()
        {
            Wikipedia wiki = new Wikipedia(driver);
            wiki.GoToUrl();
            wiki.MakeScreenshootContentImage();
        }

        public void FilterTestAli()
        {
            AliExpress ali = new AliExpress(driver);
            ali.GoToUrl();
            ali.LogIn();
            ali.SetPrice();
            ali.CheckPrice();
        }

        public void FilterTestRozetka()
        {
            Rozetka roz = new Rozetka(driver);
            roz.GoToUrl();
            roz.SetPrice();
            roz.CheckPrice();
        }
    }
}