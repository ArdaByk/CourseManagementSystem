namespace CMS.Application.Features.Exams.Queries.GetListExams
{
    public class GetListExamsResponse
    {
        public Guid Id { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public int MaxScore { get; set; }
    }
}