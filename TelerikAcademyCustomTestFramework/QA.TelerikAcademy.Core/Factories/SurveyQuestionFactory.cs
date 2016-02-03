namespace QA.TelerikAcademy.Core.Factories
{
    #region using directives

    using System;

    using Constants.Pages;

    using Enumerations;

    using TestingFramework.Core.Data;

    #endregion

    public class SurveyQuestionFactory
    {
        public static SurveyQuestion Get(SurveyQuestionType questionType)
        {
            switch (questionType)
            {
                case SurveyQuestionType.ValidText:
                    return new SurveyQuestion(
                        SurveysConstants.TextQuestionTypeIndex,
                        SurveysConstants.TextQuestionText);

                case SurveyQuestionType.ValidTextArea:
                    return new SurveyQuestion(
                        SurveysConstants.TextAreaQuestionTypeIndex,
                        SurveysConstants.TextAreaQuestionText);

                case SurveyQuestionType.ValidCheckbox:
                    return new SurveyQuestion(
                        SurveysConstants.CheckBoxQuestionTypeIndex,
                        SurveysConstants.CheckBoxQuestionText);

                case SurveyQuestionType.ValidRadio:
                    return new SurveyQuestion(
                        SurveysConstants.RadioQuestionTypeIndex,
                        SurveysConstants.RadioQuestionText);

                case SurveyQuestionType.ValidWithMaxBoundaryCharactersNumber:
                    return new SurveyQuestion(
                        SurveysConstants.TextQuestionTypeIndex,
                        SurveysConstants.Valid2000CharacterQuestionText);

                case SurveyQuestionType.InvalidWithEmptyType:
                    return new SurveyQuestion(
                        0,
                        SurveysConstants.TextQuestionText);

                case SurveyQuestionType.InvalidWithEmptyText:
                    return new SurveyQuestion(
                        SurveysConstants.TextQuestionTypeIndex,
                        string.Empty);

                case SurveyQuestionType.InvalidWithHigherCharactersNumber:
                    return new SurveyQuestion(
                        SurveysConstants.TextQuestionTypeIndex,
                        SurveysConstants.Invalid2001CharacterQuestionText);

                case SurveyQuestionType.InvalidWithOneCharacter:
                    return new SurveyQuestion(
                        SurveysConstants.TextQuestionTypeIndex,
                        "?");

                default:
                    throw new ArgumentException();
            }
        }
    }
}