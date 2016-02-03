namespace QA.TelerikAcademy.Core.Pages.SurveysPage
{
    #region using directives

    using System.Collections.Generic;

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    using TestingFramework.Core.Base;

    #endregion

    public class SurveysPageMap : BaseKendoGridPageMap
    {
        public HtmlInputText Name => this.Find.ById<HtmlInputText>("Name");

        public HtmlInputControl ActiveFrom => this.Find.ById<HtmlInputControl>("ActiveFrom");

        public HtmlControl ActiveFromLabel
            => this.Find.ByExpression<HtmlControl>("for=ActiveFrom");

        public HtmlInputControl ActiveTo => this.Find.ById<HtmlInputControl>("ActiveTo");

        public HtmlControl ActiveToLabel => this.Find.ByExpression<HtmlControl>("for=ActiveTo");

        public IList<HtmlAnchor> AllEpandForQuestionsButtons
            => this.Find.AllByExpression<HtmlAnchor>("class=k-icon k-plus");

        public HtmlTableCell DetailCell => this.Find.ByExpression<HtmlTableCell>("class=k-detail-cell");

        public KendoGrid QuestionKendoGrid => this.Find.ByExpression<KendoGrid>("id=~SurveyQuestions");

        public IList<HtmlAnchor> AddQuestionButtons => this.Find.AllByExpression<HtmlAnchor>("class=~k-grid-add");

        //  public IList<HtmlAnchor> EditQuestionButtons => this.Find.AllByExpression<HtmlAnchor>("class=~k-grid-edit");
        //
        //  public IList<HtmlAnchor> DeleteQuestionButtons => this.Find.AllByExpression<HtmlAnchor>("class=~k-grid-delete");

        public HtmlControl QuestionTypeLabel => this.Find.ByExpression<HtmlControl>("for=QuestionType");

        public HtmlUnorderedList QuestionTypeList => this.Find.ById<HtmlUnorderedList>("QuestionType_listbox");

        public IList<HtmlListItem> AllQuestionTypeList => this.Find.AllByExpression<HtmlListItem>("role=option");

        public HtmlTextArea QuestionText => this.Find.ById<HtmlTextArea>("QuestionText");

        public HtmlAnchor QuestionUpdateButton
            => this.Find.ByExpression<HtmlAnchor>("class=k-button k-button-icontext k-primary k-grid-update");

        public HtmlAnchor QuestionCancelButton
            => this.Find.ByExpression<HtmlAnchor>("class=k-button k-button-icontext k-grid-cancel");

        public HtmlDiv QuestionTypeValidationMessage => this.Find.ById<HtmlDiv>("QuestionType_validationMessage");

        public HtmlDiv QuestionTextValidationMessage => this.Find.ById<HtmlDiv>("QuestionText_validationMessage");
    }
}