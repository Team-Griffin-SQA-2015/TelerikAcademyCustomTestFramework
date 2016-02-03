namespace QA.TelerikAcademy.Core.Pages.AdminPage
{
    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    public class AdminPageValidator
    {
        public AdminPageMap Map => new AdminPageMap();

        public void ValidateSearchInput()
        {
            this.Map.SearchInAdministration.AssertIsPresent();
        }

        public void ValidateAdminContainer()
        {
            this.Map.AdminContainer.AssertIsPresent();
        }
    }
}