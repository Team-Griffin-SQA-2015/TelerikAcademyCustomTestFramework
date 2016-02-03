namespace QA.TelerikAcademy.Core.Pages.KidsCandidateFormPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;

    #endregion

    public class KidsCandidateFormPageMap : BaseElementMap
    {
        public HtmlControl KidsCandidateFormH2Tag
            =>
                this.Find.ByExpression<HtmlControl>("TextContent=^Регистрация в \"Детската академия на Телерик\"",
                    "class=greenBorderedHeader",
                    "tagname=h2");
    }
}