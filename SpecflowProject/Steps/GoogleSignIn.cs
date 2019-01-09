using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using FluentAssertions;
using System.Threading;

namespace SpecflowProject.Steps
{
    [Binding]
    public sealed class GoogleSignIn
    {
        public IWebDriver driver = null;
        public IWebElement signInButton;
        public IWebElement email;
        public IWebElement next;
        public IWebElement password;

        [Given(@"I am on google homepage")]
        public void GivenIAmOnGoogleHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
        }


        [Given(@"Sign in button displayed on the page")]
        public void GivenSignInButtonDisplayedOnThePage()
        {
            signInButton = driver.FindElement(By.Id("gb_70"));
            Assert.IsTrue(signInButton.Displayed);
            Assert.IsTrue(signInButton.Enabled);
        }

        [When(@"I click on the Sign In button")]
        public void WhenIClickOnTheSignInButton()
        {
            signInButton.Click();
        }

        [Then(@"I should be on the Sign In page")]
        public void ThenIShouldBeOnTheSignInPage()
        {
            Assert.IsTrue(driver.Url.Contains("signin"));
            email = driver.FindElement(By.Id("identifierId"));
            Assert.IsTrue(email.Displayed);
            Assert.IsTrue(email.Enabled);
        }

        [Then(@"I fill in email field with email ""(.*)""")]
        public void ThenIFillInEmailFieldWithEmail(string useremail)
        {
            email.SendKeys(useremail);
            Thread.Sleep(5000);
        }

        [When(@"I click Next button")]
        public void WhenIClickNextButton()
        {
            next = driver.FindElement(By.XPath("//span[text()='Next']"));
            next.Click();
            Thread.Sleep(5000);
        }

        [Then(@"I should see the password field")]
        public void ThenIShouldSeeThePasswordField()
        {
            password = driver.FindElement(By.Name("password"));
            Assert.IsTrue(password.Displayed);
            Assert.IsTrue(password.Enabled);
            Thread.Sleep(5000);
        }

        [Then(@"I fill password field with password ""(.*)""")]
        public void ThenIFillPasswordFieldWithPassword(string pass)
        {
            password.SendKeys(pass);
        }

        [Then(@"I should be on the homepage")]
        public void ThenIShouldBeOnTheHomepage()
        {
            Assert.IsTrue(driver.Url.Contains("www.google.com"));
        }

        [Then(@"I should see the user ""(.*)"" logged in successfully")]
        public void ThenIShouldSeeTheUserLoggedInSuccessfully(string expectedEmail)
        {
            Thread.Sleep(5000);

            IWebElement userIcon = driver.FindElement(By.XPath("(//a[@role = 'button'])[3]"));
            userIcon.Click();
            IWebElement userEmail = driver.FindElement(By.XPath("(//div[contains(text(), 'doe777530')])[1]"));
            string userID = userEmail.Text;
            driver.Quit();
        }


    }
}
