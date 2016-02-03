namespace QA.TelerikAcademy.Admin.Tests.Events.Functionality
{
    #region using directives

    using ArtOfTest.WebAii.Core;

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
    public class UpdateEventTests : BaseTest
    {
        private User currentuser;

        public EventsService EventsService { get; set; }

        [TestInitialize]
        public override void TestInit()
        {
            this.EventsService = new EventsService();
            this.currentuser = new TestUser();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            AcademyLoginProvider.Instance.Logout();
            Manager.Current.ActiveBrowser.Close();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(646)]
        public void UpdateEventWithBlankCourseMarksTheEventValidForAllCourses()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.EventsService.EventsPage.Navigate();
            this.EventsService.AddItemForSpecificCourse(EventsConstants.ValidDescription);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsService.EditItem(EventsConstants.ValidDescription,
                EventsConstants.ValidDescription,
                EventsConstants.ValidForAllCoursesId,
                EventsConstants.DefaultListOption);
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();

            var row = this.EventsService.EventsPage.Map.KendoGrid
                .IndexOfGridRowContainingText(EventsConstants.ValidDescriptionForUpdate);

            Assert.AreEqual(EventsConstants.ValidForAllCoursesText,
                this.EventsService.EventsPage.Map.KendoGrid
                    .GetCellContentAsString(row, EventsConstants.CourseColumnId));
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(659)]
        public void UpdateEventWithValidDetailsUpdatesTheEnteredEvent()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.EventsService.EventsPage.Navigate();
            this.EventsService.AddItemForSpecificCourse(EventsConstants.ValidDescription);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsService.EditItem(EventsConstants.ValidDescription,
                string.Empty,
                EventsConstants.DefaultListOption,
                EventsConstants.DefaultListOption);
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();

            var isNewDescriptionPresent =
                this.EventsService.EventsPage.Map.KendoGrid.GridContainsText(EventsConstants.ValidDescriptionForUpdate);
            var isOldDescriptionPresent =
                this.EventsService.EventsPage.Map.KendoGrid.GridContainsText(EventsConstants.ValidDescription);

            Assert.IsTrue(isNewDescriptionPresent);
            Assert.IsFalse(isOldDescriptionPresent);
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(647)]
        public void UpdateEventWithBlankTrainingRoomMarksTheEventValidForAllTrainingRooms()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.EventsService.EventsPage.Navigate();
            this.EventsService.AddItemForSpecificCourse(EventsConstants.ValidDescription);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsService.EditItem(EventsConstants.ValidDescription,
                EventsConstants.ValidDescriptionForUpdate,
                EventsConstants.DefaultListOption,
                EventsConstants.ValidForAllRoomsId);
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();

            var row = this.EventsService.EventsPage.Map.KendoGrid
                .IndexOfGridRowContainingText(EventsConstants.ValidDescriptionForUpdate);

            Assert.IsTrue(string.IsNullOrEmpty(this.EventsService.EventsPage.Map.KendoGrid
                .GetCellContentAsString(row, EventsConstants.RoomColumnId)));
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(663)]
        public void VerifyThatUpdatingEventWithWrongDetailsDoesNotAffectTheEvent()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.EventsService.EventsPage.Navigate();
            this.EventsService.AddItemForSpecificCourse(EventsConstants.ValidDescription);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsService.EditItem(EventsConstants.ValidDescription,
                string.Empty,
                EventsConstants.DefaultListOption,
                EventsConstants.DefaultListOption);
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.EventsService.EventsPage.Map.CancelChangesToItemButton.MouseClick();

            Assert.IsTrue(this.EventsService.EventsPage.Map.KendoGrid
                .GridContainsText(EventsConstants.ValidDescription));
        }
    }
}