﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium_Tests
{
    internal class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        static string findNewWindow(IWebDriver driver, ICollection<string> oldWindows, int maxRetryCount = 100)
        {
            bool boolReturnValue;
            string otherWindow = null;
            for (var i = 0; i < maxRetryCount; Thread.Sleep(10), i++)
            {

                ICollection<string> allWindows = driver.WindowHandles;
                boolReturnValue = (oldWindows.Equals(allWindows) ? true : false);

                if (!boolReturnValue)
                {
                    foreach (var window in allWindows)
                    {
                        if (!oldWindows.Contains(window)) otherWindow = window;
                        if (otherWindow != null) return otherWindow;
                    }

                }
            }

            throw new ApplicationException("New window did not open.");
        }
        [Test]

        public void New_Window()
        {
            // Входим на сайт
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.XPath("//td[@id='content']//tr[@class='row']//a")).Click();
            var elements = driver.FindElements(By.XPath("//i[@class='fa fa-external-link']"));

            string mainWindow = driver.CurrentWindowHandle;

            foreach (var element in elements)
            {
                ICollection<string> oldWindows = driver.WindowHandles;
                element.Click();
                string newWindow = findNewWindow(driver, oldWindows);
                driver.SwitchTo().Window(newWindow);
                Thread.Sleep(1000);
                driver.Close();
                driver.SwitchTo().Window(mainWindow);
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