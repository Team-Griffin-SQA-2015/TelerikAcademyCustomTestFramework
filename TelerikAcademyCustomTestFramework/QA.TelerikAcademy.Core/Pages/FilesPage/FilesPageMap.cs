namespace QA.TelerikAcademy.Core.Pages.FilesPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;

    #endregion

    public class FilesPageMap : BaseElementMap
    {
        public HtmlDiv DataGrid => this.Find.ById<HtmlDiv>("DataGrid");

        public HtmlAnchor UploadFiles
            => this.Find.ByContent<HtmlAnchor>("p:Качване на файл");

        public HtmlSpan PagerLabel => this.Find.ByExpression<HtmlSpan>("class=k-label", "class=k-pager-info");

        public HtmlAnchor DeleteButton
            => this.Find.ByExpression<HtmlAnchor>("class=~k-button", "class=~k-button-icontext", "class=~k-grid-delete")
            ;
    }
}