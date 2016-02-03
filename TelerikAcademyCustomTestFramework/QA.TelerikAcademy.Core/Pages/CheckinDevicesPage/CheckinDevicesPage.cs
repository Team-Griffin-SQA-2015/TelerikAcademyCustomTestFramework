namespace QA.TelerikAcademy.Core.Pages.CheckinDevicesPage
{
    #region using directives

    using Constants.Pages;

    using TestingFramework.Core.Base;

    #endregion

    public class CheckinDevicesPage : BaseKendoGridPage
    {
        public override string Url => CheckinDevicesConstants.Url;

        public CheckinDevicesPageMap Map => new CheckinDevicesPageMap();

        public CheckinDevicesPageValidator Validator => new CheckinDevicesPageValidator();
    }
}