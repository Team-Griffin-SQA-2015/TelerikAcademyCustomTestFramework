namespace QA.TelerikAcademy.Core.Pages.SettingsPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Extensions;

    #endregion

    public class SettingsPageMap : BaseElementMap
    {
        public HtmlInputText FirstNameEn => this.Find.ById<HtmlInputText>("FirstNameEn");

        public HtmlInputText LastNameEn => this.Find.ById<HtmlInputText>("LastNameEn");

        public HtmlInputText FirstName => this.Find.ById<HtmlInputText>("FirstName");

        public HtmlInputText LastName => this.Find.ById<HtmlInputText>("LastName");

        public HtmlInputText Birthday => this.Find.ById<HtmlInputText>("BirthDay");

        public HtmlInputRadioButton MaleRadioButton => this.Find.ById<HtmlInputRadioButton>("MaleRadioBtn");

        public HtmlInputRadioButton FemaleRadioButton => this.Find.ById<HtmlInputRadioButton>("FemaleRadioBtn");

        public HtmlInputRadioButton UnknownGenderRadioButton => this.Find.ById<HtmlInputRadioButton>("UnknownRadioBtn");

        public HtmlInputText CityId => this.Find.ByExpression<HtmlInputText>("CityId_input".NameEqualTo());

        public HtmlInputText Phone => this.Find.ById<HtmlInputText>("Phone");

        public HtmlTextArea About => this.Find.ById<HtmlTextArea>("About");

        public HtmlInputText UniversityId => this.Find.ByName<HtmlInputText>("UniversityId_input");

        public HtmlControl UsernameLabel => this.Find.ByExpression<HtmlControl>("col-sm-8 text-left".ClassEqualTo());

        public HtmlInputSubmit SaveChanges => this.Find.ByAttributes<HtmlInputSubmit>("value=Запази промените");

        public HtmlDiv SuccessMessage => this.Find.ById<HtmlDiv>("SuccessfullySavedSettingsMessageBox");

        public HtmlDiv WarningMessage => this.Find.ByAttributes<HtmlDiv>("validation-summary-errors".ClassEqualTo());

        public HtmlSpan FieldValidationError
            => this.Find.ByExpression<HtmlSpan>("field-validation-error".ClassEqualTo());

        public HtmlInputText FacultyName => this.Find.ById<HtmlInputText>("FacultyName");

        public HtmlInputText UniversitySpeciality => this.Find.ById<HtmlInputText>("UniversitySpeciality");

        public HtmlInputText FacultyNumber => this.Find.ById<HtmlInputText>("FacultyNumber");

        public HtmlInputText SchoolName => this.Find.ById<HtmlInputText>("SchoolName");

        public HtmlInputText Website => this.Find.ById<HtmlInputText>("Website");

        public HtmlInputText SkypeUsername => this.Find.ById<HtmlInputText>("SkypeUsername");

        public HtmlInputText FacebookUrl => this.Find.ById<HtmlInputText>("FacebookUrl");

        public HtmlInputText GooglePlusUrl => this.Find.ById<HtmlInputText>("GooglePlusUrl");

        public HtmlInputText LinkedInUrl => this.Find.ById<HtmlInputText>("LinkedInUrl");

        public HtmlInputText TwitterUrl => this.Find.ById<HtmlInputText>("TwitterUrl");

        public HtmlInputText GitHubUrl => this.Find.ById<HtmlInputText>("GitHubUrl");

        public HtmlInputText StackOverflowUrl => this.Find.ById<HtmlInputText>("StackOverflowUrl");

        public HtmlControl FacultyNameError => this.Find.ById<HtmlControl>("FacultyName-error");

        public HtmlControl FacultyNumberError => this.Find.ById<HtmlControl>("FacultyNumber-error");

        public HtmlControl SchoolNameError => this.Find.ById<HtmlControl>("SchoolName-error");

        public HtmlControl UniversitySpecialtyError => this.Find.ById<HtmlControl>("UniversitySpeciality-error");

        public HtmlSpan FirstNameError => this.Find.ById<HtmlSpan>("FirstName-error");

        public HtmlSpan LastNameError => this.Find.ById<HtmlSpan>("LastName-error");

        public HtmlSpan FirstNameEnError => this.Find.ById<HtmlSpan>("FirstNameEn-error");

        public HtmlSpan LastNameEnError => this.Find.ById<HtmlSpan>("LastNameEn-error");
    }
}