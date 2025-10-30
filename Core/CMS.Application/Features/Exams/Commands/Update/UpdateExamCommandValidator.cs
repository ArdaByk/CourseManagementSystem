using FluentValidation;
using CMS.Application.Features.Exams.Constants;

namespace CMS.Application.Features.Exams.Commands.Update;

public class UpdateExamCommandValidator : AbstractValidator<UpdateExamCommand>
{
    public UpdateExamCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id alanı gereklidir.");
        RuleFor(x => x.ExamName)
            .NotEmpty().WithMessage(ExamMessages.ExamNameRequired)
            .Length(3, 100).WithMessage(ExamMessages.ExamNameLength);
        RuleFor(x => x.ExamDate)
            .NotEmpty().WithMessage(ExamMessages.ExamDateRequired)
            .GreaterThan(DateTime.Now.AddDays(-1)).WithMessage("Sınav tarihi geçmişte olamaz.");
        RuleFor(x => x.MaxScore)
            .NotEmpty().WithMessage(ExamMessages.MaxScoreRequired)
            .GreaterThan(0).WithMessage(ExamMessages.MaxScoreValue);
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage(ExamMessages.CourseIdRequired);
    }
}
