namespace QA.TelerikAcademy.Core.Pages.TrainingRoomsPage
{
    #region using directives

    using Constants.Pages;

    using TestingFramework.Core.Base;

    #endregion

    public class TrainingRoomsPage : BaseKendoGridPage
    {
        public override string Url => TrainingRoomConstants.Url;

        public TrainingRoomsPageMap Map => new TrainingRoomsPageMap();

        public TrainingRoomsPageValidator Validator => new TrainingRoomsPageValidator();
    }
}