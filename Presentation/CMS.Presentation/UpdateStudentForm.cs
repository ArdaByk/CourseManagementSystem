using CMS.Application.Features.Students.Commands.Create;
using CMS.Application.Features.Students.Commands.Update;
using CMS.Application.Features.Students.Queries.GetStudentById;
using MaterialSkin;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
namespace CMS.Presentation
{
    public partial class UpdateStudentForm : MaterialForm
    {
        public Guid StudentId { get; set; }
        private readonly IMediator mediator;
        public event EventHandler StudentUpdated;
        public UpdateStudentForm(IServiceProvider serviceProvider)
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

        private async void UpdateStudentForm_Load(object sender, EventArgs e)
        {
            GetStudentByIdResponse student = await mediator.Send(new GetStudentByIdQuery { Id = StudentId });

            studentFirstNameTxt.Text = student.FirstName;
            studentLastNameTxt.Text = student.LastName;
            studentAdressTxt.Text = student.Address;
            studentBirthDate.Value = student.BirthDate;
            studentEmailTxt.Text = student.Email;
            studentPhoneTxt.Text = student.Phone;
            studentNationalIDTxt.Text = student.NationalId;
            studentGenderComboBox.SelectedIndex = student.Gender == 'E' ? 0 : 1;
            studentPhotoPath.ImageLocation = student.PhotoPath;
            studentStatusSwitch.Checked = student.Status == 'A' ? true : false;
            EmergencyContactNameTxt.Text = student.EmergencyContactName;
            EmergencyContactRelation.Text = student.EmergencyContactRelation;
            EmergencyContactPhoneTxt.Text = student.EmergencyContactPhone;
            studentEmailTxt.Text = student.Email;
        }

        private async void updateStudentBtn_Click(object sender, EventArgs e)
        {
            UpdateStudentCommand student = new UpdateStudentCommand();
            student.Id = StudentId;
            student.FirstName = studentFirstNameTxt.Text;
            student.LastName = studentLastNameTxt.Text;
            student.NationalId = studentNationalIDTxt.Text;
            student.Status = studentStatusSwitch.Checked == true ? 'A' : 'P';
            student.Email = studentEmailTxt.Text;
            student.Address = studentAdressTxt.Text;
            student.Gender = studentGenderComboBox.SelectedIndex == 0 ? 'E' : 'K';
            student.BirthDate = studentBirthDate.Value;
            student.Phone = studentPhoneTxt.Text;
            student.EmergencyContactName = EmergencyContactNameTxt.Text;
            student.EmergencyContactRelation = EmergencyContactRelation.Text;
            student.EmergencyContactPhone = EmergencyContactPhoneTxt.Text;
            student.PhotoPath = studentPhotoPath.ImageLocation;

            UpdateStudentResponse updatedStudent = await mediator.Send(student);

            MessageBox.Show(updatedStudent.FirstName+" adlı öğrenci başarıyla güncellendi.");

            StudentUpdated?.Invoke(this, EventArgs.Empty);

            this.Close();
        }
    }
}