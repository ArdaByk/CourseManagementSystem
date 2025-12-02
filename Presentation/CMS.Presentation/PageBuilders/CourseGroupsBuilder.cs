using CMS.Application.Features.CourseGroups.Commands.Delete;
using CMS.Application.Features.CourseGroups.Queries.GetListCourseGroups;
using CMS.Application.Features.Students.Queries.GetListStudents;
using CMS.Domain.Entities;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class CourseGroupsBuilder : IPageBuilder
{
    private ICollection<GetListCourseGroupsResponse> courseGroups;
    private readonly IServiceProvider serviceProvider;
    private readonly IMediator mediator;
    private DataGridView courseGroupsDataGridView;
    private BindingSource bs;
    public CourseGroupsBuilder(IServiceProvider serviceProvider)
    {
        this.mediator = serviceProvider.GetRequiredService<IMediator>();

        this.serviceProvider = serviceProvider;
    }

    public async void Build(TabPage tabPage)
    {
        this.courseGroups = await mediator.Send(new GetListCourseGroupsQuery());

        Panel mainPanel = new Panel
        {
            Dock = DockStyle.Fill
        };

        Panel inputPanel = new Panel
        {
            Dock = DockStyle.Top
        };

        var courseGroupNameTextBox = CreateTextBox("courseGroupNameTextBox", "Grup Adı", new Point(8, 3));
        var courseGroupQuotaTextBox = CreateTextBox("courseGroupQuotaTextBox", "Grup Kontenjanı", new Point(270, 3));
        var courseNameTextBox = CreateTextBox("courseNameTextBox", "Kurs Adı", new Point(530, 3));

        var addCourseGroupBtn = CreateButton("addCourseGroupBtn", "Grup Ekle", new Point(10, 57));
        var updateCourseGroupBtn = CreateButton("updateCourseGroupBtn", "Grup Güncelle", new Point(240, 57));
        var deleteCourseGroupBtn = CreateButton("deleteCourseGroupBtn", "Grup Sil", new Point(470, 57), true);
        var showStudentsBtn = CreateButton("showStudentsBtn", "Gruba Kayıtlı Öğrencileri Göster", new Point(700, 57));
        var takeAttendanceBtn = CreateButton("takeAttendanceBtn", "Yoklama Al", new Point(930, 57));
        var showAttendanceBtn = CreateButton("showAttendanceBtn", "Yoklama Göster", new Point(1160, 57));
        var registerStudentBtn = CreateButton("registerStudentBtn", "Öğrenci Kaydı Yap", new Point(1390, 57));

        deleteCourseGroupBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteCourseGroupBtn.UseAccentColor = true;

        Panel courseGroupsPanel = new Panel
        {
            Name = "coruseGroupsPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        addCourseGroupBtn.MouseClick += (o, e) =>
        {
            AddCourseGroupForm addCourseGroupForm = serviceProvider.GetRequiredService<AddCourseGroupForm>();

            addCourseGroupForm.NewCourseGroupAdded += addCourseGroupForm_NewCourseGroupAdded;

            addCourseGroupForm.ShowDialog();
        };

        updateCourseGroupBtn.MouseClick += (o, e) =>
        {
            DataGridViewRow selectedRow = courseGroupsDataGridView.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir kurs grubu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

            UpdateCourseGroupForm updateCourseGroupForm = serviceProvider.GetRequiredService<UpdateCourseGroupForm>();

            updateCourseGroupForm.CourseGroupId = id;

            updateCourseGroupForm.CourseGroupUpdated += updateCourseGroupForm_CourseGroupUpdated;

            updateCourseGroupForm.ShowDialog();
        };

        deleteCourseGroupBtn.MouseClick += async (o, e) =>
        {
            var selectedRow = courseGroupsDataGridView.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir kurs grubu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bu kurs grubunu silmek istediğinizden emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var courseGroupId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

                    await mediator.Send(new DeleteCourseGroupCommand { Id = courseGroupId });

                    courseGroups.Remove(courseGroups.First(c => c.Id == courseGroupId));
                    bs.ResetBindings(false);

                    MessageBox.Show("Kurs grubu başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme işlemi başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };

        showStudentsBtn.MouseClick += (o, e) =>
        {
            ShowCourseGroupStudentsForm showCourseGroupStudentsForm = serviceProvider.GetRequiredService<ShowCourseGroupStudentsForm>();
            showCourseGroupStudentsForm.CourseGroupId = Guid.Parse(courseGroupsDataGridView.CurrentRow.Cells["Id"].Value.ToString());
            showCourseGroupStudentsForm.Show();
        };

        showAttendanceBtn.MouseClick += (o, e) =>
        {
            ShowAttendanceForm showAttendanceForm = serviceProvider.GetRequiredService<ShowAttendanceForm>();
            showAttendanceForm.CourseGroupId = Guid.Parse(courseGroupsDataGridView.CurrentRow.Cells["Id"].Value.ToString());
            showAttendanceForm.CourseId = Guid.Parse(courseGroupsDataGridView.CurrentRow.Cells["CourseId"].Value.ToString());
            showAttendanceForm.Show();
        };

        takeAttendanceBtn.MouseClick += (o, e) =>
        {
            TakeAttendanceForm takeAttendanceForm = serviceProvider.GetRequiredService<TakeAttendanceForm>();
            takeAttendanceForm.CourseGroupId = Guid.Parse(courseGroupsDataGridView.CurrentRow.Cells["Id"].Value.ToString());
            takeAttendanceForm.CourseId = Guid.Parse(courseGroupsDataGridView.CurrentRow.Cells["CourseId"].Value.ToString());
            takeAttendanceForm.Show();
        };

        registerStudentBtn.MouseClick += (o, e) =>
        {
            RegisterStudentForm registerStudentForm = serviceProvider.GetRequiredService<RegisterStudentForm>();
            registerStudentForm.Show();
        };

        courseGroupsDataGridView = CreateCourseGroupsDataGridView(courseGroups);

        courseGroupsPanel.Controls.Add(courseGroupsDataGridView);

        inputPanel.Controls.Add(courseGroupNameTextBox);
        inputPanel.Controls.Add(courseGroupQuotaTextBox);
        inputPanel.Controls.Add(courseNameTextBox);
        inputPanel.Controls.Add(addCourseGroupBtn);
        inputPanel.Controls.Add(updateCourseGroupBtn);
        inputPanel.Controls.Add(deleteCourseGroupBtn);
        inputPanel.Controls.Add(showStudentsBtn);
        inputPanel.Controls.Add(takeAttendanceBtn);
        inputPanel.Controls.Add(showAttendanceBtn);
        inputPanel.Controls.Add(registerStudentBtn);

        mainPanel.Controls.Add(courseGroupsPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string courseNameFilter = courseNameTextBox.Text.Trim().ToLower();
            string courseGroupNameFilter = courseGroupNameTextBox.Text.Trim().ToLower();
            string courseGroupQuotaFilter = courseGroupQuotaTextBox.Text.Trim().ToLower();

            bs = (BindingSource)courseGroupsDataGridView.DataSource;

            IEnumerable<GetListCourseGroupsResponse> filtered = courseGroups;

            if (!string.IsNullOrEmpty(courseNameFilter))
                filtered = filtered.Where(c => c.Course.CourseName.ToLower().Contains(courseNameFilter));

            if (!string.IsNullOrEmpty(courseGroupNameFilter))
                filtered = filtered.Where(c => c.GroupName.ToLower().Contains(courseGroupNameFilter));

            if (!string.IsNullOrEmpty(courseGroupQuotaFilter))
                filtered = filtered.Where(c => c.Quota.Equals(courseGroupQuotaFilter));

            bs.DataSource = filtered.ToList();
            bs.ResetBindings(false);
        }

        courseNameTextBox.TextChanged += (s, e) => ApplyFilter();
    }

    private MaterialTextBox2 CreateTextBox(string name, string hint, Point location)
    {
        return new MaterialTextBox2
        {
            Name = name,
            Hint = hint,
            Location = location
        };
    }

    private MaterialButton CreateButton(string name, string text, Point location, bool useAccent = false)
    {
        return new MaterialButton
        {
            Name = name,
            Text = text,
            Location = location,
            Width = 180,
            UseAccentColor = useAccent
        };
    }

    private DataGridView CreateCourseGroupsDataGridView(ICollection<GetListCourseGroupsResponse> students)
    {
        var dataGridView = new DataGridView
        {
            Name = "courseGroupsDataGridView",
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

        bs = new BindingSource { DataSource = courseGroups.Select(c => new { c.Id,CourseId= c.Course.Id ,c.GroupName, c.Course.CourseName, c.Quota, c.StartedDate, c.EndedDate }).ToList() };
        dataGridView.DataSource = bs;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["CourseId"].Visible = false;
            dataGridView.Columns["GroupName"].HeaderText = "Kurs Grup Adı";
            dataGridView.Columns["CourseName"].HeaderText = "Kurs Adı";
            dataGridView.Columns["Quota"].HeaderText = "Kontenjan";
            dataGridView.Columns["StartedDate"].HeaderText = "Başlangıç Tarihi";
            dataGridView.Columns["EndedDate"].HeaderText = "Bitiş Tarihi";
        };

        return dataGridView;
    }

    public async void addCourseGroupForm_NewCourseGroupAdded(object o, EventArgs e)
    {
        this.courseGroups = await mediator.Send(new GetListCourseGroupsQuery());
        bs.DataSource = this.courseGroups.Select(c => new { c.Id, CourseId=c.Course.Id ,c.GroupName, c.Course.CourseName, c.Quota, c.StartedDate, c.EndedDate }).ToList();
    }

    public async void updateCourseGroupForm_CourseGroupUpdated(object o, EventArgs e)
    {
        this.courseGroups = await mediator.Send(new GetListCourseGroupsQuery());
        bs.DataSource = this.courseGroups.Select(c => new { c.Id, CourseId=c.Course.Id, c.GroupName, c.Course.CourseName, c.Quota, c.StartedDate, c.EndedDate }).ToList();
    }
}