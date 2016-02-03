namespace QA.TelerikAcademy.Core.Pages.KidsCandidateFormPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class KidsCandidateFormPage
    {
        private const string Url = @"http://stage.telerikacademy.com/KidsAcademy/Registration/ExistingAccount";

        public KidsCandidateFormPageMap Map => new KidsCandidateFormPageMap();

        public KidsCandidateFormPageValidator Validator => new KidsCandidateFormPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }

        public string GetUrl()
        {
            return Url;
        }
    }
}