namespace QA.TelerikAcademy.Core.Pages.AvatarsPage
{
    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    public class AvatarsPageValidator
    {
        public AvatarsPageMap Map => new AvatarsPageMap();

        public void ValidateUploadNewAvatarImage()
        {
            this.Map.UploadNewAvatarImage.AssertIsPresent();
        }
    }
}