namespace QA.TelerikAcademy.Core.Pages.DynamicPagesPage
{
    #region using directives

    using System.Linq;

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    using TestingFramework.Core.Base;

    #endregion

    public class DynamicPagesPageMap : BaseElementMap
    {
        public HtmlControl DynamicPagesHeader => this.Find.AllByTagName<HtmlControl>("h1").FirstOrDefault();

        public HtmlDiv DataGrid => this.Find.ById<HtmlDiv>("DataGrid");

        public HtmlAnchor AddNewDynamicPage
            => this.Find.ByAttributes<HtmlAnchor>("href=/Administration/Pages/Read?DataGrid-mode=insert");

        public HtmlDiv KendoWindow => this.Find.ByExpression<HtmlDiv>("class=~k-window");

        public KendoGrid KendoGrid => this.Find.ById<KendoGrid>("DataGrid");

        public HtmlInputText Title => this.Find.ById<HtmlInputText>("Title");

        public HtmlControl Editor => this.Find.AllByTagName<HtmlControl>("body").FirstOrDefault();

        public HtmlSpan PagerLabel => this.Find.ByExpression<HtmlSpan>("class=~k-label");

        public HtmlAnchor UpdateButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-update");

        public HtmlAnchor CancelButton => this.Find.ByExpression<HtmlAnchor>("class=~k-grid-cancel");

        public HtmlSpan DeleteButton => this.Find.ByExpression<HtmlSpan>("class=~k-delete");

        public HtmlDiv FieldValidationError => this.Find.ByExpression<HtmlDiv>("class=~field-validation-error");

        public HtmlDiv TitleValidationError => this.Find.ById<HtmlDiv>("Title_validationMessage");

        public HtmlDiv ContentValidationError => this.Find.ById<HtmlDiv>("Content_validationMessage");
    }
}