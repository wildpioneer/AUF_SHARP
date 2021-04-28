using System;
using OpenQA.Selenium;
using PageObject.BaseEntities;
using PageObject.Core.Wrappers;

namespace PageObject.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";
        
        // Описание элементов
        private static readonly By EmailInputBy = By.Id("name");
        private static readonly By PswInputBy = By.Id("password");
        private static readonly By RememberMeCheckboxBy = By.Id("rememberme");
        private static readonly By LoginInButtonBy = By.Id("button_primary");
        
        // Инициализация класса
        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseURL + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return LoginInButton().Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        // Методы
        public UIElement EmailInput()
        {
            return new UIElement(Driver, EmailInputBy);  
        }

        public IWebElement PswInput()
        {
            return Driver.FindElement(PswInputBy);
        }

        public IWebElement RememberMeCheckbox()
        {
            return Driver.FindElement(RememberMeCheckboxBy);  
        }

        public Button LoginInButton()
        {
           return new Button(Driver, LoginInButtonBy);
        }
    }
}