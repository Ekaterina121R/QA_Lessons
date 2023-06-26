using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using Assert = NUnit.Framework.Assert;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.ComponentModel;
using SeleniumExtras.WaitHelpers;

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
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = ("C:\\Program Files\\Mozilla Firefox\\firefox.exe"); //location where Firefox is installed
            driver = new FirefoxDriver(options);
        }

        [Test]

        public void Registration()
        {
           
            Random rnd = new Random();
            int value = rnd.Next(1000, 9999);
            driver.Url = "http://localhost/litecart/en/create_account";

            var inputName = driver.FindElement(By.XPath("//input[@name='firstname']"));
            var inputLastName = driver.FindElement(By.XPath("//input[@name='lastname']"));
            var inputAddress1 = driver.FindElement(By.XPath("//input[@name='address1']"));
            var inputPostcode = driver.FindElement(By.XPath("//input[@name='postcode']"));
            var inputEmail = driver.FindElement(By.XPath("//input[@name='email']"));
            var inputPhone = driver.FindElement(By.XPath("//input[@name='phone']"));
            var inputPassword = driver.FindElement(By.XPath("//input[@name='password']"));
            var inputCity = driver.FindElement(By.XPath("//input[@name='city']"));
            var confirmPassword = driver.FindElement(By.XPath("//input[@name='confirmed_password']"));
            var country = driver.FindElement(By.XPath("//select[@name='country_code']"));
            var state = driver.FindElement(By.XPath("//select[@name='zone_code']"));
            var submit = driver.FindElement(By.XPath("//button[@type='submit']"));

            string name = "Firstname";
            string lastName = "Lastname";
            string address = "Home address 5";
            string postcode = "08724";
            string city = "Test";
            string email = "user" + value + "@mail.me";
            string phone = "+19877" + value;
            string password = "test";

            // Заполняем поля
            inputName.SendKeys(name);
            inputLastName.SendKeys(lastName);
            inputAddress1.SendKeys(address);
            inputPostcode.SendKeys(postcode);
            inputCity.SendKeys(city);
            inputEmail.SendKeys(email);
            inputPhone.SendKeys(phone);


            driver.FindElement(By.ClassName("select2-selection__arrow")).Click();
            var us = driver.FindElement(By.XPath("//li[text()='United States']"));
            us.Click();


            Thread.Sleep(3000);
            SelectElement stateSelect = new SelectElement(state);
            stateSelect.SelectByText("Alaska");
            inputPassword.SendKeys(password);
            confirmPassword.SendKeys(password);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();


            /*
                        SelectElement countrySelect = new SelectElement(country);
                       // ((IJavaScriptExecutor)driver).ExecuteScript("var select = arguments[0]; for(var i = 0; i < select.options.length; i++){ if(select.options[i].text == arguments[1]){ select.options[i].selected = true; } }", countrySelect, "United States");
                        //countrySelect.SelectByText("United States");
                        //Thread.Sleep(3000);
                        SelectElement stateSelect = new SelectElement(state);
                        //((IJavaScriptExecutor)driver).ExecuteScript("var select = arguments[0]; for(var i = 0; i < select.options.length; i++){ if(select.options[i].text == arguments[1]){ select.options[i].selected = true; } }", stateSelect, "Alaska");
                        //stateSelect.SelectByText("South Dakota");
                        inputPassword.SendKeys(password);
                        confirmPassword.SendKeys(password);
                        submit.Click();
                        Thread.Sleep(3000);
                        driver.Url = "http://localhost/litecart/en/create_account";
            */

            /*
            //Assert.AreNotEqual(driver.Url, "http://localhost/litecart/en/create_account");
            // выходим из учетки
            var logout = driver.FindElement(By.XPath("//a[text()='Logout']"));
            logout.Click();
            Thread.Sleep(3000);
             */
            // driver.Url = "http://localhost/litecart/en/create_account";
            // driver.FindElement(By.XPath("//div[@id='box-account']/div/ul/li[4]/a")).Click();
            // заходим в учетку

            driver.FindElement(By.XPath("//a[text()='Logout']")).Click();
            driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
            Thread.Sleep(3000);

            // выходим из учетки
            driver.FindElement(By.XPath("//a[text()='Logout']")).Click();
            //logout = driver.FindElement(By.XPath("//a[text()='Logout']"));
           // logout.Click();
            //Thread.Sleep(3000);
           

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
