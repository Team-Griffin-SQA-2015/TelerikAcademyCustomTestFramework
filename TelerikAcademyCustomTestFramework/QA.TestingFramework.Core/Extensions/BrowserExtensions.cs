namespace QA.TestingFramework.Core.Extensions
{
    #region using directives

    using System.Threading;

    using ArtOfTest.WebAii.Core;

    #endregion

    public static class BrowserExtensions
    {
        public static void WaitForExists(this Browser browser, params string[] customExpression)
        {
            EventWaiter.WaitForEvent(
                () =>
                {
                    try
                    {
                        browser.RefreshDomTree();
                        var htmlFindExpression = new HtmlFindExpression(customExpression);
                        browser.WaitForElement(htmlFindExpression, 500, false);
                    }
                    catch
                    {
                        Thread.Sleep(100);
                        return false;
                    }

                    return true;
                },
                200000);
        }
    }
}