namespace QA.TelerikAcademy.Core.Pages.CandidateFormPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    #region using directives

    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using TestingFramework.Core.Data;

    #endregion

    #endregion

    public class CandidateFormPage
    {
        private const string Url = @"http://stage.telerikacademy.com/SoftwareAcademy/Candidate";

        public CandidateFormPageMap Map => new CandidateFormPageMap();

        public CandidateFormPageValidator Validator => new CandidateFormPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }

        public string GetUrl()
        {
            return Url;
        }

        public void Candidate(Candidate candidate)
        {
            this.Map.FirstName.Text = candidate.FirstName ?? FirstNameConstants.DefaultFirstName;
            this.Map.SecondName.Text = candidate.SecondName ?? SecondNameConstants.DefaultSecondName;
            this.Map.LastName.Text = candidate.LastName ?? LastNameConstants.DefaultLastName;

            if (candidate.Picture != null)
            {
                //TODO: Validate Picture is visible
                this.Map.Picture.Focus();
                this.Map.Picture.Upload(candidate.Picture, 10000);
            }

            if (candidate.IsMaleGender)
            {
                this.Map.MaleGender.Click();
            }
            else
            {
                this.Map.FemaleGender.Click();
            }

            HtmlListItem currentListItem;
            if (candidate.WorkEducationStatusId != null)
            {
                currentListItem = this.Map.SelectListItem(this.Map.WorkEducationStatusId,
                    candidate.WorkEducationStatusId);
                currentListItem.Click();
            }

            if (candidate.Birthday != null)
            {
                this.Map.Birthday.Text = candidate.Birthday;
            }

            this.Map.Email.Text = candidate.Email;

            this.Map.Phone.Text = candidate.Phone;

            if (candidate.City != null)
            {
                currentListItem = this.Map.SelectListItem(this.Map.City, candidate.City);
                currentListItem.Click();
            }

            if (candidate.University != null)
            {
                currentListItem = this.Map.SelectListItem(this.Map.University, candidate.University);
                currentListItem.Click();
            }

            this.Map.Faculty.Text = candidate.Faculty;

            this.Map.Speciality.Text = candidate.Speciality;

            this.Map.School.Text = candidate.School;

            if (candidate.Cv != null)
            {
                //TODO: Validate CV is visible
                this.Map.Cv.Focus();
                this.Map.Cv.Upload(candidate.Cv, 10000);
            }
            if (candidate.CoverLetter != null)
            {
                //TODO: Validate CoverLetter is visible
                this.Map.CoverLetter.Focus();
                this.Map.CoverLetter.Upload(candidate.CoverLetter, 10000);
            }

            if (candidate.AdditionalDocument != null)
            {
                //TODO: Validate AdditionalDocuments is visible
                this.Map.AdditionalDocuments.Focus();
                this.Map.AdditionalDocuments.Upload(candidate.AdditionalDocument, 10000);
            }

            if (candidate.AcceptTerms)
            {
                this.Map.AcceptTerms.Check(true, true);
            }

            this.Map.Submit.Click();
        }
    }
}