using CMS.Application.Features.CourseGroups.Queries.GetListCourseGroups;
using CMS.Application.Features.CourseGroups.Queries.GetListCourseGroupsByCourseId;
using CMS.Application.Features.Courses.Queries.GetListTeachers;
using CMS.Application.Features.StudentCourses.Commands.Create;
using CMS.Application.Features.Students.Queries.GetStudentById;
using CMS.Application.Features.Students.Queries.GetStudentByNationalId;
using CMS.Domain.Entities;
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
    public partial class RegisterStudentForm : MaterialForm
    {
        private readonly IMediator mediator;
        private ICollection<GetListCourseGroupsResponse> courseGroups;
        public RegisterStudentForm(IMediator mediator)
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

        private async void registerStudentBtn_Click(object sender, EventArgs e)
        {
            GetStudentByNationalIdResponse student = await mediator.Send(new GetStudentByNationalIdQuery { NationalId = nationalIDTxt.Text });

            CreateStudentCourseCommand studentCourse = new CreateStudentCourseCommand();
            studentCourse.StudentId = student.Id;
            studentCourse.CourseId = Guid.Parse(courseComboBox.SelectedValue.ToString());
            studentCourse.CourseGroupId = Guid.Parse(courseGroupComboBox.SelectedValue.ToString());
            studentCourse.CompletionDate = completionDate.Value;
            studentCourse.RegisteredDate = registeredDate.Value;

            CreateStudentCourseResponse result = await mediator.Send(studentCourse);

            MessageBox.Show(student.FirstName + " adlı öğrenci başarıyla kursa kayıt edildi.");

            this.Close();
        }

        private async void RegisterStudentForm_Load(object sender, EventArgs e)
        {
            var courses = await mediator.Send(new GetListCoursesQuery());
            courseGroups = await mediator.Send(new GetListCourseGroupsQuery());

            courseComboBox.DisplayMember = "CourseName";
            courseComboBox.ValueMember = "Id";
            courseComboBox.DataSource = courses;

            courseGroupComboBox.DisplayMember = "GroupName";
            courseGroupComboBox.ValueMember = "Id";
            courseGroupComboBox.DataSource = courseGroups;

            courseComboBox.SelectedIndexChanged += courseComboBox_SelectedIndexChanged;
        }

        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var updatedCourseGroups = courseGroups
                .Where(c => c.Course.Id == Guid.Parse(courseComboBox.SelectedValue.ToString()))
                .ToList();

            courseGroupComboBox.DataSource = updatedCourseGroups;
        }
    }
}
