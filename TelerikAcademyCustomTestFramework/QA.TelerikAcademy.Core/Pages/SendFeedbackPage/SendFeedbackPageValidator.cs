namespace QA.TelerikAcademy.Core.Pages.SendFeedbackPage
{
    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    public class SendFeedbackPageValidator
    {
        public SendFeedbackPageMap Map => new SendFeedbackPageMap();

        public void ValidateFullName()
        {
            this.Map.FullName.Wait.ForExists();
            this.Map.FullName.AssertIsPresent();
        }

        public void ValidateEmail()
        {
            this.Map.Email.Wait.ForExists();
            this.Map.Email.AssertIsPresent();
        }

        public void ValidateFeedbackContent()
        {
            this.Map.FeedbackContent.Wait.ForExists();
            this.Map.FeedbackContent.AssertIsPresent();
        }

        public void ValidateSubmit()
        {
            this.Map.Submit.Wait.ForExists();
            this.Map.Submit.AssertIsPresent();
        }
    }
}