using CMS.Application.Features.Classes.Queries.GetListClasses;
using CMS.Application.Features.CourseGroups.Commands.Create;
using CMS.Application.Features.CourseGroups.Commands.Update;
using CMS.Application.Features.CourseGroups.Queries.GetCourseGroupById;
using CMS.Application.Features.Courses.Queries.GetListTeachers;
using CMS.Application.Features.Teachers.Commands.Update;
using CMS.Application.Features.Teachers.Queries.GetListTeachers;
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
    public partial class UpdateCourseGroupForm : MaterialForm
    {
        public Guid CourseGroupId { get; set; }
        private readonly IMediator mediator;
        public event EventHandler CourseGroupUpdated;
        public UpdateCourseGroupForm(IServiceProvider serviceProvider)
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

        private async void updateGroupBtn_Click(object sender, EventArgs e)
        {
            List<int> selectedDays = new List<int>();

            if (monday.Checked)
                selectedDays.Add(0);
            if (tuesday.Checked)
                selectedDays.Add(1);
            if (wednesday.Checked)
                selectedDays.Add(2);
            if (thursday.Checked)
                selectedDays.Add(3);
            if (friday.Checked)
                selectedDays.Add(4);
            if (saturday.Checked)
                selectedDays.Add(5);
            if (sunday.Checked)
                selectedDays.Add(6);

            var parsedStartTime = TimeSpan.Parse(startTimeTxt.Text);
            var parsedEndTime = TimeSpan.Parse(endTimeTxt.Text);

            UpdateCourseGroupCommand updateCourseGroupCommand = new UpdateCourseGroupCommand
            {
                Id = CourseGroupId,
                ClassId = Guid.Parse(classComboBox.SelectedValue.ToString()),
                CourseId = Guid.Parse(courseComboBox.SelectedValue.ToString()),
                DaysOfWeek = selectedDays,
                StartedDate = startedDate.Value.Date + parsedStartTime,
                EndedDate = endedDate.Value.Date + parsedEndTime,
                EndTime = parsedEndTime,
                StartTime = parsedStartTime,
                GroupName = courseGroupNameTxt.Text,
                Quota = Convert.ToInt32(CourseGroupQuotaTxt.Text),
                TeacherId = Guid.Parse(teacherComboBox.SelectedValue.ToString())
            };

            UpdateCourseGroupResponse updatedCourseGroup = await mediator.Send(updateCourseGroupCommand);

            MessageBox.Show(updatedCourseGroup.GroupName + " adlı kurs grubu başarıyla güncellendi.");

            CourseGroupUpdated?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private async void UpdateCourseGroupForm_Load(object sender, EventArgs e)
        {

            var classes = await mediator.Send(new GetListClassesQuery());
            var courses = await mediator.Send(new GetListCoursesQuery());
            var teachers = await mediator.Send(new GetListTeacherQuery());


            var courseGroup = await mediator.Send(new GetCourseGroupByIdQuery { Id = CourseGroupId});

            courseGroupNameTxt.Text = courseGroup.GroupName;
            CourseGroupQuotaTxt.Text = courseGroup.Quota.ToString();
            startedDate.Value = courseGroup.StartedDate;
            endedDate.Value = courseGroup.EndedDate;
            startTimeTxt.Text = courseGroup.CourseSchedules.First().StartTime.ToString();
            endTimeTxt.Text = courseGroup.CourseSchedules.First().EndTime.ToString();

            courseComboBox.Items.Clear();
            courseComboBox.DataSource = courses;
            courseComboBox.DisplayMember = "CourseName";
            courseComboBox.ValueMember = "Id";
            courseComboBox.SelectedValue = courseGroup.Course.Id;

            classComboBox.Items.Clear();
            classComboBox.DataSource = classes;
            classComboBox.DisplayMember = "ClassName";
            classComboBox.ValueMember = "Id";
            classComboBox.SelectedValue = courseGroup.Class.Id;

            teacherComboBox.Items.Clear();
            teacherComboBox.DataSource = teachers
                            .Select(t => new
                            {
                                Id = t.Id,
                                FullName = $"{t.FirstName} {t.LastName}"
                            })
                           .ToList();
            teacherComboBox.DisplayMember = "FullName";
            teacherComboBox.ValueMember = "Id";
            teacherComboBox.SelectedValue = courseGroup.Teacher.Id;

            foreach (var courseSchedule in courseGroup.CourseSchedules)
            {
                switch (courseSchedule.DayOfWeek)
                {
                    case 0:
                        monday.Checked = true;
                        break;
                    case 1:
                        tuesday.Checked = true;
                        break;
                    case 2:
                        wednesday.Checked = true;
                        break;
                    case 3:
                        thursday.Checked = true;
                        break;
                    case 4:
                        friday.Checked = true;
                        break;
                    case 5:
                        saturday.Checked = true;
                        break;
                    case 6:
                        sunday.Checked = true;
                        break;
                }
            }
        }
    }
}