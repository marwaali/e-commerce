using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace E_commerce.Utilities
{
    public class DriverOperations
    {
        private IWebDriver _driver;

        public DriverOperations(IWebDriver driver)
        {
            _driver = driver;
        }

        public void CloseBrowser()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }

        public void WaitForElementToBeVisible(IWebElement element, int time)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
            wait.Until(d => element.Displayed);
        }
    }
}
