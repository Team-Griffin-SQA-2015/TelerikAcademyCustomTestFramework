namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using Pages.LoginPage;

    using TestingFramework.Core.Contracts;
    using TestingFramework.Core.Providers;

    #endregion

    public class AcademyLoginProvider : LoginProvider<AcademyLoginProvider>
    {
        public UpperNavigationSectionMap NavigationMap => new UpperNavigationSectionMap();

        public override ILogin Login => new LoginPage();

        public override string Url => @"http://stage.telerikacademy.com//Users/Auth/Login";

        public void Logout()
        {
            this.NavigationMap.Logout.Click();
        }
    }
}