namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Pages.FilesPage;
    using Pages.LoginPage;
    using Pages.UploadPage;

    using TestingFramework.Core.Data;

    #endregion

    public class FilesService
    {
        public FilesService()
        {
            this.LoginPage = new LoginPage();
            this.FilesPage = new FilesPage();
            this.UploadPage = new UploadPage();
        }

        private Browser Browser => Manager.Current.ActiveBrowser;

        public LoginPage LoginPage { get; set; }

        public FilesPage FilesPage { get; set; }

        public UploadPage UploadPage { get; set; }

        public void UploadNewFile(User user)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);

            this.FilesPage.Navigate();
            this.Browser.WaitUntilReady();
            this.FilesPage.Validator.ValidatePageTitle();
            this.FilesPage.Validator.ValidateUploadLink();
            this.FilesPage.Validator.ValidateDataGrid();

            this.UploadPage.Navigate();
            this.Browser.WaitUntilReady();
            this.UploadPage.Validator.ValidateChooseFileButton();
            this.UploadPage.Validator.ValidateDescriptionTextArea();
            this.UploadPage.Validator.ValidateSubmitButton();
        }
    }
}