using FluentValidation;
using CMS.Application.Features.Classes.Constants;

namespace CMS.Application.Features.Classes.Commands.Update;

public class UpdateClassCommandValidator : AbstractValidator<UpdateClassCommand>
{
    public UpdateClassCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id alanı gereklidir.");
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
