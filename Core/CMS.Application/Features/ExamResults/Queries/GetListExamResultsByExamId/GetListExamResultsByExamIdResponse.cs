using CMS.Domain.Entities;

namespace CMS.Application.Features.ExamResults.Queries.GetListExamResultsByExamId
{
    public class GetListExamResultsByExamIdResponse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int Score { get; set; }
        public char Grade { get; set; }
        public Student Student { get; set; }
    }
}