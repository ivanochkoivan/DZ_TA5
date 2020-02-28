using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace DZ_TA5.PageObjects
{
    public class AliExpress: ShopFilter
    {
        private string logIn = "olejatestick@gmail.com";
        private string password = "123456789qazx";

        [FindsBy(How = How.XPath, Using = "//span[@class ='register-btn']/a")]
        private IWebElement buttonLogIn;

        [FindsBy(How = How.XPath, Using = "//iframe[@id='alibaba-login-box']")]
        private IWebElement frameLogIn;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'close')]")]
        private IWebElement closeAdd;

        [FindsBy(How = How.XPath, Using = "//span[text() = 'Мой профиль']")]
        private IWebElement myProfile;

        [FindsBy(How = How.XPath, Using = "//form[@id = 'login-form']/descendant::input[@type = 'text']")]
        private IWebElement emailInput;

        [FindsBy(How = How.XPath, Using = "//form[@id = 'login-form']/descendant::input[@type = 'password']")]
        private IWebElement passwoedInput;

        [FindsBy(How = How.XPath, Using = "//form[@id = 'login-form']/descendant::button")]
        private IWebElement submitLogIn;

        [FindsBy(How = How.XPath, Using = "//dl[@data-role='first-menu'][1]/dt/descendant::a")]
        private IWebElement linkTelephone;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'min-price')]/input")]
        private IWebElement minPrice;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'price-input')]/a")]
        private IWebElement submitPriceButton;

        [FindsBy(How = How.XPath, Using = "//ul[@class = 'list-items']/descendant::span[@class='price-current']")]
        private IList<IWebElement> listOfPrice;

        private By newUserContainer = By.CssSelector("div.newuser-container"); 
        
        
        
        public AliExpress(IWebDriver driver)
        :base(driver)
        {
            PageFactory.InitElements(driver, this);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Url = "https://aliexpress.ru/";
            Add = newUserContainer;
            CloseAdd = closeAdd;
            MinPriceInput = minPrice;
            SubmitPriceButton = submitPriceButton;
        }

        
        public void LogIn()
        {
            CloseAddvetizment();
            buttonLogIn.Click();
            driver.SwitchTo().Frame(frameLogIn);
            emailInput.SendKeys(logIn);
            passwoedInput.SendKeys(password);
            passwoedInput.SendKeys(Keys.Enter);
            driver.SwitchTo().DefaultContent();
            linkTelephone.Click();
            CloseAddvetizment();
            ListOfPrice = listOfPrice;
        }
        protected override string Filter(string NumInString)
        {
            string digit = "0123456789,-";
            string result = "";
            for (int i = 0; i < NumInString.Length; i++)
            {
                for (int j = 0; j < digit.Length; j++)
                {

                    if ((NumInString[i] == digit[j]) & (Convert.ToString(NumInString[i]) == ","))
                    {
                        result += ".";
                    }
                    else
                    {
                        if (Convert.ToString(NumInString[i]) == "-")
                        {
                            i = NumInString.Length;
                            break;
                        }
                        else
                        {
                            if (NumInString[i] == digit[j])
                            {
                                result += NumInString[i];
                            }
                        }
                    }

                    
                }
            }
            
            return result;
        }
        //Существует ли данный символ в строке
        private bool ExistSymbol(string str)
        {
            try
            {
                int i = str.IndexOf("-");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}