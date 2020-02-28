using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DZ_TA5.PageObjects
{
    public class Search 
    {
        public IWebDriver driver;
        public string Url { get; set; }
        public IWebElement SearchInput { get; set; }
        public IList<IWebElement> ListOfTitles { get; set; }
        public IWebElement NextPage { get; set; }

        public Search(IWebDriver Chrome)
        {
            driver = Chrome;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(Url);
        }
        public void FillSearchInput()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SearchInput.SendKeys(Const.keyWord + Keys.Enter);
        }
        public void FindConsist()
        {
            for (int i = 1; i < 10; i++)
            {
                
                int iterator = 0;
                foreach (IWebElement item in ListOfTitles)
                {
                    if (item.Text.Contains(Const.companyName))
                    {
                        Const.MakeScreenShot(driver, "C:\\temp\\", $"result{i}.png");
                        int numPage = i;
                        i = 9;
                        break;
                    }
                    else
                    {
                        iterator++;
                    }
                }
                
                if (iterator==ListOfTitles.Count)
                {
                    NextPage.Click();
                }
                //listOfTitles.Clear();
                iterator = 0;
            }
        }
    }
}