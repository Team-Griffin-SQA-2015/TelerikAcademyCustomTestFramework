namespace QA.TelerikAcademy.FrontEnd.Tests.UserSettings.EducationSettings
{
    #region using directives

    using Core.Constants.Attributes;
    using Core.Constants.Pages;
    using Core.Facades;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;

    #endregion

    [TestClass]
    public class SchoolNameTests : BaseTest
    {
        private User currentUser;

        public SettingsService SettingsService { get; set; }

        public override void TestInit()
        {
            this.SettingsService = new SettingsService();
            this.currentUser = new TestUser();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidSchoolNameShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.SchoolName = SchoolNameConstants.ValidSchoolName;
            this.SettingsService.UpdateSettings(this.currentUser);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidSchoolNameWithValueUnderLowerLimitShouldThrowValidationErrorMessage()
        {
            this.currentUser.SchoolName = SchoolNameConstants.InvalidSchoolNameWithValueUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.SchoolNameError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidSchoolNameWithValueAboveUpperLimitShouldThrowValidationErrorMessage()
        {
            this.currentUser.SchoolName = SchoolNameConstants.InvalidSchoolNameWithValueAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.SchoolNameError.AssertIsPresent();
        }
    }
}