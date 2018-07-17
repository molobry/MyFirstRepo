using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Omada
{
    [Binding]
    public static class BaseClass
    {
        public static IWebDriver driver;

        [BeforeScenario]
        public static IWebDriver Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;

        }
        [AfterScenario]
        public static void Close()
        {
            driver.Close();
        }


    }
}
