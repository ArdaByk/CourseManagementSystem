using CMS.Application.Features.Courses.Commands.Create;
using CMS.Application.Features.Courses.Queries.GetListTeachers;
using CMS.Application.Features.Exams.Commands.Create;
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
    public partial class AddExamForm : MaterialForm
    {
        private readonly IMediator mediator;
        public event EventHandler NewExamAdded;
        public AddExamForm(IMediator mediator)
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

        private async void createExamBtn_Click(object sender, EventArgs e)
        {
            int maxScore;
            int.TryParse(maxScoreTxt.Text, out maxScore);

            CreateExamCommand createExamCommand = new CreateExamCommand
            {
                CourseId = Guid.Parse(courseComboBox.SelectedValue.ToString()),
                ExamDate = ExamDate.Value,
                ExamName = examNameTxt.Text,
                MaxScore = maxScore
            };

            CreateExamResponse createExamResponse = await mediator.Send(createExamCommand);

            MessageBox.Show(createExamResponse.ExamName + " Adlı sınav başarıyla kaydedildi.");

            NewExamAdded?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private async void AddExamForm_Load(object sender, EventArgs e)
        {
            var courses = await mediator.Send(new GetListCoursesQuery());

            courseComboBox.Items.Clear();
            courseComboBox.DataSource = courses;
            courseComboBox.DisplayMember = "CourseName";
            courseComboBox.ValueMember = "Id";
        }
    }
}
