using CMS.Application.Features.Attendances.Commands.Create;
using CMS.Application.Features.ExamResults.Commands.Create;
using CMS.Application.Features.StudentCourses.Queries.GetListStudentsByCourseGroupId;
using CMS.Application.Features.StudentCourses.Queries.GetListStudentsByCourseId;
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
    public partial class EnterExamResultsForm : MaterialForm
    {
        private readonly IMediator mediator;
        public Guid ExamId;
        public Guid CourseId;
        private DataGridView studentsDataGridView;
        private ICollection<GetListStudentsByCourseIdResponse> students;
        public EnterExamResultsForm(IMediator mediator)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.FormBorderStyle = FormBorderStyle.None;

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

        private async void EnterExamResultsForm_Load(object sender, EventArgs e)
        {
            this.students = await mediator.Send(new GetListStudentsByCourseIdQuery { Id = CourseId });

            studentsDataGridView = new DataGridView
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

            DataGridViewTextBoxColumn noteTxt = new DataGridViewTextBoxColumn();
            noteTxt.HeaderText = "Not";
            noteTxt.Name = "score";
            noteTxt.Width = 50;
            noteTxt.ReadOnly = false;

            studentsDataGridView.Columns.Add(noteTxt);

            BindingSource bs = new BindingSource { DataSource = students };
            studentsDataGridView.DataSource = bs;
            bs.ResetBindings(false);

            studentsDataGridView.DataBindingComplete += (s, e) =>
            {
                studentsDataGridView.Columns["Id"].Visible = false;
                studentsDataGridView.Columns["NationalId"].HeaderText = "TC Kimlik NO";
                studentsDataGridView.Columns["FirstName"].HeaderText = "Adı";
                studentsDataGridView.Columns["LastName"].HeaderText = "Soyadı";
                studentsDataGridView.Columns["Phone"].HeaderText = "Telefon Numarası";
            };

            examResultsPanel.BackColor = Color.Transparent;
            examResultsPanel.Controls.Add(studentsDataGridView);
        }

        private async void saveResultsBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in studentsDataGridView.Rows)
            {
                CreateExamResultCommand examResult = new CreateExamResultCommand();
                examResult.StudentId = Guid.Parse(row.Cells["Id"].Value.ToString());
                examResult.ExamId = ExamId;
                examResult.Score = Convert.ToInt32(row.Cells["score"].Value);

                CreateExamResultResponse result = await mediator.Send(examResult);

                MessageBox.Show("Sınav notları kaydedildi.");
            }
        }
    }
}
