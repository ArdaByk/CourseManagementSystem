using CMS.Application.Features.Courses.Queries.GetListTeachers;
using CMS.Application.Features.Specializations.Commands.Delete;
using CMS.Application.Features.Specializations.Queries.GetListSpecializations;
using CMS.Application.Features.Students.Queries.GetListStudents;
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

public class SpecializationPageBuilder : IPageBuilder
{
    private ICollection<GetListSpecializationsResponse> specializations;
    private readonly IServiceProvider serviceProvider;
    private readonly IMediator mediator;
    private DataGridView specializationsDataGridView;
    private BindingSource bs;
    public SpecializationPageBuilder(IServiceProvider serviceProvider)
    {
        this.mediator = serviceProvider.GetRequiredService<IMediator>();

        this.serviceProvider = serviceProvider;
    }

    public async void Build(TabPage tabPage)
    {
        this.specializations = await mediator.Send(new GetListSpecializationsQuery());
        
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
        var updateSpecializationBtn = CreateButton("updateSpecializationBtn", "Uzmanlık Alanını Güncelle", new Point(193, 57));
        var deleteSpecializationBtn = CreateButton("deleteSpecializationBtn", "Uzmanlık Alanını Sil", new Point(430, 57));


        deleteSpecializationBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteSpecializationBtn.UseAccentColor = true;

        Panel specializationsPanel = new Panel
        {
            Name = "specializationsPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        specializationsDataGridView = CreateSpecializationsDataGridView(specializations);

        updateSpecializationBtn.MouseClick += (o, e) =>
        {
            DataGridViewRow selectedRow = specializationsDataGridView.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir uzmanlık alanı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

            UpdateSpecializationForm updateSpecializationForm = serviceProvider.GetRequiredService<UpdateSpecializationForm>();

            updateSpecializationForm.SpecializationId = id;

            updateSpecializationForm.SpecializationUpdated += updateSpecializationForm_SpecializationUpdated;

            updateSpecializationForm.ShowDialog();
        };

        addSpecializationBtn.MouseClick += (o, e) =>
        {
            AddSpecializationForm addSpecializationForm = serviceProvider.GetRequiredService<AddSpecializationForm>();

            addSpecializationForm.NewSpecializationAdded += addSpecializationForm_NewSpecializationAdded;

            addSpecializationForm.ShowDialog();
        };

        deleteSpecializationBtn.MouseClick += async (s, e) =>
        {
            var selectedRow = specializationsDataGridView.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir uzmanlık alanı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bu uzmanlık alanını silmek istediğinizden emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var specializationId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

                    await mediator.Send(new DeleteSpecializationCommand { Id = specializationId });

                    specializations.Remove(specializations.First(s => s.Id == specializationId));
                    bs.ResetBindings(false);

                    MessageBox.Show("Uzmanlık Alanı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme işlemi başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };

        specializationsPanel.Controls.Add(specializationsDataGridView);

        inputPanel.Controls.Add(specializationNameTextBox);
        inputPanel.Controls.Add(addSpecializationBtn);
        inputPanel.Controls.Add(updateSpecializationBtn);
        inputPanel.Controls.Add(deleteSpecializationBtn);

        mainPanel.Controls.Add(specializationsPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string specializationNameFilter = specializationNameTextBox.Text.Trim().ToLower();

            bs = (BindingSource)specializationsDataGridView.DataSource;

            IEnumerable<GetListSpecializationsResponse> filtered = specializations;

            if (!string.IsNullOrEmpty(specializationNameFilter))
                filtered = filtered.Where(s => s.SpecializationName.ToLower().Contains(specializationNameFilter));

            bs.DataSource = filtered.ToList();
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
            Width = 180,
            UseAccentColor = useAccent
        };
    }

    private DataGridView CreateSpecializationsDataGridView(ICollection<GetListSpecializationsResponse> specializations)
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

        bs = new BindingSource { DataSource = specializations };
        dataGridView.DataSource = bs;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["SpecializationName"].HeaderText = "Uzmanlık Alanı Adı";
        };

        return dataGridView;
    }

    public async void addSpecializationForm_NewSpecializationAdded(object o, EventArgs e)
    {
        this.specializations = await mediator.Send(new GetListSpecializationsQuery());
        bs.DataSource = this.specializations;
        bs.ResetBindings(false);
    }

    public async void updateSpecializationForm_SpecializationUpdated(object o, EventArgs e)
    {
        this.specializations = await mediator.Send(new GetListSpecializationsQuery());
        bs.DataSource = this.specializations;
        bs.ResetBindings(false);
    }
}
