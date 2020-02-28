using System;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using WDSE;

namespace DZ_TA5
{
    public static class Const
    {
        public static string keyWord = "шоколад";
        public static string companyName = "Песто";
        
        public static void WaitAndVisible(this IWebDriver driver, By by)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public static void MakeScreenShot(IWebDriver driver, string imageSavePath, string imageName)
        {
            var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            var ms = new MemoryStream(bytesArr);
            Bitmap bitmap = new Bitmap(ms);
            bitmap.Save(imageSavePath + imageName);
        }
        public static void MakeScreenshotElement(IWebDriver driver, String imageSavePathAndImageName, IWebElement elem)
        {
            var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            var ms = new MemoryStream(bytesArr);
            Bitmap bitmap = new Bitmap(ms);
            Bitmap elemScreenshot = bitmap.Clone(new Rectangle(elem.Location, elem.Size), bitmap.PixelFormat);
            elemScreenshot.Save(imageSavePathAndImageName);
            elemScreenshot.Dispose();
            
        }
    }
}