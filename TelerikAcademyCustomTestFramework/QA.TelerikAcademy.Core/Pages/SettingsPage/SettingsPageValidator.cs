namespace QA.TelerikAcademy.Core.Pages.SettingsPage
{
    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    public class SettingsPageValidator
    {
        public SettingsPageMap Map => new SettingsPageMap();

        public void UsernameLabel(string username)
        {
            this.Map.UsernameLabel.AssertTextContains(username);
        }

        public void SettingsUpdated()
        {
            this.Map.SuccessMessage.AssertIsPresent();
        }

        public void SettingsNotUpdated()
        {
            this.Map.SuccessMessage.AssertIsNotVisible();
        }
    }
}