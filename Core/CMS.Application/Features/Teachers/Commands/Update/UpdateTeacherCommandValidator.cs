using FluentValidation;
using CMS.Application.Features.Teachers.Constants;

namespace CMS.Application.Features.Teachers.Commands.Update;

public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
{
    public UpdateTeacherCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id alanı zorunludur.");
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(TeacherMessages.FirstNameRequired)
            .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır.");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(TeacherMessages.LastNameRequired)
            .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.");
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage(TeacherMessages.PhoneRequired)
            .Matches("^05\\d{9}$").WithMessage(TeacherMessages.PhoneFormat);
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(TeacherMessages.EmailRequired)
            .EmailAddress().WithMessage(TeacherMessages.EmailFormat);
        RuleFor(x => x.SalaryType)
            .NotEmpty().WithMessage(TeacherMessages.SalaryTypeRequired);
        RuleFor(x => x.SalaryAmount)
            .NotEmpty().WithMessage(TeacherMessages.SalaryAmountRequired)
            .GreaterThan(0).WithMessage(TeacherMessages.SalaryAmountPositive);
        RuleFor(x => x.HiredDate)
            .NotEmpty().WithMessage(TeacherMessages.HiredDateRequired)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("İşe giriş tarihi bugünden ileri olamaz.");
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage(TeacherMessages.StatusRequired);
        RuleFor(x => x.SelectedIds)
            .NotNull().WithMessage(TeacherMessages.SpecializationRequired)
            .Must(ids => ids != null && ids.Count > 0).WithMessage(TeacherMessages.SpecializationRequired);
    }
}
