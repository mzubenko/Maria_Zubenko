using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEbUI
{
    internal class AddJobPage
    {

        private By _jobName = By.XPath("//form[@class='oxd-form']//input[contains(@class,'oxd-input')]");
        private By _jobDescription = By.XPath("//textarea[@placeholder = 'Type description here']");
        private By _jobNote = By.XPath("//textarea[@placeholder = 'Add note']");
        private By _saveButton = By.XPath("//button[text() = ' Save ']");

        private IWebDriver _webDriver;
        public AddJobPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AddJobPage AddJobName(string str)
        {
            WaitManagement.WaitElement(_webDriver, _jobName);
            _webDriver.FindElement(_jobName).SendKeys(str);
            return this;
        }

        public AddJobPage AddJobDescription(string str)
        {
            _webDriver.FindElement(_jobDescription).SendKeys(str);
            return this;
        }

        public AddJobPage AddNote(string str)
        {
            _webDriver.FindElement(_jobNote).SendKeys(str);
            return this;
        }

        public AdminPage SaveJob()
        {
            _webDriver.FindElement(_saveButton).Click();
            return new AdminPage(_webDriver);
        }

        public AdminPage AddJob(string jobName, string jobDescription, string jobNote)
        {
            AddJobName(jobName);
            AddJobDescription(jobDescription);
            AddNote(jobNote);
            return SaveJob();
        }


    }
}
