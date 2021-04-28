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
        public void Test1()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();
            
            Driver.Navigate().GoToUrl("https://aqa04onl01.testrail.io/index.php?/admin/overview");
            new DashboardPage(Driver, true);
            
            Assert.IsTrue(new DashboardPage(Driver).IsPageOpened());
            Assert.AreEqual(Driver.Title, "All Projects - TestRail");
            
            Console.Out.WriteLine(Project.Name);
            Console.Out.WriteLine(Project.Type);
        }

        [Test]
        [Regression]
        public void Test2()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();
            
            Assert.IsTrue(new DashboardPage(Driver).IsPageOpened());
            Assert.AreEqual(Driver.Title, "All Projects - TestRail");
        }
        
        [Test]
        [SmokeTest]
        public void Test3()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();

            var start = DateTime.Now;
            var element = new UIElement(Driver, _waitService.GetVisibleElement(By.Id("sidebar-projects-add")));
            var stop = DateTime.Now;
            Console.Out.WriteLine( stop.Ticks - start.Ticks);
        }

        [Test]
        [SmokeTest]
        public void Test4()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();

            var start = DateTime.Now;
            var element = _waitService.ExistsElement(By.Id("sidebar-projects-add"));
            var stop = DateTime.Now;
            Console.Out.WriteLine( stop.Ticks - start.Ticks);
        }
    }
}