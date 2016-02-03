namespace QA.TelerikAcademy.Core.Pages.EventsPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    using TestingFramework.Core.Base;

    #endregion

    public class EventsPageMap : BaseKendoGridPageMap
    {
        public HtmlSpan CoursesContainer => this.Find.ByExpression<HtmlSpan>("aria-controls=CourseInstanceId_listbox");

        public HtmlUnorderedList CoursesList => this.Find.ById<HtmlUnorderedList>("CourseInstanceId_listbox");

        public HtmlInputText CourseInput => this.Find.ByName<HtmlInputText>("CourseInstanceId_input");

        public HtmlTextArea Description => this.Find.ById<HtmlTextArea>("Title");

        public KendoListBox TrainingRoomsList => this.Find.ById<KendoListBox>("TrainingRoomId_listbox");

        public HtmlInputText StartTime => this.Find.ById<HtmlInputText>("StartTime");

        public KendoCalendar StartTimeCalendar => this.Find.ById<KendoCalendar>("StartTime_dateview");

        public HtmlInputText EndTime => this.Find.ById<HtmlInputText>("EndTime");

        public HtmlDiv CourseInstanceValidationMessage => this.Find.ById<HtmlDiv>("CourseInstanceId_validationMessage");

        public HtmlDiv DescriptionValidationMessage => this.Find.ById<HtmlDiv>("Title_validationMessage");
    }
}