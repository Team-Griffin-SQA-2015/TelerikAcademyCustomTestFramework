namespace QA.TelerikAcademy.Core.Pages.CandidateExamsPage
{
    #region using directives

    using System.Collections.ObjectModel;
    using System.Linq;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;

    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;

    #endregion

    public class CandidateExamsPageValidator
    {
        public CandidateExamsPageMap Map => new CandidateExamsPageMap();

        public void CandidateExamPageLoaded()
        {
            Manager.Current.ActiveBrowser.WaitForExists(this.Map.HeadingFindExpressions);
            this.Map.Heading.AssertIsPresent();
        }

        public void ValidateErrorMessageIqTestConfiguration()
        {
            this.Map.IqTestConfigurationIdValidationMessage.AssertIsVisible();
        }

        public bool CandidateExamAdded(ReadOnlyCollection<HtmlTableCell> candidateExamsGridFirstRowData,
            CandidateExam candidateExam)
        {
            var isCandidateCountSame =
                candidateExamsGridFirstRowData.Any(d => d.InnerText == candidateExam.CandidatesCountLimit);
            var isStartDateSame = candidateExamsGridFirstRowData.Any(d => d.InnerText == candidateExam.StartTime);
            var isTrainingRoomSame = candidateExamsGridFirstRowData.Any(d => d.InnerText == candidateExam.TrainingRoom);

            var isCandidateExamAdded = isCandidateCountSame && isStartDateSame && isTrainingRoomSame;

            return isCandidateExamAdded;
        }

        public void ValidateErrorMessageItTestConfiguration()
        {
            this.Map.ItTestConfigurationIdValidationMessage.AssertIsVisible();
        }

        public void ValidateErrorMessageEnglishTestConfiguration()
        {
            this.Map.EnglishTestConfigurationIdValidationMessage.AssertIsVisible();
        }
    }
}