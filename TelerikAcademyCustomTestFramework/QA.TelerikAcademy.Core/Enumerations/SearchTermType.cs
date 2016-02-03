namespace QA.TelerikAcademy.Core.Enumerations
{
    public enum SearchTermType
    {
        Valid,
        ValidEditingSearchTerm,
        InvalidWithEmptyWordField,
        InvalidWithEmptyCountField,
        InvalidWithHigherWordLength,
        InvalidWithNegativeCountValue,
        InvalidWithTextAsCountValue,
        InvalidWithLargeNumberCountValue
    }
}