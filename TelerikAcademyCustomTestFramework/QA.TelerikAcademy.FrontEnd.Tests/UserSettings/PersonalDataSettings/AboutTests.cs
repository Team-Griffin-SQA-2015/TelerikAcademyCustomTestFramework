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
    public class AboutTests : BaseTest
    {
        private readonly User currentUser;

        public AboutTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringInvalidAboutLoremIpsumTextWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.currentUser.About = AboutConstants.InvalidAbout;
            this.SettingsService.EditingSettings(this.currentUser);
            this.SettingsService.SettingsPage.Map.FieldValidationError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void EnteringValidAboutLoremIpsumTextShouldSuccessfullyUpdateUserSettings()
        {
            this.currentUser.About = AboutConstants.ValidAbout;
            this.SettingsService.UpdateSettings(this.currentUser);

            //Set field value back to default
            ExecutionDelayProvider.SleepFor(3000);
            this.currentUser.About = string.Empty;
            this.SettingsService.SettingsPage.UpdateSettings(this.currentUser);
        }
    }
}