namespace QA.TelerikAcademy.Core.Pages.FeedbackReportsPage
{
    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    public class FeedbackReportsPageValidator
    {
        public FeedbackReportsPageMap Map => new FeedbackReportsPageMap();

        public void ValidateKendoGrid()
        {
            this.Map.FeedbackReportsKendoGrid.Wait.ForExists();
            this.Map.FeedbackReportsKendoGrid.AssertIsPresent();
        }
    }
}