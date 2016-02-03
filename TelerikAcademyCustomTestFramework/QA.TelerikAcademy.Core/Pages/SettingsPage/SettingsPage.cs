namespace QA.TelerikAcademy.Core.Pages.SettingsPage
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using TestingFramework.Core.Data;

    #endregion

    public class SettingsPage
    {
        public const string Url = @"http://stage.telerikacademy.com/Users/Profile/Settings";

        public SettingsPageMap Map => new SettingsPageMap();

        public SettingsPageValidator Validator => new SettingsPageValidator();

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(Url);
        }

        public void UpdateSettings(User user)
        {
            this.Map.FirstName.Text = user.FirstName ?? FirstNameConstants.DefaultFirstName;
            this.Map.LastName.Text = user.LastName ?? LastNameConstants.DefaultLastName;
            this.Map.FirstNameEn.Text = user.FirstNameEn;
            this.Map.LastNameEn.Text = user.LastNameEn;
            this.Map.Birthday.Text = user.Birthday;
            this.Map.CityId.Text = user.CityId;
            this.Map.Phone.Text = user.Phone;
            this.Map.About.Text = user.About;
            this.Map.UniversityId.Text = user.UniversityId;
            this.Map.FacultyName.Text = user.FacultyName;
            this.Map.UniversitySpeciality.Text = user.UniversitySpecialty;
            this.Map.FacultyNumber.Text = user.FacultyNumber;
            this.Map.SchoolName.Text = user.SchoolName;
            this.Map.Website.Text = user.Website;
            this.Map.SkypeUsername.Text = user.SkypeUsername;
            this.Map.FacebookUrl.Text = user.FacebookUrl;
            this.Map.GooglePlusUrl.Text = user.GooglePlusUrl;
            this.Map.LinkedInUrl.Text = user.LinkedInUrl;
            this.Map.TwitterUrl.Text = user.TwitterUrl;
            this.Map.GitHubUrl.Text = user.GitHubUrl;
            this.Map.StackOverflowUrl.Text = user.StackOverflowUrl;
            this.Map.SaveChanges.Click();
        }

        public void SaveChanges()
        {
            this.Map.SaveChanges.Click();
        }
    }
}