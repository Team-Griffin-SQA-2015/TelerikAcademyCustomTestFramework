namespace QA.TelerikAcademy.FrontEnd.Tests.UserSettings.ProfileSettings
{
    #region using directives

    using Core.Constants.Attributes;
    using Core.Constants.Pages;
    using Core.Facades;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;

    #endregion

    [TestClass]
    public class ChangeEmailTests : BaseTest
    {
        private readonly User currentUser;

        public ChangeEmailTests()
        {
            this.currentUser = new TestUser();
            this.ChangeEmailService = new ChangeEmailService();
        }

        public ChangeEmailService ChangeEmailService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void ChangeEmailWithInvalidNewEmailWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.ChangeEmailService.ChangeCurrentEmail(ChangeEmailConstants.InvalidEmailWithLengthAboveUpperLimit);

            this.ChangeEmailService.WaitFor(ChangeEmailConstants.CustomWaitInMilliseconds);
            Assert.AreNotEqual(ChangeEmailConstants.ChangeEmailSuccessUrl, this.ChangeEmailService.GetUrl());
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void ChangeEmailWithInvalidNewEmailWithLengthUnderLowerLimitShouldThrowErrorMessage()
        {
            this.ChangeEmailService.ChangeCurrentEmail(ChangeEmailConstants.InvalidEmailWithLengthUnderLowerLimit);

            this.ChangeEmailService.WaitFor(ChangeEmailConstants.CustomWaitInMilliseconds);
            Assert.AreNotEqual(ChangeEmailConstants.ChangeEmailSuccessUrl, this.ChangeEmailService.GetUrl());
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void ChangeEmailWithValidOneShouldSuccessfullyUpdateCurrentUserEmail()
        {
            this.ChangeEmailService.ChangeCurrentEmail(ChangeEmailConstants.ValidEmail);

            this.ChangeEmailService.WaitFor(ChangeEmailConstants.CustomWaitInMilliseconds);
            this.ChangeEmailService.RefreshBrowser();
            Assert.AreEqual(ChangeEmailConstants.ChangeEmailSuccessUrl, this.ChangeEmailService.GetUrl());

            this.ChangeEmailService.SetCurrentEmailToDefault();
        }
    }
}