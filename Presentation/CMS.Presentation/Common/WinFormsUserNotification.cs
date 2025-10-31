using CMS.Application.Abstractions.Notifications;
using System.Text;
using System.Windows.Forms;

namespace CMS.Presentation.Common;

public class WinFormsUserNotification : IUserNotification
{
    public void ShowError(string title, string message)
    {
        MessageBox.Show(message, string.IsNullOrWhiteSpace(title) ? "Hata" : title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowValidationErrors(IEnumerable<string> errorMessages, string? title = null)
    {
        var builder = new StringBuilder();
        foreach (var msg in errorMessages)
        {
            if (!string.IsNullOrWhiteSpace(msg))
                builder.AppendLine("• " + msg);
        }

        var text = builder.Length > 0 ? builder.ToString() : "Geçersiz girişler bulunuyor.";
        MessageBox.Show(text, string.IsNullOrWhiteSpace(title) ? "Doğrulama Hatası" : title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}


