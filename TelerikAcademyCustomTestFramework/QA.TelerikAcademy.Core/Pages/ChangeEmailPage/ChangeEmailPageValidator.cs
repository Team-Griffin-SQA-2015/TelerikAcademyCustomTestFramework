namespace QA.TelerikAcademy.Core.Pages.ChangeEmailPage
{
    #region using directives

    using TestingFramework.Core.Extensions;

    #endregion

    public class ChangeEmailPageValidator
    {
        public ChangeEmailPageMap Map => new ChangeEmailPageMap();

        public void ValidatePasswordField()
        {
            this.Map.Password.AssertIsPresent();
        }

        public void ValidateNewEmailField()
        {
            this.Map.NewEmail.AssertIsPresent();
        }

        public void ValidateNewEmailAgainField()
        {
            this.Map.NewEmailAgain.AssertIsPresent();
        }

        public void ValidateSubmitButton()
        {
            this.Map.Submit.AssertIsPresent();
        }
    }
}