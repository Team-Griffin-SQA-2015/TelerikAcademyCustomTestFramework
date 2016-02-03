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
    public class AddEventTests : BaseTest
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
        [TestCaseId(520)]
        public void AddNewEvent()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.EventsService.EventsPage.Navigate();
            this.EventsService.AddItemForSpecificCourse(EventsConstants.ValidDescription);
            this.Browser.RefreshDomTree();

            var isEventAdded =
                this.EventsService.EventsPage.Map.KendoGrid.GridContainsText(EventsConstants.ValidDescription);

            this.EventsService.RemoveItem(EventsConstants.ValidDescription);

            Assert.IsTrue(isEventAdded);
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(518)]
        public void AddNewEventWithBlankDescriptionDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.EventsService.EventsPage.Navigate();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsService.AddItemForAllCourses(string.Empty);
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();

            this.EventsService.EventsPage.Map.DescriptionValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(519)]
        public void AddNewEventWithoutSpecifyingCourseAddsEventForAllCourses()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.EventsService.EventsPage.Navigate();
            this.EventsService.AddItemForAllCourses(EventsConstants.ValidDescription);
            this.Browser.RefreshDomTree();

            var isEventAdded =
                this.EventsService.EventsPage.Map.KendoGrid.GridContainsText(EventsConstants.ValidForAllCoursesText);

            this.EventsService.RemoveItem(EventsConstants.ValidDescription);

            Assert.IsTrue(isEventAdded);
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(644)]
        public void AddNewEventWithSameDetailsMoreThanOnceDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.EventsService.EventsPage.Navigate();
            this.EventsService.AddItemForSpecificCourse(EventsConstants.ValidDescription);
            this.Browser.RefreshDomTree();
            this.EventsService.AddItemForSpecificCourse(EventsConstants.ValidDescription);

            this.EventsService.EventsPage.Map.CourseInstanceValidationMessage.AssertIsVisible();
        }
    }
}