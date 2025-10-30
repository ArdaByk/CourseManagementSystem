using FluentValidation;
using CMS.Application.Features.Students.Constants;

namespace CMS.Application.Features.Students.Commands.Update;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id alanı gerekli.");
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(StudentMessages.FirstNameRequired)
            .MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(StudentMessages.LastNameRequired)
            .MinimumLength(2).WithMessage("Soyisim en az 2 karakter olmalıdır.");
        RuleFor(x => x.NationalId)
            .NotEmpty().WithMessage(StudentMessages.NationalIdRequired)
            .Length(11).WithMessage(StudentMessages.NationalIdFormat)
            .Matches("^[0-9]+$").WithMessage("TC Kimlik numarası sayısal olmalıdır.");
        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage(StudentMessages.GenderRequired);
        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage(StudentMessages.BirthDateRequired)
            .LessThan(DateTime.Now).WithMessage("Doğum tarihi gelecekten olamaz.");
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage(StudentMessages.PhoneRequired)
            .Matches("^05\\d{9}$").WithMessage(StudentMessages.PhoneFormat);
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(StudentMessages.EmailRequired)
            .EmailAddress().WithMessage(StudentMessages.EmailFormat);
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(StudentMessages.AddressRequired);
        RuleFor(x => x.EmergencyContactName)
            .NotEmpty().WithMessage(StudentMessages.EmergencyContactNameRequired);
        RuleFor(x => x.EmergencyContactPhone)
            .NotEmpty().WithMessage(StudentMessages.EmergencyContactPhoneRequired)
            .Matches("^05\\d{9}$").WithMessage("Acil durum telefonu hatalı.");
        RuleFor(x => x.EmergencyContactRelation)
            .NotEmpty().WithMessage(StudentMessages.EmergencyContactRelationRequired);
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage(StudentMessages.StatusRequired);
        RuleFor(x => x.PhotoPath)
            .NotEmpty().WithMessage(StudentMessages.PhotoPathRequired);
    }
}
