using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace OpenFlowSignUp
{
    [Binding]
    public class SignUpFeatureSteps
    {
        IWebDriver driver;
        static string signInPage = "https://test-8c21.oneflowcloud.com/sign-in";
        string username = string.Empty;
        string email = string.Empty;
        string password = string.Empty;


        [BeforeScenario]
		public void InitializePage()
		{
			driver = new ChromeDriver("Users/rrajaraman/Documents/Selenium");
			driver.Url = signInPage;
			IWebElement registerLinkText = driver.FindElement(By.LinkText("Register"));
			registerLinkText.Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}

		[Given(@"I am on the sign-up page")]         public void GivenIAmOnTheSign_UpPage()         {           Assert.IsTrue(driver.FindElement(By.XPath("/html/body/section/section/div[1]/div[1]/h3")).Text.Equals("Create an Account"));         }

        //[Given(@"I have entered a valid Username")]
        [Given(@"I have entered a valid Username (.*)")]         public void GivenIHaveEnteredAValidUsername(string inputUsername)         {             username = inputUsername;
			IWebElement usernameField = driver.FindElement(By.Id("at-field-username"));
			usernameField.SendKeys(username);         } 
        //[Given(@"I have entered a valid Email")]         [Given(@"I have entered a valid Email (.*)")]         public void GivenIHaveEnteredAValidEmail(string inputEmail)         {             email = inputEmail;
			IWebElement emailField = driver.FindElement(By.Id("at-field-email"));
			emailField.SendKeys(email);         } 
        //[Given(@"I have entered a valid Password")]         [Given(@"I have entered a valid Password (.*)")]         public void GivenIHaveEnteredAValidPassword(string inputPassword)         {             password = inputPassword;
			IWebElement passwordField = driver.FindElement(By.Id("at-field-password"));
			passwordField.SendKeys(password);
		}          [When(@"I click Register")]         public void WhenIClickRegister()         {
			IWebElement registerLinkText = driver.FindElement(By.Id("at-btn"));
			registerLinkText.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);         }          [Then(@"I should be signed-in")]         public void ThenIShouldBeSigned_In()         {
			IWebElement userHeader = driver.FindElement(By.Id("header-user-bar"));
			Assert.IsTrue(userHeader.FindElement(By.XPath("a")).Text.Contains(username));         }

        [AfterScenario]
		public void CloseBrowser()
		{
			driver.Quit();
		}

    }
}
