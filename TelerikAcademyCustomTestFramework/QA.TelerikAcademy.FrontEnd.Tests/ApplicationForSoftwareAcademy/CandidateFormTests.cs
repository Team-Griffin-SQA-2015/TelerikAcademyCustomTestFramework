namespace QA.TelerikAcademy.FrontEnd.Tests.ApplicationForSoftwareAcademy
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

    #endregion

    [TestClass]
    public class CandidateFormTests : BaseTest
    {
        private User currentUser;

        public CandidateFormService CandidateFormService { get; set; }

        public override void TestInit()
        {
            this.currentUser = new TestUser();
            this.CandidateFormService = new CandidateFormService();
        }

        public override void TestCleanUp()
        {
            AcademyLoginProvider.Instance.Logout();
            Manager.Current.ActiveBrowser.Close();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(760)]
        public void CandidateWithValidDetailsShouldSubmitCandidacy()
        {
            var candidate = CandidateFactory.Get(CandidateType.Valid);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            // TODO: Assert successfull message is shown
            Assert.Fail();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(827)]
        public void CandidateWithoutCheckingAcceptTermsShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.UncheckedSearchedTerms);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.AcceptTermsValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(813)]
        public void CandidateWithUnchosenPictureShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.UnchosenPicture);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.PictureValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(815)]
        public void CandidateWithUnselectedWorkEducationStatusShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.UnselectedWorkEducationStatus);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.WorkEducationStatusIdValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(816)]
        public void CandidateWithEmptyBirthdayShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.EmptyBirthday);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.BirthDayValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(817)]
        public void CandidateWithBirthdayInThePastShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.BirthdayInThePast);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.BirthDayValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(818)]
        public void CandidateWithBirthdayInTheFutureShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.BirthdayInTheFuture);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.BirthDayValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(819)]
        public void CandidateWithEmptyEmailAddressShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.EmptyEmail);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.EmailValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(820)]
        public void CandidateWithInvalidEmailAddressShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.InvalidEmail);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.EmailValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(821)]
        public void CandidateWithInvalidPhoneNumberShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.InvalidPhoneNumber);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.PhoneValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(822)]
        public void CandidateWithUnchosenCityShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.UnchosenCity);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.CityValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(823)]
        public void CandidateWithUnchosenUniversityShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.UnchosenCity);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.UniversityValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(824)]
        public void CandidateWithEmptySchoolShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.EmptySchool);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.SchoolValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(825)]
        public void CandidateWithoutCvShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.UnchosenCv);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.CvValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.EmiliyaGeorgieva)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(826)]
        public void CandidateWithoutCoverLetterShouldDisplayErrorMessage()
        {
            var candidate = CandidateFactory.Get(CandidateType.UnchosenCoverLetter);

            this.CandidateFormService.Candidate(this.currentUser, candidate);

            this.CandidateFormService.CandidateFormPage.Validator.CoverLetterValidationMessageIsShown();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(765)]
        public void VerifyThatEntering4LatinLettersFirstNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.FirstName.Text = FirstNameEnConstants.DefaultFirstNameEn;
            this.CandidateFormService.CandidateFormPage.Map.SecondName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.FirstNameValidationError.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(766)]
        public void VerifyThatEntering4LatinLettersSecondNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.SecondName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.SecondName.Text = FirstNameEnConstants.DefaultFirstNameEn;
            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.SecondNameValidationError.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(808)]
        public void VerifyThatEntering4LatinLettersLastNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.LastName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.LastName.Text = LastNameEnConstants.DefaultLastNameEn;
            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.LastNameValidationError.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(767)]
        public void VerifyThatEntering31CyrillicLettersFirstNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.FirstName.Text =
                FirstNameConstants.InvalidFirstNameWithLengthAboveUpperLimit;
            this.CandidateFormService.CandidateFormPage.Map.SecondName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.FirstNameValidationError.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(768)]
        public void VerifyThatEntering31CyrillicLettersSecondNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.SecondName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.SecondName.Text =
                FirstNameConstants.InvalidFirstNameWithLengthAboveUpperLimit;
            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.SecondNameValidationError.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(809)]
        public void VerifyThatEntering31CyrillicLettersLastNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.LastName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.LastName.Text =
                LastNameConstants.InvalidLastNameWithLengthAboveUpperLimit;
            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.LastNameValidationError.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(805)]
        public void VerifyThatEnteringFirstNameContainingInvalidSpecialCharactersDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.FirstName.Text =
                FirstNameConstants.InvalidFirstNameWithSpecialCharacters;
            this.CandidateFormService.CandidateFormPage.Map.SecondName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.FirstNameValidationError.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(806)]
        public void VerifyThatEnteringSecondNameContainingInvalidSpecialCharactersDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.SecondName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.SecondName.Text =
                FirstNameConstants.InvalidFirstNameWithSpecialCharacters;
            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.SecondNameValidationError.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(810)]
        public void VerifyThatEnteringLastNameContainingInvalidSpecialCharactersDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.LastName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.LastName.Text =
                LastNameConstants.InvalidFirstNameWithSpecialCharacters;
            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.LastNameValidationError.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.ApplicationForTelerikAcademy)]
        [TestCaseId(807)]
        public void VerifyThatEntering1CyrillicLetterLastNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);

            this.CandidateFormService.CandidateFormPage.Navigate();

            this.CandidateFormService.CandidateFormPage.Map.LastName.MouseClick(MouseClickType.LeftDoubleClick);
            this.CandidateFormService.CandidateFormPage.Map.LastName.Text =
                LastNameConstants.InvalidLastNameWithLengthUnderLowerLimit;
            this.CandidateFormService.CandidateFormPage.Map.FirstName.MouseClick(MouseClickType.LeftDoubleClick);

            this.CandidateFormService.CandidateFormPage.Map.LastNameValidationError.AssertIsVisible();
        }
    }
}