namespace QA.TelerikAcademy.Core.Pages.CandidateFormPage
{
    #region using directives

    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    #endregion

    public class CandidateFormPageValidator
    {
        public CandidateFormPageMap Map => new CandidateFormPageMap();

        public void ValidateCandidateFormH1Tag()
        {
            this.Map.CandidateFormH1Tag.Wait.ForExists();
            this.Map.CandidateFormH1Tag.AssertIsPresent();
        }

        public void AcceptTermsValidationMessageIsShown()
        {
            this.Map.AcceptTermsValidationMessage.AssertIsVisible();
        }

        public void PictureValidationMessageIsShown()
        {
            this.Map.PictureValidationMessage.AssertIsVisible();
        }

        public void WorkEducationStatusIdValidationMessageIsShown()
        {
            this.Map.WorkEducationStatusIdValidationMessage.AssertIsVisible();
        }

        public void BirthDayValidationMessageIsShown()
        {
            this.Map.BirthdayValidationMessage.AssertIsVisible();
        }

        public void EmailValidationMessageIsShown()
        {
            this.Map.EmailValidationMessage.AssertIsVisible();
        }

        public void PhoneValidationMessageIsShown()
        {
            this.Map.PhoneValidationMessage.AssertIsVisible();
        }

        public void CityValidationMessageIsShown()
        {
            this.Map.CityValidationMessage.AssertIsVisible();
        }

        public void UniversityValidationMessageIsShown()
        {
            this.Map.UniversityValidationMessage.AssertIsVisible();
        }

        public void SchoolValidationMessageIsShown()
        {
            this.Map.SchoolValidationMessage.AssertIsVisible();
        }

        public void CvValidationMessageIsShown()
        {
            this.Map.CvValidationMessage.AssertIsVisible();
        }

        public void CoverLetterValidationMessageIsShown()
        {
            this.Map.CoverLetterValidationMessage.AssertIsVisible();
        }
    }
}