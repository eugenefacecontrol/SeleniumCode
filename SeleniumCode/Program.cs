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
    public class W3SchooldsTestCase
    {
        public W3SchooldsTestCase(IWebDriver driver)
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

    public class OnlinerTestCase
    {
        By SpanLocator = By.XPath("(//span[@class=\"project-navigation__sign\"])[1]");
        By DivSamsungGalaxyM31Locator = By.XPath("(//div[@class=\"schema-product__title\"])[1]");

        private IWebDriver driver;

        public OnlinerTestCase(IWebDriver driver)
        {
            this.driver = driver;
        }

        public OnlinerTestCase ClickSpan()
        {
            driver.FindElement(SpanLocator).Click();
            return this;
        }

        public OnlinerTestCase GetTextDivSamsungGalaxyM31(out string getText)
        {
            getText = driver.FindElement(DivSamsungGalaxyM31Locator).Text;
            return this;
        }

        public OnlinerTestCase Execute()
        {
            return new OnlinerTestCase(driver)
                    .ClickSpan()
                    .GetTextDivSamsungGalaxyM31(out string getText3)
                ;
            
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

                new W3SchooldsTestCase(webDriver).Execute();

                new OnlinerTestCase(webDriver).Execute();
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
