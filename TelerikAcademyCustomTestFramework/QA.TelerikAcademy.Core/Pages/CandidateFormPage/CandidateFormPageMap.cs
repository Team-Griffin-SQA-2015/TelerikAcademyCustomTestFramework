namespace QA.TelerikAcademy.Core.Pages.CandidateFormPage
{
    #region using directives

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using TestingFramework.Core.Base;
    using TestingFramework.Core.Extensions;

    #endregion

    public class CandidateFormPageMap : BaseElementMap
    {
        public HtmlControl CandidateFormH1Tag
            =>
                this.Find.ByExpression<HtmlControl>(
                    "TextContent=Кандидатстване за \"Софтуерната академия на Телерик\"",
                    "tagname=h1",
                    "class=sectionTitle");

        public HtmlDiv CongratsText => this.Find.ById<HtmlDiv>("CongratsText");

        public HtmlControl FieldsetPersonalData => this.Find.ById<HtmlControl>("PersonalData");

        public HtmlControl LegendPersonalData
            =>
                this.FieldsetPersonalData.Find.ByExpression<HtmlControl>("tagname=legend",
                    "Лични данни".TextContentContaining());

        public HtmlInputText FirstName => this.FieldsetPersonalData.Find.ById<HtmlInputText>("FirstName");

        public HtmlInputText SecondName => this.FieldsetPersonalData.Find.ById<HtmlInputText>("SecondName");

        public HtmlInputText LastName => this.FieldsetPersonalData.Find.ById<HtmlInputText>("LastName");

        public HtmlInputFile Picture => this.FieldsetPersonalData.Find.ById<HtmlInputFile>("Picture");

        public HtmlInputRadioButton MaleGender
            => this.FieldsetPersonalData.Find.ById<HtmlInputRadioButton>("IsMale_True");

        public HtmlInputRadioButton FemaleGender
            => this.FieldsetPersonalData.Find.ById<HtmlInputRadioButton>("IsMale_False");

        public HtmlUnorderedList WorkEducationStatusId
            => this.FieldsetPersonalData.Find.ById<HtmlUnorderedList>("WorkEducationStatusId_listbox");

        public HtmlInputText Birthday => this.FieldsetPersonalData.Find.ById<HtmlInputText>("BirthDay");

        public HtmlInputText Email => this.FieldsetPersonalData.Find.ById<HtmlInputText>("Email");

        public HtmlInputText Phone => this.FieldsetPersonalData.Find.ById<HtmlInputText>("Phone");

        public HtmlUnorderedList City
            => this.FieldsetPersonalData.Find.ById<HtmlUnorderedList>("CityId_listbox");

        public HtmlUnorderedList University
            => this.FieldsetPersonalData.Find.ById<HtmlUnorderedList>("UniversityId_listbox");

        public HtmlInputText Faculty => this.FieldsetPersonalData.Find.ById<HtmlInputText>("FacultyName");

        public HtmlInputText Speciality => this.FieldsetPersonalData.Find.ById<HtmlInputText>("UniversitySpeciality");

        public HtmlInputText School => this.FieldsetPersonalData.Find.ById<HtmlInputText>("SchoolName");

        public HtmlControl FieldsetDocumentsSection => this.Find.ById<HtmlControl>("DocumentsSection");

        public HtmlControl LegendDocumentsSection
            =>
                this.FieldsetDocumentsSection.Find.ByExpression<HtmlControl>("tagname=legend",
                    "Документи".TextContentContaining());

        public HtmlInputFile Cv => this.FieldsetDocumentsSection.Find.ById<HtmlInputFile>("CV");

        public HtmlInputFile CoverLetter => this.FieldsetDocumentsSection.Find.ById<HtmlInputFile>("CoverLetter");

        public HtmlInputFile AdditionalDocuments
            => this.FieldsetDocumentsSection.Find.ById<HtmlInputFile>("AdditionalDocuments");

        public HtmlInputCheckBox AcceptTerms => this.Find.ById<HtmlInputCheckBox>("AcceptTerms");

        public HtmlInputSubmit Submit => this.Find.ById<HtmlInputSubmit>("SendButton");

        public HtmlSpan AcceptTermsValidationMessage => this.Find.ByExpression<HtmlSpan>("data-valmsg-for=AcceptTerms");

        public HtmlSpan PictureValidationMessage => this.Find.ByExpression<HtmlSpan>("data-valmsg-for=Picture");

        public HtmlSpan WorkEducationStatusIdValidationMessage
            => this.Find.ByExpression<HtmlSpan>("data-valmsg-for=WorkEducationStatusId");

        public HtmlSpan BirthdayValidationMessage => this.Find.ByExpression<HtmlSpan>("data-valmsg-for=BirthDay");

        public HtmlSpan EmailValidationMessage => this.Find.ById<HtmlSpan>("Email-error");

        public HtmlSpan PhoneValidationMessage => this.Find.ById<HtmlSpan>("Phone-error");

        public HtmlSpan CityValidationMessage => this.Find.ByExpression<HtmlSpan>("data-valmsg-for=CityId");

        public HtmlSpan UniversityValidationMessage => this.Find.ById<HtmlSpan>("UniversityId");

        public HtmlSpan SchoolValidationMessage => this.Find.ById<HtmlSpan>("SchoolName-error");

        public HtmlSpan CvValidationMessage => this.Find.ByExpression<HtmlSpan>("data-valmsg-for=CV");

        public HtmlSpan CoverLetterValidationMessage => this.Find.ByExpression<HtmlSpan>("data-valmsg-for=CoverLetter");

        public HtmlSpan FirstNameValidationError => this.Find.ById<HtmlSpan>("FirstName-error");

        public HtmlSpan SecondNameValidationError => this.Find.ById<HtmlSpan>("SecondName-error");

        public HtmlSpan LastNameValidationError => this.Find.ById<HtmlSpan>("LastName-error");

        public HtmlListItem SelectListItem(HtmlUnorderedList list, string partialText)
        {
            var itemToSelect = list.Find.ByExpression<HtmlListItem>(partialText.TextContentContaining());
            return itemToSelect;
        }
    }
}