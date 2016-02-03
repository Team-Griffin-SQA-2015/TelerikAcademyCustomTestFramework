namespace QA.TelerikAcademy.Core.Pages.SurveysPage
{
    #region using directives

    using Constants.Pages;

    using TestingFramework.Core.Base;

    #endregion

    public class SurveysPage : BaseKendoGridPage
    {
        public override string Url
        {
            get { return SurveysConstants.Url; }
        }

        public SurveysPageMap Map => new SurveysPageMap();

        public SurveysPageValidator Validator => new SurveysPageValidator();
    }
}