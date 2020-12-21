using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCode
{
    public class TestCase
    {
        public TestCase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@class=\"w3-button w3-bar-item topnav-icons fa fa-home\"]")]
        private IWebElement A;

        public void Execute()
        {
            A.Click();
        }
    }

//    public class GenerateThreeTabs
//    {
//        By ALocator = By.XPath("//a[@class=\"w3-button w3-bar-item topnav-icons fa fa-home\"]");
//        By ILocator = By.XPath("(//i[@class=\"fa\"])[6]");
//        By ImgLocator = By.XPath("//img[@alt=\"w3schools.com_official's profile picture\"]");
//
//        private IWebDriver driver;
//
//        public GenerateThreeTabs(IWebDriver driver)
//        {
//            this.driver = driver;
//        }
//
//        public GenerateThreeTabs ClickA()
//        {
//            driver.FindElement(ALocator).Click();
//            return this;
//        }
//
//        public GenerateThreeTabs SwitchToWindow(string url, string title)
//        {
//            foreach (var handle in driver.WindowHandles)
//            {
//                driver.SwitchTo().Window(handle);
//                if (driver.Url == url && driver.Title == title)
//                {
//                    break;
//                }
//            }
//            return this;
//        }

//        public GenerateThreeTabs ClickI()
//        {
//            driver.FindElement(ILocator).Click();
//            return this;
//        }
//
//        public GenerateThreeTabs ClickImg()
//        {
//            driver.FindElement(ImgLocator).Click();
//            return this;
//        }
//
//        public static GenerateThreeTabs Execute(IWebDriver driver)
//        {
//            return new GenerateThreeTabs(driver)
//                    .ClickA()
//                    .SwitchToWindow("https://www.w3schools.com/", "W3Schools Online Web Tutorials")
//                    .ClickI()
//                    .SwitchToWindow("https://www.instagram.com/w3schools.com_official/", "W3schools.com 🌎 OFFICIAL (@w3schools.com_official) • Instagram photos and videos")
//                    .ClickImg()
//                ;
//        }
//    }

    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            var driverService = ChromeDriverService.CreateDefaultService(
                @"C:\Program Files\SeleniumCodeGenerator 1.0.11.2\App_Data", "chromedriver.exe");
            var webDriver = new ChromeDriver(driverService, options);
            try
            {

                webDriver.Manage().Window.Maximize();
                webDriver.Navigate()
                    .GoToUrl("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_iframe_src");

                new TestCase(webDriver).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                webDriver.Close();
            }
        }
    }
}
