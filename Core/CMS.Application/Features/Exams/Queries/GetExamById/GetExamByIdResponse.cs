using CMS.Domain.Entities;

namespace CMS.Application.Features.Exams.Queries.GetExamById
{
    public class GetExamByIdResponse
    {
        public Guid Id { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public int MaxScore { get; set; }
        public Course Course { get; set; }
    }
}