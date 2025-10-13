using CMS.Domain.Entities;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class CourseGroupsBuilder : IPageBuilder
{
    private List<User> courseGroups;

    public CourseGroupsBuilder()
    {
        this.courseGroups = new List<User>
        {
            new User { Id = 123424234, FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet@example.com" },
            new User { Id = 123424234, FirstName = "Ayşe", LastName = "Demir", Email = "ayse@example.com" },
            new User { Id = 123424234, FirstName = "Mehmet", LastName = "Can", Email = "mehmet@example.com" }
        };
    }

    public void Build(TabPage tabPage)
    {
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
        var reviewCourseGroupBtn = CreateButton("reviewCourseGroupBtn", "Grup İncele", new Point(113, 57));
        var updateCourseGroupBtn = CreateButton("updateCourseGroupBtn", "Grup Güncelle", new Point(230, 57));
        var deleteCourseGroupBtn = CreateButton("deleteCourseGroupBtn", "Grup Sil", new Point(375, 57), true);
        var showStudentsBtn = CreateButton("showStudentsBtn", "Gruba Kayıtlı Öğrencileri Göster", new Point(465, 57));
        var takeAttendanceBtn = CreateButton("takeAttendanceBtn", "Yoklama Al", new Point(750, 57));
        var showAttendanceBtn = CreateButton("showAttendanceBtn", "Yoklama Göster", new Point(873, 57));
        var registerStudentBtn = CreateButton("registerStudentBtn", "Öğrenci Kaydı Yap", new Point(1035, 57));

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
            AddCourseGroupForm addCourseGroupForm = new AddCourseGroupForm();
            addCourseGroupForm.Show();
        };

        showStudentsBtn.MouseClick += (o, e) =>
        {
            ShowCourseGroupStudentsForm showCourseGroupStudentsForm = new ShowCourseGroupStudentsForm();
            showCourseGroupStudentsForm.Show();
        };

        showAttendanceBtn.MouseClick += (o, e) =>
        {
            ShowAttendanceForm showAttendanceForm = new ShowAttendanceForm();
            showAttendanceForm.Show();
        };

        takeAttendanceBtn.MouseClick += (o, e) =>
        {
            TakeAttendanceForm takeAttendanceForm = new TakeAttendanceForm();
            takeAttendanceForm.Show();
        };

        registerStudentBtn.MouseClick += (o, e) =>
        {
            RegisterStudentForm registerStudentForm = new RegisterStudentForm();
            registerStudentForm.Show();
        };

        DataGridView courseGroupsDataGridView = CreateCourseGroupsDataGridView(courseGroups);

        courseGroupsPanel.Controls.Add(courseGroupsDataGridView);

        inputPanel.Controls.Add(courseGroupNameTextBox);
        inputPanel.Controls.Add(courseGroupQuotaTextBox);
        inputPanel.Controls.Add(courseNameTextBox);
        inputPanel.Controls.Add(addCourseGroupBtn);
        inputPanel.Controls.Add(reviewCourseGroupBtn);
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

            var bs = (BindingSource)courseGroupsDataGridView.DataSource;
            bs.DataSource = courseGroups.Where(t =>
                (string.IsNullOrEmpty(courseNameFilter) || t.FirstName.ToLower().Contains(courseNameFilter)) ||
                (string.IsNullOrEmpty(courseGroupNameFilter) || t.FirstName.ToLower().Contains(courseGroupNameFilter)) ||
                (string.IsNullOrEmpty(courseGroupQuotaFilter) || t.FirstName.ToLower().Contains(courseGroupQuotaFilter))
            ).ToList();

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
            UseAccentColor = useAccent
        };
    }

    private DataGridView CreateCourseGroupsDataGridView(List<User> students)
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

        BindingSource bs = new BindingSource { DataSource = students };
        dataGridView.DataSource = bs;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].HeaderText = "ID";
            dataGridView.Columns["FirstName"].HeaderText = "Kurs Adı";
            dataGridView.Columns["LastName"].HeaderText = "Kurs Grup Adı";
        };

        return dataGridView;
    }
}
