namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using Pages.CandidateFormPage;
    using Pages.LoginPage;

    using TestingFramework.Core.Data;

    #endregion

    public class CandidateFormService
    {
        public CandidateFormService()
        {
            this.LoginPage = new LoginPage();
            this.CandidateFormPage = new CandidateFormPage();
        }

        public CandidateFormPage CandidateFormPage { get; }

        public LoginPage LoginPage { get; }

        public void Candidate(User user, Candidate candidate)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);

            this.CandidateFormPage.Navigate();

            this.CandidateFormPage.Candidate(candidate);
        }
    }
}