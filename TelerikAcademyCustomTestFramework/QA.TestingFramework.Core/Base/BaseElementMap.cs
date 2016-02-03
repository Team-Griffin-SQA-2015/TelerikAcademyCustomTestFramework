namespace QA.TestingFramework.Core.Base
{
    #region using directives

    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    #endregion

    public class BaseElementMap : HtmlElementContainer
    {
        public BaseElementMap()
            : base(Manager.Current.ActiveBrowser.Find)
        {
        }
    }
}