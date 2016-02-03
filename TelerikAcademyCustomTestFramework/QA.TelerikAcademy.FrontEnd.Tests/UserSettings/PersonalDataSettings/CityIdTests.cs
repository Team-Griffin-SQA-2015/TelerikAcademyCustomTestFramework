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
    public class CityIdTests : BaseTest
    {
        private readonly User currentUser;

        public CityIdTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidCityIdShouldThrowErrorMessage()
        {
            this.currentUser.CityId = CityIdConstants.InvalidCityId;
            this.SettingsService.EditingSettings(this.currentUser);
            //this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidCityIdShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.CityId = CityIdConstants.InvalidCityId;
            this.SettingsService.UpdateSettings(this.currentUser);

            //Set field value back to default
            ExecutionDelayProvider.SleepFor(3000);
            this.currentUser.CityId = CityIdConstants.DefaultCityId;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}