namespace QA.TelerikAcademy.Core.Pages.MainPage
{
    #region using directives

    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Core;

    using TestingFramework.Core.Extensions;

    #endregion

    public class MainPageValidator
    {
        public MainPageMap Map => new MainPageMap();

        public void ValidateNewsSlider()
        {
            this.Map.NewsSlider.Wait.ForExists();
            this.Map.NewsSlider.AssertIsPresent();
        }

        public void ValidatePageTitle(string pageTitle)
        {
            Assert.AreEqual(pageTitle, Manager.Current.ActiveBrowser.PageTitle);
        }

        public void ValidatePageUrl(string pageUrl)
        {
            Assert.AreEqual(pageUrl, Manager.Current.ActiveBrowser.Url);
        }
    }
}