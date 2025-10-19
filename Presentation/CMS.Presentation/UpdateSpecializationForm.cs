using CMS.Application.Features.Specializations.Commands.Update;
using CMS.Application.Features.Specializations.Queries.GetSpecializationById;
using MaterialSkin;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Drawing2D;

namespace CMS.Presentation
{
    public partial class UpdateSpecializationForm : MaterialForm
    {
        public Guid SpecializationId { get; set; }
        private readonly IMediator mediator;
        public event EventHandler SpecializationUpdated;
        public UpdateSpecializationForm(IServiceProvider serviceProvider)
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

        private async void UpdateSpecializationForm_Load(object sender, EventArgs e)
        {
            GetSpecializationByIdResponse specialization = await mediator.Send(new GetSpecializationByIdQuery { Id = SpecializationId });
            specializationNameTxt.Text = specialization.SpecializationName;
        }

        private async void updateSpecializationBtn_Click(object sender, EventArgs e)
        {
            UpdateSpecializationCommand specialization = new UpdateSpecializationCommand();
            specialization.Id = SpecializationId;
            specialization.SpecializationName = specializationNameTxt.Text;

            UpdateSpecializationResponse updatedSpecialization = await mediator.Send(specialization);

            MessageBox.Show(updatedSpecialization.SpecializationName + " adlı uzmanlık alanı başarıyla güncellendi.");

            SpecializationUpdated?.Invoke(this, EventArgs.Empty);

            this.Close();
        }
    }
}