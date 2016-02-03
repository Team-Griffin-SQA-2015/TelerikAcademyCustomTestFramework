namespace QA.TelerikAcademy.Core.Constants.Pages
{
    #region using directives

    using TestingFramework.Core.Data;

    #endregion

    public class CandidateExamConstants
    {
        public const string ValidIqTestConfiguration = "IQTest";
        public const string ValidItTestConfiguration = "ITTest";
        public const string ValidEnglishTestConfiguration = "EnglishTest";
        public const string ValidStartTime = "11/12/2016 10:00:00";
        public const string ValidEndTime = "11/12/2016 13:00:00";
        public const string ValidTrainingRoom = "Light";
        public const string ValidCandidatesCountLimit = "50";
        public const string DefaultStartTime = "07/10/2016 13:00:00";
        public const string DefaultEndTime = "07/10/2016 15:00:00";
        public const string DefaultAllowedIp = "*";
        public const string DefaultCandidatesCountLimit = "30";

        public static readonly CandidateExam ValidCandidateExam = new CandidateExam
        {
            IqTestConfiguration = ValidIqTestConfiguration,
            ItTestConfiguration = ValidItTestConfiguration,
            EnglishTestConfiguration = ValidEnglishTestConfiguration,
            StartTime = ValidStartTime,
            EndTime = ValidEndTime,
            TrainingRoom = ValidTrainingRoom,
            AllowedIp = DefaultAllowedIp,
            CandidatesCountLimit = ValidCandidatesCountLimit
        };

        public static readonly CandidateExam CandidateExamWithInvalidIqTestConfiguration = new CandidateExam
        {
            IqTestConfiguration = null,
            ItTestConfiguration = ValidItTestConfiguration,
            EnglishTestConfiguration = ValidEnglishTestConfiguration,
            StartTime = DefaultStartTime,
            EndTime = DefaultEndTime,
            TrainingRoom = ValidTrainingRoom,
            AllowedIp = DefaultAllowedIp,
            CandidatesCountLimit = DefaultCandidatesCountLimit
        };

        public static readonly CandidateExam CandidateExamWithInvalidItTestConfiguration = new CandidateExam
        {
            IqTestConfiguration = ValidIqTestConfiguration,
            ItTestConfiguration = null,
            EnglishTestConfiguration = ValidEnglishTestConfiguration,
            StartTime = DefaultStartTime,
            EndTime = DefaultEndTime,
            TrainingRoom = ValidTrainingRoom,
            AllowedIp = DefaultAllowedIp,
            CandidatesCountLimit = DefaultCandidatesCountLimit
        };

        public static readonly CandidateExam CandidateExamWithInvalidEnglishTestConfiguration = new CandidateExam
        {
            IqTestConfiguration = ValidIqTestConfiguration,
            ItTestConfiguration = ValidItTestConfiguration,
            EnglishTestConfiguration = null,
            StartTime = DefaultStartTime,
            EndTime = DefaultEndTime,
            TrainingRoom = ValidTrainingRoom,
            AllowedIp = DefaultAllowedIp,
            CandidatesCountLimit = DefaultCandidatesCountLimit
        };
    }
}