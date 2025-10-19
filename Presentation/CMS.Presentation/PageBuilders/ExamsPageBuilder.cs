using CMS.Application.Features.Exams.Commands.Delete;
using CMS.Application.Features.Exams.Queries.GetListExams;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class ExamsPageBuilder : IPageBuilder
{
    private ICollection<GetListExamsResponse> exams;
    private readonly IServiceProvider serviceProvider;
    private readonly IMediator mediator;
    private DataGridView examsDataGridView;
    private BindingSource bs;
    public ExamsPageBuilder(IServiceProvider serviceProvider)
    {
        this.mediator = serviceProvider.GetRequiredService<IMediator>();

        this.serviceProvider = serviceProvider;
    }
    public async void Build(TabPage tabPage)
    {
        this.exams = await mediator.Send(new GetListExamsQuery());

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
            AddExamForm addExamForm = serviceProvider.GetRequiredService<AddExamForm>();

            addExamForm.NewExamAdded += addExamForm_NewExamAdded;

            addExamForm.ShowDialog();
        };

        updateExamBtn.MouseClick += (o, e) =>
        {
            DataGridViewRow selectedRow = examsDataGridView.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir sınav seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

            UpdateExamForm updateExamForm = serviceProvider.GetRequiredService<UpdateExamForm>();

            updateExamForm.ExamId = id;

            updateExamForm.ExamUpdated += updateExamForm_ExamUpdated;

            updateExamForm.ShowDialog();
        };

        deleteExamBtn.MouseClick += async (o, e) =>
        {
            var selectedRow = examsDataGridView.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir sınav seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bu sınavı silmek istediğinizden emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var examId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

                    await mediator.Send(new DeleteExamCommand { Id = examId });

                    exams.Remove(exams.First(e => e.Id == examId));
                    bs.ResetBindings(false);

                    MessageBox.Show("Sınav başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme işlemi başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        examsDataGridView = CreateExamsDataGridView(exams);

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

            var bs = (BindingSource)examsDataGridView.DataSource;
            bs.DataSource = exams.Where(t =>
                (string.IsNullOrEmpty(examNameFilter) || t.ExamName.ToLower().Contains(examNameFilter))
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

    private DataGridView CreateExamsDataGridView(ICollection<GetListExamsResponse> exams)
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

        bs = new BindingSource { DataSource = exams };
        dataGridView.DataSource = bs;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].HeaderText = "ID";
            dataGridView.Columns["ExamName"].HeaderText = "Sınav Adı";
        };

        return dataGridView;
    }

    public async void addExamForm_NewExamAdded(object o, EventArgs e)
    {
        this.exams = await mediator.Send(new GetListExamsQuery());
        bs.DataSource = this.exams;
        bs.ResetBindings(false);
    }

    public async void updateExamForm_ExamUpdated(object o, EventArgs e)
    {
        this.exams = await mediator.Send(new GetListExamsQuery());
        bs.DataSource = this.exams;
        bs.ResetBindings(false);
    }
}
