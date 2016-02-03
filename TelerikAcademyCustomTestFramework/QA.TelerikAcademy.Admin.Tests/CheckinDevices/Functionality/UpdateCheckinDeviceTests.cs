namespace QA.TelerikAcademy.Admin.Tests.CheckinDevices.Functionality
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Core.Constants.Attributes;
    using Core.Constants.Pages;
    using Core.Facades;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;

    #endregion

    [TestClass]
    public class UpdateCheckinDeviceTests : BaseTest
    {
        private User currentuser;

        public CheckinDevicesService CheckinDeviceService { get; set; }

        [TestInitialize]
        public override void TestInit()
        {
            this.CheckinDeviceService = new CheckinDevicesService();
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
        [TestCaseId(658)]
        public void EditCheckinDeviceWithValidDetailsUpdatesTheEntryWithTheNewDetails()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.CheckinDeviceService.CheckinDevicesPage.Navigate();

            this.CheckinDeviceService.AddCheckinDevice(CheckinDevicesConstants.ValidNumber);
            this.CheckinDeviceService.UpdateCheckinDevice(CheckinDevicesConstants.ValidNumber,
                CheckinDevicesConstants.ValidNumberForUpdate);

            var isDeviceUpdated = this.CheckinDeviceService.CheckinDevicesPage.Map.KendoGrid
                .GridContainsText(CheckinDevicesConstants.ValidNumberForUpdate);

            this.CheckinDeviceService.DeleteCheckinDevice(CheckinDevicesConstants.ValidNumberForUpdate);

            Assert.IsTrue(isDeviceUpdated);
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        [TestCaseId(662)]
        public void EditCheckinDeviceWithInvalidDetailsDoesNotChangeTheEntry()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.CheckinDeviceService.CheckinDevicesPage.Navigate();

            this.CheckinDeviceService.AddCheckinDevice(CheckinDevicesConstants.ValidNumber);
            this.CheckinDeviceService.UpdateCheckinDeviceWithWrongDetails(CheckinDevicesConstants.ValidNumber,
                CheckinDevicesConstants.ValidNumberForUpdate);

            var isOldDevicePresent = this.CheckinDeviceService.CheckinDevicesPage.Map.KendoGrid
                .GridContainsText(CheckinDevicesConstants.ValidNumber);
            var isNewDevicePresent = this.CheckinDeviceService.CheckinDevicesPage.Map.KendoGrid
                .GridContainsText(CheckinDevicesConstants.ValidNumberForUpdate);

            this.CheckinDeviceService.DeleteCheckinDevice(CheckinDevicesConstants.ValidNumber);

            Assert.IsTrue(isOldDevicePresent);
            Assert.IsFalse(isNewDevicePresent);
        }
    }
}