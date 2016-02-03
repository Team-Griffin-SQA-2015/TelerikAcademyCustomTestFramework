namespace QA.TelerikAcademy.Core.Factories
{
    #region using directives

    using System;

    using Constants.Pages;

    using Enumerations;

    using TestingFramework.Core.Data;

    #endregion

    public class SearchTermsFactory
    {
        public static SearchTerm Get(SearchTermType searchTermType)
        {
            switch (searchTermType)
            {
                case SearchTermType.Valid:
                    return new SearchTerm(
                        SearchTermsConstants.ValidWord,
                        SearchTermsConstants.ValidCountValue);

                case SearchTermType.ValidEditingSearchTerm:
                    return new SearchTerm(
                        SearchTermsConstants.ValidEditingWord,
                        SearchTermsConstants.ValidEditingCountValue);

                case SearchTermType.InvalidWithEmptyWordField:
                    return new SearchTerm(
                        string.Empty,
                        SearchTermsConstants.ValidCountValue);

                case SearchTermType.InvalidWithEmptyCountField:
                    return new SearchTerm(
                        SearchTermsConstants.ValidWord,
                        string.Empty);

                case SearchTermType.InvalidWithHigherWordLength:
                    return new SearchTerm(
                        SearchTermsConstants.InvalidWordWithHigherLength,
                        SearchTermsConstants.ValidCountValue);

                case SearchTermType.InvalidWithLargeNumberCountValue:
                    return new SearchTerm(
                        SearchTermsConstants.ValidWord,
                        SearchTermsConstants.InvalidCountLargeNumberValue);

                case SearchTermType.InvalidWithNegativeCountValue:
                    return new SearchTerm(
                        SearchTermsConstants.ValidWord,
                        SearchTermsConstants.InvalidCountNegativeValue);

                case SearchTermType.InvalidWithTextAsCountValue:
                    return new SearchTerm(
                        SearchTermsConstants.ValidWord,
                        SearchTermsConstants.ValidWord);

                default:
                    throw new ArgumentException();
            }
        }
    }
}