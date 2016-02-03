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
    public class UploadNewAvatarImageTests : BaseTest
    {
        private readonly User currentUser;

        public UploadNewAvatarImageTests()
        {
            this.currentUser = new TestUser();
            this.AvatarsService = new AvatarsService();
        }

        public AvatarsService AvatarsService { get; set; }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void UploadingEmptyAvatarImageShouldNotChangeAvatarImagesCount()
        {
            this.AvatarsService.UploadNewAvatarImage(this.currentUser,
                UploadNewAvatarImageConstants.InvalidEmptyAvatarImageFilePath);

            this.AvatarsService.WaitFor(UploadNewAvatarImageConstants.CustomWaitForInvalidAvatarImage);
            this.AvatarsService.RefreshBrowser();
            Assert.AreEqual(0, this.AvatarsService.AvatarsPage.Map.AvatarImages.Count);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void UploadingOversizedAvatarImageShouldNotChangeAvatarImagesCount()
        {
            this.AvatarsService.UploadNewAvatarImage(this.currentUser,
                UploadNewAvatarImageConstants.InvalidOversizedAvatarImageFilePath);

            this.AvatarsService.WaitFor(UploadNewAvatarImageConstants.CustomWaitForOversizedAvatarImage);
            this.AvatarsService.RefreshBrowser();
            Assert.AreEqual(0, this.AvatarsService.AvatarsPage.Map.AvatarImages.Count);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void UploadingNewAvatarImageInInvalidFormatShouldNotChangeAvatarImagesCount()
        {
            this.AvatarsService.UploadNewAvatarImage(this.currentUser,
                UploadNewAvatarImageConstants.InvalidFormatAvatarImageFilePath);

            this.AvatarsService.WaitFor(UploadNewAvatarImageConstants.CustomWaitForInvalidAvatarImage);
            this.AvatarsService.RefreshBrowser();
            Assert.AreEqual(0, this.AvatarsService.AvatarsPage.Map.AvatarImages.Count);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.High), TestCategory(Modules.Settings)]
        public void UploadingNewAvatarImageShouldIncreaseAvatarImages()
        {
            this.AvatarsService.UploadNewAvatarImage(this.currentUser,
                UploadNewAvatarImageConstants.ValidAvatarImageFilePath);

            this.AvatarsService.WaitFor(UploadNewAvatarImageConstants.CustomWaitForValidAvatarImage);
            this.AvatarsService.RefreshBrowser();
            Assert.AreEqual(1, this.AvatarsService.AvatarsPage.Map.AvatarImages.Count);

            //Additional step for removing all uploaded avatar images
            this.AvatarsService.InvokeScript(UploadNewAvatarImageConstants.RemoveAvatarImageScript);
        }
    }
}