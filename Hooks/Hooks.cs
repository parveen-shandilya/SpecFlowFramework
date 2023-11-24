using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowFrameWork.Utility;
using TechTalk.SpecFlow;

[assembly:Parallelizable(ParallelScope.Fixtures)]
namespace SpecFlowFrameWork.Hooks
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        private readonly IObjectContainer _container;
      

        public Hooks(IObjectContainer container) {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInit();
        }

        [AfterTestRun] 
        public static void AfterTestRun()
        {
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {

        }

        [BeforeScenario("@tag1")]
        public static void BeforeScenarioWithTag()
        {
          
        }

        [BeforeScenario(Order = 1)]
        public  void FirstBeforeScenario(ScenarioContext scenarioContext)
        {

           IWebDriver driver = new ChromeDriver();
           driver.Manage().Window.Maximize();
            // stored the driver
           _container.RegisterInstanceAs<IWebDriver>(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            driver.Url = "https://app-stage.comcate.com/agencies/195/dashboard";

        }

        [AfterScenario]
        public void AfterScenario()
        {
            // get the driver
            var driver = _container.Resolve<IWebDriver>();

            if(driver != null)
            {
                driver.Quit();
            }
        }

        [AfterStep]
        public  void AfterStep(ScenarioContext senarioContext)
        {
            String steptype = senarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            String stepName = senarioContext.StepContext.StepInfo.Text;
            var driver = _container.Resolve<IWebDriver>();

            // When Sceanrio Pass
            if (senarioContext.TestError == null) {
                if (steptype == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (steptype == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                if (steptype == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
            }

            // When Sceanrio Fails
            if (senarioContext.TestError != null)

            {

                
                if (steptype == "Given")
                {
                    
                    _scenario.CreateNode<Given>(stepName).Fail(senarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, senarioContext)).Build());
                      
                }
                else if (steptype == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(senarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, senarioContext)).Build()
                         );
                }
                if (steptype == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(senarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, senarioContext)).Build()
                       );
                }

            }



        }
    }
}