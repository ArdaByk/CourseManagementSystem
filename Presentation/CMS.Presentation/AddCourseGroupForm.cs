using CMS.Application.Features.Classes.Queries.GetListClasses;
using CMS.Application.Features.CourseGroups.Commands.Create;
using CMS.Application.Features.Courses.Queries.GetListTeachers;
using CMS.Application.Features.Teachers.Queries.GetListTeachers;
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
    public partial class AddCourseGroupForm : MaterialForm
    {
        private readonly IMediator mediator;
        public event EventHandler NewCourseGroupAdded;
        public AddCourseGroupForm(IMediator mediator)
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

        private async void addGroupBtn_Click(object sender, EventArgs e)
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

            int quota;
            int.TryParse(CourseGroupQuotaTxt.Text, out quota);

            CreateCourseGroupCommand createCourseGroupCommand = new CreateCourseGroupCommand
            {
                ClassId = Guid.Parse(classComboBox.SelectedValue.ToString()),
                CourseId = Guid.Parse(courseComboBox.SelectedValue.ToString()),
                DaysOfWeek = selectedDays,
                EndedDate = endedDate.Value,
                StartedDate = startedDate.Value,
                EndTime = TimeSpan.Parse(endTimeTxt.Text),
                StartTime = TimeSpan.Parse(startTimeTxt.Text),
                GroupName = courseGroupNameTxt.Text,
                Quota = quota,
                TeacherId = Guid.Parse(teacherComboBox.SelectedValue.ToString())
            };

            CreateCourseGroupResponse createCourseGroupResponse = await mediator.Send(createCourseGroupCommand);

            MessageBox.Show(createCourseGroupResponse.GroupName + " Adlı grup başarıyla kaydedildi.");

            NewCourseGroupAdded?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private async void AddCourseGroupForm_Load(object sender, EventArgs e)
        {
            var classes = await mediator.Send(new GetListClassesQuery());
            var courses = await mediator.Send(new GetListCoursesQuery());
            var teachers = await mediator.Send(new GetListTeacherQuery());

            courseComboBox.DataSource = courses;
            courseComboBox.DisplayMember = "CourseName";
            courseComboBox.ValueMember = "Id";

            classComboBox.DataSource = classes;
            classComboBox.DisplayMember = "ClassName";
            classComboBox.ValueMember = "Id";

            teacherComboBox.DataSource = teachers
                 .Select(t => new
                 {
                     Id = t.Id,
                     FullName = $"{t.FirstName} {t.LastName}"
                 })
                .ToList();
            teacherComboBox.DisplayMember = "FullName";
            teacherComboBox.ValueMember = "Id";
        }
    }
}