using CMS.Domain.Entities;

namespace CMS.Application.Features.Teachers.Queries.GetListTeachersBySpecializationId;

public class GetListTeachersBySpecializationIdResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public char Status { get; set; }
    public Specialization Specialization { get; set; }

}