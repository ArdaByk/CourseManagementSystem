using CMS.Application.Features.Courses.Commands.Update;
using CMS.Application.Features.Courses.Queries.GetListTeachers;
using CMS.Application.Features.Courses.Queries.GetTeacherById;
using CMS.Application.Features.Exams.Commands.Update;
using CMS.Application.Features.Exams.Queries.GetExamById;
using CMS.Domain.Entities;
using MaterialSkin;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.Devices;
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
    public partial class UpdateExamForm : MaterialForm
    {
        public Guid ExamId { get; set; }
        private readonly IMediator mediator;
        public event EventHandler ExamUpdated;
        public UpdateExamForm(IServiceProvider serviceProvider)
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

        private async void UpdateExamForm_Load(object sender, EventArgs e)
        {
            GetExamByIdResponse exam = await mediator.Send(new GetExamByIdQuery { Id = ExamId });
            examNameTxt.Text = exam.ExamName;
            ExamDate.Value = exam.ExamDate;
            maxScoreTxt.Text = exam.MaxScore.ToString();

            var courses = await mediator.Send(new GetListCoursesQuery());

            courseComboBox.DataSource = courses;
            courseComboBox.DisplayMember = "CourseName";
            courseComboBox.ValueMember = "Id";
            courseComboBox.SelectedValue = exam.Course.Id;
        }

        private async void updateExamBtn_Click(object sender, EventArgs e)
        {
            int maxScore;
            int.TryParse(maxScoreTxt.Text, out maxScore);

            UpdateExamCommand updateExamCommand = new UpdateExamCommand();
            updateExamCommand.Id = ExamId;
            updateExamCommand.CourseId = Guid.Parse(courseComboBox.SelectedValue.ToString());
            updateExamCommand.ExamName = examNameTxt.Text;
            updateExamCommand.ExamDate = ExamDate.Value;
            updateExamCommand.MaxScore = maxScore;

            UpdateExamResponse updatedExam = await mediator.Send(updateExamCommand);

            MessageBox.Show(updatedExam.ExamName + " adlı sınav başarıyla güncellendi.");

            ExamUpdated?.Invoke(this, EventArgs.Empty);

            this.Close();
        }
    }
}
