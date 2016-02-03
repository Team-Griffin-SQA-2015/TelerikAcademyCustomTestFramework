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
    public class UniversitySpecialtyTests : BaseTest
    {
        private User currentUser;

        public SettingsService SettingsService { get; set; }

        public override void TestInit()
        {
            this.SettingsService = new SettingsService();
            this.currentUser = new TestUser();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidUniversitySpecialtyShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.UniversitySpecialty = UniversitySpecialtyConstants.ValidUniversitySpecialty;
            this.SettingsService.UpdateSettings(this.currentUser);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidUniversitySpecialtyWithValueUnderLowerLimitShouldThrowValidationErrorMessage()
        {
            this.currentUser.UniversitySpecialty =
                UniversitySpecialtyConstants.InvalidUniversitySpecialtyWithValueUnderLowerLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.UniversitySpecialtyError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidUniversitySpecialtyWithValueAboveUpperLimitShouldThrowValidationErrorMessage()
        {
            this.currentUser.UniversitySpecialty =
                UniversitySpecialtyConstants.InvalidUniversitySpecialtyWithValueAboveUpperLimit;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.UniversitySpecialtyError.AssertIsPresent();
        }
    }
}