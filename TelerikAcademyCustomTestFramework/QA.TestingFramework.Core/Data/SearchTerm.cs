namespace QA.TestingFramework.Core.Data
{
    public class SearchTerm
    {
        public SearchTerm(string word, string count)
        {
            this.Word = word;
            this.Count = count;
        }

        public string Word { get; set; }

        public string Count { get; set; }
    }
}