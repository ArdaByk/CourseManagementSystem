namespace CMS.Application.Features.CourseGroups.Constants;

public static class CourseGroupMessages
{
    public const string GroupNameRequired = "Grup adı alanı boş bırakılamaz.";
    public const string GroupNameLength = "Grup adı 5 ile 100 karakter arasında olmalıdır.";
    public const string QuotaRequired = "Kota zorunludur.";
    public const string QuotaRange = "Kota 1 ile 100 arasında olmalıdır.";
    public const string StartDateRequired = "Başlangıç tarihi zorunludur.";
    public const string EndDateRequired = "Bitiş tarihi zorunludur.";
    public const string EndDateMustBeAfterStart = "Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.";
    public const string CourseRequired = "Ders seçimi zorunludur.";
    public const string ClassRequired = "Sınıf seçimi zorunludur.";
    public const string TeacherRequired = "Eğitmen seçimi zorunludur.";
    public const string DaysRequired = "Haftalık gün seçimi yapılmalıdır.";
    public const string StartTimeRequired = "Başlangıç saati zorunludur.";
    public const string EndTimeRequired = "Bitiş saati zorunludur.";
    public const string EndTimeMustBeAfterStartTime = "Bitiş saati, başlangıç saatinden sonra olmalıdır.";
}
