using CMS.Domain.Entities;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class CoursesPageBuilder : IPageBuilder
{
    private List<User> courses;
    public CoursesPageBuilder()
    {
        this.courses = new List<User>
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

        var courseNameTextBox = CreateTextBox("courseNameTextBox", "Kurs Adı", new Point(8, 3));

        var courseStatusComboBox = CreateComboBox("courseStatusComboBox", "Kurs Durumu", 250, new List<string> { "Aktif", "Pasif" }, new Point(264, 3));

        var addCourseBtn = CreateButton("addCourseBtn", "Kurs Ekle", new Point(10, 57));
        var reviewCourseBtn = CreateButton("reviewCourseBtn", "Kurs İncele", new Point(110, 57));
        var showStudentsBtn = CreateButton("reviewCourseBtn", "Kursa Kayıtlı Öğrencileri Göster", new Point(230, 57));
        var updateCourseBtn = CreateButton("updateCourseBtn", "Kurs Güncelle", new Point(520, 57));
        var deleteCourseBtn = CreateButton("deleteCourseBtn", "Kurs Sil", new Point(670, 57), true);


        deleteCourseBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteCourseBtn.UseAccentColor = true;

        Panel coursesPanel = new Panel
        {
            Name = "coursesPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        addCourseBtn.MouseClick += (o, e) =>
        {
            AddCourseForm addCourseForm = new AddCourseForm();
            addCourseForm.Show();
        };

        showStudentsBtn.MouseClick += (o, e) =>
        {
            ShowCourseStudentsForm showCourseStudentsForm = new ShowCourseStudentsForm();
            showCourseStudentsForm.Show();
        };

        DataGridView coursesDataGridView = CreateCoursesDataGridView(courses);

        coursesPanel.Controls.Add(coursesDataGridView);

        inputPanel.Controls.Add(courseNameTextBox);
        inputPanel.Controls.Add(courseStatusComboBox);
        inputPanel.Controls.Add(addCourseBtn);
        inputPanel.Controls.Add(reviewCourseBtn);
        inputPanel.Controls.Add(showStudentsBtn);
        inputPanel.Controls.Add(updateCourseBtn);
        inputPanel.Controls.Add(deleteCourseBtn);

        mainPanel.Controls.Add(coursesPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string courseNameFilter = courseNameTextBox.Text.Trim().ToLower();

            var bs = (BindingSource)coursesDataGridView.DataSource;
            bs.DataSource = courses.Where(t =>
                (string.IsNullOrEmpty(courseNameFilter) || t.FirstName.ToLower().Contains(courseNameFilter))
            ).ToList();

            bs.ResetBindings(false);
        }

        courseNameTextBox.TextChanged += (s, e) => ApplyFilter();
        courseStatusComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();
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

    private MaterialComboBox CreateComboBox(string name, string hint, int width, List<string> items, Point location)
    {
        var comboBox = new MaterialComboBox
        {
            Name = name,
            Hint = hint,
            Width = width,
            Location = location
        };
        comboBox.Items.AddRange(items.ToArray());
        return comboBox;
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

    private DataGridView CreateCoursesDataGridView(List<User> students)
    {
        var dataGridView = new DataGridView
        {
            Name = "coursesDataGridView",
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
            dataGridView.Columns["LastName"].HeaderText = "Açıklama";
        };

        return dataGridView;
    }
}
