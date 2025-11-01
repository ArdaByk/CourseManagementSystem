using FluentValidation;
using CMS.Application.Features.Users.Constants;

namespace CMS.Application.Features.Users.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id alanı zorunludur.");
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(UserMessages.UsernameRequired)
            .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(UserMessages.FullNameRequired);
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(UserMessages.EmailRequired)
            .EmailAddress().WithMessage(UserMessages.EmailFormat);
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage(UserMessages.PhoneRequired);
        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage(UserMessages.RoleIdRequired);
    }
}
