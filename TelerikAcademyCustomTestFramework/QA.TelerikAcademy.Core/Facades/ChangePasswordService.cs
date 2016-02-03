namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using Pages.ChangePasswordPage;
    using Pages.LoginPage;
    using Pages.SettingsPage;

    using TestingFramework.Core.Data;
    using TestingFramework.Core.Providers;

    #endregion

    public class ChangePasswordService
    {
        private readonly User user;

        public ChangePasswordService()
        {
            this.LoginPage = new LoginPage();
            this.SettingsPage = new SettingsPage();
            this.ChangePasswordPage = new ChangePasswordPage();
            this.user = new TestUser();
        }

        public LoginPage LoginPage { get; set; }

        public SettingsPage SettingsPage { get; set; }

        public ChangePasswordPage ChangePasswordPage { get; set; }

        public void ChangeCurrentPassword(string newPassword)
        {
            AcademyLoginProvider.Instance.LoginUser(this.user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(this.user.Username);

            this.SettingsPage.Navigate();
            this.SettingsPage.Validator.UsernameLabel(this.user.Username);

            this.ChangePasswordPage.Navigate();
            this.ChangePasswordPage.Validator.ValidateCurrentPasswordField();
            this.ChangePasswordPage.Validator.ValidateNewPasswordField();
            this.ChangePasswordPage.Validator.ValidateNewPasswordAgainField();
            //this.ChangePasswordPage.Validator.ValidateSubmitButton();
            this.ChangePasswordPage.Map.CurrentPassword.MouseClick(MouseClickType.LeftClick);
            this.ChangePasswordPage.Map.CurrentPassword.Value = this.user.Password;
            this.ChangePasswordPage.Map.NewPassword.MouseClick(MouseClickType.LeftClick);
            this.ChangePasswordPage.Map.NewPassword.Value = newPassword;
            this.ChangePasswordPage.Map.NewPasswordAgain.MouseClick(MouseClickType.LeftClick);
            this.ChangePasswordPage.Map.NewPasswordAgain.Value = newPassword;
            this.ChangePasswordPage.Map.Submit.MouseClick(MouseClickType.LeftClick);
        }

        public void SetCurrentPasswordToDefault()
        {
            this.ChangePasswordPage.Navigate();
            this.ChangePasswordPage.Validator.ValidateCurrentPasswordField();
            this.ChangePasswordPage.Validator.ValidateNewPasswordField();
            this.ChangePasswordPage.Validator.ValidateNewPasswordAgainField();
            this.ChangePasswordPage.Validator.ValidateSubmitButton();
            this.ChangePasswordPage.Map.CurrentPassword.MouseClick(MouseClickType.LeftClick);
            this.ChangePasswordPage.Map.CurrentPassword.Value = ChangePasswordConstants.ValidPassword;
            this.ChangePasswordPage.Map.NewPassword.MouseClick(MouseClickType.LeftClick);
            this.ChangePasswordPage.Map.NewPassword.Value = this.user.Password;
            this.ChangePasswordPage.Map.NewPasswordAgain.MouseClick(MouseClickType.LeftClick);
            this.ChangePasswordPage.Map.NewPasswordAgain.Value = this.user.Password;
            this.ChangePasswordPage.Map.Submit.MouseClick(MouseClickType.LeftClick);
        }

        public void WaitFor(int milliseconds)
        {
            ExecutionDelayProvider.SleepFor(milliseconds);
        }

        public void RefreshBrowser()
        {
            Manager.Current.ActiveBrowser.Refresh();
        }

        public string GetUrl()
        {
            return Manager.Current.ActiveBrowser.Url;
        }
    }
}