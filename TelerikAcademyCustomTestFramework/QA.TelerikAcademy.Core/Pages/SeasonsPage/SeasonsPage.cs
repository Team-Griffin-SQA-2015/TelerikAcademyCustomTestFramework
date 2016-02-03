namespace QA.TelerikAcademy.Core.Pages.SeasonsPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class SeasonsPage
    {
        public const string Url = @"http://stage.telerikacademy.com/Administration_SoftwareAcademy/Seasons";

        public SeasonsPageMap Map => new SeasonsPageMap();

        public SeasonsPageValidator Validator => new SeasonsPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }
    }
}