using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class Exam : BaseEntity<Guid>
{
    public Exam(Guid id, string examName, DateTime examDate, int maxScore, Guid courseId)
        :base(id)
    {
        ExamName = examName;
        ExamDate = examDate;
        MaxScore = maxScore;
        CourseId = courseId;

        ExamResults = new List<ExamResult>();
    }
    public Exam()
    {
        ExamResults = new List<ExamResult>();
    }

    public string ExamName { get; set; }
    public DateTime ExamDate { get; set; }
    public int MaxScore { get; set; }
    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; }
    public virtual ICollection<ExamResult> ExamResults { get; set; }

}