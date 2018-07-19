using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://demo.abc.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/oauth2/Login.aspx?client_id=211201680946&redirect_uri=https://demo.abc.com/abcstartup.aspx&isme=1");
            driver.FindElement(By.Id("loginUsernameTextTox")).Clear();
            driver.FindElement(By.Id("loginUsernameTextTox")).SendKeys("abc@gmail.com");
            driver.FindElement(By.Id("loginPasswordTextTox")).Clear();
            driver.FindElement(By.Id("loginPasswordTextTox")).SendKeys("1");
            driver.FindElement(By.Id("btnLogin")).Click();
            driver.FindElement(By.LinkText("Global Settings")).Click();
            driver.FindElement(By.CssSelector("span[name=\"Library Configurations\"]")).Click();
            driver.FindElement(By.Id("PortalDataPortalTextBox")).Click();
            driver.FindElement(By.Id("PortalDataPortalTextBox")).Clear();
            driver.FindElement(By.Id("PortalDataPortalTextBox")).SendKeys("TestA");
            driver.FindElement(By.Id("image12")).Click();
            driver.FindElement(By.Id("PortalDataSavePortalButton")).Click();
            driver.FindElement(By.Id("ContentPlaceHolder1_btnMSGYES")).Click();
            driver.FindElement(By.Id("ContentPlaceHolder1_btnMSGOK")).Click();
        }
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

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
                } finally {
                acceptNextAlert = true;
                }
            }
        }
 }
