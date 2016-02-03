namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Pages.AvatarsPage;
    using Pages.LoginPage;
    using Pages.SettingsPage;

    using TestingFramework.Core.Data;
    using TestingFramework.Core.Providers;

    #endregion

    public class AvatarsService
    {
        public AvatarsService()
        {
            this.LoginPage = new LoginPage();
            this.SettingsPage = new SettingsPage();
            this.AvatarsPage = new AvatarsPage();
        }

        public LoginPage LoginPage { get; set; }

        public SettingsPage SettingsPage { get; set; }

        public AvatarsPage AvatarsPage { get; set; }

        public void UploadNewAvatarImage(User user, string filePath)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);

            this.SettingsPage.Navigate();
            this.SettingsPage.Validator.UsernameLabel(user.Username);

            this.AvatarsPage.Navigate();
            this.AvatarsPage.Validator.ValidateUploadNewAvatarImage();
            this.AvatarsPage.Map.UploadNewAvatarImage.Focus();
            this.AvatarsPage.Map.UploadNewAvatarImage.Upload(filePath, 10000);
        }

        public void RefreshBrowser()
        {
            Manager.Current.ActiveBrowser.Refresh();
        }

        public void WaitFor(int milliseconds)
        {
            ExecutionDelayProvider.SleepFor(milliseconds);
        }

        public void InvokeScript(string script)
        {
            Manager.Current.ActiveBrowser.Actions.InvokeScript(script);
        }
    }
}