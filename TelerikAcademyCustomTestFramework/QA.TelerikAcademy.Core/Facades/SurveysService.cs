namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #region using directives

    using Pages.LoginPage;
    using Pages.SurveysPage;

    using System.Windows.Forms;

    using TestingFramework.Core.Data;
    using TestingFramework.Core.Providers;
    using TestingFramework.Core.Extensions;

    #endregion

    #endregion

    public class SurveysService
    {
        public SurveysService()
        {
            this.LoginPage = new LoginPage();
            this.SurveysPage = new SurveysPage();
        }

        public LoginPage LoginPage { get; set; }

        public SurveysPage SurveysPage { get; set; }

        public void AddSurvey(Survey survey)
        {
            this.SurveysPage.Map.AddItemButton.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysPage.Map.Name.MouseClick();
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(survey.Name);
            this.SurveysPage.Map.ActiveFrom.MouseClick();
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(survey.ActiveFrom);
            this.SurveysPage.Map.Name.MouseClick();
            this.SurveysPage.Map.ActiveTo.MouseClick();
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(survey.ActiveTo);
            this.SurveysPage.Map.Name.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            this.SurveysPage.Map.UpdateItemButton.MouseClick();
        }

        public void EditSurvey(Survey surveyToEdit, Survey editingSurvey)
        {
            var rowIndexOfItemToEdit = this.SurveysPage.Map.KendoGrid.IndexOfGridRowContainingText(surveyToEdit.Name);
            this.SurveysPage.Map.AllEditEntryButtons[rowIndexOfItemToEdit].MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysPage.Map.Name.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(editingSurvey.Name);
            this.SurveysPage.Map.ActiveFromLabel.MouseClick();
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(editingSurvey.ActiveFrom);
            this.SurveysPage.Map.Name.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysPage.Map.ActiveToLabel.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(editingSurvey.ActiveTo);
            this.SurveysPage.Map.Name.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            this.SurveysPage.Map.UpdateItemButton.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
        }

        public void DeleteSurvey(Survey survey)
        {
            var rowIndexOfItemToDelete = this.SurveysPage.Map.KendoGrid.IndexOfGridRowContainingText(survey.Name);
            this.SurveysPage.Map.AllDeleteEntryButtons[rowIndexOfItemToDelete].MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Enter);
            ExecutionDelayProvider.SleepFor(2000);
        }

        public void AddSurveyQuestion(SurveyQuestion question, Survey survey)
        {
            var indexOfSurvey = this.SurveysPage.Map.KendoGrid.IndexOfGridRowContainingText(survey.Name);
            this.SurveysPage.Map.AllEpandForQuestionsButtons[indexOfSurvey].MouseClick();
            Manager.Current.ActiveBrowser.WaitForElement(3000, "class=k-detail-cell");
            ExecutionDelayProvider.SleepFor(5000);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            this.SurveysPage.Map.AddQuestionButtons[1].MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysPage.Map.QuestionTypeLabel.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysPage.Map.AllQuestionTypeList[question.TypeIndex].MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysPage.Map.QuestionText.MouseClick();
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(question.Text);
            this.SurveysPage.Map.QuestionUpdateButton.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
        }

        public void EditSurveyQuestion(SurveyQuestion questionToEdit, SurveyQuestion editingQuestion)
        {
            var rowIndexOfItemToEdit =
                this.SurveysPage.Map.QuestionKendoGrid.IndexOfGridRowContainingText(questionToEdit.Text);
            this.SurveysPage.Map.AllEditEntryButtons[rowIndexOfItemToEdit + 1].ScrollToVisible();
            this.SurveysPage.Map.AllEditEntryButtons[rowIndexOfItemToEdit + 1].MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysPage.Map.QuestionTypeLabel.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysPage.Map.AllQuestionTypeList[editingQuestion.TypeIndex].MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SurveysPage.Map.QuestionText.MouseClick();
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back, 1000, 18);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(editingQuestion.Text);
            this.SurveysPage.Map.QuestionUpdateButton.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
        }

        public void DeleteSurveyQuestion(SurveyQuestion question)
        {
            var rowIndexOfItemToDelete =
                this.SurveysPage.Map.QuestionKendoGrid.IndexOfGridRowContainingText(question.Text);
            this.SurveysPage.Map.AllDeleteEntryButtons[rowIndexOfItemToDelete + 1].ScrollToVisible();
            this.SurveysPage.Map.AllDeleteEntryButtons[rowIndexOfItemToDelete + 1].MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Enter);
            ExecutionDelayProvider.SleepFor(2000);
        }
    }
}