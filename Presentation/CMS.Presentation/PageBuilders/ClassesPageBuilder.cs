using CMS.Domain.Entities;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class ClassesPageBuilder : IPageBuilder
{
    private List<User> students;
    public ClassesPageBuilder()
    {
           this.students = new List<User>
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

        var classNameTextBox = CreateTextBox("classNameTextBox", "Sınıf Adı", new Point(8, 3));
        var classCapacityTextBox = CreateTextBox("classCapacityTextBox", "Sınıf Kontenjanı", new Point(270, 3));

        var addClassBtn = CreateButton("addClassBtn", "Sınıf Ekle", new Point(10, 57));
        var reviewClassBtn = CreateButton("reviewClassBtn", "Sınıfı İncele", new Point(110, 57));
        var updateClassBtn = CreateButton("updateClassBtn", "Sınıfı Güncelle", new Point(230, 57));
        var deleteClassBtn = CreateButton("deleteClassBtn", "Sınıf Sil", new Point(375, 57), true);

        deleteClassBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteClassBtn.UseAccentColor = true;

        Panel classesPanel = new Panel
        {
            Name = "classesPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        addClassBtn.MouseClick += (o, e) =>
        {
            AddClassForm addClassForm = new AddClassForm();
            addClassForm.Show();
        };

        reviewClassBtn.MouseClick += (o, e) =>
        {
            ShowCourseGroupStudentsForm showCourseGroupStudentsForm = new ShowCourseGroupStudentsForm();
            showCourseGroupStudentsForm.Show();
        };

        updateClassBtn.MouseClick += (o, e) =>
        {
            ShowAttendanceForm showAttendanceForm = new ShowAttendanceForm();
            showAttendanceForm.Show();
        };

        deleteClassBtn.MouseClick += (o, e) =>
        {
            TakeAttendanceForm takeAttendanceForm = new TakeAttendanceForm();
            takeAttendanceForm.Show();
        };

        DataGridView classesDataGridView = CreateClassesDataGridView(students);

        classesPanel.Controls.Add(classesDataGridView);

        inputPanel.Controls.Add(classNameTextBox);
        inputPanel.Controls.Add(classCapacityTextBox);
        inputPanel.Controls.Add(addClassBtn);
        inputPanel.Controls.Add(reviewClassBtn);
        inputPanel.Controls.Add(updateClassBtn);
        inputPanel.Controls.Add(deleteClassBtn);

        mainPanel.Controls.Add(classesPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string classNameFilter = classNameTextBox.Text.Trim().ToLower();
            string classCapacityFilter = classCapacityTextBox.Text.Trim().ToLower();

            var bs = (BindingSource)classesDataGridView.DataSource;
            bs.DataSource = students.Where(t =>
                (string.IsNullOrEmpty(classNameFilter) || t.FirstName.ToLower().Contains(classNameFilter)) ||
                (string.IsNullOrEmpty(classCapacityFilter) || t.FirstName.ToLower().Contains(classCapacityFilter))
            ).ToList();

            bs.ResetBindings(false);
        }

        classNameTextBox.TextChanged += (s, e) => ApplyFilter();
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

    private DataGridView CreateClassesDataGridView(List<User> students)
    {
        var dataGridView = new DataGridView
        {
            Name = "classesDataGridView",
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
            dataGridView.Columns["FirstName"].HeaderText = "Sınıf Adı";
            dataGridView.Columns["LastName"].HeaderText = "Kapasitesi";
        };

        return dataGridView;
    }
}
