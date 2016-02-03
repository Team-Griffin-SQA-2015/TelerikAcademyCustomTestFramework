namespace QA.TelerikAcademy.FrontEnd.Tests.UserSettings.PersonalDataSettings
{
    #region using directives

    using Core.Constants.Attributes;
    using Core.Facades;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    [TestClass]
    public class GenderTests : BaseTest
    {
        private readonly User currentUser;

        public GenderTests()
        {
            this.currentUser = new TestUser();
            this.SettingsService = new SettingsService();
        }

        public SettingsService SettingsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void SelectingMaleRadioButtonShouldSuccessfullyUpdateUserSettings()
        {
            this.SettingsService.NavigateToUserSettings();
            this.SettingsService.SettingsPage.Map.MaleRadioButton.Click();
            this.SettingsService.SettingsPage.SaveChanges();
            this.SettingsService.SettingsPage.Map.SuccessMessage.AssertIsPresent();

            //Set gender to default
            ExecutionDelayProvider.SleepFor(3000);
            this.SettingsService.SettingsPage.Map.UnknownGenderRadioButton.Click();
            this.SettingsService.SettingsPage.SaveChanges();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.Settings)]
        public void SelectingFemaleRadioButtonShouldSuccessfullyUpdateUserSettings()
        {
            this.SettingsService.NavigateToUserSettings();
            this.SettingsService.SettingsPage.Map.FemaleRadioButton.Click();
            this.SettingsService.SettingsPage.SaveChanges();
            this.SettingsService.SettingsPage.Map.SuccessMessage.AssertIsPresent();

            //Set gender to default
            ExecutionDelayProvider.SleepFor(3000);
            this.SettingsService.SettingsPage.Map.UnknownGenderRadioButton.Click();
            this.SettingsService.SettingsPage.SaveChanges();
        }
    }
}