namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using Constants.Pages;

    using Pages.FeedbackReportsPage;
    using Pages.LoginPage;
    using Pages.SendFeedbackPage;

    using TestingFramework.Core.Data;

    #endregion

    public class FeedbackReportsFacade
    {
        public FeedbackReportsPage FeedbackReportsPage => new FeedbackReportsPage();

        public LoginPage LoginPage => new LoginPage();

        public SendFeedbackPage SendFeedbackPage => new SendFeedbackPage();

        public void SendFeedbackReport(User user)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.Validator.ValidateUserName(user.Username);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);

            this.SendFeedbackPage.Navigate();
            this.SendFeedbackPage.Validator.ValidateFullName();
            this.SendFeedbackPage.Validator.ValidateEmail();
            this.SendFeedbackPage.Validator.ValidateFeedbackContent();
            this.SendFeedbackPage.Validator.ValidateSubmit();
            this.SendFeedbackPage.Map.FeedbackContent.Text = FeedbackReportsConstants.ValidFeedbackContent;
            this.SendFeedbackPage.Map.Submit.MouseClick();

            this.FeedbackReportsPage.Navigate();
            this.FeedbackReportsPage.Validator.ValidateKendoGrid();
        }
    }
}