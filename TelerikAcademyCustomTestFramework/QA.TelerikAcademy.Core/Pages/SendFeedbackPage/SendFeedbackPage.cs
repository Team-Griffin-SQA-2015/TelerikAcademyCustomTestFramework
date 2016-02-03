namespace QA.TelerikAcademy.Core.Pages.SendFeedbackPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class SendFeedbackPage
    {
        private const string Url = @"http://stage.telerikacademy.com/FeedbackReport";

        public SendFeedbackPageMap Map => new SendFeedbackPageMap();

        public SendFeedbackPageValidator Validator => new SendFeedbackPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }
    }
}