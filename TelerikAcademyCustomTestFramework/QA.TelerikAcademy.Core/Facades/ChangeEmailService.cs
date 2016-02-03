namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Pages.ChangeEmailPage;
    using Pages.LoginPage;
    using Pages.SettingsPage;

    using TestingFramework.Core.Data;
    using TestingFramework.Core.Providers;

    #endregion

    public class ChangeEmailService
    {
        private readonly User user;

        public ChangeEmailService()
        {
            this.LoginPage = new LoginPage();
            this.SettingsPage = new SettingsPage();
            this.ChangeEmailPage = new ChangeEmailPage();
            this.user = new TestUser();
        }

        public LoginPage LoginPage { get; set; }

        public SettingsPage SettingsPage { get; set; }

        public ChangeEmailPage ChangeEmailPage { get; set; }

        public void ChangeCurrentEmail(string newEmail)
        {
            AcademyLoginProvider.Instance.LoginUser(this.user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(this.user.Username);

            this.SettingsPage.Navigate();
            this.SettingsPage.Validator.UsernameLabel(this.user.Username);

            this.ChangeEmailPage.Navigate();
            this.ChangeEmailPage.Validator.ValidatePasswordField();
            this.ChangeEmailPage.Validator.ValidateNewEmailField();
            this.ChangeEmailPage.Validator.ValidateNewEmailAgainField();
            //this.ChangeEmailPage.Validator.ValidateSubmitButton();
            this.ChangeEmailPage.Map.Password.MouseClick(MouseClickType.LeftClick);
            this.ChangeEmailPage.Map.Password.Value = this.user.Password;
            this.ChangeEmailPage.Map.NewEmail.MouseClick(MouseClickType.LeftClick);
            this.ChangeEmailPage.Map.NewEmail.Value = newEmail;
            this.ChangeEmailPage.Map.NewEmailAgain.MouseClick(MouseClickType.LeftClick);
            this.ChangeEmailPage.Map.NewEmailAgain.Value = newEmail;
            this.ChangeEmailPage.Map.Submit.MouseClick(MouseClickType.LeftClick);
        }

        public void SetCurrentEmailToDefault()
        {
            this.ChangeEmailPage.Navigate();
            this.ChangeEmailPage.Validator.ValidatePasswordField();
            this.ChangeEmailPage.Validator.ValidateNewEmailField();
            this.ChangeEmailPage.Validator.ValidateNewEmailAgainField();
            //this.ChangeEmailPage.Validator.ValidateSubmitButton();
            this.ChangeEmailPage.Map.Password.MouseClick(MouseClickType.LeftClick);
            this.ChangeEmailPage.Map.Password.Value = this.user.Password;
            this.ChangeEmailPage.Map.NewEmail.MouseClick(MouseClickType.LeftClick);
            this.ChangeEmailPage.Map.NewEmail.Value = this.user.Email;
            this.ChangeEmailPage.Map.NewEmailAgain.MouseClick(MouseClickType.LeftClick);
            this.ChangeEmailPage.Map.NewEmailAgain.Value = this.user.Email;
            this.ChangeEmailPage.Map.Submit.MouseClick(MouseClickType.LeftClick);
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