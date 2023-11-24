using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFrameWork.Pages
{
    public class CreateCasePage
    {

        private IWebDriver driver;
        public CreateCasePage(IWebDriver driver)
        {

            this.driver = driver;
        }

        public static By CreateCaseHeaderLbl_Xpath = By.XPath("//h1[text()='Create A Case']");
    }
}
