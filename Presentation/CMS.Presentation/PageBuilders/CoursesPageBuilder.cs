using CMS.Application.Features.Courses.Commands.Delete;
using CMS.Application.Features.Courses.Queries.GetListTeachers;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class CoursesPageBuilder : IPageBuilder
{
    private ICollection<GetListCoursesResponse> courses;
    private readonly IServiceProvider serviceProvider;
    private readonly IMediator mediator;
    private DataGridView coursesDataGridView;
    private BindingSource bs;
    public CoursesPageBuilder(IServiceProvider serviceProvider)
    {
        this.mediator = serviceProvider.GetRequiredService<IMediator>();

        this.serviceProvider = serviceProvider;
    }

    public async void Build(TabPage tabPage)
    {
        this.courses = await mediator.Send(new GetListCoursesQuery());

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
        var showStudentsBtn = CreateButton("showStudentsBtn", "Kursa Kayıtlı Öğrencileri Göster", new Point(230, 57));
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
            AddCourseForm addCourseForm = serviceProvider.GetRequiredService<AddCourseForm>();

            addCourseForm.NewCourseAdded += addCourseForm_NewCourseAdded;

            addCourseForm.ShowDialog();
        };

        updateCourseBtn.MouseClick += (o, e) =>
        {
            DataGridViewRow selectedRow = coursesDataGridView.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir kurs seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

            UpdateCourseForm updateCourseForm = serviceProvider.GetRequiredService<UpdateCourseForm>();

            updateCourseForm.CourseId = id;

            updateCourseForm.CourseUpdated += updateCourseForm_CourseUpdated;

            updateCourseForm.ShowDialog();
        };

        deleteCourseBtn.MouseClick += async (s, e) =>
        {
            var selectedRow = coursesDataGridView.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir kurs seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bu kursu silmek istediğinizden emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var courseId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

                    await mediator.Send(new DeleteCourseCommand { Id = courseId });

                    courses.Remove(courses.First(c => c.Id == courseId));
                    bs.ResetBindings(false);

                    MessageBox.Show("Kurs başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme işlemi başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };

        showStudentsBtn.MouseClick += (o, e) =>
        {
            ShowCourseStudentsForm showCourseStudentsForm = serviceProvider.GetRequiredService<ShowCourseStudentsForm>();
            showCourseStudentsForm.CourseId = Guid.Parse(coursesDataGridView.CurrentRow.Cells["Id"].Value.ToString());
            showCourseStudentsForm.Show();
        };

        coursesDataGridView = CreateCoursesDataGridView(courses);

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
            bs.DataSource = courses.Where(c =>
                (string.IsNullOrEmpty(courseNameFilter) || c.CourseName.ToLower().Contains(courseNameFilter))
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

    private DataGridView CreateCoursesDataGridView(ICollection<GetListCoursesResponse> students)
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

        bs = new BindingSource { DataSource = students };
        dataGridView.DataSource = bs;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["CourseName"].HeaderText = "Kurs Adı";
            dataGridView.Columns["Description"].HeaderText = "Açıklama";
            dataGridView.Columns["Status"].HeaderText = "Kurs Durumu";
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

    public async void addCourseForm_NewCourseAdded(object o, EventArgs e)
    {
        this.courses = await mediator.Send(new GetListCoursesQuery());
        bs.DataSource = this.courses;
        bs.ResetBindings(false);
    }

    public async void updateCourseForm_CourseUpdated(object o, EventArgs e)
    {
        this.courses = await mediator.Send(new GetListCoursesQuery());
        bs.DataSource = this.courses;
        bs.ResetBindings(false);
    }
}
