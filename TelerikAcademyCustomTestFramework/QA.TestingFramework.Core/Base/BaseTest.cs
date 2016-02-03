namespace QA.TestingFramework.Core.Base
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    #endregion

    [TestClass]
    public class BaseTest
    {
        private Manager manager;

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
        public void CoreCleanUp()
        {
            this.TestCleanUp();
            this.CleanUp();
        }

        private void CleanUp()
        {
            if (Manager.Current == null)
            {
                return;
            }

            if (Manager.Current.Settings.Web.RecycleBrowser)
            {
                return;
            }

            this.manager.Dispose();
        }

        [ClassCleanup]
        public virtual void CoreClassCleanUp()
        {
            this.Shutdown();
        }

        private void Shutdown()
        {
            if (Manager.Current == null || !Manager.Current.Settings.Web.RecycleBrowser)
            {
                return;
            }

            this.Browser.Close();
            this.manager.Dispose();
        }

        private void InitializeBrowser()
        {
            if (Manager.Current == null)
            {
                var settings = new Settings
                {
                    Web =
                    {
                        DefaultBrowser = BrowserType.InternetExplorer
                    }
                };

                this.manager = new Manager(settings);
                this.manager.Start();
            }

            this.manager.LaunchNewBrowser();
            this.Browser.Window.Maximize();
            this.Browser.AutoDomRefresh = true;
            this.Browser.AutoWaitUntilReady = true;
            this.Browser.CommandTimeOut = 20000;
        }

        private void ClearBrowserCache()
        {
            this.Browser.ClearCache(BrowserCacheType.Cookies);
            this.Browser.ClearCache(BrowserCacheType.History);
            this.Browser.ClearCache(BrowserCacheType.TempFilesCache);
        }
    }
}