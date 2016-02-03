namespace QA.TelerikAcademy.Admin.Tests.TrainingRooms.Functionality
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Core.Constants.Attributes;
    using Core.Enumerations;
    using Core.Facades;
    using Core.Factories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    [TestClass]
    public class UpdateTrainingRoomTests : BaseTest
    {
        private User currentuser;

        public TrainingRoomService TrainingRoomService { get; set; }

        [TestInitialize]
        public override void TestInit()
        {
            this.TrainingRoomService = new TrainingRoomService();
            this.currentuser = new TestUser();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            AcademyLoginProvider.Instance.Logout();
            Manager.Current.ActiveBrowser.Close();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(661)]
        public void EditTrainingRoomWithValidDetailsUpdatesTheEntryWithTheNewDetails()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.TrainingRoomService.TrainingRoomsPage.Navigate();

            var trainingRoomToUpdate = TrainingRoomsFactory.Get(TrainingRoomType.Valid);
            var newTrainingRoom = TrainingRoomsFactory.Get(TrainingRoomType.ValidForMultiAdd);

            this.TrainingRoomService.AddItem(trainingRoomToUpdate);
            ExecutionDelayProvider.SleepFor(3000);
            this.TrainingRoomService.EditItem(trainingRoomToUpdate, newTrainingRoom);

            var isOldRoomPresent =
                this.TrainingRoomService.TrainingRoomsPage.Map.KendoGrid.GridContainsText(trainingRoomToUpdate.Name);
            var isNewRoomPresent =
                this.TrainingRoomService.TrainingRoomsPage.Map.KendoGrid.GridContainsText(newTrainingRoom.Name);

            this.TrainingRoomService.RemoveItem(newTrainingRoom);

            Assert.IsFalse(isOldRoomPresent);
            Assert.IsTrue(isNewRoomPresent);
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(665)]
        public void EditTrainingRoomWithInvalidDetailsDoesNotChangeTheEntry()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.TrainingRoomService.TrainingRoomsPage.Navigate();

            var trainingRoomToUpdate = TrainingRoomsFactory.Get(TrainingRoomType.Valid);
            var newTrainingRoom = TrainingRoomsFactory.Get(TrainingRoomType.BlankName);

            this.TrainingRoomService.AddItem(trainingRoomToUpdate);
            ExecutionDelayProvider.SleepFor(3000);
            this.TrainingRoomService.EditItemWithInvalidDetails(trainingRoomToUpdate, newTrainingRoom);

            var isOldRoomPresent =
                this.TrainingRoomService.TrainingRoomsPage.Map.KendoGrid.GridContainsText(trainingRoomToUpdate.Name);
            var isNewRoomPresent =
                this.TrainingRoomService.TrainingRoomsPage.Map.KendoGrid.GridContainsText(newTrainingRoom.Name);

            Assert.IsTrue(isOldRoomPresent);
            Assert.IsFalse(isNewRoomPresent);
        }
    }
}