namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using Pages.AdminSettingsPage;
    using Pages.CandidateFormPage;
    using Pages.KidsCandidateFormPage;
    using Pages.LoginPage;
    using Pages.MainPage;

    using TestingFramework.Core.Data;

    #endregion

    public class SettingsFacade
    {
        public LoginPage LoginPage => new LoginPage();

        public AdminSettingsPage AdminSettingsPage => new AdminSettingsPage();

        public MainPage MainPage => new MainPage();

        public CandidateFormPage CandidateFormPage => new CandidateFormPage();

        public KidsCandidateFormPage KidsCandidateFormPage => new KidsCandidateFormPage();

        public void NavigateToAdminSettingsPage(User user)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.Validator.ValidateUserName(user.Username);

            this.AdminSettingsPage.Navigate();
            this.AdminSettingsPage.Validator.ValidateSettingsH1Tag();
            this.AdminSettingsPage.Map.SortingBySettingIdLink.MouseClick();
        }

        public void NavigateToMainPage()
        {
            this.MainPage.Navigate();
            this.MainPage.Validator.ValidateNewsSlider();
        }

        public void NavigateToCandidateFormPage()
        {
            this.CandidateFormPage.Navigate();
            this.CandidateFormPage.Validator.ValidateCandidateFormH1Tag();
        }

        public void NavigateToKidsCandidateFormPage()
        {
            this.KidsCandidateFormPage.Navigate();
            this.KidsCandidateFormPage.Validator.ValidateKidsCandidateFormH2Tag();
        }
    }
}