namespace QA.TelerikAcademy.FrontEnd.Tests.UserSettings.SocialMediaSettings
{
    #region using directives

    using Core.Constants.Attributes;
    using Core.Constants.Pages;
    using Core.Facades;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    [TestClass]
    public class SkypeUsernameTests : BaseTest
    {
        private readonly User currentUser;

        public SkypeUsernameTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidSkypeUsernameWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.currentUser.SkypeUsername = SkypeUsernameConstants.InvalidSkypeUsernameWithLengthAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidSkypeUsernameWithLengthUnderLowerLimitShouldThrowErrorMessage()
        {
            this.currentUser.SkypeUsername = SkypeUsernameConstants.InvalidSkypeUsernameWithLengthUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidSkypeUsernameShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.SkypeUsername = SkypeUsernameConstants.ValidSkypeUsername;
            this.SettingsService.UpdateSettings(this.currentUser);

            // Set field value back to default
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.currentUser.SkypeUsername = string.Empty;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}