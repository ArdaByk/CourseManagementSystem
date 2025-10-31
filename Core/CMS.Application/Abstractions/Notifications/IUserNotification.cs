namespace CMS.Application.Abstractions.Notifications;

public interface IUserNotification
{
    void ShowError(string title, string message);
    void ShowValidationErrors(IEnumerable<string> errorMessages, string? title = null);
}


