namespace QA.TelerikAcademy.Core.Pages.FilesPage
{
    #region using directives

    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using TestingFramework.Core.Extensions;

    #endregion

    public class FilesPageValidator
    {
        public FilesPageMap Map => new FilesPageMap();

        public void ValidatePageTitle()
        {
            Assert.AreEqual(FilesConstants.PageTitle, Manager.Current.ActiveBrowser.PageTitle);
        }

        public void ValidateDataGrid()
        {
            this.Map.DataGrid.AssertIsPresent();
        }

        public void ValidateUploadLink()
        {
            this.Map.UploadFiles.AssertIsPresent();
        }
    }
}