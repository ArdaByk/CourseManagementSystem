using CMS.Domain.Entities;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class TeachersPageBuilder : IPageBuilder
{
    private List<User> teachers;
    public TeachersPageBuilder()
    {
        this.teachers = new List<User>
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

        var firstNameTextBox = CreateTextBox("firstNameTextBox", "Adı", new Point(8, 3));
        var lastNameTextBox = CreateTextBox("lastNameTextBox", "Soyadı", new Point(264, 3));

        var teacherStatusComboBox = CreateComboBox("teacherStatusComboBox", "Öğretmen Durumu", 250, new List<string> { "Aktif", "Pasif" }, new Point(520, 3));

        var addTeacherButton = CreateButton("addTeacherButton", "Öğretmen Ekle", new Point(10, 57));
        var reviewTeacherBtn = CreateButton("reviewTeacherBtn", "Öğretmen İncele", new Point(160, 57));
        var updateTeacherBtn = CreateButton("updateTeacherBtn", "Öğretmen Güncelle", new Point(325, 57));
        var deleteTeacherBtn = CreateButton("deleteTeacherBtn", "Öğretmen Sil", new Point(515, 57), true);

        deleteTeacherBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteTeacherBtn.UseAccentColor = true;

        Panel teachersPanel = new Panel
        {
            Name = "teachersPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        addTeacherButton.MouseClick += (o, e) =>
        {
            AddTeacherForm addTeacherForm = new AddTeacherForm();
            addTeacherForm.Show();
        };

        DataGridView teachersDataGridView = CreateTeachersDataGridView(teachers);

        teachersPanel.Controls.Add(teachersDataGridView);

        inputPanel.Controls.Add(firstNameTextBox);
        inputPanel.Controls.Add(lastNameTextBox);
        inputPanel.Controls.Add(teacherStatusComboBox);
        inputPanel.Controls.Add(addTeacherButton);
        inputPanel.Controls.Add(reviewTeacherBtn);
        inputPanel.Controls.Add(updateTeacherBtn);
        inputPanel.Controls.Add(deleteTeacherBtn);

        mainPanel.Controls.Add(teachersPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string firstNameFilter = firstNameTextBox.Text.Trim().ToLower();
            string lastNameFilter = lastNameTextBox.Text.Trim().ToLower();

            var bs = (BindingSource)teachersDataGridView.DataSource;
            bs.DataSource = teachers.Where(t =>
                (string.IsNullOrEmpty(firstNameFilter) || t.FirstName.ToLower().Contains(firstNameFilter)) &&
                (string.IsNullOrEmpty(lastNameFilter) || t.LastName.ToLower().Contains(lastNameFilter))
            ).ToList();

            bs.ResetBindings(false);
        }

        firstNameTextBox.TextChanged += (s, e) => ApplyFilter();
        lastNameTextBox.TextChanged += (s, e) => ApplyFilter();
        teacherStatusComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();
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

    private DataGridView CreateTeachersDataGridView(List<User> students)
    {
        var dataGridView = new DataGridView
        {
            Name = "teachersDataGridView",
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
            dataGridView.Columns["FirstName"].HeaderText = "Adı";
            dataGridView.Columns["LastName"].HeaderText = "Soyadı";
            dataGridView.Columns["Email"].HeaderText = "Telefon Numarası";
        };

        return dataGridView;
    }
}
