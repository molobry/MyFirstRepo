using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omada.Pages
{
    class ContactPage
    {
        private IWebDriver driver;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='tabmenu__menu']/span[text()='U.S. West']")]
        public IWebElement USWest;

        [FindsBy(How = How.XPath, Using = "//div[@class='tabmenu__menu']/span[text()='Germany']")]
        public IWebElement Germany;


    }
}
