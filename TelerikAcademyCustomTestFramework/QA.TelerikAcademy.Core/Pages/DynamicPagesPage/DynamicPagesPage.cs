namespace QA.TelerikAcademy.Core.Pages.DynamicPagesPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public class DynamicPagesPage
    {
        public const string Url = @"http://stage.telerikacademy.com/Administration/Pages";

        public DynamicPagesPageMap Map => new DynamicPagesPageMap();

        public DynamicPagesPageValidator Validator => new DynamicPagesPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }
    }
}