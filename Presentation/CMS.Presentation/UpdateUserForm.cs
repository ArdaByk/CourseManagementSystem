using CMS.Application.Features.Roles.Queries.GetListRoles;
using CMS.Application.Features.Users.Commands.Update;
using CMS.Application.Features.Users.Queries.GetUserById;
using CMS.Domain.Entities;
using MaterialSkin;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Presentation
{
    public partial class UpdateUserForm : MaterialForm
    {
        public Guid UserId { get; set; }
        private readonly IMediator mediator;
        public event EventHandler UserUpdated;
        public UpdateUserForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.FormBorderStyle = FormBorderStyle.None;
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

        private async void updateUserBtn_Click(object sender, EventArgs e)
        {
            UpdateUserCommand user = new UpdateUserCommand();
            user.Id = UserId;
            user.RoleId = Guid.Parse(roleComboBox.SelectedValue.ToString());
            user.Username = userNameTxt.Text;
            user.FullName = fullNameTxt.Text;
            user.Email = emailTxt.Text;
            user.Phone = userPhoneTxt.Text;

            UpdateUserResponse updatedUser = await mediator.Send(user);

            MessageBox.Show(updatedUser.Username + " adlı kullanıcı başarıyla güncellendi.");

            UserUpdated?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private async void UpdateUserForm_Load(object sender, EventArgs e)
        {
            GetUserByIdResponse user = await mediator.Send(new GetUserByIdQuery { Id = UserId });
            userNameTxt.Text = user.Username;
            fullNameTxt.Text = user.FullName;
            emailTxt.Text = user.Email;
            userPhoneTxt.Text = user.Phone;

            ICollection<GetListRolesResponse> roles = await mediator.Send(new GetListRolesQuery());

            roleComboBox.Items.Clear();
            roleComboBox.DataSource = roles;
            roleComboBox.DisplayMember = "RoleName";
            roleComboBox.ValueMember = "Id";
            roleComboBox.SelectedValue = user.Role.Id;
        }
    }
}

