namespace QA.TelerikAcademy.Core.Pages.LoginPage
{
    #region using directives

    using Facades;

    using TestingFramework.Core.Extensions;

    #endregion

    public class LoginPageValidator
    {
        public UpperNavigationSectionMap NavigationMap => new UpperNavigationSectionMap();

        public void ValidateUserName(string userName)
        {
            this.NavigationMap.UserName.AssertTextEquals(userName);
        }
    }
}