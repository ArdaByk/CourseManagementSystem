using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class ExamResult : BaseEntity<Guid>
{
    public ExamResult(Guid id, int score, char grade, Guid examId, Guid studentId)
        :base(id)
    {
        Score = score;
        Grade = grade;
        ExamId = examId;
        StudentId = studentId;
    }
    public ExamResult()
    {
        
    }

    public int Score { get; set; }
    public char Grade { get; set; }
    public Guid ExamId { get; set; }
    public Guid StudentId { get; set; }

    public virtual Exam Exam { get; set; }
    public virtual Student Student { get; set; }
}