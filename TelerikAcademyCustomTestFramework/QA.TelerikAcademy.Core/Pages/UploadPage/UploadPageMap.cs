namespace QA.TelerikAcademy.Core.Pages.UploadPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;

    #endregion

    public class UploadPageMap : BaseElementMap
    {
        public HtmlDiv ChooseFile => this.Find.ByExpression<HtmlDiv>("class=~k-upload-button");

        public HtmlTextArea Description => this.Find.ById<HtmlTextArea>("Description");

        public HtmlInputControl Submit => this.Find.ById<HtmlInputControl>("SendButton");

        public HtmlDiv ValidationSummaryErrors => this.Find.ByExpression<HtmlDiv>("class=~validation-summary-errors");

        public HtmlSpan DescriptionError => this.Find.ById<HtmlSpan>("Description-error");
    }
}