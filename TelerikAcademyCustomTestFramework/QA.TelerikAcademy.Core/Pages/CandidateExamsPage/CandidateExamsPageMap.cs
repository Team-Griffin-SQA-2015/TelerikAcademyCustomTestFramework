namespace QA.TelerikAcademy.Core.Pages.CandidateExamsPage
{
    #region using directives

    using System.Collections.ObjectModel;
    using System.Linq;

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Extensions;

    #endregion

    public class CandidateExamsPageMap : BaseElementMap
    {
        public readonly string[] HeadingFindExpressions =
        {
            "tagname=h1",
            "Входни изпити за софтуерната академия".TextContentContaining()
        };

        public HtmlControl Heading => this.Find.ByExpression<HtmlControl>(this.HeadingFindExpressions);

        public HtmlAnchor AddNewCandidateExam => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-add");

        public HtmlAnchor UpdateCandidateExam => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-update");

        public HtmlAnchor CancelCandidateExamChanges => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-cancel");

        //public HtmlSelect IQTestConfigurationIdSelect => this.Find.ById<HtmlSelect>("IQTestConfigurationId");
        //public HtmlDiv IQTestDiv => this.Find.ById<HtmlDiv>("IQTestConfigurationId-list");
        //public HtmlUnorderedList IQTestList => this.IQTestDiv.Find.ById<HtmlUnorderedList>("IQTestConfigurationId_listbox");
        public HtmlUnorderedList IqTestConfigurationIdList
            => this.Find.ById<HtmlUnorderedList>("IQTestConfigurationId_listbox");

        //public HtmlSelect ITTestConfigurationIdSelect => this.Find.ById<HtmlSelect>("ITTestConfigurationId");
        public HtmlUnorderedList ItTestConfigurationIdList
            => this.Find.ById<HtmlUnorderedList>("ITTestConfigurationId_listbox");

        //public HtmlSelect EnglishTestConfigurationIdSelect => this.Find.ById<HtmlSelect>("EnglishTestConfigurationId");
        public HtmlUnorderedList EnglishTestConfigurationIdList
            => this.Find.ById<HtmlUnorderedList>("EnglishTestConfigurationId_listbox");

        public HtmlInputText StartTime => this.Find.ById<HtmlInputText>("StartTime");

        public HtmlInputText EndTime => this.Find.ById<HtmlInputText>("EndTime");

        //public HtmlSelect TrainingRoomSelect => this.Find.ById<HtmlSelect>("TrainingRoomId");
        public HtmlUnorderedList TrainingRoomList => this.Find.ById<HtmlUnorderedList>("TrainingRoomId_listbox");

        public HtmlInputText AllowedIp => this.Find.ById<HtmlInputText>("AllowedIp");

        public HtmlInputNumber CandidatesCountLimit => this.Find.ById<HtmlInputNumber>("CandidatesCountLimit");

        public HtmlDiv IqTestConfigurationIdValidationMessage
            => this.Find.ById<HtmlDiv>("IQTestConfigurationId_validationMessage");

        public HtmlDiv ItTestConfigurationIdValidationMessage
            => this.Find.ById<HtmlDiv>("ITTestConfigurationId_validationMessage");

        public HtmlDiv EnglishTestConfigurationIdValidationMessage
            => this.Find.ById<HtmlDiv>("EnglishTestConfigurationId_validationMessage");

        public HtmlDiv TrainingRoomValidationMessage => this.Find.ById<HtmlDiv>("TrainingRoomId_validationMessage");

        public HtmlDiv CandidatesCountLimitValidationMessage
            => this.Find.ById<HtmlDiv>("CandidatesCountLimit_validationMessage");

        public HtmlDiv CandidateExamsGrid => this.Find.ById<HtmlDiv>("DataGrid");

        public ReadOnlyCollection<HtmlTableRow> CandidateExamsGridRows
            => this.CandidateExamsGrid.Find.AllByExpression<HtmlTableRow>("tagName=tr", "class=~k-master-row");

        public HtmlTableRow CandidateExamsGridFirstRow => this.CandidateExamsGridRows.FirstOrDefault();

        public ReadOnlyCollection<HtmlTableCell> CandidateExamsGridFirstRowData
            => this.CandidateExamsGridFirstRow.Find.AllByExpression<HtmlTableCell>("tagName=td", "role=gridcell");

        public HtmlListItem SelectListItem(HtmlUnorderedList list, string partialText)
        {
            var itemToSelect = list.Find.ByExpression<HtmlListItem>(partialText.TextContentContaining());
            return itemToSelect;
        }
    }
}