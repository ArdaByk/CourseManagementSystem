using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Drawing2D;
using MediatR;
using CMS.Application.Features.Authentication.Commands.Login;
using CMS.Presentation.Common;
using System;
using CMS.Application.Common.Authentication;

namespace CMS.Presentation;

public partial class LoginForm : MaterialForm
{
    private readonly IServiceProvider serviceProvider;
    private readonly IMediator mediator;
    
    public LoginForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        this.FormBorderStyle = FormBorderStyle.None;
        this.serviceProvider = serviceProvider;
        this.mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    protected override CreateParams CreateParams
    {
        get
        {
            const int CS_DROPSHADOW = 0x00020000;
            CreateParams cp = base.CreateParams;
            cp.ClassStyle |= CS_DROPSHADOW;
            return cp;
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateFormRegion();
    }

    private void UpdateFormRegion()
    {
        int radius = 15;
        var path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
        path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), -90, 90);
        path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
        path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
        path.CloseFigure();
        this.Region = new Region(path);
    }

    private async void loginBtn_Click(object sender, EventArgs e)
    {
        string emailOrUsername = emailTxt.Text.Trim();
        string password = passwordTxt.Text;

        if (string.IsNullOrWhiteSpace(emailOrUsername))
        {
            MessageBox.Show("E-posta veya kullanıcı adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Şifre boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            loginBtn.Enabled = false;
            loginBtn.Text = "Giriş yapılıyor...";

            var loginCommand = new LoginCommand
            {
                EmailOrUsername = emailOrUsername,
                Password = password
            };

            var response = await mediator.Send(loginCommand);

            if (response.Success && response.UserId.HasValue && response.RoleId.HasValue && !string.IsNullOrEmpty(response.Token))
            {
                CurrentUserContext.Instance.SetUser(
                    response.Token,
                    response.UserId.Value,
                    response.Username,
                    response.Email,
                    response.FullName,
                    response.RoleId.Value,
                    response.RoleName
                );

                DashboardForm dashboardForm = serviceProvider.GetRequiredService<DashboardForm>();
                dashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(response.Message, "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTxt.Clear();
                passwordTxt.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            loginBtn.Enabled = true;
            loginBtn.Text = "Giriş Yap";
        }
    }
}
