using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEbUI
{
    internal class LoginPage
    {

        private By _passwordInput = By.XPath("//input[@name = 'password']");
        private By _loginInput = By.XPath("//input[@name = 'username']");
        private By _submitButton = By.XPath("//button[@type = 'submit']");

        private IWebDriver _webDriver;
        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public LoginPage EnterLogin(string login)
        {
            WaitManagement.WaitElement(_webDriver, _loginInput);
            _webDriver.FindElement(_loginInput).SendKeys(login);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            _webDriver.FindElement(_passwordInput).SendKeys(password);
            return this;
        }

        public LoginPage Submit()
        {
            _webDriver.FindElement(_submitButton).Click();
            return this;
        }

        public SideMenuPage LogIn(string login, string password)
        {
            EnterLogin(login);
            EnterPassword(password);
            Submit();
            return new SideMenuPage(_webDriver);
        }

    }
}
