using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.Assist;
using SpecFlowFrameWork.Pages;
using Newtonsoft.Json;
using SpecFlowFrameWork.Utility;

namespace SpecFlowFrameWork.StepDefinitions
{
    [Binding]
    public class CreateCase : Helper
    {

        private IWebDriver driver;
        

        public CreateCase(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
           
        }


        [Given(@"User logged into Application")]
        public void GivenUserLoggedIntoApplication()
        {
            Helper.WaitForElementUntillVisible(AgencyLoginPage.usernameTxt_Id);
            String userEmail = Helper.LocalDataString("emailId");
            String password = Helper.LocalDataString("password");
            driver.FindElement(AgencyLoginPage.usernameTxt_Id).SendKeys(userEmail);
            Helper.WaitForElementUntillVisible(AgencyLoginPage.userNextBtn_Id);
            driver.FindElement(AgencyLoginPage.userNextBtn_Id).Click();
            Helper.WaitForElementUntillVisible(AgencyLoginPage.userPasswordTxt_Id);
            driver.FindElement(AgencyLoginPage.userPasswordTxt_Id).SendKeys(password);
            Helper.WaitForElementUntillVisible(AgencyLoginPage.userSubmittBtn_Id);
            driver.FindElement(AgencyLoginPage.userSubmittBtn_Id).Click();
            Thread.Sleep(5000);
        }

        [Given(@"User is on Case Create Case Page")]
        public void GivenUserIsOnCaseCreateCasePage()
        {




        }

        [When(@"User Click on plus and Code Enforcemetn Case Option")]
        public void WhenUserClickOnPlusAndCodeEnforcemetnCaseOption()
        {
            Thread.Sleep(15000);
            driver.FindElement(AgencyLoginPage.headerPlusIcon_Css).Click();
            Thread.Sleep(5000);
            driver.FindElement(AgencyLoginPage.CodeEnforementLntxt_XPath).Click();
            Thread.Sleep(5000);
        }

        [Then(@"I see user is on '([^']*)' page")]
        public void ThenISeeUserIsOnPage(string createCase)
        {
            Thread.Sleep(20000);
            string header = driver.FindElement(CreateCasePage.CreateCaseHeaderLbl_Xpath).Text;
            header.Should().Be(createCase);
        }

        [Then(@"I See user is on (.*)")]
        public void ThenISeeUserIsOnCreateACase(string headers)
        {
            Thread.Sleep(20000);
            string header = driver.FindElement(CreateCasePage.CreateCaseHeaderLbl_Xpath).Text;
            header.Should().Be(headers);
        }

        [Then(@"I see user is on create case pagePopup")]
        public void ThenISeeUserIsOnCreateCasePagePopup(Table table)
        {
            // get all the data from table 
            var headers = table.CreateSet<HeaderNamesData>();
            Thread.Sleep(20000);
            string header = driver.FindElement(CreateCasePage.CreateCaseHeaderLbl_Xpath).Text;

            foreach (var headerKey in headers)
            {
                header.Should().Be(headerKey.headerName);
            }
        }

    }
        // class create to get the table value using get and set.
        public class HeaderNamesData
        {
            public string headerName {
                get; 
                set; 
            }

        }

    }

