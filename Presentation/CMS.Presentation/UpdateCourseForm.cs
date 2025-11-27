using CMS.Application.Features.Courses.Commands.Update;
using CMS.Application.Features.Courses.Queries.GetTeacherById;
using CMS.Application.Features.Specializations.Queries.GetListSpecializations;
using CMS.Domain.Entities;
using MaterialSkin;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Presentation
{
    public partial class UpdateCourseForm : MaterialForm
    {
        public Guid CourseId { get; set; }
        private readonly IMediator mediator;
        public event EventHandler CourseUpdated;
        public UpdateCourseForm(IServiceProvider serviceProvider)
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

        private async void updateCourseBtn_Click(object sender, EventArgs e)
        {
            int durationWeeks;
            int weeklyHours;

            int.TryParse(durationWeekTxt.Text, out durationWeeks);
            int.TryParse(weeklyHoursTxt.Text, out weeklyHours);

            UpdateCourseCommand course = new UpdateCourseCommand();
            course.Id = CourseId;
            course.CourseName = courseNameTxt.Text;
            course.Description = courseDescriptionTxt.Text;
            course.DurationWeeks =durationWeeks;
            course.WeeklyHours = weeklyHours;
            course.Status = courseStatusSwitch.Checked == true ? 'A' : 'P';
            course.SpecializationId = Guid.Parse(specializationComboBox.SelectedValue.ToString());

            UpdateCourseResponse updatedCourse = await mediator.Send(course);

            MessageBox.Show(updatedCourse.CourseName + " adlı kurs başarıyla güncellendi.");

            CourseUpdated?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private async void UpdateCourseForm_Load(object sender, EventArgs e)
        {
            GetCourseByIdResponse course = await mediator.Send(new GetCourseByIdQuery { Id = CourseId });
            courseNameTxt.Text = course.CourseName;
            courseDescriptionTxt.Text = course.Description;
            durationWeekTxt.Text = course.DurationWeeks.ToString();
            weeklyHoursTxt.Text = course.WeeklyHours.ToString();
            courseStatusSwitch.Checked = course.Status == 'A' ? true : false;
            specializationComboBox.SelectedValue = course.Specialization.Id;

            var specializations = await mediator.Send(new GetListSpecializationsQuery());

            specializationComboBox.Controls.Clear();

            specializationComboBox.DataSource = specializations;
            specializationComboBox.DisplayMember = "SpecializationName";
            specializationComboBox.ValueMember = "Id";
        }
    }
}
