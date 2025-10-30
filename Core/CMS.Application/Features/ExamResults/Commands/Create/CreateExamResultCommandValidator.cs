using FluentValidation;

namespace CMS.Application.Features.ExamResults.Commands.Create;

public class CreateExamResultCommandValidator : AbstractValidator<CreateExamResultCommand>
{
    public CreateExamResultCommandValidator()
    {
        RuleFor(x => x.Score).NotEmpty();
        RuleFor(x => x.Grade).NotEmpty();
        RuleFor(x => x.ExamId).NotEmpty();
        RuleFor(x => x.StudentId).NotEmpty();
    }
}
