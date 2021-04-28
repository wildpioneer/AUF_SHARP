using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObject.BaseEntities;
using PageObject.Core.Wrappers;
using PageObject.Steps;

namespace PageObject
{
    public class ActionTest : BaseTest
    {
        [Test]
        public void ActionTest1()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();

            Driver.Navigate().GoToUrl(@"https://aqa04onl02.testrail.io/index.php?/cases/edit/36/1");

            var webElement = _waitService.GetVisibleElement(By.Id("custom_preconds"));
            var webElement1 = _waitService.GetVisibleElement(By.ClassName("icon-markdown-table"));
 
            Actions actions = new Actions(Driver);
            actions
                .MoveToElement(webElement1)
                .Build()
                .Perform();
            
            //((IJavaScriptExecutor) Driver).ExecuteScript("arguments[0]", webElement);
            
            Thread.Sleep(5000);
        }

        [Test]
        public void ActionTest2()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();

            Driver.Navigate().GoToUrl(@"https://aqa04onl02.testrail.io/index.php?/cases/edit/36/1");

            var webElement1 = new UIElement(Driver, By.ClassName("icon-markdown-table"));
 
            webElement1.Hover();
            
            Thread.Sleep(5000);
        }
    }
}