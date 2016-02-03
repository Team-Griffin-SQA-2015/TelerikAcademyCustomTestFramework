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
    public class ChangePasswordTests : BaseTest
    {
        private readonly User currentUser;

        public ChangePasswordTests()
        {
            this.currentUser = new TestUser();
            this.ChangePasswordService = new ChangePasswordService();
        }

        public ChangePasswordService ChangePasswordService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void ChangePasswordWithInvalidNewPasswordWithLengthAboveUpperLimitShouldThrowErrorMessage()
        {
            this.ChangePasswordService.ChangeCurrentPassword(
                ChangePasswordConstants.InvalidPasswordWithLengthAboveUpperLimit);

            this.ChangePasswordService.WaitFor(ChangePasswordConstants.CustomWaitInMilliseconds);
            Assert.AreNotEqual(ChangePasswordConstants.ChangePasswordSuccessUrl, this.ChangePasswordService.GetUrl());
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void ChangePasswordWithInvalidNewPasswordWithLengthUnderLowerLimitShouldThrowErrorMessage()
        {
            this.ChangePasswordService.ChangeCurrentPassword(
                ChangePasswordConstants.InvalidPasswordWithLengthUnderLowerLimit);

            this.ChangePasswordService.WaitFor(ChangePasswordConstants.CustomWaitInMilliseconds);
            Assert.AreNotEqual(ChangePasswordConstants.ChangePasswordSuccessUrl, this.ChangePasswordService.GetUrl());
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void ChangePasswordWithValidOneShouldSuccessfullyUpdateCurrentUserPassword()
        {
            this.ChangePasswordService.ChangeCurrentPassword(ChangePasswordConstants.ValidPassword);

            this.ChangePasswordService.WaitFor(ChangePasswordConstants.CustomWaitInMilliseconds);
            this.ChangePasswordService.RefreshBrowser();
            Assert.AreEqual(ChangePasswordConstants.ChangePasswordSuccessUrl, this.ChangePasswordService.GetUrl());

            this.ChangePasswordService.SetCurrentPasswordToDefault();
        }
    }
}