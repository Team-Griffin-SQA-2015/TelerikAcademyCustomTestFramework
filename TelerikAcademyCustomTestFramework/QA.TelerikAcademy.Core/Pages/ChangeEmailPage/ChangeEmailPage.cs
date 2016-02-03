namespace QA.TelerikAcademy.Core.Pages.ChangeEmailPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class ChangeEmailPage
    {
        public const string ChangeEmailUrl = @"http://stage.telerikacademy.com/Users/Auth/ChangeEmail";

        public ChangeEmailPageMap Map => new ChangeEmailPageMap();

        public ChangeEmailPageValidator Validator => new ChangeEmailPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(ChangeEmailUrl);
        }
    }
}