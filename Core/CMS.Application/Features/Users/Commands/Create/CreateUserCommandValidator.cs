using FluentValidation;
using CMS.Application.Features.Users.Constants;

namespace CMS.Application.Features.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(UserMessages.UsernameRequired)
            .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(UserMessages.PasswordRequired)
            .MinimumLength(6).WithMessage(UserMessages.PasswordLength);
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(UserMessages.FullNameRequired);
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(UserMessages.EmailRequired)
            .EmailAddress().WithMessage(UserMessages.EmailFormat);
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage(UserMessages.PhoneRequired)
            .Matches("^05\\d{9}$").WithMessage(UserMessages.PhoneFormat);
        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage(UserMessages.RoleIdRequired);
    }
}
