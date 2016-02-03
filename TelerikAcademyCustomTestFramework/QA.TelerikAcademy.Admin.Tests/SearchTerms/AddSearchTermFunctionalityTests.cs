namespace QA.TelerikAcademy.Admin.Tests.SearchTerms
{
    #region using directives

    using System;

    using ArtOfTest.WebAii.Core;

    using Core.Constants.Attributes;
    using Core.Constants.Pages;
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
    public class AddSearchTermFunctionalityTests : BaseTest
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
        public void AddingSearchTermWithValidFieldsShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());
            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.Valid);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);

            var isSearchTermAdded =
                this.SearchTermsService.SearchTermsPage.Map.SearchTermsGrid.GridContainsText(
                    SearchTermsConstants.ValidWord);

            this.SearchTermsService.RemoveSearchTerm(testSearchTerm);

            Assert.IsTrue(isSearchTermAdded);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingSearchTermWithEmptyWordFieldShouldDisplayAnErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());
            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.InvalidWithEmptyWordField);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            this.SearchTermsService.SearchTermsPage.Map.WordValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingSearchTermWithEmptyCountFieldShouldDisplayAnErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());
            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.InvalidWithEmptyCountField);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SearchTermsService.SearchTermsPage.Map.CountValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingSearchTermWithInvalidWordFieldWithHigherLengthShouldDisplayAnErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());
            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.InvalidWithHigherWordLength);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.SearchTermsService.SearchTermsPage.Map.WordValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingSearchTermWithInvalidCountFieldWithNegativeValueShouldDisplayAnErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());

            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.InvalidWithNegativeCountValue);

            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            var isMessageDispayed = true;
            try
            {
                this.SearchTermsService.SearchTermsPage.Map.CountValidationMessage.AssertIsVisible();
            }
            catch (NullReferenceException)
            {
                isMessageDispayed = false;
            }
            this.SearchTermsService.RemoveSearchTerm(testSearchTerm);
            Assert.IsTrue(isMessageDispayed);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingSearchTermWithTextInCountFieldShouldDisplayAnErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());
            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.InvalidWithTextAsCountValue);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            this.SearchTermsService.SearchTermsPage.Map.CountValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingSearchTermWithLargeNumberInCountFieldShouldDisplayAnErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());

            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.InvalidWithLargeNumberCountValue);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.SearchTermsService.SearchTermsPage.Map.CountValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingAlreadyExistingSearchTermShouldDisplayError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.SearchTermsService.SearchTermsPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());

            var testSearchTerm = SearchTermsFactory.Get(SearchTermType.Valid);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);

            var isSearchTermAdded =
                this.SearchTermsService.SearchTermsPage.Map.SearchTermsGrid.GridContainsText(
                    SearchTermsConstants.ValidWord);

            Assert.IsTrue(isSearchTermAdded);

            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            this.SearchTermsService.AddSearchTerm(testSearchTerm);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            this.SearchTermsService.SearchTermsPage.Map.WordValidationMessage.AssertIsVisible();
            this.SearchTermsService.SearchTermsPage.Map.CancelChangesToItemButton.Click();
            ExecutionDelayProvider.SleepFor(3000);
            this.SearchTermsService.RemoveSearchTerm(testSearchTerm);
        }
    }
}