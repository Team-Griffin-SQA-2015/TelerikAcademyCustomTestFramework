namespace QA.TelerikAcademy.Core.Pages.ChangePasswordPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Extensions;

    #endregion

    public class ChangePasswordPageMap : BaseElementMap
    {
        public HtmlInputPassword CurrentPassword => this.Find.ById<HtmlInputPassword>("CurrentPassword");

        public HtmlInputPassword NewPassword => this.Find.ById<HtmlInputPassword>("NewPassword");

        public HtmlInputPassword NewPasswordAgain => this.Find.ById<HtmlInputPassword>("NewPasswordAgain");

        public HtmlInputControl Submit
            => this.Find.ByExpression<HtmlInputControl>(
                "btn-success".ClassEndingWith(),
                "Смяна на паролата".ValueEqualTo());
    }
}