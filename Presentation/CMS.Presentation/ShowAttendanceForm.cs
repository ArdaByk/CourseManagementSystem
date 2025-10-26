using CMS.Application.Features.Attendances.Commands.Create;
using CMS.Application.Features.Attendances.Commands.Update;
using CMS.Application.Features.Attendances.Queries.GetListAttendancesByCourseGroupId;
using CMS.Application.Features.StudentCourses.Queries.GetListStudentsByCourseGroupId;
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
    public partial class ShowAttendanceForm : MaterialForm
    {
        private readonly IMediator mediator;
        public Guid CourseGroupId;
        public Guid CourseId;
        private List<DataGridView> dataGridViews;
        private ICollection<GetListAttendancesByCourseGroupIdResponse> students;
        public ShowAttendanceForm(IMediator mediator)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.FormBorderStyle = FormBorderStyle.None;
            dataGridViews = new List<DataGridView>();

            this.mediator = mediator;

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

        private async void ShowAttendanceForm_Load(object sender, EventArgs e)
        {
            students = await mediator.Send(new GetListAttendancesByCourseGroupIdQuery { Id = CourseGroupId });

            foreach (var studentGroup in students)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = studentGroup.Key + " tarihli yoklama";
                groupBox.Width = 1231;
                groupBox.Height = 500;

                groupBox.Controls.Add(CreateDataGridView(studentGroup.Students));

                mainPanel.Controls.Add(groupBox);

            }

        }

        private DataGridView CreateDataGridView(ICollection<GetListAttendancesByCourseGroupIdGroupDto> studentGroup)
        {
            var studentsDataGridView = new DataGridView
            {
                Name = "studentsDataGridView",
                BackgroundColor = Color.FromArgb(30, 30, 30),
                GridColor = Color.FromArgb(60, 60, 60),
                RowsDefaultCellStyle = { BackColor = Color.FromArgb(45, 45, 45), ForeColor = Color.WhiteSmoke },
                AlternatingRowsDefaultCellStyle = { BackColor = Color.FromArgb(55, 55, 55) },
                EnableHeadersVisualStyles = false,
                ColumnHeadersDefaultCellStyle = { BackColor = Color.Black, ForeColor = Color.White },
                RowHeadersDefaultCellStyle = { BackColor = Color.FromArgb(50, 50, 50), ForeColor = Color.White },
                DefaultCellStyle = { SelectionBackColor = Color.Gray, SelectionForeColor = Color.White },
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            BindingSource bs = new BindingSource { DataSource = studentGroup };
            studentsDataGridView.DataSource = bs;
            bs.ResetBindings(false);

            studentsDataGridView.DataBindingComplete += (s, e) =>
            {
                studentsDataGridView.Columns["Id"].Visible = false;
                studentsDataGridView.Columns["StudentId"].Visible = false;
                studentsDataGridView.Columns["NationalId"].HeaderText = "TC Kimlik NO";
                studentsDataGridView.Columns["FirstName"].HeaderText = "Adı";
                studentsDataGridView.Columns["LastName"].HeaderText = "Soyadı";
                studentsDataGridView.Columns["Phone"].HeaderText = "Telefon Numarası";
                studentsDataGridView.Columns["Status"].HeaderText = "İşlem";
            };

            mainPanel.BackColor = Color.Transparent;

            dataGridViews.Add(studentsDataGridView);

            return studentsDataGridView;
        }

        private async void saveAttendanceBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridView dgv in dataGridViews)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    UpdateAttendanceCommand attendance = new UpdateAttendanceCommand();
                    attendance.StudentId = Guid.Parse(row.Cells["StudentId"].Value.ToString());
                    attendance.CourseGroupId = CourseGroupId;
                    attendance.CourseId = CourseId;
                    attendance.Id = Guid.Parse(row.Cells["Id"].Value.ToString());

                    bool isSelected = Convert.ToBoolean(row.Cells["Status"].Value);
                    if (isSelected)
                    {
                        attendance.Status = true;
                    }
                    else
                    {
                        attendance.Status = false;
                    }

                    UpdateAttendanceResponse result = await mediator.Send(attendance);

                    MessageBox.Show("Yoklama kaydedildi.");
                }

            }
        }
    }
}