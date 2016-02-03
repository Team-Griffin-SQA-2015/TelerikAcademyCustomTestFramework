namespace QA.TelerikAcademy.Core.Pages.CandidateExamsPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using TestingFramework.Core.Data;

    #endregion

    public class CandidateExamsPage
    {
        public const string Url = @"http://stage.telerikacademy.com/Administration_SoftwareAcademy/CandidateExams";

        public CandidateExamsPageMap Map => new CandidateExamsPageMap();

        public CandidateExamsPageValidator Validator => new CandidateExamsPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }

        public void AddCandidateExam(CandidateExam candidateExam)
        {
            this.Map.AddNewCandidateExam.Click();

            HtmlListItem currentListItem;

            if (candidateExam.IqTestConfiguration != null)
            {
                currentListItem = this.Map.SelectListItem(this.Map.IqTestConfigurationIdList,
                    candidateExam.IqTestConfiguration);
                currentListItem.Click();
            }

            if (candidateExam.ItTestConfiguration != null)
            {
                currentListItem = this.Map.SelectListItem(this.Map.ItTestConfigurationIdList,
                    candidateExam.ItTestConfiguration);
                currentListItem.Click();
            }

            if (candidateExam.EnglishTestConfiguration != null)
            {
                currentListItem = this.Map.SelectListItem(this.Map.EnglishTestConfigurationIdList,
                    candidateExam.EnglishTestConfiguration);
                currentListItem.Click();
            }

            this.Map.StartTime.Text = candidateExam.StartTime ?? CandidateExamConstants.DefaultStartTime;

            this.Map.EndTime.Text = candidateExam.EndTime ?? CandidateExamConstants.DefaultEndTime;

            if (candidateExam.TrainingRoom != null)
            {
                currentListItem = this.Map.SelectListItem(this.Map.TrainingRoomList, candidateExam.TrainingRoom);
                currentListItem.Click();
            }

            this.Map.AllowedIp.Text = candidateExam.AllowedIp ?? CandidateExamConstants.DefaultAllowedIp;

            this.Map.CandidatesCountLimit.Text = candidateExam.CandidatesCountLimit ??
                                                 CandidateExamConstants.DefaultCandidatesCountLimit;
        }

        public void UpdateCandidateExam()
        {
            this.Map.UpdateCandidateExam.Click();
        }

        public void CancelCandidateExamChanges()
        {
            this.Map.CancelCandidateExamChanges.Click();
        }
    }
}