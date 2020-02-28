using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DZ_TA5.PageObjects
{
    public class Bing : Search
    {
        public Bing(IWebDriver chrome)
        :base(chrome)
        {
            PageFactory.InitElements(chrome, this);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Url = url;
            SearchInput = searchInput;
            ListOfTitles = listOfTitles;
            NextPage = nextPage;
        }
        
        string url = "https://www.bing.com/";
        
        [FindsBy(How = How.XPath, Using = "//input[@type = 'search']")]
        public IWebElement searchInput;
        
        [FindsBy(How = How.XPath, Using = "//ol[@id = 'b_results']/descendant::h2 | //ol[@id = 'b_results']/descendant::p")]
        private IList<IWebElement> listOfTitles;
        
        [FindsBy(How = How.XPath, Using = "//a[@title = 'Next page']")]
        private IWebElement nextPage;
    }
}