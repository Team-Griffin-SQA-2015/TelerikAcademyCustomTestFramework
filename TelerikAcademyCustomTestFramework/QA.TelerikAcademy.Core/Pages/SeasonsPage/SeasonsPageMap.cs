namespace QA.TelerikAcademy.Core.Pages.SeasonsPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;

    #endregion

    public class SeasonsPageMap : BaseKendoGridPageMap
    {
        public HtmlAnchor AddNewSeason => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-add");

        public HtmlButton ExportToExcel => this.Find.ByExpression<HtmlButton>("class=~k-grid-excel");

        public HtmlButton ExportToPdf => this.Find.ByExpression<HtmlButton>("class=~k-grid-pdf");

        public HtmlAnchor NavigateToAdministration
            => this.Find.ByAttributes<HtmlAnchor>("href=/Administration/Navigation");

        public HtmlAnchor RefreshButton => this.Find.ByAttributes<HtmlAnchor>("title=Refresh");

        public HtmlAnchor ShowFirstPage => this.Find.ByExpression<HtmlAnchor>("class=~k-pager-first");

        public HtmlAnchor ShowLastPage => this.Find.ByExpression<HtmlAnchor>("class=~k-pager-last");

        public HtmlAnchor ShowPreviousPage => this.Find.ByAttributes<HtmlAnchor>("title=Go to the previous page");

        public HtmlAnchor ShowNextPage => this.Find.ByAttributes<HtmlAnchor>("title=Go to the next page");

        public HtmlSpan CurrentPageNumber => this.Find.ByExpression<HtmlSpan>("class=~k-state-selected");

        public HtmlAnchor EditSeason => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-edit");

        public HtmlAnchor UpdateSeasonesChanges => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-update");

        public HtmlAnchor CancelSeasonsChanges => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-cancel");

        public HtmlAnchor DeleteSeason => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-delete");

        public HtmlInputText SeasonName => this.Find.ById<HtmlInputText>("Name");

        //public KendoGrid KendoGrid => this.Find.ById<KendoGrid>("DataGrid");

        public HtmlInputCheckBox IsActive => this.Find.ById<HtmlInputCheckBox>("IsActive");

        public HtmlDiv ValidationMessage => this.Find.ById<HtmlDiv>("Name_validationMessage");

        public HtmlTableCell CurrentCell => this.Find.ByXPath<HtmlTableCell>("//td[text()='New Season']");

        //public IList<HtmlTableCell> AllIsActiveStates => this.Find.AllByAttributes<HtmlTableCell>("role=gridcell");
    }
}