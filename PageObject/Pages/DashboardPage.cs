using System;
using OpenQA.Selenium;
using PageObject.BaseEntities;

namespace PageObject.Pages
{
    public class DashboardPage : BasePage
    {
        private static string END_POINT = "index.php?/dashboard";
        
        // Описание элементов
        private static readonly By SidebarProjectsAddButtonBy = By.Id("sidebar-projects-add");
        
        
        public DashboardPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public DashboardPage(IWebDriver driver) : base(driver, false)
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
                return SidebarProjectsAddButton.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public IWebElement SidebarProjectsAddButton => Driver.FindElement(SidebarProjectsAddButtonBy);
    }
}