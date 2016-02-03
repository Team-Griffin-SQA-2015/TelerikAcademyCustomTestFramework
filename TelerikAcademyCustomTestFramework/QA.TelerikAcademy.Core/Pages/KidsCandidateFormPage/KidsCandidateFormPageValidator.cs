namespace QA.TelerikAcademy.Core.Pages.KidsCandidateFormPage
{
    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    public class KidsCandidateFormPageValidator
    {
        public KidsCandidateFormPageMap Map => new KidsCandidateFormPageMap();

        public void ValidateKidsCandidateFormH2Tag()
        {
            this.Map.KidsCandidateFormH2Tag.Wait.ForExists();
            this.Map.KidsCandidateFormH2Tag.AssertIsPresent();
        }
    }
}