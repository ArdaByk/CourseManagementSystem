using CMS.Domain.Entities;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class SpecializationPageBuilder : IPageBuilder
{
    private List<User> specializations;

    public SpecializationPageBuilder()
    {
        this.specializations = new List<User>
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

        var specializationNameTextBox = CreateTextBox("specializationNameTextBox", "Uzmanlık Alanı Adı", new Point(8, 3));

        var addSpecializationBtn = CreateButton("addSpecializationBtn", "Uzmanlık Alanı Ekle", new Point(10, 57));
        var reviewSpecializationBtn = CreateButton("reviewSpecializationBtn", "Uzmanlık Alanını İncele", new Point(200, 57));
        var updateSpecializationBtn = CreateButton("updateSpecializationBtn", "Uzmanlık Alanını Güncelle", new Point(420, 57));
        var deleteSpecializationBtn = CreateButton("deleteSpecializationBtn", "Uzmanlık Alanını Sil", new Point(664, 57));


        deleteSpecializationBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteSpecializationBtn.UseAccentColor = true;

        Panel specializationsPanel = new Panel
        {
            Name = "specializationsPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        addSpecializationBtn.MouseClick += (o, e) =>
        {
            AddSpecializationForm addSpecializationForm = new AddSpecializationForm();
            addSpecializationForm.Show();
        };

        reviewSpecializationBtn.MouseClick += (o, e) =>
        {
            ShowCourseStudentsForm showCourseStudentsForm = new ShowCourseStudentsForm();
            showCourseStudentsForm.Show();
        };

        updateSpecializationBtn.MouseClick += (o, e) =>
        {
            ShowCourseStudentsForm showCourseStudentsForm = new ShowCourseStudentsForm();
            showCourseStudentsForm.Show();
        };

        deleteSpecializationBtn.MouseClick += (o, e) =>
        {
            ShowCourseStudentsForm showCourseStudentsForm = new ShowCourseStudentsForm();
            showCourseStudentsForm.Show();
        };

        DataGridView specializationsDataGridView = CreateSpecializationsDataGridView(specializations);

        specializationsPanel.Controls.Add(specializationsDataGridView);

        inputPanel.Controls.Add(specializationNameTextBox);
        inputPanel.Controls.Add(addSpecializationBtn);
        inputPanel.Controls.Add(reviewSpecializationBtn);
        inputPanel.Controls.Add(updateSpecializationBtn);
        inputPanel.Controls.Add(deleteSpecializationBtn);

        mainPanel.Controls.Add(specializationsPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string specializationNameFilter = specializationNameTextBox.Text.Trim().ToLower();

            var bs = (BindingSource)specializationsDataGridView.DataSource;
            bs.DataSource = specializations.Where(t =>
                (string.IsNullOrEmpty(specializationNameFilter) || t.FirstName.ToLower().Contains(specializationNameFilter))
            ).ToList();

            bs.ResetBindings(false);
        }

        specializationNameTextBox.TextChanged += (s, e) => ApplyFilter();
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

    private DataGridView CreateSpecializationsDataGridView(List<User> students)
    {
        var dataGridView = new DataGridView
        {
            Name = "specializationsDataGridView",
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
