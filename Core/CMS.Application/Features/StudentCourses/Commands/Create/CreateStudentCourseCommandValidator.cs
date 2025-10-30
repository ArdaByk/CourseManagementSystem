using FluentValidation;
using CMS.Application.Features.StudentCourses.Constants;

namespace CMS.Application.Features.StudentCourses.Commands.Create;

public class CreateStudentCourseCommandValidator : AbstractValidator<CreateStudentCourseCommand>
{
    public CreateStudentCourseCommandValidator()
    {
        RuleFor(x => x.RegisteredDate)
            .NotEmpty().WithMessage(StudentCourseMessages.RegisteredDateRequired);
        RuleFor(x => x.CompletionDate)
            .NotEmpty().WithMessage(StudentCourseMessages.CompletionDateRequired)
            .GreaterThan(x => x.RegisteredDate).WithMessage("Bitirme tarihi kayıt tarihinden sonra olmalıdır.");
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage(StudentCourseMessages.StudentIdRequired);
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage(StudentCourseMessages.CourseIdRequired);
        RuleFor(x => x.CourseGroupId)
            .NotEmpty().WithMessage(StudentCourseMessages.CourseGroupIdRequired);
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage(StudentCourseMessages.StatusRequired);
    }
}
