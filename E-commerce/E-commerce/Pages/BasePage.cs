using E_commerce.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Pages
{
    public class BasePage
    {
        private IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region objects
        private IWebElement _logout => _driver.FindElement(By.CssSelector("a[href*='logout']"));
        private IWebElement _deleteAccount => _driver.FindElement(By.CssSelector("a[href*='delete_account']"));
        
        #endregion objects

        public bool IsLogoutDisplayed()
        {
            try
            {
                return _logout.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsDeleteAccountDisplayed()
        {
            try
            {
                return _deleteAccount.Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
