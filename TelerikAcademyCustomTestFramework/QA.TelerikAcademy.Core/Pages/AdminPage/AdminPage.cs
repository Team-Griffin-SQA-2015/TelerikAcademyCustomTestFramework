namespace QA.TelerikAcademy.Core.Pages.AdminPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;

    #endregion

    public class AdminPage
    {
        public const string AdminPanelUrl = @"http://stage.telerikacademy.com/Administration/Navigation";

        public AdminPageMap Map => new AdminPageMap();

        public AdminPageValidator Validator => new AdminPageValidator();

        public void ChooseModule(HtmlControl htmlElement)
        {
            htmlElement.Click();
        }

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(AdminPanelUrl);
        }
    }
}