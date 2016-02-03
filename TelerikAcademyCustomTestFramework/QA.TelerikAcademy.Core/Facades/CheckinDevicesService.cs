namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using System.Windows.Forms;

    using ArtOfTest.WebAii.Core;

    using Pages.CheckinDevicesPage;
    using Pages.LoginPage;

    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    public class CheckinDevicesService
    {
        public CheckinDevicesService()
        {
            this.LoginPage = new LoginPage();
            this.CheckinDevicesPage = new CheckinDevicesPage();
        }

        public LoginPage LoginPage { get; set; }

        public CheckinDevicesPage CheckinDevicesPage { get; set; }

        public void AddCheckinDevice(string number)
        {
            this.CheckinDevicesPage.Map.AddItemButton.MouseClick();
            this.CheckinDevicesPage.Validator.ValidateAddPopUpAppeared();
            ExecutionDelayProvider.SleepFor(3000);
            this.CheckinDevicesPage.Map.DeviceNumber.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(number, 30);
            this.CheckinDevicesPage.Map.AvailableTrainingRooms.MouseClick();
            this.CheckinDevicesPage.Map.AvailableTrainingRooms.SelectItem(1);
            this.CheckinDevicesPage.Map.UpdateItemButton.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
        }

        public void DeleteCheckinDevice(string number)
        {
            var rowToDelete = this.CheckinDevicesPage.Map.KendoGrid.IndexOfGridRowContainingText(number);
            this.CheckinDevicesPage.Map.AllDeleteEntryButtons[rowToDelete].MouseClick();
            this.CheckinDevicesPage.Map.DeleteEntryButton.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            Manager.Current.Desktop.KeyBoard.KeyPress(Keys.Enter);
        }

        public void UpdateCheckinDevice(string number, string newNumber)
        {
            var rowOfItem = this.CheckinDevicesPage.Map.KendoGrid.IndexOfGridRowContainingText(number);
            this.CheckinDevicesPage.Map.AllEditEntryButtons[rowOfItem].MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            Manager.Current.ActiveBrowser.RefreshDomTree();
            this.CheckinDevicesPage.Validator.ValidateAddPopUpAppeared();
            ExecutionDelayProvider.SleepFor(3000);
            this.CheckinDevicesPage.Map.DeviceNumber.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(newNumber);
            this.CheckinDevicesPage.Map.UpdateItemButton.MouseClick();
        }

        public void UpdateCheckinDeviceWithWrongDetails(string number, string newNumber)
        {
            this.UpdateCheckinDevice(number, newNumber);
            ExecutionDelayProvider.SleepFor(3000);
            this.CheckinDevicesPage.Map.CancelChangesToItemButton.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
        }
    }
}