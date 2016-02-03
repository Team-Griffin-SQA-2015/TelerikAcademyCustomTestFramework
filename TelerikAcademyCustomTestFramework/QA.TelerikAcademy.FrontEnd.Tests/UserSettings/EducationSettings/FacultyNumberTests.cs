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
    public class FacultyNumberTests : BaseTest
    {
        private User currentUser;

        public SettingsService SettingsService { get; set; }

        public override void TestInit()
        {
            this.SettingsService = new SettingsService();
            this.currentUser = new TestUser();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidFacultyNumberShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.FacultyNumber = FacultyNumberConstants.ValidFacultyNumber;
            this.SettingsService.UpdateSettings(this.currentUser);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidFacultyNumberWithValueUnderLowerLimitShouldThrowValidationErrorMessage()
        {
            this.currentUser.FacultyNumber = FacultyNumberConstants.InvalidFacultyNumberWithValueUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FacultyNumberError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidFacultyNumberWithValueAboveUpperLimitShouldThrowValidationErrorMessage()
        {
            this.currentUser.FacultyNumber = FacultyNumberConstants.InvalidFacultyNumberWithValueAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FacultyNumberError.AssertIsPresent();
        }
    }
}