namespace QA.TelerikAcademy.Core.Pages.ChangePasswordPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class ChangePasswordPage
    {
        public const string ChangePasswordUrl = @"http://stage.telerikacademy.com/Users/Auth/ChangePassword";

        public ChangePasswordPageMap Map => new ChangePasswordPageMap();

        public ChangePasswordPageValidator Validator => new ChangePasswordPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(ChangePasswordUrl);
        }
    }
}