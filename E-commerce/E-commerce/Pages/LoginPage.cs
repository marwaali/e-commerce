using E_commerce.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Pages
{
    public class LoginPage
    {

        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region objects
        private IWebElement _email => _driver.FindElement(By.Name("email"));
        private IWebElement _password => _driver.FindElement(By.Name("password"));
        private IWebElement _login => _driver.FindElement(By.CssSelector("button[data-qa='login-button']"));

        #endregion objects

        public void Login(string user, string pass)
        {
            _email.SendKeys(user);
            _password.SendKeys(pass);
            _login.Click();
        }

    } 
}
