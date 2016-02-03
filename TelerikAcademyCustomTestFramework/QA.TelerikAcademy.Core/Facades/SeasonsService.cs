namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using System.Windows.Forms;

    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;

    using Constants.Pages;

    using Pages.LoginPage;
    using Pages.SeasonsPage;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    public class SeasonsService : BaseTest
    {
        public SeasonsService()
        {
            this.LoginPage = new LoginPage();
            this.SeasonsPage = new SeasonsPage();
        }

        private DialogMonitor DialogMonitor => Manager.Current.DialogMonitor;

        public LoginPage LoginPage { get; set; }

        public SeasonsPage SeasonsPage { get; set; }

        public void NavigateToSeasonsPage(User user)
        {
            AcademyLoginProvider.Instance.LoginUser(user);
            this.LoginPage.WaitForUserName();
            this.LoginPage.Validator.ValidateUserName(user.Username);
            this.SeasonsPage.Navigate();
            this.SeasonsPage.Validator.ValidatePageTitle();
            this.SeasonsPage.Validator.ValidateDataGrid();
        }

        public void OpenEditNewSeasonWindow(User user)
        {
            this.NavigateToSeasonsPage(user);
            this.SeasonsPage.Map.AddNewSeason.Click();
            this.SeasonsPage.Map.UpdateSeasonesChanges.Wait.ForVisible();
        }

        public void EditNewSeasonWithName(string name, User user, bool active = false)
        {
            this.OpenEditNewSeasonWindow(user);
            this.SeasonsPage.Map.SeasonName.MouseClick();
            Manager.Current.Desktop.KeyBoard.TypeText(name);

            if (active)
            {
                this.IsActiveCheckboxClickAndWait();
            }

            this.SeasonsPage.Map.UpdateSeasonesChanges.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.TwoSecondsDelay);
            this.Browser.RefreshDomTree();
        }

        public void IsActiveCheckboxClickAndWait()
        {
            this.SeasonsPage.Map.IsActive.Click();
            ExecutionDelayProvider.SleepFor(DelayConstants.TwoSecondsDelay);
            this.Browser.RefreshDomTree();
        }

        public int FindIfSeasonWithNamePresents(string name)
        {
            var rowNumber = this.SeasonsPage.Map.KendoGrid.IndexOfGridRowContainingText(name);

            return rowNumber;
        }

        public void ChangeActiveState(string name)
        {
            var rowNumber = this.FindIfSeasonWithNamePresents(name);

            this.SeasonsPage.Map.AllEditEntryButtons[rowNumber].MouseClick();
            this.IsActiveCheckboxClickAndWait();
        }

        public void DeleteSeasonWithName(string name)
        {
            var rowNumber = this.FindIfSeasonWithNamePresents(name);

            this.DialogMonitor.AddDialog(AlertDialog.CreateAlertDialog(this.Browser, DialogButton.OK));
            this.DialogMonitor.Start();

            this.SeasonsPage.Map.AllDeleteEntryButtons[rowNumber].MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.TwoSecondsDelay);
            this.Browser.RefreshDomTree();
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Enter);
            ExecutionDelayProvider.SleepFor(DelayConstants.TwoSecondsDelay);
            this.Browser.RefreshDomTree();
        }
    }
}