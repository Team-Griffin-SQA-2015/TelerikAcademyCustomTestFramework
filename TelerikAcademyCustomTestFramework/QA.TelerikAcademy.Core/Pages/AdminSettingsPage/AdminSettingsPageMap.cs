namespace QA.TelerikAcademy.Core.Pages.AdminSettingsPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    using TestingFramework.Core.Base;

    #endregion

    public class AdminSettingsPageMap : BaseElementMap
    {
        public HtmlControl SettingsH1Tag => this.Find.ByExpression<HtmlControl>("TextContent=Настройки", "tagname=h1");

        public HtmlAnchor SortingBySettingIdLink
            =>
                this.Find.ByExpression<HtmlAnchor>("href=/Administration/Settings/Read?DataGrid-sort=SettingId-asc",
                    "tagname=a");

        public HtmlTableCell SoftwareAcademyCandidatePeriodNameCell
            => this.Find.ByExpression<HtmlTableCell>("TextContent=IsInSoftwareAcademyCandidatePeriod", "tagname=td");

        public HtmlAnchor SoftwareAcademyCandidatePeriodEditLink
            => this.Find.ByExpression<HtmlAnchor>("id=DataGrid", "|", "tagIndex=a:12");

        public HtmlInputText KendoWindowValueText => this.Find.ByExpression<HtmlInputText>("id=Value", "tagname=input");

        public HtmlAnchor KendoWindowUpdateButton
            => this.Find.ByExpression<HtmlAnchor>("textcontent=~Update", "tagname=a");

        public KendoGridDataCell IsInSoftwareAcademyCandidatePeriodDataCell
            =>
                this.Find.ByExpression<KendoGridDataCell>("data-role=grid",
                    "GroupIndex=0",
                    "|",
                    "TagName=td",
                    "TagIndex=td:2");

        public HtmlTableCell SoftwareAcademyCandidateFormOpenedNameCell
            => this.Find.ByExpression<HtmlTableCell>("TextContent=IsSoftwareAcademyCandidateFormOpened", "tagname=td");

        public HtmlAnchor SoftwareAcademyCandidateFormOpenedEditLink
            => this.Find.ByExpression<HtmlAnchor>("id=DataGrid", "|", "tagIndex=a:18");

        public KendoGridDataCell IsSoftwareAcademyCandidateFormOpenedDataCell
            =>
                this.Find.ByExpression<KendoGridDataCell>("data-role=grid",
                    "GroupIndex=0",
                    "|",
                    "TagName=td",
                    "TagIndex=td:23");

        public HtmlAnchor KidsCandidateFormOpenedEditLink
            => this.Find.ByExpression<HtmlAnchor>("id=DataGrid", "|", "tagIndex=a:20");

        public KendoGridDataCell IsKidsAcademyRegistraionFormOpenedDataCell
            => this.Find.ByExpression<KendoGridDataCell>("data-role=grid",
                "GroupIndex=0",
                "|",
                "TagName=td",
                "TagIndex=td:30");

        public HtmlAnchor FirstHomePageCourseInstanceEditLink
            => this.Find.ByExpression<HtmlAnchor>("id=DataGrid", "|", "tagIndex=a:26");

        public KendoGridDataCell FirstHomePageCourseInstanceDataCell
            => this.Find.ByExpression<KendoGridDataCell>("data-role=grid",
                "GroupIndex=0",
                "|",
                "TagName=td",
                "TagIndex=td:51");

        public HtmlAnchor SecondHomePageCourseInstanceEditLink
            => this.Find.ByExpression<HtmlAnchor>("id=DataGrid", "|", "tagIndex=a:28");

        public KendoGridDataCell SecondHomePageCourseInstanceDataCell
            => this.Find.ByExpression<KendoGridDataCell>("data-role=grid",
                "GroupIndex=0",
                "|",
                "TagName=td",
                "TagIndex=td:58");

        public HtmlAnchor SoftwareAcademyCandidatePeriodOverTextEditLink
            => this.Find.ByExpression<HtmlAnchor>("id=DataGrid", "|", "tagIndex=a:48");

        public KendoGridDataCell SoftwareAcademyCandidatePeriodOverTextDataCell
            => this.Find.ByExpression<KendoGridDataCell>("data-role=grid",
                "GroupIndex=0",
                "|",
                "TagName=td",
                "TagIndex=td:128");
    }
}