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
    public class CloseCase : Helper
    {

        private IWebDriver driver;


        public CloseCase(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

        }



    }
}
