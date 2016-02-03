namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using Pages.CandidateExamsPage;
    using Pages.LoginPage;

    using TestingFramework.Core.Data;

    #endregion

    public class CandidateExamsService
    {
        public CandidateExamsService()
        {
            this.LoginPage = new LoginPage();
            this.CandidateExamsPage = new CandidateExamsPage();
        }

        public CandidateExamsPage CandidateExamsPage { get; }

        public LoginPage LoginPage { get; }

        public void AddCandidateExam(User user, CandidateExam candidateExam)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);
            this.CandidateExamsPage.Navigate();
            this.CandidateExamsPage.Validator.CandidateExamPageLoaded();
            this.CandidateExamsPage.AddCandidateExam(candidateExam);
        }

        public void UpdateCandidateExam()
        {
            this.CandidateExamsPage.UpdateCandidateExam();
        }

        public void CancelCandidateExamChanges()
        {
            this.CandidateExamsPage.CancelCandidateExamChanges();
        }

        public void ValidateErrorMessageIqTestConfiguration()
        {
            this.CandidateExamsPage.Validator.ValidateErrorMessageIqTestConfiguration();
        }

        public void ValidateErrorMessageItTestConfiguration()
        {
            this.CandidateExamsPage.Validator.ValidateErrorMessageItTestConfiguration();
        }

        public void ValidateErrorMessageEnglishTestConfiguration()
        {
            this.CandidateExamsPage.Validator.ValidateErrorMessageEnglishTestConfiguration();
        }
    }
}