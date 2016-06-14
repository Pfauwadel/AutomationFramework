﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameWork.Driver
{
    public class BrowserType
    {
        public enum WebBrowser
        {
            ChromeDesktop,
            FirefoxDesktop,
            InternetExploreDesktop,
            iPad,
            iPhone4,
            iPhone5,
            iPhone6,
            Nexus5,
            Nexus6,
            Nexus7
        }
        public enum HeadlessBrowser
        {
            PhantomJSBrowser
        }
        public enum RemoteBrowser
        {
            RemoteBrowser
        }
        public enum MobileBrowser
        {
        }
    }
}
