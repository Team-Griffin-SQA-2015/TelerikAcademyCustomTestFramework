namespace QA.TestingFramework.Core.Data
{
    public class Survey
    {
        public Survey(string name, string activeFrom, string activeTo)
        {
            this.Name = name;
            this.ActiveFrom = activeFrom;
            this.ActiveTo = activeTo;
        }

        public string Name { get; set; }

        public string ActiveFrom { get; set; }

        public string ActiveTo { get; set; }
    }
}