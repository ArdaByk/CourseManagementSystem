using FluentValidation;
using CMS.Application.Features.Courses.Constants;

namespace CMS.Application.Features.Courses.Commands.Create;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(x => x.CourseName)
            .NotEmpty().WithMessage(CourseMessages.CourseNameRequired)
            .Length(3, 100).WithMessage(CourseMessages.CourseNameLength);
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(CourseMessages.DescriptionRequired);
        RuleFor(x => x.DurationWeeks)
            .NotEmpty().WithMessage(CourseMessages.DurationWeeksRequired)
            .InclusiveBetween(1, 52).WithMessage(CourseMessages.DurationWeeksRange);
        RuleFor(x => x.WeeklyHours)
            .NotEmpty().WithMessage(CourseMessages.WeeklyHoursRequired)
            .InclusiveBetween(1, 40).WithMessage(CourseMessages.WeeklyHoursRange);
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage(CourseMessages.StatusRequired);
    }
}
