namespace QA.TelerikAcademy.Admin.Tests.CandidateExams
{
    #region using directives

    using Core.Constants.Attributes;
    using Core.Constants.Pages;
    using Core.Facades;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;

    #endregion

    [TestClass]
    public class AddCandidateExamTests : BaseTest
    {
        private User currentUser;

        public CandidateExamsService CandidateExamsService { get; set; }

        public override void TestInit()
        {
            this.CandidateExamsService = new CandidateExamsService();
            this.currentUser = new TestUser();
        }

        public override void TestCleanUp()
        {
            AcademyLoginProvider.Instance.Logout();
            this.Browser.Close();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.SoftwareAcademy)]
        public void AddValidCandidateExam()
        {
            this.CandidateExamsService.AddCandidateExam(this.currentUser, CandidateExamConstants.ValidCandidateExam);
            this.CandidateExamsService.UpdateCandidateExam();

            var isCandidateExamAdded =
                this.CandidateExamsService.CandidateExamsPage.Validator.CandidateExamAdded(
                    this.CandidateExamsService.CandidateExamsPage.Map.CandidateExamsGridFirstRowData,
                    CandidateExamConstants.ValidCandidateExam);

            Assert.IsTrue(isCandidateExamAdded);
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.SoftwareAcademy)]
        public void AddValidCandidateExamAndCancelShouldNotSaveChanges()
        {
            this.CandidateExamsService.AddCandidateExam(this.currentUser, CandidateExamConstants.ValidCandidateExam);
            this.CandidateExamsService.CancelCandidateExamChanges();

            var isCandidateExamAdded =
                this.CandidateExamsService.CandidateExamsPage.Validator.CandidateExamAdded(
                    this.CandidateExamsService.CandidateExamsPage.Map.CandidateExamsGridFirstRowData,
                    CandidateExamConstants.ValidCandidateExam);

            Assert.IsFalse(isCandidateExamAdded);
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.SoftwareAcademy)]
        public void AddingCandidateExamWithoutIqTestConfigurationShouldDisplayAnErrorMessage()
        {
            this.CandidateExamsService.AddCandidateExam(this.currentUser,
                CandidateExamConstants.CandidateExamWithInvalidIqTestConfiguration);
            this.CandidateExamsService.UpdateCandidateExam();
            this.CandidateExamsService.ValidateErrorMessageIqTestConfiguration();

            this.CandidateExamsService.CancelCandidateExamChanges();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.SoftwareAcademy)]
        public void AddingCandidateExamWithoutItTestConfigurationShouldDisplayAnErrorMessage()
        {
            this.CandidateExamsService.AddCandidateExam(this.currentUser,
                CandidateExamConstants.CandidateExamWithInvalidItTestConfiguration);
            this.CandidateExamsService.UpdateCandidateExam();
            this.CandidateExamsService.ValidateErrorMessageItTestConfiguration();

            this.CandidateExamsService.CancelCandidateExamChanges();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.SoftwareAcademy)]
        public void AddingCandidateExamWithoutEnglishTestConfigurationShouldDisplayAnErrorMessage()
        {
            this.CandidateExamsService.AddCandidateExam(this.currentUser,
                CandidateExamConstants.CandidateExamWithInvalidEnglishTestConfiguration);
            this.CandidateExamsService.UpdateCandidateExam();
            this.CandidateExamsService.ValidateErrorMessageEnglishTestConfiguration();

            this.CandidateExamsService.CancelCandidateExamChanges();
        }
    }
}