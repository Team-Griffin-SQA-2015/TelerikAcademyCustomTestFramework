namespace QA.TelerikAcademy.Core.Pages.SearchTermsPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    using TestingFramework.Core.Base;

    #endregion

    public class SearchTermsPageMap : BaseKendoGridPageMap
    {
        public KendoGrid SearchTermsGrid => this.Find.ById<KendoGrid>("DataGrid");

        public HtmlInputText Word => this.Find.ById<HtmlInputText>("Word");

        public HtmlInputNumber Count => this.Find.ById<HtmlInputNumber>("Count");

        public HtmlDiv WordValidationMessage => this.Find.ById<HtmlDiv>("Word_validationMessage");

        public HtmlDiv CountValidationMessage => this.Find.ById<HtmlDiv>("Count_validationMessage");
    }
}