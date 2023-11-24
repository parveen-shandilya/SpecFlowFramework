using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFrameWork.Pages
{
    public class AgencyLoginPage
    {
        private IWebDriver driver;
        public AgencyLoginPage(IWebDriver driver) { 
        
            this.driver = driver;
        }



        public static By usernameTxt_Id = By.Id("idp-discovery-username");
        public static By userNextBtn_Id = By.Id("idp-discovery-submit");
        public static By userPasswordTxt_Id = By.Id("okta-signin-password");
        public static By userSubmittBtn_Id = By.Id("okta-signin-submit");


        public static By headerPlusIcon_Css = By.CssSelector("#header div.app-header__new");
        public static By CodeEnforementLntxt_XPath = By.XPath("//label[text()='Code Enforcement Case']");






    }
}
