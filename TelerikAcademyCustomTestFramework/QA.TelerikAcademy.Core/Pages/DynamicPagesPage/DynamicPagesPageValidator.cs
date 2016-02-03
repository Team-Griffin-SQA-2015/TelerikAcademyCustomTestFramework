namespace QA.TelerikAcademy.Core.Pages.DynamicPagesPage
{
    #region using directives

    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using TestingFramework.Core.Extensions;

    #endregion

    public class DynamicPagesPageValidator
    {
        public DynamicPagesPageMap Map => new DynamicPagesPageMap();

        public void ValidatePageTitle()
        {
            Assert.AreEqual(DynamicPagesConstants.PageTitle, Manager.Current.ActiveBrowser.PageTitle);
        }

        public void ValidateDataGrid()
        {
            this.Map.DataGrid.AssertIsPresent();
        }
    }
}