using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omada.Pages
{


    class CasesPage
    {
        private IWebDriver driver;

        public CasesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[leadfield='jobtitle']")]
        public IWebElement jobTitle;

        [FindsBy(How = How.CssSelector, Using = "input[leadfield='firstname']")]
        public IWebElement firstName;

        [FindsBy(How = How.CssSelector, Using = "input[leadfield='lastname']")]
        public IWebElement lastName;

        [FindsBy(How = How.CssSelector, Using = "input[leadfield='emailaddress1']")]
        public IWebElement emailAddress;

        [FindsBy(How = How.CssSelector, Using = "input[leadfield='telephone1']")]
        public IWebElement telephone;

        [FindsBy(How = How.CssSelector, Using = "input[leadfield='companyname']")]
        public IWebElement companyName;

        [FindsBy(How = How.CssSelector, Using = "select[leadfield='address1_county']")]
        public IWebElement country;

        [FindsBy(How = How.CssSelector, Using = "input[leadfield='new_omada_buddymail']")]
        public IWebElement acceptButton;

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        public IWebElement downloadPDFButton;


    }
}
