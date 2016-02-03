namespace QA.TelerikAcademy.Core.Pages.AdminSettingsPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class AdminSettingsPage
    {
        private const string Url = @"http://stage.telerikacademy.com/Administration/Settings";

        public AdminSettingsPageMap Map => new AdminSettingsPageMap();

        public AdminSettingsPageValidator Validator => new AdminSettingsPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }
    }
}