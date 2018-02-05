using System;
using System.Linq;
using System.Net.Mail;
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

		static string homePage = "https://test-8c21.oneflowcloud.com";
        static string signInPage = $"{homePage}/sign-in";

        string username = string.Empty;
        string email = string.Empty;
        string password = string.Empty;

		string language = string.Empty;
        int languageId = 5;             //default language: English

		static string expectedImageSrc = $"{homePage}/wekan-logo.png";

        string pageTitle = string.Empty;
        string userNameDisplay = string.Empty;
        string emailDisplay = string.Empty;
        string passwordDisplay = string.Empty;
        string registerButtonDisplay = string.Empty;
        string alreadyHaveAccountDisplay = string.Empty;

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

        [Given(@"I have entered a valid Username (.*)")]         public void GivenIHaveEnteredAValidUsername(string inputUsername)         {             username = inputUsername;
			IWebElement usernameField = driver.FindElement(By.Id("at-field-username"));
			usernameField.SendKeys(username);         }          [Given(@"I have entered a valid Email (.*)")]         public void GivenIHaveEnteredAValidEmail(string inputEmail)         {             email = inputEmail;
			IWebElement emailField = driver.FindElement(By.Id("at-field-email"));
			emailField.SendKeys(email);         }          [Given(@"I have entered a valid Password (.*)")]         public void GivenIHaveEnteredAValidPassword(string inputPassword)         {             password = inputPassword;
			IWebElement passwordField = driver.FindElement(By.Id("at-field-password"));
			passwordField.SendKeys(password);
		}

		[Given(@"I leave a required field blank (.*) (.*) (.*)")]
		public void GivenILeaveARequiredFieldBlank(string inputUsername, 
                                                   string inputEmail,
                                                   string inputPassword)
		{
			username = inputUsername;
            email = inputEmail;
            password = inputPassword;

			IWebElement usernameField = driver.FindElement(By.Id("at-field-username"));
			usernameField.SendKeys(username);

			IWebElement emailField = driver.FindElement(By.Id("at-field-email"));
			emailField.SendKeys(email);

			IWebElement passwordField = driver.FindElement(By.Id("at-field-password"));
			passwordField.SendKeys(password);
		}

		[Given(@"I enter an invalid value for a field (.*) (.*) (.*)")]
		public void GivenIEnterAnInvalidValueForAField(string inputUsername,
												       string inputEmail,
												       string inputPassword)
		{
			username = inputUsername;
			email = inputEmail;
			password = inputPassword;

			IWebElement usernameField = driver.FindElement(By.Id("at-field-username"));
			usernameField.SendKeys(username);

			IWebElement emailField = driver.FindElement(By.Id("at-field-email"));
			emailField.SendKeys(email);

			IWebElement passwordField = driver.FindElement(By.Id("at-field-password"));
			passwordField.SendKeys(password);
		}

		[Given(@"I enter an existing value for a field (.*) (.*) (.*)")]
		public void GivenIEnterAnExistingValueForAField(string inputUsername,
													    string inputEmail,
													    string inputPassword)
		{
			username = inputUsername;
			email = inputEmail;
			password = inputPassword;

			IWebElement usernameField = driver.FindElement(By.Id("at-field-username"));
			usernameField.SendKeys(username);

			IWebElement emailField = driver.FindElement(By.Id("at-field-email"));
			emailField.SendKeys(email);

			IWebElement passwordField = driver.FindElement(By.Id("at-field-password"));
			passwordField.SendKeys(password);
		}
         [When(@"I click Register")]         public void WhenIClickRegister()         {
			IWebElement registerLinkText = driver.FindElement(By.Id("at-btn"));
			registerLinkText.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);         }

		[When(@"I click on Sign In")]
		public void WhenIClickOnSignIn()
		{
			IWebElement signInButton = driver.FindElement(By.Id("at-signIn"));
            signInButton.Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}

        [When(@"I select a Language from the dropdown (.*)")]
		public void WhenISelectALanguageFromTheDropdown(int inputId)
		{
            languageId = inputId;
            IWebElement languageField = driver.FindElement(By.ClassName("at-form-lang"));
            languageField.FindElement(By.XPath($"/html/body/section/section/div[2]/select/option[{languageId}]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			switch (languageId)
			{
				case 1:
					pageTitle = "Buat Account";
					userNameDisplay = "Username";
					emailDisplay = "Email";
					passwordDisplay = "Password";
					registerButtonDisplay = "Mendaftar";
					alreadyHaveAccountDisplay = "Jika Anda sudah punya akun sign in";
					break;
				case 5:
					pageTitle = "Create an Account";
					userNameDisplay = "Username";
					emailDisplay = "Email";
					passwordDisplay = "Password";
					registerButtonDisplay = "Register";
					alreadyHaveAccountDisplay = "If you already have an account sign in";
					break;
				case 11:
					pageTitle = "Créer un compte";
					userNameDisplay = "Nom d'utilisateur";
					emailDisplay = "Email";
					passwordDisplay = "Mot de passe";
                    registerButtonDisplay = "S'enregistrer";
					alreadyHaveAccountDisplay = "Si vous avez déjà un compte se connecter";
					break;
				case 21:
					pageTitle = "Skapa ett konto";
					userNameDisplay = "Användarnamn";
					emailDisplay = "Email";
					passwordDisplay = "Lösenord";
					registerButtonDisplay = "Bli medlem";
					alreadyHaveAccountDisplay = "Är du redan medlem? logga in";
					break;
				case 36:
					pageTitle = "계정 생성";
					userNameDisplay = "아이디";
					emailDisplay = "Email";
					passwordDisplay = "비밀번호";
					registerButtonDisplay = "Register";
					alreadyHaveAccountDisplay = "If you already have an account sign in";
					break;
				default:
					pageTitle = "Create an Account";
					userNameDisplay = "Username";
					emailDisplay = "Email";
					passwordDisplay = "Password";
					registerButtonDisplay = "회원가입";
					alreadyHaveAccountDisplay = "I이미 계정이 있으시면로그인";
					break;
			}
		}          [Then(@"I should be signed-in")]         public void ThenIShouldBeSigned_In()         {
			IWebElement userHeader = driver.FindElement(By.Id("header-user-bar"));
			Assert.IsTrue(userHeader.FindElement(By.XPath("a")).Text.Contains(username));         }

		[Then(@"I should see the appropriate error for missing field")]
		public void ThenIShouldSeeTheAppropriateErrorMessageForMissingField()
		{
			IWebElement errorMessage = driver.FindElement(By.ClassName("at-error"));
            Assert.IsTrue(errorMessage.Displayed);

            if (username.Length == 0)
                Assert.IsTrue(errorMessage.Text.Contains("Username: Required Field"));
			if (email.Length == 0)
				Assert.IsTrue(errorMessage.Text.Contains("Email: Required Field"));
			if (password.Length == 0)
				Assert.IsTrue(errorMessage.Text.Contains("Password: Required Field"));
		}

		[Then(@"I should see the appropriate error for invalid value")]
		public void ThenIShouldSeeTheAppropriateErrorForInvalidValue()
		{
			IWebElement errorMessage = driver.FindElement(By.ClassName("at-error"));
			Assert.IsTrue(errorMessage.Displayed);

			if (username.Length < 2)
				Assert.IsTrue(errorMessage.Text.Contains("Username: Minimum required length: 2"));

            try 
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                //int countOfAtSign = email.Count(x => x == '@');
				//if (!email.Equals("*@*.com") || email.Contains(" ") || countOfAtSign > 1)
				//Assert.IsTrue(errorMessage.Text.Contains("Address must be a valid e-mail address"));
				Assert.IsTrue(errorMessage.Text.Contains("Address must be a valid e-mail address"));
            }

            if (password.Length < 6)
				Assert.IsTrue(errorMessage.Text.Contains("Password: Minimum required length: 6"));
		}

		[Then(@"I should see the appropriate error message")]
		public void ThenIShouldSeeTheAppropriateErrorMessage()
		{
			IWebElement errorMessage = driver.FindElement(By.ClassName("at-error"));
			Assert.IsTrue(errorMessage.Displayed);

			Assert.IsTrue(errorMessage.Text.Contains("Username already exists") || errorMessage.Text.Contains("Email already exists."));
		}

		[Then(@"I should be taken to the sign-in page")]
		public void ThenIShouldBeTakenToTheSign_InPage()
		{
            IWebElement formTitle = driver.FindElement(By.XPath("/html/body/section/section/div[1]/div[1]/h3"));
			Assert.AreEqual("Sign In", formTitle.Text);
		}

		[Then(@"I should see the correct values for the other fields")]
		public void ThenIShouldSeeTheCorrectValuesForTheOtherFields()
		{
            VerifyPageFormat();
		}

		public void VerifyPageFormat()
		{
            
			//Wekan logo
			IWebElement logoImagePath = driver.FindElement(By.XPath("/html/body/section/h1/img"));
			Assert.IsTrue(logoImagePath.Displayed);
			string actualImageSrc = logoImagePath.GetAttribute("src");
			Assert.AreEqual(expectedImageSrc, actualImageSrc);

			//Page title
			IWebElement formTitle = driver.FindElement(By.XPath("/html/body/section/section/div[1]/div[1]/h3"));
			Assert.IsTrue(formTitle.Displayed);
            Assert.AreEqual(pageTitle, formTitle.Text);

			//Username
			IWebElement usernameField = driver.FindElement(By.Id("at-field-username"));
			Assert.IsTrue(usernameField.Displayed);
			//Assert.AreEqual(username, usernameField.Text);

			//Email
			IWebElement emailField = driver.FindElement(By.Id("at-field-email"));
			Assert.IsTrue(emailField.Displayed);
			//Assert.AreEqual(email, emailField.Text);

			//Password
			IWebElement passwordField = driver.FindElement(By.Id("at-field-password"));
			Assert.IsTrue(passwordField.Displayed);
			//Assert.AreEqual(password, passwordField.Text);

			//Register Button
			IWebElement registerButton = driver.FindElement(By.Id("at-btn"));
			Assert.IsTrue(registerButton.Displayed);
			//Assert.AreEqual(registerbutton, registerButton.Text);

			//Already have an account?
			IWebElement alreadyHaveAccount = driver.FindElement(By.XPath("/html/body/section/section/div[1]/div[3]/p"));
			Assert.IsTrue(alreadyHaveAccount.Displayed);
			string alreadyHaveAccountText = alreadyHaveAccount.Text;
			//Assert.AreEqual(alreadyhaveaccount, alreadyHaveAccountText);

			//Language Dropdown
			IWebElement languageOptions = driver.FindElement(By.XPath("/html/body/section/section/div[2]/select"));
			Assert.IsTrue(languageOptions.Displayed);
		}

		[AfterScenario]
		public void CloseBrowser()
		{
			driver.Quit();
		}

    }
}