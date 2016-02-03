namespace QA.TelerikAcademy.Core.Pages.AvatarsPage
{
    #region using directives

    using System.Collections.Generic;

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Extensions;

    #endregion

    public class AvatarsPageMap : BaseElementMap
    {
        public HtmlInputFile UploadNewAvatarImage => this.Find.ById<HtmlInputFile>("AvatarImage");

        public IReadOnlyCollection<HtmlImage> AvatarImages
            => this.Find.AllByExpression<HtmlImage>("Avatar".IdContaining());

        public HtmlButton CloseButton => this.Find.ById<HtmlButton>("CloseBtn");
    }
}