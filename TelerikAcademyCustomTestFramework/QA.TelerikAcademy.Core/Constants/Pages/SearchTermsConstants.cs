namespace QA.TelerikAcademy.Core.Constants.Pages
{
    public class SearchTermsConstants
    {
        public const string Url = @"http://stage.telerikacademy.com/Administration/SearchTerms";
        public const string ValidWord = "SearchTerm";
        public const string ValidEditingWord = "EditedSearchTerm";

        public const string InvalidWordWithHigherLength =
            "Invalid Searched Word Invalid Searched Word Invalid Searched Word Invalid Searched Word Invalid Searched Word";

        public const string ValidCountValue = "3";
        public const string ValidEditingCountValue = "5";
        public const string InvalidCountNegativeValue = "-4";
        public const string InvalidCountLargeNumberValue = "10000000000000000";
    }
}