namespace QA.TelerikAcademy.Core.Pages.ChangeEmailPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Extensions;

    #endregion

    public class ChangeEmailPageMap : BaseElementMap
    {
        public HtmlInputPassword Password => this.Find.ById<HtmlInputPassword>("Password");

        public HtmlInputText NewEmail => this.Find.ById<HtmlInputText>("NewEmail");

        public HtmlInputText NewEmailAgain => this.Find.ById<HtmlInputText>("NewEmailAgain");

        public HtmlInputControl Submit
            => this.Find.ByExpression<HtmlInputControl>(
                "btn-success".ClassEndingWith(),
                "Смяна на имейл адреса".ValueEqualTo());
    }
}