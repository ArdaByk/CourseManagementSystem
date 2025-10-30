using FluentValidation;
using CMS.Application.Features.Specializations.Constants;

namespace CMS.Application.Features.Specializations.Commands.Update;

public class UpdateSpecializationCommandValidator : AbstractValidator<UpdateSpecializationCommand>
{
    public UpdateSpecializationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id alanı gereklidir.");
        RuleFor(x => x.SpecializationName)
            .NotEmpty().WithMessage(SpecializationMessages.SpecializationNameRequired)
            .Length(2, 50).WithMessage(SpecializationMessages.SpecializationNameLength);
    }
}
