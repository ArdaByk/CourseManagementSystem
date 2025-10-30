using FluentValidation;
using CMS.Application.Features.StudentCourses.Constants;

namespace CMS.Application.Features.StudentCourses.Commands.Update;

public class UpdateStudentCoursesCommandValidator : AbstractValidator<UpdateStudentCoursesCommand>
{
    public UpdateStudentCoursesCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id alanı gereklidir.");
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
