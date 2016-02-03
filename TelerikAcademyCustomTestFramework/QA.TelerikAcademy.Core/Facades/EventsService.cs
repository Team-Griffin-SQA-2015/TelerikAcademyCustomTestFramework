namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using System.Windows.Forms;

    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using Pages.EventsPage;
    using Pages.LoginPage;

    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    public class EventsService
    {
        public EventsService()
        {
            this.LoginPage = new LoginPage();
            this.EventsPage = new EventsPage();
        }

        private Browser Browser => Manager.Current.ActiveBrowser;

        public LoginPage LoginPage { get; set; }

        public EventsPage EventsPage { get; set; }

        public void AddItemForSpecificCourse(string desciption)
        {
            this.EventsPage.Map.AddItemButton.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.EventsPage.Validator.ValidateAddPopUpAppeared();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsPage.Map.CoursesContainer.Click();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.EventsPage.Map.CoursesList.AllItems[EventsConstants.DefaultListOption].MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsPage.Map.Description.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.Desktop.KeyBoard.TypeText(EventsConstants.ValidDescription, 30);
            this.EventsPage.Map.TrainingRoomsList.SelectItem(EventsConstants.DefaultListOption);
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsPage.Map.UpdateItemButton.MouseClick();
        }

        public void AddItemForAllCourses(string description)
        {
            this.EventsPage.Map.AddItemButton.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.EventsPage.Validator.ValidateAddPopUpAppeared();
            this.EventsPage.Map.Description.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.Desktop.KeyBoard.TypeText(description, 30);
            this.EventsPage.Map.UpdateItemButton.MouseClick(MouseClickType.LeftDoubleClick);
        }

        public void RemoveItem(string description)
        {
            var rowToDelete = this.EventsPage.Map.KendoGrid.IndexOfGridRowContainingText(description);
            this.EventsPage.Map.AllDeleteEntryButtons[rowToDelete].MouseClick();
            this.EventsPage.Map.DeleteEntryButton.MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            Manager.Current.Desktop.KeyBoard.KeyPress(Keys.Enter);
        }

        public void EditItem(string oldDescription, string newDescription, int courseId, int roomId)
        {
            var rowOfItem = this.EventsPage.Map.KendoGrid.IndexOfGridRowContainingText(oldDescription);
            this.EventsPage.Map.AllEditEntryButtons[rowOfItem].MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.EventsPage.Validator.ValidateAddPopUpAppeared();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsPage.Map.CoursesContainer.Click();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.EventsPage.Map.CoursesList.AllItems[courseId].MouseClick();
            ExecutionDelayProvider.SleepFor(3000);
            this.EventsPage.Map.Description.Text = newDescription;
            this.EventsPage.Map.Description.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.Desktop.KeyBoard.TypeText(EventsConstants.ValidDescriptionForUpdate, 30);
            this.EventsPage.Map.TrainingRoomsList.SelectItem(roomId);
            this.EventsPage.Map.UpdateItemButton.MouseClick();
        }
    }
}