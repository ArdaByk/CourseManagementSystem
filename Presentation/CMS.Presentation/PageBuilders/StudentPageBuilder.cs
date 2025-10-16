using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class StudentPageBuilder : IPageBuilder
{
    private List<User> students;
    private readonly IServiceProvider serviceProvider;
    public StudentPageBuilder(IServiceProvider serviceProvider)
    {
        this.students = new List<User>
        {
            new User { Id = 123424234, FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet@example.com" },
            new User { Id = 123424234, FirstName = "Ayşe", LastName = "Demir", Email = "ayse@example.com" },
            new User { Id = 123424234, FirstName = "Mehmet", LastName = "Can", Email = "mehmet@example.com" }
        };

        this.serviceProvider = serviceProvider;
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

        var nationalIDTextBox = CreateTextBox("nationalIDTextBox", "TC Kimlik NO", new Point(8, 3));
        var firstNameTextBox = CreateTextBox("firstNameTextBox", "Adı", new Point(264, 3));
        var lastNameTextBox = CreateTextBox("lastNameTextBox", "Soyadı", new Point(520, 3));

        var genderComboBox = CreateComboBox("genderComboBox", "Cinsiyet", 250, new List<string> { "Erkek", "Kız" }, new Point(776, 2));
        var studentStatusComboBox = CreateComboBox("studentStatusComboBox", "Öğrenci Durumu", 250, new List<string> { "Aktif", "Pasif" }, new Point(1035, 2));

        var addStudentBtn = CreateButton("addStudentButton", "Öğrenci Ekle", new Point(10, 57));
        var reviewStudentBtn = CreateButton("reviewStudentBtn", "Öğrenci İncele", new Point(140, 57));
        var updateStudentBtn = CreateButton("updateStudentBtn", "Öğrenci Güncelle", new Point(285, 57));
        var deleteStudentBtn = CreateButton("deleteStudentBtn", "Öğrenci Sil", new Point(455, 57), true);

        deleteStudentBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteStudentBtn.UseAccentColor = true;

        Panel studentsPanel = new Panel
        {
            Name = "studentsPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        addStudentBtn.MouseClick += (o, e) =>
        {
            AddStudentForm addStudentForm = serviceProvider.GetRequiredService<AddStudentForm>();
            addStudentForm.Show();
        };

        DataGridView studentsDataGridView = CreateStudentsDataGridView(students);

        studentsPanel.Controls.Add(studentsDataGridView);

        inputPanel.Controls.Add(nationalIDTextBox);
        inputPanel.Controls.Add(firstNameTextBox);
        inputPanel.Controls.Add(lastNameTextBox);
        inputPanel.Controls.Add(genderComboBox);
        inputPanel.Controls.Add(studentStatusComboBox);
        inputPanel.Controls.Add(addStudentBtn);
        inputPanel.Controls.Add(reviewStudentBtn);
        inputPanel.Controls.Add(updateStudentBtn);
        inputPanel.Controls.Add(deleteStudentBtn);

        mainPanel.Controls.Add(studentsPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string idFilter = nationalIDTextBox.Text.Trim();
            string firstNameFilter = firstNameTextBox.Text.Trim().ToLower();
            string lastNameFilter = lastNameTextBox.Text.Trim().ToLower();

            var bs = (BindingSource)studentsDataGridView.DataSource;
            bs.DataSource = students.Where(s =>
                (string.IsNullOrEmpty(idFilter) || s.Id.Equals(idFilter)) &&
                (string.IsNullOrEmpty(firstNameFilter) || s.FirstName.ToLower().Contains(firstNameFilter)) &&
                (string.IsNullOrEmpty(lastNameFilter) || s.LastName.ToLower().Contains(lastNameFilter))
            ).ToList();

            bs.ResetBindings(false);
        }

        nationalIDTextBox.TextChanged += (s, e) => ApplyFilter();
        firstNameTextBox.TextChanged += (s, e) => ApplyFilter();
        lastNameTextBox.TextChanged += (s, e) => ApplyFilter();
        genderComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();
        studentStatusComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();
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

    private DataGridView CreateStudentsDataGridView(List<User> students)
    {
        var dataGridView = new DataGridView
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

        BindingSource bs = new BindingSource { DataSource = students };
        dataGridView.DataSource = bs;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].HeaderText = "TC Kimlik No";
            dataGridView.Columns["FirstName"].HeaderText = "Adı";
            dataGridView.Columns["LastName"].HeaderText = "Soyadı";
            dataGridView.Columns["Email"].HeaderText = "E-Posta";
        };

        return dataGridView;
    }
}
