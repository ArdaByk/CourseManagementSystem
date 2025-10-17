namespace CMS.Application.Features.Classes.Queries.GetListClasses
{
    public class GetListClassesResponse
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}