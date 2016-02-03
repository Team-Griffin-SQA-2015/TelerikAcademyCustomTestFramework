namespace QA.TelerikAcademy.Admin.Tests.Seasons.Functionality
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
    using TestingFramework.Core.Providers;

    #endregion

    [TestClass]
    public class AddNewSeasonFunctionalityTest : BaseTest
    {
        private User currentUser;

        public SeasonsService SeasonsService { get; set; }

        public override void TestInit()
        {
            this.SeasonsService = new SeasonsService();
            this.currentUser = new TestUser();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            AcademyLoginProvider.Instance.Logout();
            Manager.Current.ActiveBrowser.Close();
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.MainModules)]
        public void TryToClickSometing()
        {
            this.SeasonsService.OpenEditNewSeasonWindow(this.currentUser);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.SoftwareAcademy)]
        public void VerifyThatWhenAddNewSeasonItPresentsAfterThat()
        {
            this.SeasonsService.NavigateToSeasonsPage(this.currentUser);
            //this.SeasonsService.DeleteSeasonWithName(SeasonsConstants.ValidSeasonName);
            this.SeasonsService.EditNewSeasonWithName(SeasonsConstants.ValidSeasonName, this.currentUser);

            var seasonName =
                this.SeasonsService.SeasonsPage.Map.KendoGrid.DataItems.FirstOrDefault().ChildNodes[1].InnerText;
            this.Browser.RefreshDomTree();
            this.SeasonsService.DeleteSeasonWithName(SeasonsConstants.ValidSeasonName);
            Assert.AreEqual(seasonName, SeasonsConstants.ValidSeasonName);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.SoftwareAcademy)]
        public void VerifyThatWhenAddNewSeasonTwiceErrorMessageIsShown()
        {
            this.SeasonsService.EditNewSeasonWithName(SeasonsConstants.ValidSeasonName, this.currentUser, false);
            this.SeasonsService.SeasonsPage.Map.AddNewSeason.Click();
            this.SeasonsService.SeasonsPage.Map.UpdateSeasonesChanges.Wait.ForVisible();
            ExecutionDelayProvider.SleepFor(DelayConstants.TwoSecondsDelay);
            this.SeasonsService.SeasonsPage.Map.SeasonName.MouseClick();
            Manager.Current.Desktop.KeyBoard.TypeText(SeasonsConstants.ValidSeasonName);
            this.SeasonsService.SeasonsPage.Map.UpdateSeasonesChanges.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.TwoSecondsDelay);
            this.Browser.RefreshDomTree();

            var warningMessage = this.SeasonsService.SeasonsPage.Map.ValidationMessage.InnerText;

            this.SeasonsService.SeasonsPage.Map.CancelChangesToItemButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SeasonsService.DeleteSeasonWithName(SeasonsConstants.ValidSeasonName);

            Assert.AreEqual(warningMessage, SeasonsConstants.ThereHaveSuchSeasonMessage);
        }
    }
}