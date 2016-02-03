namespace QA.TelerikAcademy.Core.Constants.Pages
{
    #region using directives

    using System;
    using System.IO;

    #endregion

    public class UploadNewAvatarImageConstants
    {
        public const int CustomWaitForInvalidAvatarImage = 5000;
        public const int CustomWaitForValidAvatarImage = 10000;
        public const int CustomWaitForOversizedAvatarImage = 15000;

        public const string RemoveAvatarImageScript = "$('a.deleteAvatarBtnYes').click()";

        public static readonly string ValidAvatarImageFilePath =
            Path.GetFullPath(
                Path.Combine(
                    Environment.CurrentDirectory
                    + @"/../../../QA.TelerikAcademy.Core/Items/ws_Iron_Man_3_Suit_1920x1080.jpg"));

        public static readonly string InvalidEmptyAvatarImageFilePath =
            Path.GetFullPath(
                Path.Combine(
                    Environment.CurrentDirectory + @"/../../../QA.TelerikAcademy.Core/Items/New Bitmap Image.bmp"));

        public static readonly string InvalidOversizedAvatarImageFilePath =
            Path.GetFullPath(
                Path.Combine(Environment.CurrentDirectory + @"/../../../QA.TelerikAcademy.Core/Items/178440.jpg"));

        public static readonly string InvalidFormatAvatarImageFilePath =
            Path.GetFullPath(
                Path.Combine(
                    Environment.CurrentDirectory
                    + @"/../../../QA.TelerikAcademy.Core/Items/TeamGriffinTestStatusReport.docx"));
    }
}