namespace QA.TelerikAcademy.Core.Pages.AdminPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Extensions;

    #endregion

    public class AdminPageMap : BaseElementMap
    {
        public HtmlInputSearch SearchInAdministration
            => this.Find.ByExpression<HtmlInputSearch>(
                "k-textbox".ClassEqualTo(),
                "search".IdEqualTo(),
                "search".NameEqualTo(),
                "Търси администрация...".PlaceholderEqualTo());

        public HtmlDiv AdminContainer
            => this.Find.ByExpression<HtmlDiv>("container".ClassEqualTo(), "Администрация".TextContentContaining());

        public HtmlAnchor Dashboard
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Dashboard".HrefContaining());

        public HtmlAnchor Files
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Files".HrefContaining());

        public HtmlAnchor Pages
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Pages".HrefContaining());

        public HtmlAnchor FeedbackReports
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "FeedbackReports".HrefContaining());

        public HtmlAnchor Cleanup
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Cleanup".HrefContaining());

        public HtmlAnchor Calendar
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Calendar".HrefContaining());

        public HtmlAnchor TrainingRooms
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "TrainingRooms".HrefContaining());

        public HtmlAnchor Devices
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Devices".HrefContaining());

        public HtmlAnchor CustomEvents
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "CustomEvents".HrefContaining());

        public HtmlAnchor MovedLectures
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "MovedLectures".HrefContaining());

        public HtmlAnchor Surveys
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Surveys".HrefContaining());

        public HtmlAnchor SearchTerms
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "SearchTerms".HrefContaining());

        public HtmlAnchor Candidates
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Candidates".HrefContaining())
            ;

        public HtmlAnchor AdditionalDocuments
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "AdditionalDocuments".HrefContaining());

        public HtmlAnchor CandidateStatistics
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "CandidateStatistics".HrefContaining());

        public HtmlAnchor CandidateFormQaStatistics
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "CandidateFormQAStatistics".HrefContaining());

        public HtmlAnchor CandidateCorrelations
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "CandidateCorrelations".HrefContaining());

        public HtmlAnchor CandidateExams
            => this.Find.ByExpression<HtmlAnchor>(
                "admin-navigation-link".ClassEqualTo(),
                "CandidateExams".HrefContaining());

        public HtmlAnchor Students
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Students".HrefContaining());

        public HtmlAnchor Seasons
            => this.Find.ByExpression<HtmlAnchor>("admin-navigation-link".ClassEqualTo(), "Seasons".HrefContaining());
    }
}