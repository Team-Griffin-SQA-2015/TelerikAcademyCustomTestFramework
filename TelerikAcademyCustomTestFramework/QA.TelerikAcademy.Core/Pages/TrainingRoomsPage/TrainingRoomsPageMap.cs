namespace QA.TelerikAcademy.Core.Pages.TrainingRoomsPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;

    #endregion

    public class TrainingRoomsPageMap : BaseKendoGridPageMap
    {
        public HtmlInputText TrainingRoomName => this.Find.ById<HtmlInputText>("Name");

        public HtmlInputText TrainingRoomAddress => this.Find.ById<HtmlInputText>("Address");

        public HtmlInputText TrainingRoomCapacity => this.Find.ById<HtmlInputText>("Capacity");

        public HtmlInputText TrainingRoomEquipment => this.Find.ById<HtmlInputText>("Equipment");

        public HtmlDiv NameValidationMessage => this.Find.ById<HtmlDiv>("Name_validationMessage");

        public HtmlDiv AddressValidationMessage => this.Find.ById<HtmlDiv>("Address_validationMessage");

        public HtmlDiv CapacityValidationMessage => this.Find.ById<HtmlDiv>("Capacity_validationMessage");

        public HtmlDiv EquipmentValidationMessage => this.Find.ById<HtmlDiv>("Equipment_validationMessage");
    }
}