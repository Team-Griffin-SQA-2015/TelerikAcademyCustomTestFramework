namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using System.Windows.Forms;

    using ArtOfTest.WebAii.Core;

    using Pages.LoginPage;
    using Pages.TrainingRoomsPage;

    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    public class TrainingRoomService
    {
        public TrainingRoomService()
        {
            this.LoginPage = new LoginPage();
            this.TrainingRoomsPage = new TrainingRoomsPage();
        }

        private Browser Browser => Manager.Current.ActiveBrowser;

        public LoginPage LoginPage { get; set; }

        public TrainingRoomsPage TrainingRoomsPage { get; set; }

        public void AddItem(TrainingRoom trainingRoom)
        {
            this.TrainingRoomsPage.Map.AddItemButton.MouseClick();
            this.TrainingRoomsPage.Validator.ValidateAddPopUpAppeared();
            ExecutionDelayProvider.SleepFor(3000);
            this.TrainingRoomsPage.Map.TrainingRoomName.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(trainingRoom.Name, 30);
            this.TrainingRoomsPage.Map.TrainingRoomAddress.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(trainingRoom.Address, 30);
            this.TrainingRoomsPage.Map.TrainingRoomCapacity.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(trainingRoom.Capacity, 30);
            this.TrainingRoomsPage.Map.TrainingRoomEquipment.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(trainingRoom.Equipment, 30);
            this.TrainingRoomsPage.Map.UpdateItemButton.MouseClick();
            this.Browser.RefreshDomTree();
        }

        public void RemoveItem(TrainingRoom trainingRoom)
        {
            var rowToDelete = this.TrainingRoomsPage.Map.KendoGrid.IndexOfGridRowContainingText(trainingRoom.Name);
            this.TrainingRoomsPage.Map.AllDeleteEntryButtons[rowToDelete].MouseClick();
            this.TrainingRoomsPage.Map.DeleteEntryButton.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            Manager.Current.Desktop.KeyBoard.KeyPress(Keys.Enter);
        }

        public void EditItem(TrainingRoom trainingRoomToEdit, TrainingRoom newTrainingRoom)
        {
            var rowToEdit = this.TrainingRoomsPage.Map.KendoGrid.IndexOfGridRowContainingText(trainingRoomToEdit.Name);
            this.TrainingRoomsPage.Map.AllEditEntryButtons[rowToEdit].MouseClick();
            this.Browser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(3000);
            this.TrainingRoomsPage.Map.TrainingRoomName.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(newTrainingRoom.Name, 30);
            this.TrainingRoomsPage.Map.TrainingRoomAddress.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(newTrainingRoom.Address, 30);
            this.TrainingRoomsPage.Map.TrainingRoomCapacity.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(newTrainingRoom.Capacity, 30);
            this.TrainingRoomsPage.Map.TrainingRoomEquipment.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(newTrainingRoom.Equipment, 30);
            this.TrainingRoomsPage.Map.UpdateItemButton.MouseClick();
            this.Browser.RefreshDomTree();
        }

        public void EditItemWithInvalidDetails(TrainingRoom trainingRoomToEdit, TrainingRoom newTrainingRoom)
        {
            this.EditItem(trainingRoomToEdit, newTrainingRoom);
            ExecutionDelayProvider.SleepFor(3000);
            this.TrainingRoomsPage.Map.CancelChangesToItemButton.MouseClick();
            this.Browser.RefreshDomTree();
        }
    }
}