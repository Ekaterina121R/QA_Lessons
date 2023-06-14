using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace QA_lesson_1
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LitecartCheckStikers()
        {
            driver.Url = "http://localhost/litecart/";

            By Popular = By.Id("box-most-popular");
            By Campaigns = By.Id("box-campaigns");
            By Latest = By.Id("box-latest-products");


            var elements = driver.FindElement(Popular);
            var PopEl = elements.FindElement(By.TagName("ul")).FindElements(By.TagName("li"));

            for (int i = 0; i < PopEl.Count(); i++)
            {
                var PopElStickerCheck = PopEl[i].FindElements(By.ClassName("sticker"));
                if (PopElStickerCheck.Count() != 1) Console.WriteLine("Popular: sticker error");

            }

            elements = driver.FindElement(Campaigns);
            var CampEl = elements.FindElement(By.TagName("ul")).FindElements(By.TagName("li"));

            for (int i = 0; i < CampEl.Count(); i++)
            {
                var CampElStickerCheck = CampEl[i].FindElements(By.ClassName("sticker"));
                if (CampElStickerCheck.Count() != 1) Console.WriteLine("Campaigns: sticker error");

            }

            elements = driver.FindElement(Latest);
            var LatestEl = elements.FindElement(By.TagName("ul")).FindElements(By.TagName("li"));

            for (int i = 0; i < LatestEl.Count(); i++)
            {
                var LatestElStickerCheck = LatestEl[i].FindElements(By.ClassName("sticker"));
                if (LatestElStickerCheck.Count() != 1) Console.WriteLine("Latest: sticker error");

            }

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
