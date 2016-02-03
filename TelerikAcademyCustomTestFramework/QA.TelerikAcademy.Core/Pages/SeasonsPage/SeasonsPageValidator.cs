namespace QA.TelerikAcademy.Core.Pages.SeasonsPage
{
    #region using directives

    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using TestingFramework.Core.Extensions;

    #endregion

    public class SeasonsPageValidator
    {
        public SeasonsPageMap Map => new SeasonsPageMap();

        public void ValidatePageTitle()
        {
            Assert.AreEqual(SeasonsConstants.PageTitle, Manager.Current.ActiveBrowser.PageTitle);
        }

        public void ValidateDataGrid()
        {
            this.Map.KendoGrid.AssertIsPresent();
        }

        public void ValidateWarningMessage()
        {
            this.Map.ValidationMessage.AssertIsPresent();
        }
    }
}