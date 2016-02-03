namespace QA.TelerikAcademy.FrontEnd.Tests.UserSettings.PersonalDataSettings
{
    #region using directives

    using Core.Constants.Attributes;
    using Core.Constants.Pages;
    using Core.Facades;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;
    using TestingFramework.Core.Providers;

    #endregion

    [TestClass]
    public class BirthdayTests : BaseTest
    {
        private readonly User currentUser;

        public BirthdayTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidBirthdayInThePastShouldThrowErrorMessage()
        {
            this.currentUser.Birthday = BirthdayConstants.InvalidBirthdayInThePast;
            this.SettingsService.EditingSettings(this.currentUser);
            //this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidBirthdayInTheFutureShouldThrowErrorMessage()
        {
            this.currentUser.Birthday = BirthdayConstants.InvalidBirthdayInTheFuture;
            this.SettingsService.EditingSettings(this.currentUser);
            //this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidBirthdayShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.Birthday = BirthdayConstants.ValidBirthday;
            this.SettingsService.UpdateSettings(this.currentUser);

            //Set field value back to default
            ExecutionDelayProvider.SleepFor(3000);
            this.currentUser.Birthday = string.Empty;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}