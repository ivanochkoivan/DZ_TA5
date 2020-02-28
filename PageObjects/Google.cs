using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace DZ_TA5.PageObjects
{
    public class Google : Search
    {
        
        [FindsBy(How = How.XPath, Using = "//input[@type='text']")]
        public IWebElement searchInput;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='r']//h3 | //div[@class='ads-visurl']/following-sibling::h3 | //span[@class='st'] | //div[@class = 'ads-creative']")]
        private IList<IWebElement> listOfTitles;

        [FindsBy(How = How.XPath, Using = "//a[@class='pn']")]
        private IWebElement nextPage;

        public Google(IWebDriver Chrome) 
            :base(Chrome)
        {
            PageFactory.InitElements(Chrome, this);
            driver.Manage().Window.Maximize();
            Url = "https://www.google.com/";
            SearchInput = searchInput;
            ListOfTitles = listOfTitles;
            NextPage = nextPage;
        }
    }
}