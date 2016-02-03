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
    public class LinkedInUrlTests : BaseTest
    {
        private readonly User currentUser;

        public LinkedInUrlTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidLinkedInUrlWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.currentUser.LinkedInUrl = LinkedInUrlConstants.InvalidLinkedInUrlWithLengthAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidLinkedInUrlWithLengthUnderLowerLimitShouldThrowErrorMessage()
        {
            this.currentUser.LinkedInUrl = LinkedInUrlConstants.InvalidLinkedInUrlWithLengthUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidLinkedInUrlShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.LinkedInUrl = LinkedInUrlConstants.ValidLinkedInUrl;
            this.SettingsService.UpdateSettings(this.currentUser);

            // Set field value back to default
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.currentUser.LinkedInUrl = string.Empty;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}