namespace QA.UI.TestingFramework.Core.Base
{
    using ArtOfTest.WebAii.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseTest
    {
        public Browser Browser => Manager.Current.ActiveBrowser;

        public virtual void TestInit()
        {
        }

        public virtual void TestCleanUp()
        {
        }

        [TestInitialize]
        public void CoreTestInit()
        {
            this.TestInit();
            this.InitializeBrowser();
            this.ClearBrowserCache();
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            this.TestCleanUp();
            //this.DisposeBrowser();
        }

        private void InitializeBrowser()
        {
            if (Manager.Current == null)
            {
                var mySettings = new Settings
                    {
                        Web = { KillBrowserProcessOnClose = true },
                        DisableDialogMonitoring = true,
                        UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue
                    };

                mySettings.Web.ExecutingBrowsers.Add(BrowserExecutionType.InternetExplorer);
                mySettings.Web.Browser = BrowserExecutionType.InternetExplorer;
                mySettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
                mySettings.ElementWaitTimeout = 10000;
                var manager = new Manager(mySettings);
                manager.Start();
            }

            Manager.Current.LaunchNewBrowser();
            Manager.Current.ActiveBrowser.Window.Maximize();
            Manager.Current.Settings.Web.RecycleBrowser = true;
        }

        private void DisposeBrowser()
        {
            foreach (var browser in Manager.Current.Browsers)
            {
                browser.Close();
            }

            if (Manager.Current != null)
            {
                Manager.Current.Dispose();
            }
        }

        private void ClearBrowserCache()
        {
            this.Browser.ClearCache(BrowserCacheType.Cookies);
            this.Browser.ClearCache(BrowserCacheType.History);
            this.Browser.ClearCache(BrowserCacheType.TempFilesCache);
        }
    }
}