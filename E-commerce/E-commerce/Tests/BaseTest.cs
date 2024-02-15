﻿using E_commerce.Utilities;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace E_commerce.Tests
{
    public class BaseTest
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
        public string proDir;
        public DataList dl;
        string browser;
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            proDir = Environment.CurrentDirectory;
            string path = proDir + @"\DataList.xml";
            XmlUtilities method = new XmlUtilities();
            dl = method.Deserialize(path);
            browser = dl.website[0].browser;

            try
            {
                _extent = new ExtentReports();
                DirectoryInfo di = Directory.CreateDirectory(proDir + @"\Test_Execution_Reports");
                ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(di + "\\Automation_Report" + ".html");
                _extent.AddSystemInfo("Environment", "ItWorx");
                _extent.AddSystemInfo("User Name", "Marwa");
                _extent.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [SetUp]
        public void Setup()
        {
            try
            {
                switch (browser)
                {
                    case "chrome":
                        driver = new ChromeDriver();
                        break;
                    case "firefox":
                        driver = new FirefoxDriver();
                        break;
                    default:
                        break;
                }
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                driver.Navigate().GoToUrl(dl.website[0].url);
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        [TearDown]
        public void AfterTest()
        {
            DriverOperations op = new DriverOperations(driver);
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = Capture(driver, TestContext.CurrentContext.Test.Name);
                        _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            op.CloseBrowser();
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath = "";
            try
            {
                Thread.Sleep(4000);
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                DirectoryInfo di = Directory.CreateDirectory(proDir + @"\Defect_Screenshots");
                string finalpth = di.FullName + @"\" + screenShotName + ".jpeg";
                localpath = new Uri(finalpth).LocalPath;
                image.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }
    }
}
