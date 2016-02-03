namespace QA.TelerikAcademy.Core.Pages.SearchTermsPage
{
    #region using directives

    using Constants.Pages;

    #region using directives

    using TestingFramework.Core.Base;

    #endregion

    #endregion

    public class SearchTermsPage : BaseKendoGridPage
    {
        public SearchTermsPageMap Map => new SearchTermsPageMap();

        public SearchTermsPageValidator Validator => new SearchTermsPageValidator();

        public override string Url
        {
            get { return SearchTermsConstants.Url; }
        }
    }
}