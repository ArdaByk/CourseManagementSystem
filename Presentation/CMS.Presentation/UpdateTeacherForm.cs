using CMS.Application.Features.Specializations.Queries.GetListSpecializations;
using CMS.Application.Features.Teachers.Commands.Update;
using CMS.Application.Features.Teachers.Queries.GetTeacherById;
using CMS.Domain.Entities;
using MaterialSkin;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class UpdateTeacherForm : MaterialForm
    {
        public Guid TeacherId { get; set; }
        private readonly IMediator mediator;
        public event EventHandler TeacherUpdated;
        public UpdateTeacherForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.FormBorderStyle = FormBorderStyle.None;
            this.mediator = serviceProvider.GetRequiredService<IMediator>();
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

        private async void UpdateTeacherForm_Load(object sender, EventArgs e)
        {
            GetTeacherByIdResponse teacher = await mediator.Send(new GetTeacherByIdQuery { Id = TeacherId });

            teacherFirstNameTxt.Text = teacher.FirstName;
            teacherLastNameTxt.Text = teacher.LastName;
            teacherPhoneTxt.Text = teacher.Phone;
            teacherHiredDate.Value = teacher.HiredDate;
            teacherSalaryAmountTxt.Text = teacher.SalaryAmount.ToString();
            teacherSalaryTypeComboBox.SelectedIndex = 0;
            teacherStatusSwitch.Checked = teacher.Status == 'A' ? true : false;
            teacherEmailTxt.Text = teacher.Email;

            var teacherSpecializationIds = teacher.TeacherSpecializations
                .Select(ts => ts.SpecializationId)
                .ToList();

            var specializations = await mediator.Send(new GetListSpecializationsQuery());

            specializationCheckedListBox.Controls.Clear();

            foreach (var specialization in specializations)
            {
                var checkBox = new MaterialSkin.Controls.MaterialCheckbox
                {
                    Text = specialization.SpecializationName,
                    Tag = specialization.Id,
                    AutoSize = true,
                    Checked = teacherSpecializationIds.Contains(specialization.Id)
                };

                specializationCheckedListBox.Items.Add(checkBox);
            }


        }

        private async void updateTeacherBtn_Click(object sender, EventArgs e)
        {
            var selectedIds = specializationCheckedListBox.Controls
                .OfType<MaterialSkin.Controls.MaterialCheckbox>()
                .Where(cb => cb.Checked)
                .Select(cb => (Guid)cb.Tag)
                .ToList();


            UpdateTeacherCommand teacher = new UpdateTeacherCommand();
            teacher.Id = TeacherId;
            teacher.FirstName = teacherFirstNameTxt.Text;
            teacher.LastName = teacherLastNameTxt.Text;
            teacher.Phone = teacherPhoneTxt.Text;
            teacher.HiredDate = teacherHiredDate.Value;
            teacher.SalaryAmount = float.Parse(teacherSalaryAmountTxt.Text);
            teacher.SalaryType = teacherSalaryTypeComboBox.SelectedItem.ToString();
            teacher.Status = teacherStatusSwitch.Checked == true ? 'A' : 'P';
            teacher.Email = teacherEmailTxt.Text;
            teacher.SelectedIds = selectedIds;

            UpdateTeacherResponse updatedTeacher = await mediator.Send(teacher);

            MessageBox.Show(updatedTeacher.FirstName + " adlı öğretmen başarıyla güncellendi.");

            TeacherUpdated?.Invoke(this, EventArgs.Empty);

            this.Close();
        }
    }
}
