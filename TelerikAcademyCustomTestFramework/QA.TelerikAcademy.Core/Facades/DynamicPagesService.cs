namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using Pages.DynamicPagesPage;
    using Pages.LoginPage;

    using TestingFramework.Core.Data;

    #endregion

    public class DynamicPagesService
    {
        public DynamicPagesService()
        {
            this.LoginPage = new LoginPage();
            this.DynamicPagesPage = new DynamicPagesPage();
        }

        public LoginPage LoginPage { get; set; }

        public DynamicPagesPage DynamicPagesPage { get; set; }

        public void InsertNewDynamicPage(User user)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);
            this.DynamicPagesPage.Navigate();
            this.DynamicPagesPage.Validator.ValidatePageTitle();
            this.DynamicPagesPage.Validator.ValidateDataGrid();
            this.DynamicPagesPage.Map.AddNewDynamicPage.Click();
            this.DynamicPagesPage.Map.UpdateButton.Wait.ForVisible();
        }
    }
}