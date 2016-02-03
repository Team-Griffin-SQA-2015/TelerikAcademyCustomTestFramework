namespace QA.TelerikAcademy.Core.Constants.Pages
{
    #region using directives

    using System;
    using System.IO;

    #endregion

    internal class CandidateFilesConstants
    {
        public static readonly string ValidPictureFilePath =
            Path.GetFullPath(
                Path.Combine(
                    Environment.CurrentDirectory
                    + @"/../../../QA.TelerikAcademy.Core/Items/cat.jpg"));

        public static readonly string ValidCvFilePath =
            Path.GetFullPath(
                Path.Combine(
                    Environment.CurrentDirectory
                    + @"/../../../QA.TelerikAcademy.Core/Items/testCandidateCV.docx"));

        public static readonly string ValidCoverLetterFilePath =
            Path.GetFullPath(
                Path.Combine(
                    Environment.CurrentDirectory
                    + @"/../../../QA.TelerikAcademy.Core/Items/testCandidateCoverLetter.docx"));

        public static readonly string ValidAdditionalDocumentFilePath =
            Path.GetFullPath(
                Path.Combine(
                    Environment.CurrentDirectory
                    + @"/../../../QA.TelerikAcademy.Core/Items/testCandidateAdditionalDocument.docx"));
    }
}