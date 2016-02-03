namespace QA.TelerikAcademy.Admin.Tests.CheckinDevices.Functionality
{
    #region using directives

    using System.Linq;

    using ArtOfTest.WebAii.Core;

    using Core.Constants.Attributes;
    using Core.Constants.Pages;
    using Core.Facades;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    [TestClass]
    public class AddCheckinDeviceTests : BaseTest
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
        public void AddNewCheckinDevice()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.CheckinDeviceService.CheckinDevicesPage.Navigate();

            this.CheckinDeviceService.AddCheckinDevice(CheckinDevicesConstants.ValidNumber);
            this.Browser.RefreshDomTree();

            var isDeviceAdded = this.CheckinDeviceService.CheckinDevicesPage.Map.KendoGrid.DataItems
                .Any(tr => tr.Cells.Any(c => c.InnerText == CheckinDevicesConstants.ValidNumber));

            Assert.IsTrue(isDeviceAdded);
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddNewDeviceWithoutNumberDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.CheckinDeviceService.CheckinDevicesPage.Navigate();

            this.CheckinDeviceService.AddCheckinDevice(
                CheckinDevicesConstants.Invalid17CharactersLongNumber);

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.CheckinDeviceService.CheckinDevicesPage.Map.DeviceNumberValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddNewDeviceWithBlankNumberDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.CheckinDeviceService.CheckinDevicesPage.Navigate();

            this.CheckinDeviceService.AddCheckinDevice(string.Empty);

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.CheckinDeviceService.CheckinDevicesPage.Map.DeviceNumberValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddNewDeviceWithSpecialCharactersInNumberDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.CheckinDeviceService.CheckinDevicesPage.Navigate();

            this.CheckinDeviceService.AddCheckinDevice(
                CheckinDevicesConstants.InvalidSpecialCharactersNumber);

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.CheckinDeviceService.CheckinDevicesPage.Map.DeviceNumberValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddNewDeviceWithCyrillicCharactersInNumberDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.CheckinDeviceService.CheckinDevicesPage.Navigate();

            this.CheckinDeviceService.AddCheckinDevice(
                CheckinDevicesConstants.InvalidCyrillicCharactersNumber);

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.CheckinDeviceService.CheckinDevicesPage.Map.DeviceNumberValidationMessage.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.NikolaNenov)]
        [Priority(Priorities.High)]
        [TestCategory(Modules.MainModules)]
        public void AddDeviceWithSameNumberMoreThanOnceDisplaysAnError()
        {
            AcademyLoginProvider.Instance.LoginUser(this.currentuser);

            this.CheckinDeviceService.CheckinDevicesPage.Navigate();

            this.CheckinDeviceService.AddCheckinDevice(CheckinDevicesConstants.ValidNumber);
            ExecutionDelayProvider.SleepFor(3000);
            this.CheckinDeviceService.AddCheckinDevice(CheckinDevicesConstants.ValidNumber);

            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.CheckinDeviceService.CheckinDevicesPage.Map.DeviceNumberValidationMessage.AssertIsVisible();
        }
    }
}