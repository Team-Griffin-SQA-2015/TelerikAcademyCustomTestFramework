namespace QA.TelerikAcademy.Core.Pages.CheckinDevicesPage
{
    #region using directives

    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using TestingFramework.Core.Extensions;

    #endregion

    public class CheckinDevicesPageValidator
    {
        public CheckinDevicesPageMap Map => new CheckinDevicesPageMap();

        public void ValidatePageTitle()
        {
            Assert.AreEqual(CheckinDevicesConstants.PageTitle, Manager.Current.ActiveBrowser.PageTitle);
        }

        public void ValidateAddPopUpAppeared()
        {
            this.Map.DeviceNumber.AssertIsPresent();
        }
    }
}