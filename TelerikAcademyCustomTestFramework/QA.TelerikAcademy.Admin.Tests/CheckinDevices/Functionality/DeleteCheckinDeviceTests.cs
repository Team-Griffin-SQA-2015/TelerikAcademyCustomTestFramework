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
    public class DeleteCheckinDeviceTests : BaseTest
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
        [TestCaseId(654)]
        public void VerifyThatClickingTheDeleteButtonInTheGridRemovesTheEntry()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.CheckinDeviceService.CheckinDevicesPage.Navigate();

            this.CheckinDeviceService.AddCheckinDevice(CheckinDevicesConstants.ValidNumber);
            this.CheckinDeviceService.DeleteCheckinDevice(CheckinDevicesConstants.ValidNumber);

            var isDeviceRemoved = !this.CheckinDeviceService.CheckinDevicesPage.Map.KendoGrid
                .GridContainsText(CheckinDevicesConstants.ValidNumber);

            Assert.IsTrue(isDeviceRemoved);
        }
    }
}