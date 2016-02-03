namespace QA.TelerikAcademy.Core.Constants.Pages
{
    #region using directives

    using System;

    #endregion

    public class EventsConstants
    {
        public const string Url = @"http://stage.telerikacademy.com/Administration/CustomEvents";
        public const string PageTitle = "Събития - Телерик Академия - Студентска система";

        public const string ValidDescription = "This is an event created for testing purposes.";
        public const string ValidDescriptionForUpdate = "This event was updated";
        public const string ValidForAllCoursesText = " За всички курсове ";
        public const int ValidForAllRoomsId = 0;
        public const int ValidForAllCoursesId = 0;
        public const int DefaultListOption = 1;
        public const int UpdatedListOption = 2;
        public const int CourseColumnId = 0;
        public const int RoomColumnId = 1;

        public static readonly string ValidStartDate = DateTime.Now.AddDays(2).Day.ToString();
        public static readonly string ValidEndDate = DateTime.Now.AddDays(3).Day.ToString();

        public static readonly string InvalidEndDateEarlierThanStartDate =
            DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy HH:mm");
    }
}