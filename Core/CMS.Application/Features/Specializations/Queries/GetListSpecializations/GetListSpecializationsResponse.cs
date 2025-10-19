namespace CMS.Application.Features.Specializations.Queries.GetListSpecializations
{
    public class GetListSpecializationsResponse
    {
        public Guid Id { get; set; }
        public string SpecializationName { get; set; }

        public override string ToString()
        {
            return SpecializationName;
        }
    }
}