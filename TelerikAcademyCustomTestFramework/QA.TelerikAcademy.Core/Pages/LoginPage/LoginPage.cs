namespace QA.TelerikAcademy.Core.Pages.LoginPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Facades;

    using TestingFramework.Core.Contracts;
    using TestingFramework.Core.Extensions;

    #endregion

    public class LoginPage : ILogin
    {
        public const string LoginUrl = @"http://stage.telerikacademy.com/Users/Auth/Login";

        public LoginPageMap Map => new LoginPageMap();

        public UpperNavigationSectionMap NavigationMap => new UpperNavigationSectionMap();

        public LoginPageValidator Validator => new LoginPageValidator();

        public void TypeEmail(string email)
        {
            this.Map.UserName.Text = email;
        }

        public void TypePassword(string password)
        {
            this.Map.Password.Text = password;
        }

        public void Submit()
        {
            this.Map.Submit.Click();
        }

        public void WaitForUserName()
        {
            Manager.Current.ActiveBrowser.WaitForExists(this.NavigationMap.UserNameExpression);
        }

        public void Logout()
        {
            this.NavigationMap.Logout.Click();
        }

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(LoginUrl);
        }
    }
}