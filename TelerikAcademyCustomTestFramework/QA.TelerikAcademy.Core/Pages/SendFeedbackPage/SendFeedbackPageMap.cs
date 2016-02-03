namespace QA.TelerikAcademy.Core.Pages.SendFeedbackPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;

    #endregion

    public class SendFeedbackPageMap : BaseElementMap
    {
        public HtmlInputText FullName => this.Find.ById<HtmlInputText>("FullName");

        public HtmlInputText Email => this.Find.ById<HtmlInputText>("Email");

        public HtmlTextArea FeedbackContent => this.Find.ById<HtmlTextArea>("FeedbackContent");

        public HtmlInputControl Submit
            => this.Find.ByAttributes<HtmlInputControl>("value=Изпратете съобщението", "type=submit");
    }
}