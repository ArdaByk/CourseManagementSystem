using CMS.Application.Features.Students.Commands.Create;
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
    public partial class AddStudentForm : MaterialForm
    {
        private readonly IMediator mediator;
        public AddStudentForm(IMediator mediator)
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

        private void studentPhotoUploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = ofd.FileName;

                studentPhotoPath.Image = Image.FromFile(selectedFilePath);
            }
        }

        private async void addStudentBtn_Click(object sender, EventArgs e)
        {
            string baseFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentPhotos");

            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            string studentId = studentNationalIDTxt.Text;
            string fileName = $"{studentId}.jpg";

            string fullPath = Path.Combine(baseFolder, fileName);

            if (studentPhotoPath.Image != null)
            {
                studentPhotoPath.Image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                MessageBox.Show("Önce fotoğraf seçin!");
            }

            CreateStudentCommand createStudentCommand = new CreateStudentCommand();
            createStudentCommand.FirstName = studentFirstNameTxt.Text;
            createStudentCommand.LastName = studentLastNameTxt.Text;
            createStudentCommand.NationalId = studentNationalIDTxt.Text;
            createStudentCommand.Status = studentStatusSwitch.Checked == true ? 'A' : 'P';
            createStudentCommand.Email = studentEmailTxt.Text;
            createStudentCommand.Address = studentAdressTxt.Text;
            createStudentCommand.Gender = studentGenderComboBox.SelectedIndex == 0 ? 'E' : 'K';
            createStudentCommand.BirthDate = studentBirthDate.Value;
            createStudentCommand.Phone = studentPhoneTxt.Text;
            createStudentCommand.EmergencyContactName = EmergencyContactNameTxt.Text;
            createStudentCommand.EmergencyContactRelation = EmergencyContactRelation.Text;
            createStudentCommand.EmergencyContactPhone = EmergencyContactPhoneTxt.Text;
            createStudentCommand.PhotoPath = fullPath;

            CreateStudentResponse createStudentResponse = await mediator.Send(createStudentCommand);

            MessageBox.Show(createStudentResponse.FirstName + " Adlı öğrenci başarıyla kaydedildi.");

        }
    }
}
