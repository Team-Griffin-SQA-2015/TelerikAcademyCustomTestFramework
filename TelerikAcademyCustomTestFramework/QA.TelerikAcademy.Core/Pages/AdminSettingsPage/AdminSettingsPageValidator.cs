namespace QA.TelerikAcademy.Core.Pages.AdminSettingsPage
{
    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    public class AdminSettingsPageValidator
    {
        public AdminSettingsPageMap Map => new AdminSettingsPageMap();

        public void ValidateSettingsH1Tag()
        {
            this.Map.SettingsH1Tag.Wait.ForVisible();
            this.Map.SettingsH1Tag.AssertIsPresent();
        }
    }
}