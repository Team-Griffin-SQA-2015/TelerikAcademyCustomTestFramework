namespace QA.TelerikAcademy.FrontEnd.Tests.UserSettings.PersonalDataSettings
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
    public class FirstNameTests : BaseTest
    {
        private readonly User currentUser;

        public FirstNameTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidFirstNameWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.currentUser.FirstName = FirstNameConstants.InvalidFirstNameWithLengthAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FirstNameError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidFirstNameWithLengthUnderLowerLimitShouldThrowErrorMessage()
        {
            this.currentUser.FirstName = FirstNameConstants.InvalidFirstNameWithLengthUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FirstNameError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidFirstNameShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.FirstName = FirstNameConstants.ValidFirstName;
            this.SettingsService.UpdateSettings(this.currentUser);

            // Set field value back to default
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.currentUser.FirstName = FirstNameConstants.DefaultFirstName;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}