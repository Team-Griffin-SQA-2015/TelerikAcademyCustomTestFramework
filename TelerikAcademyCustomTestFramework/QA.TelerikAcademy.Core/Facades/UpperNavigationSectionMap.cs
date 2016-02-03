namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Extensions;

    #endregion

    public class UpperNavigationSectionMap : BaseElementMap
    {
        public readonly string UserNameExpression = "Users/".HrefContaining();

        public HtmlAnchor UserName => this.Find.ByExpression<HtmlAnchor>(this.UserNameExpression);

        public HtmlAnchor Logout => this.Find.ById<HtmlAnchor>("ExitMI");
    }
}