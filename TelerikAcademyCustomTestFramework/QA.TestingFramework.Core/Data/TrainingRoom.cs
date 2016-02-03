namespace QA.TestingFramework.Core.Data
{
    #region using directives

    using Contracts;

    #endregion

    public class TrainingRoom : IGridComponent
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Capacity { get; set; }

        public string Equipment { get; set; }
    }
}