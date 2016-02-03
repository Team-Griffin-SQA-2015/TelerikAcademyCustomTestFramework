namespace QA.TelerikAcademy.Core.Pages.FeedbackReportsPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class FeedbackReportsPage
    {
        private const string Url = @"http://stage.telerikacademy.com/Administration/FeedbackReports";

        public FeedbackReportsPageMap Map => new FeedbackReportsPageMap();

        public FeedbackReportsPageValidator Validator => new FeedbackReportsPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }
    }
}