namespace QA.TelerikAcademy.Core.Pages.LoginPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Extensions;

    #endregion

    public class LoginPageMap : BaseElementMap
    {
        public HtmlInputText UserName => this.Find.ById<HtmlInputText>("UsernameOrEmail");

        public HtmlInputPassword Password => this.Find.ById<HtmlInputPassword>("Password");

        public HtmlInputSubmit Submit
            => this.Find.ByExpression<HtmlInputSubmit>(
                "btn btn-success pull-left".ClassEqualTo(),
                "Вход".ValueEqualTo());
    }
}