namespace QA.TelerikAcademy.Core.Constants.Pages
{
    public class ChangeEmailConstants
    {
        public const int CustomWaitInMilliseconds = 5000;
        public const string ChangeEmailSuccessUrl = "http://stage.telerikacademy.com/Users/Auth/ChangeEmailSuccess";
        public const string ValidEmail = "aaa@aaa.com";
        public const string InvalidEmailWithLengthUnderLowerLimit = "a@a.com";

        public const string InvalidEmailWithLengthAboveUpperLimit =
            "aaaaaaaaaaaaaaaaaaaaaaa@aaaaaaaaaaaaaaaaaaaaaaa.com";
    }
}