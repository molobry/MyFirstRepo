using NUnit.Framework;
using Omada.BDDSteps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Omada
{
    [Binding]
    public static class Driver
    {
        public static IWebDriver driver;
        


        [BeforeScenario]
        public static IWebDriver Setup()
        {
            

            string browser = ConfigurationManager.AppSettings["Browser"];
            switch (browser)
            {
                case "Chrome":
                    RunChrome();
                    break;

                case "IE":
                    RunIE();
                    break;

                default:
                    Console.WriteLine("Browser was not recognizate as IE or Chrome Driver");
                    Log.log.Info("Browser was not recognizate as IE or Chrome Driver");
                    break;

            }

            driver.Manage().Window.Maximize();

            return driver;

        }
        [AfterScenario]
        public static void Close()
        {
            driver.Close();
            Log.log.Info("Closing driver");
        }

        public static void RunIE()
        {
            driver = new InternetExplorerDriver();
            Log.log.Info("IE driver running");
        }
        public static void RunChrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArgument("--incognito");
            driver = new ChromeDriver(options);
            Log.log.Info("Chrome driver running");

        }


    }
}
