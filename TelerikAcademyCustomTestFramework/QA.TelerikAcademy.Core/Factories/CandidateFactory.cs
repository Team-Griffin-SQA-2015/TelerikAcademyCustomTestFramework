namespace QA.TelerikAcademy.Core.Factories
{
    #region using directives

    using System;

    using Constants.Pages;

    using Enumerations;

    using TestingFramework.Core.Data;

    #endregion

    public static class CandidateFactory
    {
        public static Candidate Get(CandidateType candidate)
        {
            switch (candidate)
            {
                case CandidateType.Valid:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.ValidFirstName,
                        SecondName = SecondNameConstants.ValidSecondName,
                        LastName = LastNameConstants.ValidLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.UncheckedSearchedTerms:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = false
                    };
                case CandidateType.UnchosenPicture:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = null,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.UnselectedWorkEducationStatus:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = null,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.EmptyBirthday:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = null,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.BirthdayInThePast:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.BirthdayInThePast,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.BirthdayInTheFuture:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.BirthdayInTheFuture,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.EmptyEmail:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = string.Empty,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.InvalidEmail:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.InvalidEmailAddress,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.InvalidPhoneNumber:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.InvalidPhoneNumber,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.UnchosenCity:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = null,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.UnchosenUniversity:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = null,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.EmptySchool:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = string.Empty,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.UnchosenCv:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = null,
                        CoverLetter = CandidateFilesConstants.ValidCoverLetterFilePath,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                case CandidateType.UnchosenCoverLetter:
                    return new Candidate
                    {
                        FirstName = FirstNameConstants.DefaultFirstName,
                        SecondName = SecondNameConstants.DefaultSecondName,
                        LastName = LastNameConstants.DefaultLastName,
                        Picture = CandidateFilesConstants.ValidPictureFilePath,
                        IsMaleGender = CandidateInformationConstants.DefaultIsMaleGender,
                        WorkEducationStatusId = CandidateInformationConstants.DefaultWorkEducationStatusId,
                        Birthday = CandidateInformationConstants.DefaultBirthday,
                        Email = CandidateInformationConstants.DefaultEmail,
                        Phone = CandidateInformationConstants.DefaultPhone,
                        City = CandidateInformationConstants.DefaultCity,
                        University = CandidateInformationConstants.DefaultUniversity,
                        Faculty = CandidateInformationConstants.DefaultFaculty,
                        Speciality = CandidateInformationConstants.DefaultSpeciality,
                        School = CandidateInformationConstants.DefaultSchool,
                        Cv = CandidateFilesConstants.ValidCvFilePath,
                        CoverLetter = null,
                        AdditionalDocument = CandidateFilesConstants.ValidAdditionalDocumentFilePath,
                        AcceptTerms = true
                    };
                default:
                    throw new ArgumentException();
            }
        }
    }
}