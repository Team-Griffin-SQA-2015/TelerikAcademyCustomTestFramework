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
    public class LastNameEnTests : BaseTest
    {
        private readonly User currentUser;

        public LastNameEnTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidLastNameEnWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.currentUser.LastNameEn = LastNameEnConstants.InvalidLastNameEnWithLengthAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.LastNameEnError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidLastNameEnWithLengthUnderLowerLimitShouldThrowErrorMessage()
        {
            this.currentUser.LastNameEn = LastNameEnConstants.InvalidLastNameEnWithLengthUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.LastNameEnError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidLastNameEnShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.LastNameEn = LastNameEnConstants.ValidLastNameEn;
            this.SettingsService.UpdateSettings(this.currentUser);

            // Set Last name to default
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.currentUser.LastNameEn = LastNameEnConstants.DefaultLastNameEn;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}