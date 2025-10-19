using CMS.Application.Features.Specializations.Queries.GetListSpecializations;
using CMS.Application.Features.Teachers.Commands.Create;
using CMS.Domain.Entities;
using MaterialSkin;
using MaterialSkin.Controls;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Presentation
{
    public partial class AddTeacherForm : MaterialForm
    {
        private readonly IMediator mediator;
        public event EventHandler NewTeacherAdded;
        public AddTeacherForm(IMediator mediator)
        {
            InitializeComponent();

            this.mediator = mediator;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.FormBorderStyle = FormBorderStyle.None;

        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x00020000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateFormRegion();
        }

        private void UpdateFormRegion()
        {
            int radius = 15;
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), -90, 90);
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        private async void addTeacherBtn_Click(object sender, EventArgs e)
        {
            var selectedIds = specializationCheckedListBox.Controls
              .OfType<MaterialSkin.Controls.MaterialCheckbox>()
              .Where(cb => cb.Checked)
              .Select(cb => (Guid)cb.Tag)
              .ToList();

            CreateTeacherCommand createTeacherCommand = new CreateTeacherCommand
            {
                FirstName = teacherFirstNameTxt.Text,
                LastName = teacherLastNameTxt.Text,
                HiredDate = teacherHiredDate.Value,
                Phone = teacherPhoneTxt.Text,
                SalaryAmount = Convert.ToInt32(teacherSalaryAmountTxt.Text),
                SalaryType = teacherSalaryTypeComboBox.SelectedItem.ToString(),
                Status = teacherStatusSwitch.Checked ? 'A' : 'P',
                Email = teacherEmailTxt.Text,
                SpecializationIds = selectedIds
            };

            CreateTeacherResponse createTeacherResponse = await mediator.Send(createTeacherCommand);

            MessageBox.Show(createTeacherResponse.FirstName + " Adlı öğretmen başarıyla kaydedildi.");

            NewTeacherAdded?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private async void AddTeacherForm_Load(object sender, EventArgs e)
        {
            var specializations = await mediator.Send(new GetListSpecializationsQuery());

            specializationCheckedListBox.Controls.Clear();

            foreach (var specialization in specializations)
            {
                var checkBox = new MaterialSkin.Controls.MaterialCheckbox
                {
                    Text = specialization.SpecializationName,
                    Tag = specialization.Id, // görünmeyen value için Tag kullan
                    AutoSize = true
                };

                specializationCheckedListBox.Items.Add(checkBox);
            }
        }
    }
}
