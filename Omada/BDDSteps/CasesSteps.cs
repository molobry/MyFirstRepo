using Omada.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Omada.BDDSteps
{
    [Binding]
    public class CasesSteps
    {
        IWebDriver driver = Driver.driver;

        [When(@"I click download for '(.*)' company")]
        public void WhenIClickDownloadForCompany(string companyName)
        {
            var download = driver.FindElement(By.XPath("//a[contains(@href,'"+ companyName +"')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(download).Click().Build().Perform();

        }

        [When(@"I fill all require fields")]
        public void WhenIFillAllRequireFields(Table table)
        {
            CasesPage casesPage = new CasesPage(driver);
            casesPage.jobTitle.SendKeys(table.Rows[0][0]);
            casesPage.firstName.SendKeys(table.Rows[0][1]);
            casesPage.lastName.SendKeys(table.Rows[0][2]);
            casesPage.emailAddress.SendKeys(table.Rows[0][3]);
            casesPage.telephone.SendKeys(table.Rows[0][4]);
            casesPage.companyName.SendKeys(table.Rows[0]["CompanyName"]);

            var selectElement = new SelectElement(casesPage.country);
            selectElement.SelectByValue(table.Rows[0]["Country"]);

        }
        [When(@"I click accept")]
        public void WhenIClickAccept()
        {
            CasesPage casesPage = new CasesPage(driver);
            //Those methods did not work, need to use javascript
            /*
            casesPage.acceptButton.Click();
            Actions actions = new Actions(driver);
            actions.MoveToElement(casesPage.acceptButton).Click().Build().Perform();
            actions.MoveToElement(casesPage.acceptButton).SendKeys(Keys.Space);
            */

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", casesPage.acceptButton);

        }

        [When(@"I Unlock form by sliding slider")]
        public void WhenIUnlockFormBySlidingSlider()
        {
            var slider = driver.FindElement(By.Id("Slider"));

            //to unclock I need to slide slider
            Actions actions = new Actions(driver);
            actions.ClickAndHold(slider);
            actions.MoveByOffset(160, 0);
            actions.Release().Build().Perform();


        }
        [When(@"I click download button")]
        public void WhenIClickDownloadButton()
        {
            CasesPage casesPage = new CasesPage(driver);
            casesPage.downloadPDFButton.Click();
        }

        [When(@"I click Download Customer Case")]
        public void WhenIClickDownloadCustomerCase()
        {
            driver.FindElement(By.XPath("//*[contains(text(),'Download Customer Case')]")).Click();
        }

        [When(@"I wait till download of file '(.*)' finish")]
        public void WhenIWaitTillDownloadOfFileFinish(string filename)
        {
            var downloadsPath = ConfigurationManager.AppSettings["DownloadFolder"] + "\\" + filename;
            for (var i = 0; i < 30; i++)
            {
                if (File.Exists(downloadsPath)) { break; }
                Thread.Sleep(1000);
            }
            var length = new FileInfo(downloadsPath).Length;
            for (var i = 0; i < 30; i++)
            {
                Thread.Sleep(1000);
                var newLength = new FileInfo(downloadsPath).Length;
                if (newLength == length && length != 0) { break; }
                length = newLength;
            }
        }











    }
}
