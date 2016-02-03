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
    public class GooglePlusUrlTests : BaseTest
    {
        private readonly User currentUser;

        public GooglePlusUrlTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidGooglePlusUrlWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.currentUser.GooglePlusUrl = GooglePlusUrlConstants.InvalidGooglePlusUrlWithLengthAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidGooglePlusUrlWithLengthUnderLowerLimitShouldThrowErrorMessage()
        {
            this.currentUser.GooglePlusUrl = GooglePlusUrlConstants.InvalidGooglePlusUrlWithLengthUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidGooglePlusUrlShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.GooglePlusUrl = GooglePlusUrlConstants.ValidGooglePlusUrl;
            this.SettingsService.UpdateSettings(this.currentUser);

            // Set field value back to default
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.currentUser.GooglePlusUrl = string.Empty;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}