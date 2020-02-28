using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DZ_TA5.PageObjects
{
    public class Wikipedia
    {
        private IWebDriver driver;
        private string path = "C:\\temp\\";
        private string url = "https://en.wikipedia.org/wiki/Main_Page";

        [FindsBy(How = How.XPath, Using = "//a[@class='image']/img")]
        private IList<IWebElement> contentImage;

        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(url);
        }
        
        public void MakeScreenshootContentImage()
        {
            for (int i = 0; i< contentImage.Count;i++)
            {
                Const.MakeScreenshotElement(driver, path + $"result{i}.png", contentImage[i]);
            }
        }
        
        public Wikipedia(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
            driver.Manage().Window.Maximize();
        }
        
    }
}