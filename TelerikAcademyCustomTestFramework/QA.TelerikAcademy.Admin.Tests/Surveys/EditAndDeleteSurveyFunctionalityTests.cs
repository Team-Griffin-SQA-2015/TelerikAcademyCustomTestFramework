namespace QA.TelerikAcademy.Admin.Tests.Surveys
{
    #region using directives

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
    public class EditAndDeleteSurveyFunctionalityTests : BaseTest
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
        public void EditingSurveyWithValidNewNameValueShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            var surveyNameInitialValue =
                this.SurveysService.SurveysPage.Map.KendoGrid.GetCellContentAsString(0, 2);
            var testEditingSurvey = SurveysFactory.Get(SurveyType.ValidEdited);
            this.SurveysService.EditSurvey(testSurvey, testEditingSurvey);
            var surveyNameEditedValue =
                this.SurveysService.SurveysPage.Map.KendoGrid.GetCellContentAsString(0, 2);
            Assert.AreNotEqual(surveyNameInitialValue, surveyNameEditedValue);
            Assert.AreEqual(surveyNameEditedValue, testEditingSurvey.Name);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void EditingSurveyWithValidActiveFromValueShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            var surveyActiveFromInitialValue =
                this.SurveysService.SurveysPage.Map.KendoGrid.GetCellContentAsString(0, 4);
            var testEditingSurvey = SurveysFactory.Get(SurveyType.ValidEdited);
            this.SurveysService.EditSurvey(testSurvey, testEditingSurvey);
            var surveyActiveFromEditedValue =
                this.SurveysService.SurveysPage.Map.KendoGrid.GetCellContentAsString(0, 4);
            Assert.AreNotEqual(surveyActiveFromInitialValue, SurveysConstants.ValidResultEditedActiveFromDateAndTime);
            Assert.AreEqual(surveyActiveFromEditedValue, SurveysConstants.ValidResultEditedActiveFromDateAndTime);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void EditingSurveyWithValidActiveToValueShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            this.SurveysService.AddSurvey(testSurvey);
            var surveyActiveToInitialValue =
                this.SurveysService.SurveysPage.Map.KendoGrid.GetCellContentAsString(0, 5);
            var testEditingSurvey = SurveysFactory.Get(SurveyType.ValidEdited);
            this.SurveysService.EditSurvey(testSurvey, testEditingSurvey);
            var surveyActiveToEditedValue =
                this.SurveysService.SurveysPage.Map.KendoGrid.GetCellContentAsString(0, 5);
            Assert.AreNotEqual(surveyActiveToInitialValue, SurveysConstants.ValidResultEditedActiveToDateAndTime);
            Assert.AreEqual(surveyActiveToEditedValue, SurveysConstants.ValidResultEditedActiveToDateAndTime);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void DeletingSurveyShouldSucceed()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.SurveysService.SurveysPage.Navigate();
            Manager.Current.ActiveBrowser.WaitForExists("DataGrid".IdEqualTo());
            var testSurvey = SurveysFactory.Get(SurveyType.Valid);
            var initialCountOfElements = this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count;
            this.SurveysService.AddSurvey(testSurvey);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            Assert.AreEqual(this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count,
                initialCountOfElements + 1);
            this.SurveysService.DeleteSurvey(testSurvey);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            Assert.AreEqual(this.SurveysService.SurveysPage.Map.KendoGrid.DataItems.Count,
                initialCountOfElements);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void EditingSurveyQuestionWithValidNewTextValueShouldSucceed()
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
            ExecutionDelayProvider.SleepFor(2000);
            var editingQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.ValidTextArea);
            this.SurveysService.EditSurveyQuestion(testQuestion, editingQuestion);
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var questionNewText = this.SurveysService.SurveysPage.Map.QuestionKendoGrid.GetCellContentAsString(0, 2);
            Assert.AreEqual(questionNewText, editingQuestion.Text);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void EditingSurveyQuestionWithValidNewTypeValueShouldSucceed()
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
            ExecutionDelayProvider.SleepFor(2000);
            var editingQuestion = SurveyQuestionFactory.Get(SurveyQuestionType.ValidTextArea);
            this.SurveysService.EditSurveyQuestion(testQuestion, editingQuestion);
            var typeAsText =
                this.SurveysService.SurveysPage.Map.AllQuestionTypeList[editingQuestion.TypeIndex].InnerText;
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            var questionNewType = this.SurveysService.SurveysPage.Map.QuestionKendoGrid.GetCellContentAsString(0, 3);
            Assert.AreEqual(questionNewType, typeAsText);
        }

        [TestMethod]
        [Owner(Owners.NikolaBogomirov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void DeletingSurveyQuestionShouldSucceed()
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
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysService.DeleteSurveyQuestion(testQuestion);
            this.Browser.RefreshDomTree();
            Assert.AreEqual(this.SurveysService.SurveysPage.Map.QuestionKendoGrid.DataItems.Count, 0);
        }
    }
}