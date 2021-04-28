using System;
using System.Timers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.BaseEntities;
using PageObject.Core.Wrappers;
using PageObject.Pages;
using PageObject.Steps;

namespace PageObject
{
    [Parallelizable(ParallelScope.All)]
    public class Tests : BaseTest
    {
        [Test]
        [SmokeTest]
        [Description("Проверить корректный логин")]
        public void SuccessLoginTest()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();
            
            Assert.IsTrue(new DashboardPage(Driver).IsPageOpened());
            Assert.AreEqual(Driver.Title, "All Projects - TestRail");
        }

        [Test]
        [SmokeTest]
        [Description("Проверить некорректный логин")]
        public void IncorrectLoginTest()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();
            
            Assert.IsTrue(new DashboardPage(Driver).IsPageOpened());
            Assert.AreEqual(Driver.Title, "All Projects - TestRail");
        }
    }
}