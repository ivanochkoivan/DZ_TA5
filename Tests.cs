using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using DZ_TA5.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DZ_TA5
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Rozetka1()
        {
            IWebDriver driver = new ChromeDriver();
            var rozetka = new Rozetka(driver);
            rozetka.GoToUrl();
            rozetka.SetPrice();
            rozetka.CheckPrice();
        }


        [Test]
        public void Google()
        {
            IWebDriver Chrome = new ChromeDriver();
            BLL google = new BLL(Chrome);
            google.SearchInGoogle();
        }

        [Test]
        public void Bing()
        {
            IWebDriver driver = new ChromeDriver();
            Bing bing = new Bing(driver);
            bing.GoToUrl();
            bing.FillSearchInput();
            bing.FindConsist();
        }

        [Test]
        public void Yahoo()
        {
            IWebDriver driver = new ChromeDriver();
            Yahoo yahoo = new Yahoo(driver);
            yahoo.GoToUrl();
            yahoo.FillSearchInput();
            yahoo.FindConsist();
        }

        [Test]
        public void Wiki()
        {
            IWebDriver driver = new ChromeDriver();
            Wikipedia wiki = new Wikipedia(driver);
            wiki.GoToUrl();
            wiki.MakeScreenshootContentImage();
        }

        [Test]
        public void AliExpress()
        {
            IWebDriver driver = new ChromeDriver();
            AliExpress ali = new AliExpress(driver);
            ali.GoToUrl();
            ali.LogIn();
            ali.SetPrice();
            ali.CheckPrice();
        }
    }
}