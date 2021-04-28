using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.BaseEntities;
using PageObject.Core.Wrappers;
using PageObject.Steps;

namespace PageObject
{
    public class WrappersTest : BaseTest
    {
        [Test]
        public void TableTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();

            Driver.Navigate().GoToUrl("https://aqa04onl02.testrail.io/index.php?/admin/projects/overview");
            
            Table table = new Table(Driver, By.CssSelector("table.grid"));
            Console.Out.WriteLine(table.RowCount());
        }
    }
}