using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEbUI
{
    internal class SideMenuPage
    {

        private static By _adminButton = By.XPath("//a[@href  = '/web/index.php/admin/viewAdminModule']");

        private IWebDriver _webDriver;
        public SideMenuPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public AdminPage AdminButton()
        {
            WaitManagement.WaitElement(_webDriver, _adminButton);
            _webDriver.FindElement(_adminButton).Click();
            return new AdminPage(_webDriver);
        }
    }
}
