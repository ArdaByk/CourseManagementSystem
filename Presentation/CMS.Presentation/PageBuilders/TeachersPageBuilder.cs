using CMS.Application.Features.CourseGroups.Queries.GetListCourseGroups;
using CMS.Application.Features.Students.Queries.GetListStudents;
using CMS.Application.Features.Teachers.Commands.Delete;
using CMS.Application.Features.Teachers.Queries.GetListTeachers;
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

public class TeachersPageBuilder : IPageBuilder
{
    private ICollection<GetListTeacherResponse> teachers;
    private readonly IServiceProvider serviceProvider;
    private readonly IMediator mediator;
    private DataGridView teachersDataGridView;
    private BindingSource bs;
    public TeachersPageBuilder(IServiceProvider serviceProvider)
    {
        this.mediator = serviceProvider.GetRequiredService<IMediator>();

        this.serviceProvider = serviceProvider;
    }
    public async void Build(TabPage tabPage)
    {
        this.teachers = await mediator.Send(new GetListTeacherQuery());

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
        var updateTeacherBtn = CreateButton("updateTeacherBtn", "Öğretmen Güncelle", new Point(160, 57));
        var deleteTeacherBtn = CreateButton("deleteTeacherBtn", "Öğretmen Sil", new Point(345, 57), true);

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
            AddTeacherForm addTeacherForm = serviceProvider.GetRequiredService<AddTeacherForm>();

            addTeacherForm.NewTeacherAdded += addTeacherForm_NewTeacherAdded;

            addTeacherForm.ShowDialog();
        };

        updateTeacherBtn.MouseClick += (o, e) =>
        {
            DataGridViewRow selectedRow = teachersDataGridView.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir öğretmen seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

            UpdateTeacherForm updateTeacherForm = serviceProvider.GetRequiredService<UpdateTeacherForm>();

            updateTeacherForm.TeacherId = id;

            updateTeacherForm.TeacherUpdated += updateTeacherForm_TeacherUpdated;

            updateTeacherForm.ShowDialog();
        };

        deleteTeacherBtn.MouseClick += async (s, e) =>
        {
            var selectedRow = teachersDataGridView.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir öğretmen seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bu Öğretmeni silmek istediğinizden emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var teacherId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

                    await mediator.Send(new DeleteTeacherCommand { Id = teacherId });

                    teachers.Remove(teachers.First(t => t.Id == teacherId));
                    bs.ResetBindings(false);

                    MessageBox.Show("Öğretmen başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme işlemi başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };

        teachersDataGridView = CreateTeachersDataGridView(teachers);

        teachersPanel.Controls.Add(teachersDataGridView);

        inputPanel.Controls.Add(firstNameTextBox);
        inputPanel.Controls.Add(lastNameTextBox);
        inputPanel.Controls.Add(teacherStatusComboBox);
        inputPanel.Controls.Add(addTeacherButton);
        inputPanel.Controls.Add(updateTeacherBtn);
        inputPanel.Controls.Add(deleteTeacherBtn);

        mainPanel.Controls.Add(teachersPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string firstNameFilter = firstNameTextBox.Text.Trim().ToLower();
            string lastNameFilter = lastNameTextBox.Text.Trim().ToLower();

            bs = (BindingSource)teachersDataGridView.DataSource;

            IEnumerable<GetListTeacherResponse> filtered = teachers;

            if (!string.IsNullOrEmpty(firstNameFilter))
                filtered = filtered.Where(t => t.FirstName.ToLower().Contains(firstNameFilter));

            if (!string.IsNullOrEmpty(lastNameFilter))
                filtered = filtered.Where(t => t.LastName.ToLower().Contains(lastNameFilter));

            if (teacherStatusComboBox.SelectedItem != null)
            {
                char genderFilter = teacherStatusComboBox.SelectedItem.ToString() == "Aktif" ? 'A' : 'P';
                filtered = filtered.Where(t => t.Status == genderFilter);
            }

            bs.DataSource = filtered.ToList();
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
            Width = 180,
            UseAccentColor = useAccent
        };
    }

    private DataGridView CreateTeachersDataGridView(ICollection<GetListTeacherResponse> teachers)
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

        bs = new BindingSource { DataSource = teachers.Select(t => new { t.Id, t.FirstName, t.LastName, t.Status }).ToList() };
        dataGridView.DataSource = bs;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["FirstName"].HeaderText = "Adı";
            dataGridView.Columns["LastName"].HeaderText = "Soyadı";
            dataGridView.Columns["Status"].HeaderText = "Öğretmen Durumu";
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

    public async void addTeacherForm_NewTeacherAdded(object o, EventArgs e)
    {
        this.teachers = await mediator.Send(new GetListTeacherQuery());
        bs.DataSource = this.teachers.Select(t => new { t.Id, t.FirstName, t.LastName, t.Status }).ToList();
        bs.ResetBindings(false);
    }

    public async void updateTeacherForm_TeacherUpdated(object o, EventArgs e)
    {
        this.teachers = await mediator.Send(new GetListTeacherQuery());
        bs.DataSource = this.teachers.Select(t => new { t.Id, t.FirstName, t.LastName, t.Status }).ToList();
        bs.ResetBindings(false);
    }
}
