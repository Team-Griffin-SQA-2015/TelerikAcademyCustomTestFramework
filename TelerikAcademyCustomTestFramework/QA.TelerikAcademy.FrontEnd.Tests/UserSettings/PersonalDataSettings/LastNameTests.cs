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
    public class LastNameTests : BaseTest
    {
        private readonly User currentUser;

        public LastNameTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidLastNameWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.currentUser.LastName = LastNameConstants.InvalidLastNameWithLengthAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.LastNameError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidLastNameWithLengthUnderLowerLimitShouldThrowErrorMessage()
        {
            this.currentUser.LastName = LastNameConstants.InvalidLastNameWithLengthUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.LastNameError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidLastNameShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.LastName = LastNameConstants.ValidLastName;
            this.SettingsService.UpdateSettings(this.currentUser);

            // Set Last name to default
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.currentUser.LastName = LastNameConstants.DefaultLastName;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}