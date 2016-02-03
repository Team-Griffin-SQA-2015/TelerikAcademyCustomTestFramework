namespace QA.TelerikAcademy.Core.Pages.AvatarsPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class AvatarsPage
    {
        public const string AvatarsPageUrl = @"http://stage.telerikacademy.com/Users/Avatars";

        public AvatarsPageMap Map => new AvatarsPageMap();

        public AvatarsPageValidator Validator => new AvatarsPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(AvatarsPageUrl);
        }
    }
}