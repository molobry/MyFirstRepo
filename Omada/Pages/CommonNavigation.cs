using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omada.Pages
{
    class CommonNavigation
    {
        private IWebDriver driver;

        public CommonNavigation(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "a.header__menulink--submenu[href = '/en-us/more/news-events/news'")]
        public IWebElement news;

        [FindsBy(How = How.CssSelector, Using = "a.header__menulink--function-nav[href='/en-us/more/company/contact']")]
        public IWebElement contact;
        
        


    }
}
