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

    #endregion

    [TestClass]
    public class DeleteTrainingRoomTests : BaseTest
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
        [TestCaseId(657)]
        public void VerifyThatClickingTheDeleteButtonInTheGridRemovesTheEntry()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.TrainingRoomService.TrainingRoomsPage.Navigate();

            var trainingRoom = TrainingRoomsFactory.Get(TrainingRoomType.Valid);
            this.TrainingRoomService.AddItem(trainingRoom);
            this.TrainingRoomService.RemoveItem(trainingRoom);

            var isRoomRemoved = !this.TrainingRoomService.TrainingRoomsPage.Map.KendoGrid
                .GridContainsText(trainingRoom.Name);

            Assert.IsTrue(isRoomRemoved);
        }
    }
}