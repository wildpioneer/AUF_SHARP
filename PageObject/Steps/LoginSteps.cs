using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Steps
{
    public class LoginSteps
    {
        private IWebDriver _driver;
        
        public LoginSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        public void LogIn()
        {
            LoginPage loginPage = new LoginPage(_driver, true);
            
            loginPage.EmailInput().SendKeys(Configurator.Username);
            loginPage.PswInput().SendKeys(Configurator.Password);
            loginPage.LoginInButton().Click();
        }
    }
}