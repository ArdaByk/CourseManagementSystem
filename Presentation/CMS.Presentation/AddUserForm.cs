using CMS.Application.Features.Courses.Commands.Create;
using CMS.Application.Features.Roles.Queries.GetListRoles;
using CMS.Application.Features.Specializations.Queries.GetListSpecializations;
using CMS.Application.Features.Users.Commands.Create;
using CMS.Application.Features.Users.Queries.GetListUsers;
using MaterialSkin;
using MaterialSkin.Controls;
using MediatR;
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
    public partial class AddUserForm : MaterialForm
    {
        private readonly IMediator mediator;
        public event EventHandler NewUserAdded;
        public AddUserForm(IMediator mediator)
        {
            InitializeComponent();

            this.mediator = mediator;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.FormBorderStyle = FormBorderStyle.None;

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

        private async void addUserBtn_Click(object sender, EventArgs e)
        {
            CreateUserCommand createUserCommand = new CreateUserCommand
            {
                Email = emailTxt.Text,
                FullName = fullNameTxt.Text,
                Password = userPasswordTxt.Text,
                Phone = userPhoneTxt.Text,
                RoleId = Guid.Parse(roleComboBox.SelectedValue.ToString()),
                Username = userNameTxt.Text                
            };

            CreateUserResponse createUserResponse = await mediator.Send(createUserCommand);

            MessageBox.Show(createUserResponse.Username + " Adlı kullanıcı başarıyla kaydedildi.");

            NewUserAdded?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private async void AddUserForm_Load(object sender, EventArgs e)
        {
            var roles = await mediator.Send(new GetListRolesQuery());

            roleComboBox.Items.Clear();

            roleComboBox.DataSource = roles;

            roleComboBox.DisplayMember = "RoleName";
            roleComboBox.ValueMember = "Id";
        }
    }
}
