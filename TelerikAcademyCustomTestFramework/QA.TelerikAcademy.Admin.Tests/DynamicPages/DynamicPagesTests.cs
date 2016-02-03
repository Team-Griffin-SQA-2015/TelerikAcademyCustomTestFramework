namespace QA.TelerikAcademy.Admin.Tests.DynamicPages
{
    #region using directives

    using System.Linq;

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
    public class DynamicPagesTests : BaseTest
    {
        private User currentUser;

        public DynamicPagesService DynamicPagesService { get; set; }

        public override void TestInit()
        {
            this.DynamicPagesService = new DynamicPagesService();
            this.currentUser = new TestUser();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.MainModules)]
        public void AddingDynamicPageWithEmptyRequiredFieldsShouldThrowValidationErrorMessages()
        {
            this.DynamicPagesService.InsertNewDynamicPage(this.currentUser);
            this.DynamicPagesService.DynamicPagesPage.Map.UpdateButton.Wait.ForExists();
            this.DynamicPagesService.DynamicPagesPage.Map.UpdateButton.MouseClick();
            this.DynamicPagesService.DynamicPagesPage.Map.KendoWindow.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.MainModules)]
        public void AddingDynamicPageWithOversizedTitleAndEmptyContentShouldThrowValidationErrorMessage()
        {
            this.DynamicPagesService.InsertNewDynamicPage(this.currentUser);
            this.DynamicPagesService.DynamicPagesPage.Map.Title.Text = DynamicPagesConstants.InvalidOversizedTitle;
            this.DynamicPagesService.DynamicPagesPage.Map.UpdateButton.Wait.ForExists();
            this.DynamicPagesService.DynamicPagesPage.Map.UpdateButton.MouseClick();
            this.DynamicPagesService.DynamicPagesPage.Map.KendoWindow.AssertIsPresent();
        }

        [TestMethod, Owner(Owners.LyudmilNikodimov), Priority(Priorities.Medium), TestCategory(Modules.MainModules)]
        public void AddingDynamicPageWithValidRequiredFieldsShouldSuccessfullyInsertNewGridCellInKendoDataGrid()
        {
            this.DynamicPagesService.InsertNewDynamicPage(this.currentUser);
            this.DynamicPagesService.DynamicPagesPage.Map.Title.Wait.ForVisible();
            this.DynamicPagesService.DynamicPagesPage.Map.Title.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(DynamicPagesConstants.ValidTitle);
            this.DynamicPagesService.DynamicPagesPage.Map.Editor.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(DynamicPagesConstants.ValidContent);
            this.DynamicPagesService.DynamicPagesPage.Map.UpdateButton.Wait.ForExists();
            this.DynamicPagesService.DynamicPagesPage.Map.UpdateButton.MouseClick();

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            var kendoGrid = this.DynamicPagesService.DynamicPagesPage.Map.KendoGrid;
            var actualTitle = kendoGrid.DataItems.FirstOrDefault().ChildNodes[1].InnerText;
            var actualContent =
                kendoGrid.DataItems.FirstOrDefault().ChildNodes[4].ChildNodes.FirstOrDefault().TextContent;

            Assert.AreEqual(DynamicPagesConstants.ValidTitle, actualTitle);
            Assert.AreEqual(DynamicPagesConstants.ValidContent, actualContent);
        }
    }
}