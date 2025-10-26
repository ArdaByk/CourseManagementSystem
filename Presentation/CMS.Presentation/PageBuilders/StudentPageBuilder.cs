using CMS.Application.Features.Students.Commands.Delete;
using CMS.Application.Features.Students.Commands.Update;
using CMS.Application.Features.Students.Queries.GetListStudents;
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
    private ICollection<GetListStudentResponse> students;
    private readonly IServiceProvider serviceProvider;
    private readonly IMediator mediator;
    private DataGridView studentsDataGridView;
    private BindingSource bs;
    public StudentPageBuilder(IServiceProvider serviceProvider)
    {
        this.mediator = serviceProvider.GetRequiredService<IMediator>();

        this.serviceProvider = serviceProvider;
    }
    public async void Build(TabPage tabPage)
    {
        this.students = await mediator.Send(new GetListStudentQuery());

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

        studentsDataGridView = CreateStudentsDataGridView(students);

        updateStudentBtn.MouseClick += (o, e) =>
        {
            DataGridViewRow selectedRow = studentsDataGridView.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir öğrenci seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());
               
            UpdateStudentForm updateStudentForm = serviceProvider.GetRequiredService<UpdateStudentForm>();

            updateStudentForm.StudentId = id;

            updateStudentForm.StudentUpdated += updateStudentForm_StudentUpdated;

            updateStudentForm.ShowDialog();
        };

        addStudentBtn.MouseClick += (o, e) =>
        {
            AddStudentForm addStudentForm = serviceProvider.GetRequiredService<AddStudentForm>();

            addStudentForm.NewStudentAdded += addStudentForm_NewStudentAdded;

            addStudentForm.ShowDialog();
        };

        deleteStudentBtn.MouseClick += async (s, e) =>
        {
            var selectedRow = studentsDataGridView.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir öğrenci seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bu öğrenciyi silmek istediğinizden emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var studentId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

                    await mediator.Send(new DeleteStudentCommand { Id= studentId});

                    students.Remove(students.First(s => s.Id == studentId));
                    bs.ResetBindings(false);

                    MessageBox.Show("Öğrenci başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme işlemi başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };


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
            string nationalIdFilter = nationalIDTextBox.Text.Trim();
            string firstNameFilter = firstNameTextBox.Text.Trim().ToLower();
            string lastNameFilter = lastNameTextBox.Text.Trim().ToLower();

            bs = (BindingSource)studentsDataGridView.DataSource;

            IEnumerable<GetListStudentResponse> filtered = students;

            if (!string.IsNullOrEmpty(nationalIdFilter))
                filtered = filtered.Where(s => s.NationalId.Contains(nationalIdFilter));

            if (!string.IsNullOrEmpty(firstNameFilter))
                filtered = filtered.Where(s => s.FirstName.ToLower().Contains(firstNameFilter));

            if (!string.IsNullOrEmpty(lastNameFilter))
                filtered = filtered.Where(s => s.LastName.ToLower().Contains(lastNameFilter));

            if (genderComboBox.SelectedItem != null)
            {
                char genderFilter = genderComboBox.SelectedItem.ToString() == "Erkek" ? 'E' : 'K';
                filtered = filtered.Where(s => s.Gender == genderFilter);
            }

            if (studentStatusComboBox.SelectedItem != null)
            {
                char statusFilter = studentStatusComboBox.SelectedItem.ToString() == "Aktif" ? 'A' : 'P';
                filtered = filtered.Where(s => s.Status == statusFilter);
            }

            bs.DataSource = filtered.ToList();
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

    private DataGridView CreateStudentsDataGridView(ICollection<GetListStudentResponse> students)
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

        bs = new BindingSource { DataSource = students };
        dataGridView.DataSource = bs;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["NationalId"].HeaderText = "TC Kimlik No";
            dataGridView.Columns["FirstName"].HeaderText = "Adı";
            dataGridView.Columns["LastName"].HeaderText = "Soyadı";
            dataGridView.Columns["Status"].HeaderText = "Öğrenci Durumu";

        };

        dataGridView.CellFormatting += (s, e) =>
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "A")
                    e.Value = "Aktif";
                else if (status == "P")
                    e.Value = "Pasif";
            }
        };

        return dataGridView;
    }

    public async void addStudentForm_NewStudentAdded(object o, EventArgs e)
    {
        this.students = await mediator.Send(new GetListStudentQuery());
        bs.DataSource = this.students;
        bs.ResetBindings(false);
    }

    public async void updateStudentForm_StudentUpdated(object o, EventArgs e)
    {
        this.students = await mediator.Send(new GetListStudentQuery());
        bs.DataSource = this.students;
        bs.ResetBindings(false);
    }
}
