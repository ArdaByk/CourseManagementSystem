using FluentValidation;
using CMS.Application.Features.Specializations.Constants;

namespace CMS.Application.Features.Specializations.Commands.Create;

public class CreateSpecializationCommandValidator : AbstractValidator<CreateSpecializationCommand>
{
    public CreateSpecializationCommandValidator()
    {
        RuleFor(x => x.SpecializationName)
            .NotEmpty().WithMessage(SpecializationMessages.SpecializationNameRequired)
            .Length(2, 50).WithMessage(SpecializationMessages.SpecializationNameLength);
    }
}
