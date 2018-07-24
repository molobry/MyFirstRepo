using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omada.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".header__search input.header__search-input")]
        public IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//a[@class='footer__menulink--submenu' and text()='Cases']")]
        public IWebElement Cases;

    }
}
