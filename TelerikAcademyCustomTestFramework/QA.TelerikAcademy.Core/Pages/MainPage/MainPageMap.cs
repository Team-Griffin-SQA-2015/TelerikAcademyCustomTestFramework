namespace QA.TelerikAcademy.Core.Pages.MainPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    using TestingFramework.Core.Base;

    #endregion

    public class MainPageMap : BaseElementMap
    {
        public HtmlControl NewsSlider => this.Find.ByExpression<HtmlControl>("id=NewsSlider", "tagname=section");

        public HtmlAnchor FirstCourseInstance
            =>
                this.Find.ByExpression<HtmlAnchor>("id=NewsSlider",
                    "|",
                    "tagIndex=div:1",
                    "|",
                    "tagIndex=a:1",
                    "href=/Courses/Courses/Details/56");

        public HtmlAnchor SecondCourseInstance
            =>
                this.Find.ByExpression<HtmlAnchor>("id=NewsSlider",
                    "|",
                    "tagIndex=div:1",
                    "|",
                    "tagIndex=a:2",
                    "href=/Courses/Courses/Details/57");

        public HtmlSpan HomepageButton => this.Find.ByExpression<HtmlSpan>("class=~glyphicon-home");

        public KendoMenuItem UsernameButton
            =>
                this.Find.ByExpression<KendoMenuItem>("data-role=menu",
                    "GroupIndex=0",
                    "|",
                    "TagName=li",
                    "TagIndex=li:1");

        public HtmlSpan TelerikAcademyButton => this.Find.ByAttributes<HtmlSpan>("title=Софтуерна академия");

        public KendoMenuItem CoursesButton
            =>
                this.Find.ByExpression<KendoMenuItem>("data-role=menu",
                    "GroupIndex=0",
                    "|",
                    "TagName=li",
                    "TagIndex=li:19");

        public HtmlSpan ArchiveButton => this.Find.ByAttributes<HtmlSpan>("title=Архив");

        public HtmlAnchor ForumButton => this.Find.ByAttributes<HtmlAnchor>("href=/Forum/Home");

        public HtmlSpan HelpButton => this.Find.ByExpression<HtmlSpan>("title=Помощ");

        public HtmlSpan AdminButton => this.Find.ByExpression<HtmlSpan>("title=Админ");

        public HtmlInputText Title => this.Find.ById<HtmlInputText>("Title");

        public HtmlSpan CalendarButton => this.Find.ByExpression<HtmlSpan>("title=Календар");

        public HtmlSpan FriendsButton => this.Find.ByExpression<HtmlSpan>("title=Приятели");

        public HtmlSpan MessagesButton => this.Find.ByExpression<HtmlSpan>("title=Съобщения");

        public HtmlSpan TeamworkButton => this.Find.ByExpression<HtmlSpan>("title=Отборна работа");

        public HtmlSpan HomeworkEvaluationButton => this.Find.ByExpression<HtmlSpan>("title=Оцени домашно");

        public HtmlSpan SettingsButton => this.Find.ByExpression<HtmlSpan>("title=Настройки");

        public HtmlSpan ExitButton => this.Find.ByExpression<HtmlSpan>("title=Изход");

        public HtmlAnchor CandidateButton => this.Find.ByContent<HtmlAnchor>("Кандидатстване за академията");

        public HtmlAnchor EntaranceExamButton => this.Find.ByContent<HtmlAnchor>("Входен изпит");

        public HtmlAnchor CourseTracksButton => this.Find.ByContent<HtmlAnchor>("Специалности");

        public HtmlAnchor ArchiveTracksButton => this.Find.ByContent<HtmlAnchor>("Архивни специалности");

        public HtmlAnchor ArcherHomeworkEvalButton => this.Find.ByContent<HtmlAnchor>("Archer HomeworkEval");

        public HtmlAnchor TestCourseTwoButton => this.Find.ByContent<HtmlAnchor>("Тестови курс 2");

        public HtmlAnchor KidsAcademyCoursesButton
            => this.Find.ByAttributes<HtmlAnchor>("href=/Courses/KidsCourses/List");

        public HtmlAnchor TestCategory1Button => this.Find.ByContent<HtmlAnchor>("Test Category 01");

        public HtmlAnchor TestCategory2Button => this.Find.ByContent<HtmlAnchor>("Test Category 02");

        public HtmlAnchor MyTestForumCategoryButton => this.Find.ByContent<HtmlAnchor>("My Test Forum Category");

        public HtmlAnchor AaaaaaButton => this.Find.ByContent<HtmlAnchor>("aaaaaaaaaaaaaaaa");

        public HtmlAnchor FeedbackButton => this.Find.ByContent<HtmlAnchor>("Обратна връзка");

        public HtmlAnchor TermsAndConditionsButton
            => this.Find.ByContent<HtmlAnchor>("Условията и правилата за участие в Академията на Телерик");

        public HtmlAnchor AcademyWebSiteButton => this.Find.ByContent<HtmlAnchor>("Уебсайт на академията");

        public HtmlAnchor BgCoderButton => this.Find.ByContent<HtmlAnchor>("BGCoder judge system");

        public HtmlAnchor SiteInformationButton => this.Find.ByContent<HtmlAnchor>("Информация за сайта");

        public HtmlSpan AdminCalendarButton => this.Find.ByExpression<HtmlSpan>("title=Календар");

        public HtmlAnchor PublicCalendarButton
            => this.Find.ByAttributes<HtmlAnchor>("href=/Users/Calendar/PublicFullScreen");

        public HtmlSpan CoursesAndLecturesButton => this.Find.ByAttributes<HtmlSpan>("title=Курсове и лекции");

        public HtmlSpan StudentsInCourseButton => this.Find.ByAttributes<HtmlSpan>("title=Студенти");

        public HtmlSpan CertificatesRequestsButton
            => this.Find.ByAttributes<HtmlSpan>("title=Кандидатури за сертификати");

        public HtmlSpan BugsInMaterialsButton => this.Find.ByAttributes<HtmlSpan>("title=Грешки в материалите");

        public HtmlSpan ComplexSearchButton => this.Find.ByAttributes<HtmlSpan>("title=Сложно търсене");
    }
}