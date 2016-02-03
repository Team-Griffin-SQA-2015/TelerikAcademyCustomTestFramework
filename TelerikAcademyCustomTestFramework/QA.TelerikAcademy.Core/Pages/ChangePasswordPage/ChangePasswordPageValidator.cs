namespace QA.TelerikAcademy.Core.Pages.ChangePasswordPage
{
    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    public class ChangePasswordPageValidator
    {
        public ChangePasswordPageMap Map => new ChangePasswordPageMap();

        public void ValidateCurrentPasswordField()
        {
            this.Map.CurrentPassword.AssertIsPresent();
        }

        public void ValidateNewPasswordField()
        {
            this.Map.NewPassword.AssertIsPresent();
        }

        public void ValidateNewPasswordAgainField()
        {
            this.Map.NewPasswordAgain.AssertIsPresent();
        }

        public void ValidateSubmitButton()
        {
            this.Map.Submit.AssertIsPresent();
        }
    }
}