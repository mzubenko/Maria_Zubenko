using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEbUI
{
    internal class AdminPage
    {
        private static readonly By _jobMenuButton = By.XPath("//*[text() = 'Job ']");
        private static readonly By _jobTitlesButton = By.XPath("//*[text() = 'Job Titles']");
        private static readonly By _addJobButton = By.XPath("//button[text() = ' Add ']");
        private static readonly By _acceptDeleteButton = By.XPath("//button[text() = ' Yes, Delete ']");

        private IWebDriver _webDriver;
        public AdminPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AdminPage JobButton()
        {
            WaitManagement.WaitElement(_webDriver, _jobMenuButton);
            _webDriver.FindElement(_jobMenuButton).Click();
            return this;
        }

        public AdminPage JobTitlesButton()
        {
            _webDriver.FindElement(_jobTitlesButton).Click();
            return this;
        }

        public AddJobPage AddJobButton()
        {
            WaitManagement.WaitElement(_webDriver, _addJobButton);
            _webDriver.FindElement(_addJobButton).Click();
            return new AddJobPage(_webDriver);
        }

        public AdminPage DeleteJob(string str)
        {
            By _deleteJob = By.XPath($"//div[text() = '{str}']/parent::div/following-sibling::div/following-sibling::div/child::div/child::button");
            WaitManagement.WaitElement(_webDriver, _deleteJob);
            _webDriver.FindElement(_deleteJob).Click();
            _webDriver.FindElement(_acceptDeleteButton).Click();
            return this;
        }

        public bool IsElementExist(string str)
        {
            try
            {
                _webDriver.FindElement(By.XPath($"//div[text() = '{str}']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
