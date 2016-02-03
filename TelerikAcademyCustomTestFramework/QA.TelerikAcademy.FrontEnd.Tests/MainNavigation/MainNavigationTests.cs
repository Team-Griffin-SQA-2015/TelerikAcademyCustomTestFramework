namespace QA.TelerikAcademy.FrontEnd.Tests.MainNavigation
{
    #region using directives

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
    public class MainNavigationTests : BaseTest
    {
        private User currentUser;

        public MainService MainService { get; set; }

        public override void TestInit()
        {
            this.MainService = new MainService();
            this.currentUser = new TestUser();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            AcademyLoginProvider.Instance.Logout();
            Manager.Current.ActiveBrowser.Close();
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void HomeButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.AdminButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.HomepageButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.HomePageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void UsernameButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.UsernameButton.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.TeamGriffinProfilePageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void CoursesButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.CoursesButton.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.CoursesPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void ForumButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.ForumButton.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.ForumPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void AdminButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.AdminButton.MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.AdministrationPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void CalendarButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.UsernameButton.MouseHover();
            this.MainService.MainPage.Map.CalendarButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.CalendarPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void FriendsButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.UsernameButton.MouseHover();
            this.MainService.MainPage.Map.FriendsButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.FriendsPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void MessagesButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.UsernameButton.MouseHover();
            this.MainService.MainPage.Map.MessagesButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.MessagesPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void TeamworkButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.UsernameButton.MouseHover();
            this.MainService.MainPage.Map.TeamworkButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.TeamworkListPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void HomeworkEvaluationButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.UsernameButton.MouseHover();
            this.MainService.MainPage.Map.HomeworkEvaluationButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.HomeworkEvaluationPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void SettingsButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.UsernameButton.MouseHover();
            this.MainService.MainPage.Map.SettingsButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.SettingsPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void ExitButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.UsernameButton.MouseHover();
            this.MainService.MainPage.Map.ExitButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.LoginPageTitle);
            AcademyLoginProvider.Instance.LoginUser(this.currentUser);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void CandidateButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.TelerikAcademyButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.CandidateButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.CandidatePageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void EntaranceExamButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.TelerikAcademyButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.EntaranceExamButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.CandidatePageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void CourseTracksButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.TelerikAcademyButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.CourseTracksButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.CourseTracksPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void ArchiveTracksButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.TelerikAcademyButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.ArchiveTracksButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.ArchiveTracksPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void ArcherHomeworkEvalButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.CoursesButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.ArcherHomeworkEvalButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.ArcherHomeworkEvalPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void TestCourseTwoButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.CoursesButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.TestCourseTwoButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.TestCourseTwoPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void KidsAcademyCoursesButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.CoursesButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.KidsAcademyCoursesButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.KidsAcademyCoursesPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void TestCategory1Button()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.ForumButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.TestCategory1Button.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.ForumTestCategory1PageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void TestCategory2Button()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.ForumButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.TestCategory2Button.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.ForumTestCategory2PageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void AaaaaaButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.ForumButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.AaaaaaButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.AaaaaaPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void MyTestForumCategoryButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.ForumButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.MyTestForumCategoryButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.ForumMyTestCategoryPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void FeedbackButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.HelpButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.FeedbackButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.FeedbackPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void TermsAndConditionsButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.HelpButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.TermsAndConditionsButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageUrl(MainPageConstants.TermsAndConditionsPageUrl);
            Manager.Current.ActiveBrowser.Close();
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void AcademyWebSiteButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.HelpButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.AcademyWebSiteButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.AcademyWebSitePageTitle);
            Manager.Current.ActiveBrowser.Close();
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void BgCoderButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.HelpButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.BgCoderButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.BgcoderSitePageTitle);
            Manager.Current.ActiveBrowser.Close();
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void SiteInformationButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.HelpButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.SiteInformationButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.InformationAboutTheSitePageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void AdminCalendarButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.AdminButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.AdminCalendarButton.Click();
            ExecutionDelayProvider.SleepFor(2000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.CalendarPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void PublicCalendarButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.AdminButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.PublicCalendarButton.Click();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.PublicCalendarPageTitle);
            this.MainService.MainPage.Navigate();
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void CoursesAndLecturesButtonCoursesAndLecturesButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.AdminButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.CoursesAndLecturesButton.Click();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.CoursesAndLecturesPageTitle);
            this.MainService.MainPage.Navigate();
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void StudentsInCourseButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.AdminButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.StudentsInCourseButton.Click();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.StudentsInCoursesPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void CertificatesRequestsButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.AdminButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.CertificatesRequestsButton.Click();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.CertificateRequestsPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void BugsInMaterialsButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.AdminButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.BugsInMaterialsButton.Click();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.BugsInMaterialsPageTitle);
        }

        [TestMethod, Owner(Owners.PlamenPaunov), Priority(Priorities.Medium), TestCategory(Modules.Navigation)]
        public void ComplexSearchButton()
        {
            this.MainService.NavigateToMainPage(this.currentUser);
            this.MainService.MainPage.Map.AdminButton.MouseHover();
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Map.ComplexSearchButton.Click();
            ExecutionDelayProvider.SleepFor(3000);
            this.Browser.RefreshDomTree();
            this.MainService.MainPage.Validator.ValidatePageTitle(MainPageConstants.ComplexSearchPageTitle);
        }
    }
}