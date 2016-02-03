namespace QA.TelerikAcademy.Admin.Tests.TrainingRooms.Functionality
{
    #region using directives

    using System.Linq;

    using ArtOfTest.WebAii.Core;

    using Core.Constants.Attributes;
    using Core.Constants.Pages;
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
    public class AddTrainingRoomTests : BaseTest
    {
        private User currentuser;

        public TrainingRoomService TrainingRoomsService { get; set; }

        [TestInitialize]
        public override void TestInit()
        {
            this.TrainingRoomsService = new TrainingRoomService();
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
        public void AddNewTrainingRoom()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.Valid));
            this.Browser.RefreshDomTree();

            var isTrainingRoomAdded = this.TrainingRoomsService.TrainingRoomsPage.Map.KendoGrid.DataItems
                .Any(tr => tr.Cells.Any(c => c.InnerText == TrainingRoomConstants.ValidName));

            Assert.IsTrue(isTrainingRoomAdded);
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWithSameDetailsMoreThanOnceDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.ValidForMultiAdd));
            this.Browser.RefreshDomTree();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.ValidForMultiAdd));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.NameValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWithOutNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.BlankName));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.NameValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWith51CharactersLongNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.TooLongName));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.NameValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWithSpecialCharacterInNameDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.SpecialCharactersName));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.NameValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWith251CharactersLongAddressDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.TooLongAddress));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.AddressValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWithSpecialCharactersInAddressDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.SpecialCharactersAddress));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.AddressValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWith51CharactersLongCapacityDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.TooLongCapacity));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.CapacityValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWithLettersInCapacityDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.LettersCapacity));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.CapacityValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWithSpecialCharactersInCapacityDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.SpecialCharactersCapacity));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.CapacityValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWith251CharactersLongEquipmentDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.TooLongEquipment));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.EquipmentValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.Medium)]
        [TestCategory(Modules.MainModules)]
        public void AddNewTrainingRoomWithSpecialCharactersInEquipmentDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);
            this.TrainingRoomsService.TrainingRoomsPage.Navigate();

            this.TrainingRoomsService.AddItem(
                TrainingRoomsFactory.Get(TrainingRoomType.SpecialCharactersEquipment));

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.TrainingRoomsService.TrainingRoomsPage.Map.CapacityValidationMessage.AssertIsVisible();
        }
    }
}