using CMS.Application.Features.Classes.Commands.Delete;
using CMS.Application.Features.Classes.Queries.GetListClasses;
using CMS.Application.Features.CourseGroups.Queries.GetListCourseGroups;
using CMS.Application.Features.Courses.Queries.GetListTeachers;
using CMS.Domain.Entities;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class ClassesPageBuilder : IPageBuilder
{
    private ICollection<GetListClassesResponse> classes;
    private readonly IServiceProvider serviceProvider;
    private readonly IMediator mediator;
    private DataGridView classesDataGridView;
    private BindingSource bs;
    public ClassesPageBuilder(IServiceProvider serviceProvider)
    {
        this.mediator = serviceProvider.GetRequiredService<IMediator>();

        this.serviceProvider = serviceProvider;
    }

    public async void Build(TabPage tabPage)
    {
        this.classes = await mediator.Send(new GetListClassesQuery());

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
            AddClassForm addClassForm = serviceProvider.GetRequiredService<AddClassForm>();

            addClassForm.NewClassAdded += addClassForm_NewClassAdded;

            addClassForm.ShowDialog();
        };

        reviewClassBtn.MouseClick += (o, e) =>
        {
        };

        updateClassBtn.MouseClick += (o, e) =>
        {
            DataGridViewRow selectedRow = classesDataGridView.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir sınıf seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

            UpdateClassForm updateClassForm = serviceProvider.GetRequiredService<UpdateClassForm>();

            updateClassForm.ClassId = id;

            updateClassForm.ClassUpdated += updateClassForm_ClassUpdated;

            updateClassForm.ShowDialog();
        };

        deleteClassBtn.MouseClick += async (o, e) =>
        {
            var selectedRow = classesDataGridView.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir sınıf seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bu sınıfı silmek istediğinizden emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var classId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

                    await mediator.Send(new DeleteClassCommand { Id = classId });

                    classes.Remove(classes.First(c => c.Id == classId));
                    bs.ResetBindings(false);

                    MessageBox.Show("Sınıf başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme işlemi başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };

        classesDataGridView = CreateClassesDataGridView(classes);

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

            bs = (BindingSource)classesDataGridView.DataSource;

            IEnumerable<GetListClassesResponse> filtered = classes;

            if (!string.IsNullOrEmpty(classNameFilter))
                filtered = filtered.Where(c => c.ClassName.ToLower().Contains(classNameFilter));

            if (!string.IsNullOrEmpty(classCapacityFilter))
                filtered = filtered.Where(c => c.Capacity.Equals(classCapacityFilter));

            bs.DataSource = filtered.ToList();
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

    private DataGridView CreateClassesDataGridView(ICollection<GetListClassesResponse> classes)
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

        bs = new BindingSource { DataSource = classes };
        dataGridView.DataSource = bs;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["ClassName"].HeaderText = "Sınıf Adı";
            dataGridView.Columns["Capacity"].HeaderText = "Kapasitesi";
            dataGridView.Columns["Location"].HeaderText = "Konumu";
        };

        return dataGridView;
    }

    public async void addClassForm_NewClassAdded(object o, EventArgs e)
    {
        this.classes = await mediator.Send(new GetListClassesQuery());
        bs.DataSource = this.classes;
        bs.ResetBindings(false);
    }

    public async void updateClassForm_ClassUpdated(object o, EventArgs e)
    {
        this.classes = await mediator.Send(new GetListClassesQuery());
        bs.DataSource = this.classes;
        bs.ResetBindings(false);
    }
}
