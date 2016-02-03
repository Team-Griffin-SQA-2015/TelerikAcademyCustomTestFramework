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
    public class DeleteEventTests : BaseTest
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
        [TestCaseId(655)]
        public void AddingAnEventAndCLickingItsDeleteButtonRemovesTheEventFromTheList()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.EventsService.EventsPage.Navigate();

            this.EventsService.AddItemForSpecificCourse(EventsConstants.ValidDescription);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsService.RemoveItem(EventsConstants.ValidDescription);

            Assert.IsFalse(this.EventsService.EventsPage.Map.KendoGrid.GridContainsText(EventsConstants.ValidDescription));
        }
    }
}