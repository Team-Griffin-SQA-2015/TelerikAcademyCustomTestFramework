namespace QA.TelerikAcademy.FrontEnd.Tests.UserSettings.EducationSettings
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
    public class UniversityIdTests : BaseTest
    {
        private User currentUser;

        public SettingsService SettingsService { get; set; }

        public override void TestInit()
        {
            this.SettingsService = new SettingsService();
            this.currentUser = new TestUser();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidUniversityIdShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.UniversityId = UniversityIdConstants.ValidUniversityId;
            this.SettingsService.UpdateSettings(this.currentUser);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidUniversityIdShouldThrowValidationErrorMessage()
        {
            this.currentUser.UniversityId = UniversityIdConstants.InvalidUniversityId;
            this.SettingsService.UpdateSettings(this.currentUser);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        [Description("This test introduce a new bug in the field 'UniversityId'")]
        public void EnteringInvalidUniversityIdShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.UniversityId = UniversityIdConstants.InvalidUniversityId;
            this.SettingsService.UpdateSettings(this.currentUser);
            ExecutionDelayProvider.SleepFor(1000);
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}