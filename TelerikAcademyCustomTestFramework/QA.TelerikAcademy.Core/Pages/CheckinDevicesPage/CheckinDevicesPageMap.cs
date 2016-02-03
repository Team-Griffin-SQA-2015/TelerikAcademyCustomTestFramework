namespace QA.TelerikAcademy.Core.Pages.CheckinDevicesPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    using TestingFramework.Core.Base;

    #endregion

    public class CheckinDevicesPageMap : BaseKendoGridPageMap
    {
        public HtmlInputText DeviceNumber => this.Find.ById<HtmlInputText>("DeviceNumber");

        public KendoListBox AvailableTrainingRooms => this.Find.ById<KendoListBox>("TrainingRoomId_listbox");

        public HtmlDiv DeviceNumberValidationMessage => this.Find.ById<HtmlDiv>("DeviceNumber_validationMessage");

        public HtmlInputText StartDate => this.Find.ById<HtmlInputText>("StartTime");

        public KendoInput EndDate => this.Find.ById<KendoInput>("EndTime");
    }
}