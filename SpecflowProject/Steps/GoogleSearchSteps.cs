using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SpecflowProject.Steps
{
    [Binding]
    public sealed class GoogleSearchSteps
    {
        public IWebDriver driver = null;
        public IWebElement SearchBar = null;

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
        }

        [Given(@"I should see the page fully loaded")]
        public void GivenIShouldSeeThePageFullyLoaded()
        {
            SearchBar = driver.FindElement(By.Name("q"));
        }

        [When(@"I search for the keyword ""(.*)""")]
        public void WhenISearchForTheKeyword(string keyword)
        {
            SearchBar.SendKeys(keyword + Keys.Enter); 

        }

        [Then(@"I should see selenium in the search results")]
        public void ThenIShouldSeeSeleniumInTheSearchResults()
        {
            IWebElement element = driver.FindElement(By.XPath("//a[@href='https://www.seleniumhq.org/']"));
            Assert.IsTrue(element.Displayed);
            driver.Quit();
        }
    }
}






