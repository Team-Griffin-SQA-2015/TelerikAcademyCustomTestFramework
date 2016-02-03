namespace QA.TelerikAcademy.Core.Enumerations
{
    public enum SurveyQuestionType
    {
        ValidText,
        ValidTextArea,
        ValidCheckbox,
        ValidRadio,
        ValidWithMaxBoundaryCharactersNumber,
        InvalidWithEmptyType,
        InvalidWithEmptyText,
        InvalidWithHigherCharactersNumber,
        InvalidWithOneCharacter
    }
}