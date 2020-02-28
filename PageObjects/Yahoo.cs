using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DZ_TA5.PageObjects
{
    public class Yahoo : Search
    {
        string url = "https://www.yahoo.com/";
        
        
        [FindsBy(How = How.Id, Using = "header-search-input")]
        public IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//ol[contains(@class,'searchCenterMiddle')]/descendant::h3[@class='title'] | //p[@class='lh-16']")]
        private IList<IWebElement> listOfTitles;
      
        [FindsBy(How = How.CssSelector, Using = "a.next")]
        private IWebElement nextPage;
        
        public Yahoo(IWebDriver chrome)
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
    }
}