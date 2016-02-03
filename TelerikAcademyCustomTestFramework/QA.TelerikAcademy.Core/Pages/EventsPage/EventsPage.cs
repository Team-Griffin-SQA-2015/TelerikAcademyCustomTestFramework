namespace QA.TelerikAcademy.Core.Pages.EventsPage
{
    #region using directives

    using Constants.Pages;

    using TestingFramework.Core.Base;

    #endregion

    public class EventsPage : BaseKendoGridPage
    {
        public override string Url => EventsConstants.Url;

        public EventsPageMap Map => new EventsPageMap();

        public EventsPageValidator Validator => new EventsPageValidator();
    }
}