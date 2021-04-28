using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.Enums;
using PageObject.Models;
using PageObject.Services;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PageObject.BaseEntities
{
    public class BaseTest
    {
        public static string BaseURL = Configurator.BaseUrl;
        protected Project Project;
        protected WaitService _waitService;
        
        [ThreadStatic] protected static IWebDriver Driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            SeSetUpProjects();
        }
        
        [SetUp]
        public void Setup()
        {
            Driver = new BrowserService().WebDriver;
            _waitService = new WaitService(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        private void SeSetUpProjects()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = Path.Combine(basePath, $"TestData{Path.DirectorySeparatorChar}", @"project.json");
            
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonStream = File.ReadAllText(fullPathToFile);
            Project = JsonSerializer.Deserialize<Project>(jsonStream);
        }
    }
}