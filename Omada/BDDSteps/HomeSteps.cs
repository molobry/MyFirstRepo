using NUnit.Framework;
using Omada.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Omada.BDDSteps
{
    [Binding]
    public class HomeSteps
    {
        IWebDriver driver = Driver.driver;

        [When(@"I have open home test page")]
        public void WhenIHaveOpenHomeTestPage()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["TestURL"]);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.header__menulink--megamenu.js-menulink[href='/en-us/more']")));

        }



        [Then(@"I want check if header elements are displayed")]
        public void ThenIWantCheckIfHeaderElementsAreDisplayed()
        {
            
            var headerLinks = driver.FindElements(By.CssSelector("ul.header__menu--function-nav a"));
            Assert.AreEqual(6, headerLinks.Count, "Probably one of header links is missing");
        }
        [Then(@"I want to check if footer is displayed")]
        public void ThenIWantToCheckIfFooterIsDisplayed()
        {
            var footer = driver.FindElement(By.Id("brick-20")).Displayed;
            Assert.True(footer, "Footer is not displayed properly");
        }
        [When(@"I navigate to News")]
        public void WhenINavigateToNews()
        {
            CommonNavigation commonNavigation = new CommonNavigation(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var more = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.header__menulink--megamenu.js-menulink[href='/en-us/more']")));

            Actions action = new Actions(driver);
            action.MoveToElement(more).Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.header__menulink--submenu[href = '/en-us/more/news-events/news'")));
            
            commonNavigation.news.Click();
        }

        [When(@"I want to click Contact")]
        public void WhenIWantToClickContact()
        {
            CommonNavigation commonNavigation = new CommonNavigation(driver);
            commonNavigation.contact.Click();
        }

        [Then(@"I want to check if privacy policy is no longer visible")]
        public void ThenIWantToCheckIfPrivacyPolicyIsNoLongerVisible()
        {
            bool privacyPolicyVisible = driver.FindElement(By.CssSelector(".brick.cookiebar--variant1.has-background.background--quaternary")).Displayed;

            Assert.False(privacyPolicyVisible, "Privacy policy is still visible");

        }

        [When(@"I click Cases from Resources")]
        public void WhenIClickCasesFromResources()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Cases.Click(); 
        }

        [When(@"I want to open multiple tabs")]
        public void WhenIWantToOpenMultipleTabs()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
        }












    }
}
