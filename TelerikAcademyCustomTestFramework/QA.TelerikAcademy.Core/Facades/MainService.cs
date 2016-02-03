namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;

    using Pages.LoginPage;
    using Pages.MainPage;

    using TestingFramework.Core.Data;
    using TestingFramework.Core.Providers;

    #endregion

    public class MainService
    {
        public MainService()
        {
            this.LoginPage = new LoginPage();
            this.MainPage = new MainPage();
        }

        public Browser Browser => Manager.Current.ActiveBrowser;

        public LoginPage LoginPage { get; set; }

        public MainPage MainPage { get; set; }

        public void NavigateToMainPage(User user)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);
        }

        public void ClickCurrentButton(User currentUser, HtmlControl navigationButton)
        {
            this.NavigateToMainPage(currentUser);
            navigationButton.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
        }
    }
}