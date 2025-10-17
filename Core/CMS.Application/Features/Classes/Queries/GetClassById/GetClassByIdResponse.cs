namespace CMS.Application.Features.Classes.Queries.GetClassById;

public class GetClassByIdResponse
{
    public Guid Id { get; set; }
    public string ClassName { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }
}