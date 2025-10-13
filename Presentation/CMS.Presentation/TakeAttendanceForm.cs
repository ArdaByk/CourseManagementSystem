using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class TakeAttendanceForm : MaterialForm
    {
        private List<User> students;
        public TakeAttendanceForm()
        {
            InitializeComponent();

            this.students = new List<User>
        {
            new User { Id = 123424234, FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet@example.com" },
            new User { Id = 123424234, FirstName = "Ayşe", LastName = "Demir", Email = "ayse@example.com" },
            new User { Id = 123424234, FirstName = "Mehmet", LastName = "Can", Email = "mehmet@example.com" }
        };

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

        private void TakeAttendanceForm_Load(object sender, EventArgs e)
        {
            var dataGridView = new DataGridView
            {
                Name = "studentsDataGridView",
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
                dataGridView.Columns["FirstName"].HeaderText = "Adı";
                dataGridView.Columns["LastName"].HeaderText = "Soyadı";
                dataGridView.Columns["Email"].HeaderText = "Telefon Numarası";
            };

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "İşlem";
            chk.Name = "attendance";
            chk.Width = 50;
            chk.ReadOnly = false;
            chk.TrueValue = true;
            chk.FalseValue = false;

            dataGridView.Columns.Add(chk);

            studentsPanel.BackColor = Color.Transparent;
            studentsPanel.Controls.Add(dataGridView);
        }
    }
}
