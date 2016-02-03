namespace QA.TestingFramework.Core.Base
{
    #region using directives

    using System.Collections.Generic;

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    #endregion

    public class BaseKendoGridPageMap : BaseElementMap
    {
        public HtmlAnchor AddItemButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-add");

        public HtmlAnchor ExportToExcelButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-excel");

        public HtmlAnchor ExportToPdfButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-pdf");

        public HtmlAnchor UpdateItemButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-update");

        public HtmlAnchor CancelChangesToItemButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-cancel");

        public HtmlAnchor EditEntryButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-edit");

        public IList<HtmlAnchor> AllEditEntryButtons => this.Find.AllByExpression<HtmlAnchor>("class=~k-grid-edit");

        public HtmlAnchor DeleteEntryButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-delete");

        public IList<HtmlAnchor> AllDeleteEntryButtons => this.Find.AllByExpression<HtmlAnchor>("class=~k-grid-delete");

        public HtmlAnchor NavigateToAdministrationButton
            => this.Find.ByAttributes<HtmlAnchor>("href=/Administration/Navigation");

        public KendoGrid KendoGrid => this.Find.ById<KendoGrid>("DataGrid");
    }
}