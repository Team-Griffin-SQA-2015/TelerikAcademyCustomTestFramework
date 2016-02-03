namespace QA.TelerikAcademy.Core.Pages.FilesPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class FilesPage
    {
        public const string Url = @"http://stage.telerikacademy.com/Administration/Files";

        public FilesPageMap Map => new FilesPageMap();

        public FilesPageValidator Validator => new FilesPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }
    }
}