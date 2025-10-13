using CMS.Domain.Entities;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class ExamsPageBuilder : IPageBuilder
{
    private List<User> exams;
    public ExamsPageBuilder()
    {
        this.exams = new List<User>
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

        var examNameTextBox = CreateTextBox("examNameTextBox", "Sınav Adı", new Point(8, 3));
        var courseTextBox = CreateTextBox("courseTextBox", "Kurs", new Point(270, 3));

        var createExamBtn = CreateButton("createExamBtn", "Sınav Oluştur", new Point(10, 57));
        var updateExamBtn = CreateButton("updateExamBtn", "Sınavı Güncelle", new Point(150, 57));
        var deleteExamBtn = CreateButton("deleteExamBtn", "Sınavı Sil", new Point(302, 57));
        var showExamResultsBtn = CreateButton("showExamResultsBtn", "Sınav Sonuçlarını Göster", new Point(397, 57));
        var enterExamResultsBtn = CreateButton("enterExamResultsBtn", "Sınav Sonuçlarını Gir", new Point(628, 57));

        deleteExamBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteExamBtn.UseAccentColor = true;

        Panel examsPanel = new Panel
        {
            Name = "examsPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        createExamBtn.MouseClick += (o, e) =>
        {
            AddExamForm addExamForm = new AddExamForm();
            addExamForm.Show();
        };

        updateExamBtn.MouseClick += (o, e) =>
        {
            ShowAttendanceForm showAttendanceForm = new ShowAttendanceForm();
            showAttendanceForm.Show();
        };

        deleteExamBtn.MouseClick += (o, e) =>
        {
            TakeAttendanceForm takeAttendanceForm = new TakeAttendanceForm();
            takeAttendanceForm.Show();
        };

        showExamResultsBtn.MouseClick += (o, e) =>
        {
            ShowExamResultsForm showExamResultsForm = new ShowExamResultsForm();
            showExamResultsForm.Show();
        };

        enterExamResultsBtn.MouseClick += (o, e) =>
        {
            EnterExamResultsForm enterExamResultsForm = new EnterExamResultsForm();
            enterExamResultsForm.Show();
        };

        DataGridView examsDataGridView = CreateExamsDataGridView(exams);

        examsPanel.Controls.Add(examsDataGridView);

        inputPanel.Controls.Add(examNameTextBox);
        inputPanel.Controls.Add(courseTextBox);
        inputPanel.Controls.Add(createExamBtn);
        inputPanel.Controls.Add(updateExamBtn);
        inputPanel.Controls.Add(deleteExamBtn);
        inputPanel.Controls.Add(showExamResultsBtn);
        inputPanel.Controls.Add(enterExamResultsBtn);

        mainPanel.Controls.Add(examsPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string examNameFilter = examNameTextBox.Text.Trim().ToLower();
            string courseFilter = courseTextBox.Text.Trim().ToLower();

            var bs = (BindingSource)examsDataGridView.DataSource;
            bs.DataSource = exams.Where(t =>
                (string.IsNullOrEmpty(examNameFilter) || t.FirstName.ToLower().Contains(examNameFilter)) ||
                (string.IsNullOrEmpty(courseFilter) || t.FirstName.ToLower().Contains(courseFilter))
            ).ToList();

            bs.ResetBindings(false);
        }

        courseTextBox.TextChanged += (s, e) => ApplyFilter();
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

    private DataGridView CreateExamsDataGridView(List<User> students)
    {
        var dataGridView = new DataGridView
        {
            Name = "examsDatGridView",
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
            dataGridView.Columns["FirstName"].HeaderText = "Sınav Adı";
            dataGridView.Columns["LastName"].HeaderText = "Kurs";
        };

        return dataGridView;
    }
}
