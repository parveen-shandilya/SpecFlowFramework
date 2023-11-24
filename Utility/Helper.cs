using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFrameWork.Utility
{
    public class Helper
    {

        private IWebDriver driver;
        public static WebDriverWait wait;
        

        public Helper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));


        }

        public static void WaitForElementUntillVisible(By element)
        { 
           try {

               
                wait.Until(ExpectedConditions.ElementToBeClickable(element));     
           }
            catch (WebDriverException e) {
           }
        }

    public static string GetValueByKey(string jsonData, string key)
        {
            string value = "";
                dynamic json = JsonConvert.DeserializeObject(jsonData);   
                    if (json != null && json.ContainsKey(key))
                    {
                    value = json[key];
                    }
                    else
                    {
                       
                        return null;
                    }
                
                return value;
            }
        

        public static string LocalDataString(String Key)
        {

            string jsonFilePath = "C:\\Users\\lenovo\\source\\repos\\SpecFlowFrameWork\\testData.json";
            string jsonData = File.ReadAllText(jsonFilePath);
            string Value = GetValueByKey(jsonData, Key);

            return Value;
        }
  
}

}

