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
