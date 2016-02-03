namespace QA.TelerikAcademy.Admin.Tests.Surveys
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
    public class AddSurveyFunctionalityTests : BaseTest
    {
        private User currentuser;

        public SurveysService SurveysService { get; set; }

        [TestInitialize]
        public override void TestInit()
        {
            this.SurveysService = new SurveysService();
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
        public void AddingSurveyWithValidNameAndActiveFromAndToFieldsShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);

            this.SurveysService.AddSurvey(testSurvey);

            var isSurveyAdded =
                this.SurveysService.SurveysPage.Map.KendoGrid.GridContainsText(testSurvey.Name);

            Assert.IsTrue(isSurveyAdded);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingAlreadyExistingSurveyShouldFail()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            var initialElementCount = this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count;

            this.SurveysService.AddSurvey(testSurvey);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            Assert.AreEqual(initialElementCount + 1, this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count);
            this.SurveysService.AddSurvey(testSurvey);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            Assert.AreNotEqual(initialElementCount + 2, this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingSurveyWithEmptyNameShouldFail()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var initialElementCount = this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count;
            var testSurvey = SurveysFactory.Get(SurveyType.InvalidWithEmptyName);

            this.SurveysService.AddSurvey(testSurvey);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            var isSurveyAdded = initialElementCount + 1 == this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count;
            isSurveyAdded = isSurveyAdded && !this.SurveysService.SurveysPage.Map.Name.IsVisible();
            Assert.IsFalse(isSurveyAdded);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingSurveyWithTooPastActiveFromShouldFail()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var initialElementCount = this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count;
            var testSurvey = SurveysFactory.Get(SurveyType.InvalidWithTooPastActiveFrom);

            this.SurveysService.AddSurvey(testSurvey);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            var isSurveyAdded = initialElementCount + 1 == this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count;
            isSurveyAdded = isSurveyAdded && !this.SurveysService.SurveysPage.Map.Name.IsVisible();
            Assert.IsFalse(isSurveyAdded);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingSurveyWithTooFutureActiveFromShouldFail()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var initialElementCount = this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count;
            var testSurvey = SurveysFactory.Get(SurveyType.InvalidWithTooFutureActiveFrom);

            this.SurveysService.AddSurvey(testSurvey);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            var isSurveyAdded = initialElementCount + 1 == this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count;
            isSurveyAdded = isSurveyAdded && !this.SurveysService.SurveysPage.Map.Name.IsVisible();
            Assert.IsFalse(isSurveyAdded);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingValidSurveyTextQuestionShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var testQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.ValidText);
            this.SurveysService.AddSurveyQuestion(testQuestion, testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var questionsCount = this.SurveysService.SurveysPage.Map.QuestionKendoGrid.DataItems.Count;
            Assert.AreEqual(questionsCount, 1);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingValidSurveyTextAreaQuestionShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var testQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.ValidTextArea);
            this.SurveysService.AddSurveyQuestion(testQuestion, testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var questionsCount = this.SurveysService.SurveysPage.Map.QuestionKendoGrid.DataItems.Count;
            Assert.AreEqual(questionsCount, 1);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingValidSurveyRadioQuestionShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var testQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.ValidRadio);
            this.SurveysService.AddSurveyQuestion(testQuestion, testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var questionsCount = this.SurveysService.SurveysPage.Map.QuestionKendoGrid.DataItems.Count;
            Assert.AreEqual(questionsCount, 1);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingValidSurveyCheckBoxQuestionShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var testQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.ValidCheckbox);
            this.SurveysService.AddSurveyQuestion(testQuestion, testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var questionsCount = this.SurveysService.SurveysPage.Map.QuestionKendoGrid.DataItems.Count;
            Assert.AreEqual(questionsCount, 1);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddingValidSurveyWithMaxCharacterBoundaryNumberTextQuestionShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var testQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.ValidWithMaxBoundaryCharactersNumber);
            this.SurveysService.AddSurveyQuestion(testQuestion, testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var questionsCount = this.SurveysService.SurveysPage.Map.QuestionKendoGrid.DataItems.Count;
            Assert.AreEqual(questionsCount, 1);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingInvalidSurveyQuestionWithEmptyTypeShouldDisplayErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var testQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.InvalidWithEmptyType);
            this.SurveysService.AddSurveyQuestion(testQuestion, testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var isMessageDisplayed = this.SurveysService.SurveysPage.Map.QuestionTypeValidationMessage.IsVisible();
            Assert.IsTrue(isMessageDisplayed);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddingInvalidSurveyQuestionWithEmptyTextShouldDisplayErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var testQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.InvalidWithEmptyText);
            this.SurveysService.AddSurveyQuestion(testQuestion, testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var isMessageDisplayed = this.SurveysService.SurveysPage.Map.QuestionTextValidationMessage.IsVisible();
            Assert.IsTrue(isMessageDisplayed);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddingInvalidSurveyQuestionWithHigherCharacterNumberInTextShouldDisplayErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var testQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.InvalidWithHigherCharactersNumber);
            this.SurveysService.AddSurveyQuestion(testQuestion, testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var isMessageDisplayed = this.SurveysService.SurveysPage.Map.QuestionTextValidationMessage.IsVisible();
            Assert.IsTrue(isMessageDisplayed);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddingInvalidSurveyQuestionWithOneCharacterNumberInTextShouldDisplayErrorMessage()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var testQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.InvalidWithOneCharacter);
            this.SurveysService.AddSurveyQuestion(testQuestion, testSurvey);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            var isMessageDisplayed = this.SurveysService.SurveysPage.Map.QuestionTextValidationMessage.IsVisible();
            Assert.IsTrue(isMessageDisplayed);
        }
    }
}