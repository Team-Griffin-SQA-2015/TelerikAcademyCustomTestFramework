namespace QA.TestingFramework.Core.Base
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    #endregion

    public abstract class BaseKendoGridPage
    {
        public abstract string Url { get; }

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(this.Url);
        }
    }
}