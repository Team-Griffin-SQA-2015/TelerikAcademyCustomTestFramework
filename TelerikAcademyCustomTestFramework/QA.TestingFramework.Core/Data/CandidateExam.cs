namespace QA.TestingFramework.Core.Data
{
    public class CandidateExam
    {
        public string IqTestConfiguration { get; set; }

        public string ItTestConfiguration { get; set; }

        public string EnglishTestConfiguration { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string AllowedIp { get; set; }

        public string CandidatesCountLimit { get; set; }

        public string TrainingRoom { get; set; }
    }
}