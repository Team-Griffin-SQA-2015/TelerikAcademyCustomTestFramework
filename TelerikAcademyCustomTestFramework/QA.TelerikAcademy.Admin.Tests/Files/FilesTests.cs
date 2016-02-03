namespace QA.TelerikAcademy.Admin.Tests.Files
{
    #region using directives

    using System;
    using System.IO;
    using System.Windows.Forms;

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
    public class FilesTests : BaseTest
    {
        private User user;

        public FilesService FilesService { get; set; }

        public override void TestInit()
        {
            this.user = new TestUser();
            this.FilesService = new FilesService();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.MainModules)]
        public void ClickingUploadButtonWithoutUploadingAnyFileAndEnteringDescriptionShouldThrowValidationErrorMessages()
        {
            this.FilesService.UploadNewFile(this.user);

            this.Browser.WaitUntilReady();
            this.FilesService.UploadPage.Map.Submit.MouseClick();

            this.Browser.RefreshDomTree();
            this.FilesService.UploadPage.Map.ValidationSummaryErrors.AssertIsPresent();
            this.FilesService.UploadPage.Map.DescriptionError.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.MainModules)]
        [Description("This test introduce a new bug in the system")]
        public void UploadingBlankFileShouldThrowValidationErrorMessage()
        {
            this.FilesService.UploadNewFile(this.user);

            this.Browser.WaitUntilReady();
            this.FilesService.UploadPage.Map.ChooseFile.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.Desktop.KeyBoard.TypeText(
                Path.GetFullPath(Path.Combine(Environment.CurrentDirectory + FilesConstants.BlankFilePath)));
            this.Browser.Desktop.KeyBoard.KeyPress(Keys.Enter);
            this.FilesService.UploadPage.Map.Description.Text = FilesConstants.DefaultDescriptionText;
            this.FilesService.UploadPage.Map.Submit.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);

            Assert.AreNotEqual(this.FilesService.UploadPage.GetTitle(), this.Browser.PageTitle);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.MainModules)]
        public void UploadingFileInInvalidFormatShouldThrowValidationFailedErrorMessage()
        {
            this.FilesService.UploadNewFile(this.user);

            this.Browser.WaitUntilReady();
            this.FilesService.UploadPage.Map.ChooseFile.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.Desktop.KeyBoard.TypeText(
                Path.GetFullPath(Path.Combine(Environment.CurrentDirectory + FilesConstants.FileInInvalidFormatPath)));
            this.Browser.Desktop.KeyBoard.KeyPress(Keys.Enter);
            this.FilesService.UploadPage.Map.Description.Text = FilesConstants.DefaultDescriptionText;
            this.FilesService.UploadPage.Map.Submit.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);

            Assert.AreNotEqual(FilesConstants.ValidationFailedErrorPageTitle, this.Browser.PageTitle);
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.MainModules)]
        public void UploadingFileInValidFormatShouldSuccessfullyUpdateDataGridPagerLabel()
        {
            this.FilesService.UploadNewFile(this.user);

            this.Browser.WaitUntilReady();
            this.FilesService.UploadPage.Map.ChooseFile.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.Desktop.KeyBoard.TypeText(
                Path.GetFullPath(Path.Combine(Environment.CurrentDirectory + FilesConstants.FileInValidFormatPath)));
            this.Browser.Desktop.KeyBoard.KeyPress(Keys.Enter);
            this.FilesService.UploadPage.Map.Description.Text = FilesConstants.DefaultDescriptionText;
            this.FilesService.UploadPage.Map.Submit.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();

            this.FilesService.FilesPage.Map.PagerLabel.AssertTextContains(FilesConstants.PagerLabelContent);
        }
    }
}