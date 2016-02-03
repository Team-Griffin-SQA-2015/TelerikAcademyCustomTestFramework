namespace QA.TelerikAcademy.Admin.Tests.Settings
{
    #region using directives

    using ArtOfTest.Common;
    using ArtOfTest.WebAii.Controls.HtmlControls;

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
    public class SettingsTests : BaseTest
    {
        private User user;

        public SettingsFacade SettingsFacade { get; set; }

        public override void TestInit()
        {
            this.user = new TestUser();
            this.SettingsFacade = new SettingsFacade();
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void SettingValueTrueOfCandidatePeriodShouldShowCandidateNowButtonAtHomePage()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodNameCell.Wait.ForVisible();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodEditLink.Wait.ForVisible();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.ValueTextTrue, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.IsInSoftwareAcademyCandidatePeriodDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText, KendoWindowConstants.ValueTextTrue, StringCompareType.Exact);
            this.SettingsFacade.NavigateToMainPage();
            this.Browser.WaitUntilReady();

            this.SettingsFacade.MainPage.Map.FirstCourseInstance.Wait.ForExists();
            this.SettingsFacade.MainPage.Map.FirstCourseInstance.AssertIsVisible();
            this.SettingsFacade.MainPage.Map.SecondCourseInstance.Wait.ForExists();
            this.SettingsFacade.MainPage.Map.SecondCourseInstance.AssertIsVisible();
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void SettingValueFalseOfCandidatePeriodShouldShowFirstAndSecondHomePageCourseInstances()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodNameCell.Wait.ForVisible();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodEditLink.Wait.ForVisible();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.ValueTextFalse, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.IsInSoftwareAcademyCandidatePeriodDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText, KendoWindowConstants.ValueTextFalse, StringCompareType.Exact);
            this.SettingsFacade.NavigateToMainPage();
            this.Browser.WaitUntilReady();

            this.SettingsFacade.MainPage.Map.FirstCourseInstance.AssertIsNotPresent();
            this.SettingsFacade.MainPage.Map.SecondCourseInstance.AssertIsNotPresent();
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void
            SettingValueTrueOfCandidateFormOpenedShouldMakeCandidateFormAvailableByClickingCandidateNowHomePageButton()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidateFormOpenedNameCell.Wait.ForVisible();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidateFormOpenedEditLink.Wait.ForVisible();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.ValueTextTrue, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.IsSoftwareAcademyCandidateFormOpenedDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText, KendoWindowConstants.ValueTextTrue, StringCompareType.Exact);
            this.SettingsFacade.NavigateToCandidateFormPage();
            this.Browser.WaitUntilReady();

            Assert.AreEqual(this.SettingsFacade.CandidateFormPage.GetUrl(), this.Browser.Url);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void
            SettingValueFalseOfCandidateFormOpenedShouldMakeCandidateFormUnavailableByClickingCandidateNowHomePageButton
            ()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidateFormOpenedNameCell.Wait.ForVisible();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidateFormOpenedEditLink.Wait.ForVisible();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.ValueTextFalse, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.IsSoftwareAcademyCandidateFormOpenedDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText, KendoWindowConstants.ValueTextFalse, StringCompareType.Exact);
            this.SettingsFacade.NavigateToCandidateFormPage();
            this.Browser.WaitUntilReady();

            Assert.AreNotEqual(this.SettingsFacade.CandidateFormPage.GetUrl(), this.Browser.Url);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void SettingValueTrueOfKidsAcademyRegistrationFormOpenedShouldMakeKidsAcademyRegistrationFormAvailable()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KidsCandidateFormOpenedEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.ValueTextTrue, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.IsKidsAcademyRegistraionFormOpenedDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText, KendoWindowConstants.ValueTextTrue, StringCompareType.Exact);
            this.SettingsFacade.NavigateToKidsCandidateFormPage();
            this.Browser.WaitUntilReady();

            Assert.AreEqual(this.SettingsFacade.KidsCandidateFormPage.GetUrl(), this.Browser.Url);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void SettingValueFalseOfKidsAcademyRegistrationFormOpenedShouldMakeKidsAcademyRegistrationFormUnavailable
            ()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KidsCandidateFormOpenedEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.ValueTextFalse, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.IsKidsAcademyRegistraionFormOpenedDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText, KendoWindowConstants.ValueTextFalse, StringCompareType.Exact);
            this.SettingsFacade.NavigateToKidsCandidateFormPage();
            this.Browser.WaitUntilReady();

            Assert.AreNotEqual(this.SettingsFacade.KidsCandidateFormPage.GetUrl(), this.Browser.Url);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void SettingValueTrueOfKidsAcademyCandidatePeriodShouldMakeKidsAcademyCandidatingAvailable()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KidsCandidateFormOpenedEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.ValueTextTrue, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.IsKidsAcademyRegistraionFormOpenedDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText, KendoWindowConstants.ValueTextTrue, StringCompareType.Exact);
            this.SettingsFacade.NavigateToKidsCandidateFormPage();
            this.Browser.WaitUntilReady();

            Assert.AreEqual(this.SettingsFacade.KidsCandidateFormPage.GetUrl(), this.Browser.Url);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void SettingValueFalseOfKidsAcademyCandidatePeriodShouldMakeKidsAcademyCandidatingAvailable()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KidsCandidateFormOpenedEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.ValueTextFalse, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.IsKidsAcademyRegistraionFormOpenedDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText, KendoWindowConstants.ValueTextFalse, StringCompareType.Exact);
            this.SettingsFacade.NavigateToKidsCandidateFormPage();
            this.Browser.WaitUntilReady();

            Assert.AreNotEqual(this.SettingsFacade.KidsCandidateFormPage.GetUrl(), this.Browser.Url);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void ChangingFirstHomePageCourseInstanceShouldSuccessfullyUpdateHomePageCourseInstances()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.FirstHomePageCourseInstanceEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.FirstHomePageCourseInstanceText, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.FirstHomePageCourseInstanceDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText,
                    KendoWindowConstants.FirstHomePageCourseInstanceText,
                    StringCompareType.Exact);
            this.SettingsFacade.NavigateToMainPage();
            this.Browser.WaitUntilReady();

            this.SettingsFacade.MainPage.Map.FirstCourseInstance.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.FirstHomePageCourseInstanceText);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void ChangingSecondHomePageCourseInstanceShouldSuccessfullyUpdateHomePageCourseInstances()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.SecondHomePageCourseInstanceEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.SecondHomePageCourseInstanceText, 50, 100, true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.SecondHomePageCourseInstanceDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText,
                    KendoWindowConstants.SecondHomePageCourseInstanceText,
                    StringCompareType.Exact);
            this.SettingsFacade.NavigateToMainPage();
            this.Browser.WaitUntilReady();

            this.SettingsFacade.MainPage.Map.SecondCourseInstance.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.SecondHomePageCourseInstanceText);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void ChangingCandidateOverTextShouldChangeTextThatIsShowedWhenCandidateFormIsClosed()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);

            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodOverTextEditLink.MouseClick();
            ExecutionDelayProvider.SleepFor(DelayConstants.ThreeSecondsDelay);
            this.Browser.RefreshDomTree();
            this.Browser.Actions.SetText(this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText, string.Empty);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.Focus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowValueText.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(KendoWindowConstants.SoftwareAcademyCandidatePeriodOverText,
                50,
                100,
                true);
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.UpdateButtonText);
            this.Browser.Window.SetFocus();
            this.SettingsFacade.AdminSettingsPage.Map.KendoWindowUpdateButton.MouseClick();
            this.Browser.RefreshDomTree();
            this.SettingsFacade.AdminSettingsPage.Map.SoftwareAcademyCandidatePeriodOverTextDataCell.ControlAssert()
                .StringValue(KendoWindowConstants.CellText,
                    KendoWindowConstants.SoftwareAcademyCandidatePeriodOverText,
                    StringCompareType.Exact);
            this.SettingsFacade.NavigateToCandidateFormPage();
            this.Browser.WaitUntilReady();

            this.SettingsFacade.CandidateFormPage.Map.CongratsText.AssertContent()
                .TextContent(StringCompareType.Contains, KendoWindowConstants.SoftwareAcademyCandidatePeriodOverText);
        }

        // All tests under this comment line are in status PENDING, because of temporary unavailability of Telerik Academy Learning System (TALS) Forum functionalities
        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void ChangingValueOfForumPointsUpVoteShouldRespondReasonablyByGivingForumUpVote()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void ChangingValueOfForumPointsDownVoteShouldRespondReasonablyByGivingForumDownVote()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void ChangingValueOfForumPointsUpVotePointsLimitShouldRangePointsUpLimitGivenToForumPost()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void ChangingValueOfForumPointsDownVotePointsLimitShouldRangePointsDownLimitGivenToForumPost()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void
            ChangingValueOfForumPointsHavingAnswerSelectedAsTheBestShouldChangeRespectivelyGivenPointsToBestAnswer()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void ChangingValueOfForumPointsUsefulPostShouldChangeRespectivelyGivenPointsToSingleUsefulPost()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);
        }

        [TestMethod]
        [Owner(Owners.LyudmilNikodimov)]
        [Priority(Priorities.Urgent)]
        [TestCategory(Modules.MainModules)]
        public void ChangingValueOfForumPointsUsefulPostPointsLimitShouldRangeUsefulPostPoints()
        {
            this.SettingsFacade.NavigateToAdminSettingsPage(this.user);
        }
    }
}