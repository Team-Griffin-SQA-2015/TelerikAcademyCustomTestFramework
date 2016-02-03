namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using Pages.LoginPage;
    using Pages.SettingsPage;

    using TestingFramework.Core.Data;

    #endregion

    public class SettingsService
    {
        public SettingsService()
        {
            this.LoginPage = new LoginPage();
            this.SettingsPage = new SettingsPage();
        }

        public LoginPage LoginPage { get; set; }

        public SettingsPage SettingsPage { get; set; }

        public void UpdateSettings(User user)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);
            this.SettingsPage.Navigate();
            this.SettingsPage.Validator.UsernameLabel(user.Username);
            this.SettingsPage.UpdateSettings(user);
            this.SettingsPage.Validator.SettingsUpdated();
        }

        public void EditingSettings(User user)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);
            this.SettingsPage.Navigate();
            this.SettingsPage.Validator.UsernameLabel(user.Username);
            this.SettingsPage.UpdateSettings(user);
        }

        public void NavigateToUserSettings()
        {
            var user = new TestUser();
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);
            this.SettingsPage.Navigate();
            this.SettingsPage.Validator.UsernameLabel(user.Username);
        }

        public void ValidationSummaryErrors(User user)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);
            this.SettingsPage.Navigate();
            this.SettingsPage.Validator.UsernameLabel(user.Username);
            this.SettingsPage.UpdateSettings(user);
            this.SettingsPage.Validator.SettingsNotUpdated();
        }
    }
}