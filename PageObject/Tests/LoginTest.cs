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
        public void Test2()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();
            
            Assert.IsTrue(new DashboardPage(Driver).IsPageOpened());
            Assert.AreEqual(Driver.Title, "All Projects - TestRail");
        }
    }
}