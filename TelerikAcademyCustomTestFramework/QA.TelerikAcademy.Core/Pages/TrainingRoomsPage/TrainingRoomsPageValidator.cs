namespace QA.TelerikAcademy.Core.Pages.TrainingRoomsPage
{
    #region using directives

    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using TestingFramework.Core.Extensions;

    #endregion

    public class TrainingRoomsPageValidator
    {
        public TrainingRoomsPageMap Map => new TrainingRoomsPageMap();

        public void ValidatePageTitle()
        {
            Assert.AreEqual(TrainingRoomConstants.PageTitle, Manager.Current.ActiveBrowser.PageTitle);
        }

        public void ValidateAddPopUpAppeared()
        {
            this.Map.TrainingRoomName.AssertIsPresent();
        }
    }
}