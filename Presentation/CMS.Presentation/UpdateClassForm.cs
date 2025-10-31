using CMS.Application.Features.Classes.Commands.Update;
using CMS.Application.Features.Classes.Queries.GetClassById;
using CMS.Application.Features.Courses.Commands.Update;
using CMS.Application.Features.Courses.Queries.GetTeacherById;
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
    public partial class UpdateClassForm : MaterialForm
    {
        public Guid ClassId { get; set; }
        private readonly IMediator mediator;
        public event EventHandler ClassUpdated;
        public UpdateClassForm(IServiceProvider serviceProvider)
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

        private async void updateClassBtn_Click(object sender, EventArgs e)
        {
            int capacity;
            int.TryParse(capacityTxt.Text, out capacity);

            UpdateClassCommand myClass = new UpdateClassCommand();
            myClass.Id = ClassId;
            myClass.ClassName = classNameTxt.Text;
            myClass.Capacity = capacity;
            myClass.Location = locationTxt.Text;

            UpdateClassResponse updatedClass = await mediator.Send(myClass);

            MessageBox.Show(updatedClass.ClassName + " adlı sınıf başarıyla güncellendi.");

            ClassUpdated?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private async void UpdateClassForm_Load(object sender, EventArgs e)
        {
            GetClassByIdResponse myClass = await mediator.Send(new GetClassByIdQuery { Id = ClassId });
            classNameTxt.Text = myClass.ClassName;
            capacityTxt.Text = myClass.Capacity.ToString();
            locationTxt.Text = myClass.Location;
        }
    }
}