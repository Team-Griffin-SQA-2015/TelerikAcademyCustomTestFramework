namespace QA.TelerikAcademy.Core.Pages.UploadPage
{
    #region using directives

    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Core;

    using TestingFramework.Core.Extensions;

    #endregion

    public class UploadPageValidator
    {
        private const string PageTitle = "Качване на файл - Телерик Академия - Студентска система";

        public UploadPageMap Map => new UploadPageMap();

        public void ValidatePageTitle()
        {
            Assert.AreEqual(PageTitle, Manager.Current.ActiveBrowser.PageTitle);
        }

        public void ValidateChooseFileButton()
        {
            this.Map.ChooseFile.AssertIsPresent();
        }

        public void ValidateDescriptionTextArea()
        {
            this.Map.Description.AssertIsPresent();
        }

        public void ValidateSubmitButton()
        {
            this.Map.Submit.AssertIsPresent();
        }
    }
}