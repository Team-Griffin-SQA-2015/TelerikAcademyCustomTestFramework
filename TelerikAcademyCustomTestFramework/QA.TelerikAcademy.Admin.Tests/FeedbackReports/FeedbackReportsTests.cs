namespace QA.TelerikAcademy.Admin.Tests.FeedbackReports
{
    #region using directives

    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;

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
    public class FeedbackReportsTests : BaseTest
    {
        private User user;
        private DialogMonitor DialogMonitor => Manager.Current.DialogMonitor;

        public FeedbackReportsFacade FeedbackReportsFacade { get; set; }

        public override void TestInit()
        {
            this.user = new TestUser();
            this.FeedbackReportsFacade = new FeedbackReportsFacade();
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void SendedFeedbackReportShouldBeVisibleInAdminFeedbackReportsPage()
        {
            this.FeedbackReportsFacade.SendFeedbackReport(this.user);

            Assert.IsTrue(this.FeedbackReportsFacade.FeedbackReportsPage.Map.FeedbackReportsKendoGrid.GridContainsText(
                this.user.Username));
            Assert.IsTrue(this.FeedbackReportsFacade.FeedbackReportsPage.Map.FeedbackReportsKendoGrid.GridContainsText(
                FeedbackReportsConstants.ValidFeedbackContent));
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void EditingExistingFeedbackReportShouldUpdateKendoGridCellsContent()
        {
            this.FeedbackReportsFacade.SendFeedbackReport(this.user);

            this.FeedbackReportsFacade.FeedbackReportsPage.Map.KendoGridEditButton.MouseClick();
            this.FeedbackReportsFacade.FeedbackReportsPage.Map.KendoWindowEditor.Wait.ForExists();
            this.FeedbackReportsFacade.FeedbackReportsPage.Map.KendoWindowEditorContent.Text =
                FeedbackReportsConstants.ValidEditedFeedbackContent;
            this.FeedbackReportsFacade.FeedbackReportsPage.Map.KendoWindowEditorUpdateButton.MouseClick();

            Assert.IsTrue(this.FeedbackReportsFacade.FeedbackReportsPage.Map.FeedbackReportsKendoGrid.GridContainsText(
                FeedbackReportsConstants.ValidEditedFeedbackContent));
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void DeletingExistingFeedbackReportShouldUpdateKendoGridCellsContent()
        {
            this.FeedbackReportsFacade.SendFeedbackReport(this.user);
            this.DialogMonitor.AddDialog(AlertDialog.CreateAlertDialog(this.Browser, DialogButton.OK));
            this.DialogMonitor.Start();

            this.FeedbackReportsFacade.FeedbackReportsPage.Map.KendoGridDeleteButton.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);

            Assert.IsFalse(this.FeedbackReportsFacade.FeedbackReportsPage.Map.FeedbackReportsKendoGrid.GridContainsText(
                FeedbackReportsConstants.ValidEditedFeedbackContent));
        }
    }
}