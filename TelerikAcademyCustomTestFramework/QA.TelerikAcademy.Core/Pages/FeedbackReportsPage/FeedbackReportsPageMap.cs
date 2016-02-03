namespace QA.TelerikAcademy.Core.Pages.FeedbackReportsPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    using TestingFramework.Core.Base;

    #endregion

    public class FeedbackReportsPageMap : BaseKendoGridPageMap
    {
        public KendoGrid FeedbackReportsKendoGrid => this.Find.ById<KendoGrid>("DataGrid");

        public HtmlAnchor KendoGridEditButton
            => this.FeedbackReportsKendoGrid.DataItems[0].Cells[8].ChildNodes[0].As<HtmlAnchor>();

        public HtmlAnchor KendoGridDeleteButton
            => this.FeedbackReportsKendoGrid.DataItems[0].Cells[9].ChildNodes[0].As<HtmlAnchor>();

        public HtmlDiv KendoWindowEditor => this.Find.ByExpression<HtmlDiv>("class=~k-window");

        public HtmlTextArea KendoWindowEditorContent => this.Find.ById<HtmlTextArea>("Content");

        public HtmlAnchor KendoWindowEditorUpdateButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-update");
    }
}