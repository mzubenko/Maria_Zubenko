using System;
using TechTalk.SpecFlow;

namespace WEbUI.StepDefinitions
{
    [Binding]
    public class JobFeaturesStepDefinitions
    {
        private IWebDriver _webDriver;
        private AddJobPage new_page;
        private AdminPage new_admin_page;

        private string username = "Admin";
        private string password = "admin123";

        private string jobName = "SeleniumTest";
        private string jobDescription = "the job of testing";
        private string jobNote = "the job";

        [Given(@"user is on the website")]
        public void GivenUserIsOnTheWebsite()
        {
            _webDriver = new ChromeDriver("C:\\Users\\Admin\\.nuget\\packages\\selenium.webdriver.chromedriver\\113.0.5672.6300\\driver\\win32\\chromedriver.exe");
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [When(@"user logs into the site")]
        public void WhenUserLogsIntoTheSite()
        {
            var page = new LoginPage(_webDriver);
            page.LogIn(username, password);
        }

        [When(@"user goes to the Job page")]
        public void WhenUserGoesToTheJobPage()
        {
            var page = new SideMenuPage(_webDriver);
            page.AdminButton().JobButton().JobTitlesButton().AddJobButton();
        }

        [When(@"user adds new job")]
        public void WhenUserAddsNewJob()
        {
            new_page = new AddJobPage(_webDriver);
        }

        [Then(@"the new job is added")]
        public void ThenTheNewJobIsAdded()
        {
            if (new_page.AddJob(jobName, jobDescription, jobNote).IsElementExist(jobName))
                throw new InvalidOperationException("Does not exist");
        }

        [When(@"user deletes the job")]
        public void WhenUserDeletesTheJob()
        {
            new_admin_page = new AdminPage(_webDriver);
            new_admin_page.DeleteJob(jobName);
        }

        [Then(@"the job is deleted")]
        public void ThenTheJobIsDeleted()
        {
            if (new_admin_page.IsElementExist(jobName))
                throw new InvalidOperationException("Does exist");
        }

    }
}
