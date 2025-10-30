using FluentValidation;

namespace CMS.Application.Features.ExamResults.Commands.Update;

public class UpdateExamResultCommandValidator : AbstractValidator<UpdateExamResultCommand>
{
    public UpdateExamResultCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Score).NotEmpty();
        RuleFor(x => x.Grade).NotEmpty();
        RuleFor(x => x.ExamId).NotEmpty();
        RuleFor(x => x.StudentId).NotEmpty();
    }
}
