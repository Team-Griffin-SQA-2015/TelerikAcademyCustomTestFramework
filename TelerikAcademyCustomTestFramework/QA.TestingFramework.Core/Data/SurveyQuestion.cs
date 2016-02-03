namespace QA.TestingFramework.Core.Data
{
    public class SurveyQuestion
    {
        public SurveyQuestion(int typeIndex, string text)
        {
            this.TypeIndex = typeIndex;
            this.Text = text;
        }

        public int TypeIndex { get; set; }

        public string Text { get; set; }
    }
}