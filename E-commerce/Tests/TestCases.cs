using AngleSharp.Dom;
using E_commerce.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_commerce.Tests
{
    public class TestCases:BaseTest
    {

        [Test]
        public void LoginWithValidUser()
        {
            LoginPage login = new LoginPage(driver);
            login.Login(dl.website[0].user, dl.website[0].pass);
            BasePage basePage = new BasePage(driver);
            Assert.IsTrue(basePage.IsLogoutDisplayed());
            Assert.IsTrue(basePage.IsDeleteAccountDisplayed());
        }
    }
}
