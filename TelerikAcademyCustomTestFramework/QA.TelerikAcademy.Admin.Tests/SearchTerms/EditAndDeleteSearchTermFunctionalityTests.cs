namespace QA.TelerikAcademy.Admin.Tests.SearchTerms
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Core.Constants.Attributes;
    using Core.Enumerations;
    using Core.Facades;
    using Core.Factories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    [TestClass]
    public class EditAndDeleteSearchTermFunctionalityTests : BaseTest
    {
        private User currentuser;

        public SearchTermsService SearchTermsService { get; set; }

        [TestInitialize]
        public override void TestInit()
        {
            this.SearchTermsService = new SearchTermsService();
            this.currentuser = new TestUser();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            AcademyLoginProvider.Instance.Logout();
            Manager.Current.ActiveBrowser.Close();
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void RemovingSearchTermShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());

            var initialDataItemsCount = this.SearchTermsService.SearchTermsPage.Map.SearchTermsGrid.DataItems.Count;
            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.Valid);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            this.Browser.RefreshDomTree();
            Assert.AreEqual(this.SearchTermsService.SearchTermsPage.Map.SearchTermsGrid.DataItems.Count,
                initialDataItemsCount + 1);

            this.SearchTermsService.RemoveSearchTerm(testSearchTerm);
            this.Browser.RefreshDomTree();
            Assert.AreEqual(this.SearchTermsService.SearchTermsPage.Map.SearchTermsGrid.DataItems.Count,
                initialDataItemsCount);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void UpdatingWordFieldWithNewValueShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());
            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.Valid);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            var searchTermWordInitialValue =
                this.SearchTermsService.SearchTermsPage.Map.SearchTermsGrid.GetCellContentAsString(0, 1);

            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var editingSearchTerm = SearchTermsFactory.Get(SearchTermType.ValidEditingSearchTerm);
            this.SearchTermsService.EditSearchTerm(testSearchTerm, editingSearchTerm);
            this.Browser.RefreshDomTree();

            var searchTermWordEditedValue =
                this.SearchTermsService.SearchTermsPage.Map.SearchTermsGrid.GetCellContentAsString(0, 1);
            this.SearchTermsService.RemoveSearchTerm(editingSearchTerm);
            Assert.AreNotEqual(searchTermWordInitialValue, searchTermWordEditedValue);
            Assert.AreEqual(searchTermWordEditedValue, editingSearchTerm.Word);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void UpdatingCountFieldWithNewValueShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());
            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.Valid);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            var searchTermCountInitialValue =
                this.SearchTermsService.SearchTermsPage.Map.SearchTermsGrid.GetCellContentAsString(0, 2);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);

            var editingSearchTerm = SearchTermsFactory.Get(SearchTermType.ValidEditingSearchTerm);
            this.SearchTermsService.EditSearchTerm(testSearchTerm, editingSearchTerm);
            this.Browser.RefreshDomTree();

            var searchTermCountEditedValue =
                this.SearchTermsService.SearchTermsPage.Map.SearchTermsGrid.GetCellContentAsString(0, 2);
            this.SearchTermsService.RemoveSearchTerm(editingSearchTerm);
            Assert.AreNotEqual(searchTermCountInitialValue, searchTermCountEditedValue);
            Assert.AreEqual(searchTermCountEditedValue, editingSearchTerm.Count);
        }
    }
}