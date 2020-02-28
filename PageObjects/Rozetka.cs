using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DZ_TA5.PageObjects
{
    public class Rozetka: ShopFilter
    {
        
        [FindsBy(How = How.XPath, Using = "//div[@class = 'slider-filter__inner']/input")]
        private IWebElement minPriceInput;
        
        [FindsBy(How = How.XPath, Using = "//div[@class = 'slider-filter__inner']/button")]
        private IWebElement submitPriceButton;

        [FindsBy(How = How.XPath, Using = "//span[@class='exponea-close-cross']")]
        private IWebElement closeAdd;

        [FindsBy(How = How.XPath, Using = "//span[@class = 'goods-tile__price-value']")]
        private IList<IWebElement> listOfPrice;

        private readonly string url = "https://rozetka.com.ua/ua/mobile-phones/c80003/";
        
        private By add = By.CssSelector("//a[@id='rz-banner']");

        public Rozetka(IWebDriver Chrome)
        :base(Chrome)
        {
            PageFactory.InitElements(Chrome, this);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            MinPriceInput = minPriceInput;
            SubmitPriceButton = submitPriceButton;
            CloseAdd = closeAdd;
            ListOfPrice = listOfPrice;
            Url = url;
            Add = add;
        }
        
        
    }
}