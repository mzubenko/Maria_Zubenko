using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEbUI
{
    internal class BasicPage
    {
        public IWebDriver _webDriver;

        public BasicPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
