using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Attendances.Commands.Create;

public class CreateAttendanceCommandValidator : AbstractValidator<CreateAttendanceCommand>
{
    public CreateAttendanceCommandValidator()
    {
        RuleFor(a => a.CourseGroupId).NotEmpty();
        RuleFor(a => a.CourseId).NotEmpty();
        RuleFor(a => a.Status).NotEmpty();
        RuleFor(a => a.Date).NotEmpty();
        RuleFor(a => a.StudentId).NotEmpty();
    }
}
