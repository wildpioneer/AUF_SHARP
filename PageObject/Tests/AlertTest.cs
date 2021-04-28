using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.BaseEntities;

namespace PageObject
{
    public class AlertTest : BaseTest
    {
        [Test]
        public void WaitAlertTest()
        {
            Driver.Navigate().GoToUrl(@"https://www.toolsqa.com/handling-alerts-using-selenium-webdriver/");
            
            _waitService.GetVisibleElement(By.Id("timerAlertButton")).Click();
            var alert = _waitService.GetAlertOnPage();
            alert.Accept();
        }
    }
}