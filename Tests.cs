using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using DZ_TA5.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DZ_TA5
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Rozetka1()
        {
            IWebDriver driver = new ChromeDriver();
            BLL rozetka = new BLL(driver);
            rozetka.FilterTestRozetka();
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
            BLL bing = new BLL(driver);
            bing.SearchInBing();
        }

        [Test]
        public void Yahoo()
        {
            IWebDriver driver = new ChromeDriver();
            BLL yahoo = new BLL(driver);
            yahoo.SearchInYahoo();
        }

        [Test]
        public void Wiki()
        {
            IWebDriver driver = new ChromeDriver();
            BLL wiki = new BLL(driver);
            wiki.Screenshot();
        }

        [Test]
        public void AliExpress()
        {
            IWebDriver driver = new ChromeDriver();
            BLL ali = new BLL(driver);
            ali.FilterTestAli();
        }
    }
}