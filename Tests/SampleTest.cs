using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

[TestClass]
public class SampleTest
{
    private IWebDriver _driver = null!;

    [TestInitialize]
    public void Setup()
    {
        var options = new ChromeOptions();
        if (Settings.Headless)
        {
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        }
        _driver = new RemoteWebDriver(new Uri(Settings.SeleniumHub), options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.TimeoutSeconds);
    }

    [TestMethod]
    public void PageTitle_ShouldNotBeEmpty()
    {
        _driver.Navigate().GoToUrl(Settings.BaseUrl);
        Assert.IsFalse(string.IsNullOrEmpty(_driver.Title));
    }

    [TestCleanup]
    public void Teardown()
    {
        _driver?.Quit();
    }
}
