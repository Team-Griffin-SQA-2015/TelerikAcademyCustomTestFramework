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
    public class FacultyNameTests : BaseTest
    {
        private User currentUser;

        public SettingsService SettingsService { get; set; }

        public override void TestInit()
        {
            this.SettingsService = new SettingsService();
            this.currentUser = new TestUser();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidFacultyNameShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.FacultyName = FacultyNameConstants.ValidFacultyName;
            this.SettingsService.UpdateSettings(this.currentUser);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidFacultyNameWithValueUnderLowerLimitShouldThrowValidationErrorMessage()
        {
            this.currentUser.FacultyName = FacultyNameConstants.InvalidFacultyNameWithValueUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FacultyNameError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidFacultyNameWithValueAboveUpperLimitShouldThrowValidationErrorMessage()
        {
            this.currentUser.FacultyName = FacultyNameConstants.InvalidFacultyNameWithValueAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FacultyNameError.AssertIsPresent();
        }
    }
}