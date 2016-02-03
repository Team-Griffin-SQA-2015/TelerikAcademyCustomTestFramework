namespace QA.TelerikAcademy.Core.Factories
{
    #region using directives

    using System;

    using Constants.Pages;

    using Enumerations;

    using TestingFramework.Core.Data;

    #endregion

    public class SurveysFactory
    {
        public static Survey Get(SurveyType surveyType)
        {
            switch (surveyType)
            {
                case SurveyType.Valid:
                    return new Survey(
                        SurveysConstants.ValidName,
                        SurveysConstants.ValidActiveFromDateAndTime,
                        SurveysConstants.ValidActiveToDateAndTime);

                case SurveyType.ValidEdited:
                    return new Survey(
                        SurveysConstants.ValidEditedName,
                        SurveysConstants.ValidEditedActiveFromDateAndTime,
                        SurveysConstants.ValidEditedActiveToDateAndTime);

                case SurveyType.InvalidWithEmptyName:
                    return new Survey(
                        string.Empty,
                        SurveysConstants.ValidEditedActiveFromDateAndTime,
                        SurveysConstants.ValidEditedActiveToDateAndTime);

                case SurveyType.InvalidWithTooPastActiveFrom:
                    return new Survey(
                        SurveysConstants.ValidName,
                        SurveysConstants.InvalidTooPastActiveFromDateAndTime,
                        string.Empty);

                case SurveyType.InvalidWithTooFutureActiveFrom:
                    return new Survey(
                        SurveysConstants.ValidName,
                        SurveysConstants.InvalidTooFutureActiveFromDateAndTime,
                        string.Empty);

                default:
                    throw new ArgumentException();
            }
        }
    }
}