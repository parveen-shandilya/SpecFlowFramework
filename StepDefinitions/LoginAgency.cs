using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SpecFlowFrameWork.Utility;

namespace SpecFlowFrameWork.StepDefinitions
{
    [Binding]
    public class LoginAgency : Helper
    {

        private IWebDriver driver;

        public LoginAgency(IWebDriver driver) : base(driver) 
        {
            this.driver = driver;
        }

        [Given(@"Open the Browser")]
        public void GivenOpenTheBrowser()
        {
            
          
        }

        [When(@"Enter the URL")]
        public void WhenEnterTheURL()
        {
            //driver.Url = "https://app-stage.comcate.com/agencies/195/dashboard";
        }

        [Then(@"Login is page opened")]
        public void ThenLoginIsPageOpened()
        {
            Thread.Sleep(10000);
            Boolean login = driver.FindElement(By.Id("idp-discovery-username")).Displayed;
            Thread.Sleep(5000);
            login.Should().BeTrue();
          

        }

        [Then(@"Login is page opened is not Wrong")]
        public void ThenLoginIsPageOpenedIsNotWrong()
        {
            Thread.Sleep(10000);
            Boolean login = driver.FindElement(By.Id("idp-discovery-username")).Displayed;
            Thread.Sleep(5000);
            login.Should().BeFalse();

        }



    }
}
