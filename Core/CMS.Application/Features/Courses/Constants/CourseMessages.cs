namespace CMS.Application.Features.Courses.Constants;

public static class CourseMessages
{
    public const string CourseNameRequired = "Ders adı zorunludur.";
    public const string CourseNameLength = "Ders adı 3-100 karakter arasında olmalıdır.";
    public const string DescriptionRequired = "Açıklama zorunludur.";
    public const string DurationWeeksRequired = "Süre (hafta) zorunludur.";
    public const string DurationWeeksRange = "Süre aralığı 1-52 hafta olmalıdır.";
    public const string WeeklyHoursRequired = "Haftalık ders saati zorunludur.";
    public const string WeeklyHoursRange = "Haftalık ders saati 1-40 saat arası olmalıdır.";
    public const string StatusRequired = "Durum bilgisi zorunludur.";
}
