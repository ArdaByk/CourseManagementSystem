using FluentValidation;
using CMS.Application.Features.Classes.Constants;

namespace CMS.Application.Features.Classes.Commands.Create;

public class CreateClassCommandValidator : AbstractValidator<CreateClassCommand>
{
    public CreateClassCommandValidator()
    {
        RuleFor(x => x.ClassName)
            .NotEmpty().WithMessage(ClassMessages.ClassNameRequired)
            .Length(2,100).WithMessage(ClassMessages.ClassNameLength);
        RuleFor(x => x.Capacity)
            .NotEmpty().WithMessage(ClassMessages.CapacityRequired)
            .InclusiveBetween(1,200).WithMessage(ClassMessages.CapacityRange);
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage(ClassMessages.LocationRequired);
    }
}
