namespace QA.TelerikAcademy.Core.Pages.MainPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class MainPage
    {
        private const string Url = @"http://stage.telerikacademy.com/";

        public MainPageMap Map => new MainPageMap();

        public MainPageValidator Validator => new MainPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }
    }
}