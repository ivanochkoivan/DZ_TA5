using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;


namespace DZ_TA5.PageObjects
{
    public class ShopFilter
    {
        protected IWebDriver driver;
        
        private readonly int MinPrice = 2000;
        public IWebElement MinPriceInput { get; set; }
        public IWebElement SubmitPriceButton { get; set; }
        public IList<IWebElement> ListOfPrice { get; set; }
        public IWebElement CloseAdd { get; set; }
        
        public By Add { get; set; }
        public string Url { get; set; }

        public ShopFilter(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void SetPrice()
        {
            MinPriceInput.Clear();
            CloseAddvetizment();
            MinPriceInput.SendKeys(MinPrice.ToString());
            SubmitPriceButton.Click();
        }
        //Проверяем цену на вхождение в ценовой диапазон
        public void CheckPrice()
        {
            CloseAddvetizment();
            foreach (IWebElement element in ListOfPrice)
            {
                int temp = 0;
                string tempString = element.Text;
                int.TryParse(Filter(tempString), out temp);
                Console.WriteLine(temp);
                Assert.IsTrue(temp>MinPrice);
            }
        }

        
        //убираю пробелы в цифрах
        protected virtual string Filter(string NumInString)
        {
            string digit = "0123456789";
            string result = "";
            for (int i = 0; i < NumInString.Length; i++)
            {
                for (int j = 0; j < digit.Length; j++)
                {
                    if (NumInString[i]==digit[j])
                    {
                        result += NumInString[i];
                    }
                }
            }

            return result;
        }
        //Закрывает рекламу
        protected void CloseAddvetizment()
        {
            if (IsElementPresent(Add))
            {
                CloseAdd.Click();
            }    
        }
        //Проверка на существования ел-та
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}