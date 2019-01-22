using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_nunit_azure
{

    public class TestClass
    {

        ChromeDriver driver;

        [SetUp]
        public void SetUpMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void VerifyUserCanSearchOnGoogle()
        {
            int searchIndex = 0;

            // Navigate to Google.
            driver.Url = "https://www.google.com";

            // Search for the "Test" keyword.
            driver.FindElement(By.CssSelector("[title=\"Search\"]")).SendKeys("Test" + Keys.Enter);

            // Get the text of first searched result.
            string expectedHeaderTextOfWebsite = driver.FindElements(By.CssSelector(".rc>.r>a>h3"))[searchIndex].Text;

            // Select the first link from searched result.
            driver.FindElements(By.CssSelector(".rc>.r>a"))[searchIndex].Click();

            // Get the actual text of header for navigated website.
            string actualHeaderTextOfWebsite = driver.Title;

            // Assert that expected website header(from Google search result) and actual website header text(from navigated website) matches.
            Assert.AreEqual(expectedHeaderTextOfWebsite, actualHeaderTextOfWebsite, "Header text of (first)navigated website didn't match!");

        }

        [TearDown]
        public void TearDownMethod()
        {
            driver.Quit();
        }

    }
}
