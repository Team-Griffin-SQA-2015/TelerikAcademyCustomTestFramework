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
    public class FirstNameEnTests : BaseTest
    {
        private readonly User currentUser;

        public FirstNameEnTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidFirstNameEnWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.currentUser.FirstNameEn = FirstNameEnConstants.InvalidFirstNameEnWithLengthAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FirstNameEnError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidFirstNameEnWithLengthUnderLowerLimitShouldThrowErrorMessage()
        {
            this.currentUser.FirstNameEn = FirstNameEnConstants.InvalidFirstNameEnWithLengthUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FirstNameEnError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidFirstNameEnShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.FirstNameEn = FirstNameEnConstants.ValidFirstNameEn;
            this.SettingsService.UpdateSettings(this.currentUser);

            // Set field value back to default
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.currentUser.FirstNameEn = FirstNameEnConstants.DefaultFirstNameEn;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}