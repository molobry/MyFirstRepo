using NUnit.Framework;
using Omada.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Omada.BDDSteps
{
    [Binding]
    public class ContactSteps
    {
        IWebDriver driver = Driver.driver;

        [Then(@"I want to click U\.S West")]
        public void ThenIWantToClickU_SWest()
        {
            ContactPage contactPage = new ContactPage(driver);
            string classBeforeSelect = contactPage.USWest.GetAttribute("class");
            contactPage.USWest.Click();
            string classAfterSelect = contactPage.USWest.GetAttribute("class");
        }

        [Then(@"I want to mouseover Germany")]
        public void ThenIWantToMouseoverGermany()
        {
            ContactPage contactPage = new ContactPage(driver);
            Actions actions = new Actions(driver);
            actions.MoveToElement(contactPage.Germany).Perform();
        }

        [Then(@"I open privacy policy in new tab")]
        public void ThenIOpenPrivacyPolicyInNewTab()
        {
            var privacyPolicy = driver.FindElement(By.XPath("//*[text()='privacy policy']/../.."));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", privacyPolicy);
            var privacyPolicyUrl = privacyPolicy.GetAttribute("href");

            //Those selenium methods did not work so I need to use javascript
            /*
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Control + "t");
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            */

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open(arguments[0]);", privacyPolicyUrl);

            var tabs = driver.WindowHandles;
            driver.SwitchTo().Window(tabs[1]);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var header = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h1.text__heading")));

            string actualHeader = header.Text;

            Assert.AreEqual("WEBSITE PRIVACY POLICY", actualHeader);

        }
        [When(@"I want to close tab")]
        public void WhenIWantToCloseTab()
        {
            //I want to close other tab, leave only first one
            var tabs = driver.WindowHandles;
            


            while(tabs.Count>1)
            {
                driver.SwitchTo().Window(tabs[tabs.Count-1]);
                driver.Close();
                tabs = driver.WindowHandles;
            }
            driver.SwitchTo().Window(tabs[0]);

            
            
        }


        [When(@"I want to close privacy policy")]
        public void WhenIWantToClosePrivacyPolicy()
        {
            //if there is policy close button then I want to close it
            if(driver.FindElements(By.CssSelector("span.cookiebar__button.button--variant1")).Count> 0)
            {
                driver.FindElement(By.CssSelector("span.cookiebar__button.button--variant1")).Click();
            }
            
            driver.SwitchTo().DefaultContent().Navigate().Refresh();
        }










    }
}
