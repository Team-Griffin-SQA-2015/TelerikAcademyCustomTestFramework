namespace QA.TelerikAcademy.Core.Pages.UploadPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class UploadPage
    {
        private const string Url = @"http://stage.telerikacademy.com/Administration/Files/Upload";

        public UploadPageMap Map => new UploadPageMap();

        public UploadPageValidator Validator => new UploadPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }

        public string GetUrl()
        {
            return Url;
        }

        public string GetTitle()
        {
            return "Файлове - Телерик Академия - Студентска система";
        }
    }
}