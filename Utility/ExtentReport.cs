using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;

namespace SpecFlowFrameWork.Utility
{
    public  class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

   
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0\\", "TestResults");
      
        public static void ExtentReportInit()
        {


            if (!Directory.Exists(testResultPath))
            {
                try
                {
                    // Create the folder
                    Directory.CreateDirectory(testResultPath);
                    Console.WriteLine("Folder created successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating folder: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Folder already exists.");
            }


            ExtentSparkReporter spark = new ExtentSparkReporter(testResultPath+"\\ExtentReport.html");
            spark.Config.Theme = Theme.Standard;
            spark.Config.ReportName = "SpecflowFrameWork Status Report";
            spark.Config.DocumentTitle = "Automationn Status Report";
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(spark);
            _extentReports.AddSystemInfo("Application","Comcate");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");



        }

        public static void ExtentReportTearDown()
        {
      
            _extentReports.Flush();
        }

        // 1 parameter driver and 2 is scenario context
        public static String addScreenShot(IWebDriver driver,ScenarioContext scenarioContext) {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenShot = takesScreenshot.GetScreenshot();
            string screenShotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title.Split("|")[0]+".png");
            screenShot.SaveAsFile(screenShotLocation);
            return screenShotLocation;
        }

      
    }
}
