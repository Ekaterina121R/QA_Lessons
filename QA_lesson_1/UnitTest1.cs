using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
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
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            var elements = driver.FindElements(By.Id("app-"));
            int a = elements.Count();


            for (int i = 0; i < a; i++)
            {
                elements[i].Click();
                elements = driver.FindElements(By.Id("app-"));
                driver.FindElement(By.TagName("h1"));

                var DocsElement = elements[i].FindElements(By.TagName("li"));
                for (int j = 0; j < DocsElement.Count(); j++)
                {
                    DocsElement[j].Click();
                    elements = driver.FindElements(By.Id("app-"));
                    DocsElement = elements[i].FindElements(By.TagName("li"));
                    driver.FindElement(By.TagName("h1"));
                }
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
