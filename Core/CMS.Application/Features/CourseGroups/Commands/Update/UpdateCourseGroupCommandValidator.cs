using FluentValidation;
using CMS.Application.Features.CourseGroups.Constants;

namespace CMS.Application.Features.CourseGroups.Commands.Update;

public class UpdateCourseGroupCommandValidator : AbstractValidator<UpdateCourseGroupCommand>
{
    public UpdateCourseGroupCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id alanı boş bırakılamaz.");
        RuleFor(x => x.GroupName)
            .NotEmpty().WithMessage(CourseGroupMessages.GroupNameRequired)
            .Length(5, 100).WithMessage(CourseGroupMessages.GroupNameLength);
        RuleFor(x => x.Quota)
            .NotEmpty().WithMessage(CourseGroupMessages.QuotaRequired)
            .InclusiveBetween(1, 100).WithMessage(CourseGroupMessages.QuotaRange);
        RuleFor(x => x.StartedDate)
            .NotEmpty().WithMessage(CourseGroupMessages.StartDateRequired);
        RuleFor(x => x.EndedDate)
            .NotEmpty().WithMessage(CourseGroupMessages.EndDateRequired)
            .GreaterThan(x => x.StartedDate).WithMessage(CourseGroupMessages.EndDateMustBeAfterStart);
        RuleFor(x => x.EndedDate)
            .Must((cmd, endDate) => endDate >= cmd.StartedDate.AddMonths(1))
            .WithMessage(CourseGroupMessages.CourseDurationMinOneMonth);
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage(CourseGroupMessages.CourseRequired);
        RuleFor(x => x.ClassId)
            .NotEmpty().WithMessage(CourseGroupMessages.ClassRequired);
        RuleFor(x => x.TeacherId)
            .NotEmpty().WithMessage(CourseGroupMessages.TeacherRequired);
        RuleFor(x => x.DaysOfWeek)
            .NotNull().WithMessage(CourseGroupMessages.DaysRequired)
            .Must(x => x != null && x.Count > 0).WithMessage(CourseGroupMessages.DaysRequired);
        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage(CourseGroupMessages.StartTimeRequired);
        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage(CourseGroupMessages.EndTimeRequired)
            .Must((cmd, endTime) => endTime > cmd.StartTime)
            .WithMessage(CourseGroupMessages.EndTimeMustBeAfterStartTime);

        RuleFor(x => x)
            .Must(cmd =>
            {
                var duration = cmd.EndTime - cmd.StartTime;
                return duration >= TimeSpan.FromMinutes(20) && duration <= TimeSpan.FromMinutes(40);
            })
            .WithMessage(CourseGroupMessages.LessonDurationMaxFortyMinutes);
    }
}
