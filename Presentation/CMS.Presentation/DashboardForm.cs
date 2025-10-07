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

namespace CMS.Presentation;

public partial class DashboardForm : MaterialForm
{
    public DashboardForm()
    {
        InitializeComponent();

        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.DeepOrange700, TextShade.WHITE);


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

    private bool studentsLoaded = false;
    private bool teachersLoaded = false;

  

    private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (materialTabControl1.SelectedTab == students && !studentsLoaded)
        {
            LoadStudents();
            studentsLoaded = true; 
        }
        if (materialTabControl1.SelectedTab == teachers && !teachersLoaded)
        {
            LoadTeachers();
            teachersLoaded = true; 
        }
    }

    private void LoadStudents()
    {

        MaterialCard headerCard = new MaterialCard
        {
            Size = new Size(flowLayoutPanelStudents.Width - 20, 40),
            BackColor = Color.LightGray
        };
        headerCard.Controls.Add(CreateHeaderLabel("Kimlik NO", 10));
        headerCard.Controls.Add(CreateHeaderLabel("Adı", 140));
        headerCard.Controls.Add(CreateHeaderLabel("Soyadı", 250));
        headerCard.Controls.Add(CreateHeaderLabel("E-Posta", 400));
        headerCard.Controls.Add(CreateHeaderLabel("İşlemler", 700));
        flowLayoutPanelStudents.Controls.Add(headerCard);

        List<User> users = new List<User>
        {
            new User { Id = 123424234, FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet@example.com" },
            new User { Id = 123424234, FirstName = "Ayşe", LastName = "Demir", Email = "ayse@example.com" },
            new User { Id = 123424234, FirstName = "Mehmet", LastName = "Can", Email = "mehmet@example.com" }
        };

        foreach (var user in users)
        {
            flowLayoutPanelStudents.Controls.Add(CreateStudentRow(user));
        }
    }

    private Control CreateStudentRow(User user)
    {
        MaterialCard rowCard = new MaterialCard
        {
            Size = new Size(flowLayoutPanelStudents.Width - 20, 40),
            BackColor = Color.White,
            Tag = user
        };

        rowCard.Controls.Add(CreateDataLabel(user.Id.ToString(), 10));
        rowCard.Controls.Add(CreateDataLabel(user.FirstName, 140));
        rowCard.Controls.Add(CreateDataLabel(user.LastName, 250));
        rowCard.Controls.Add(CreateDataLabel(user.Email, 400));

        MaterialButton btnDelete = new MaterialButton
        {
            Text = "Sil",
            Location = new Point(800, 5),
            BackColor = Color.Red,
            ForeColor = Color.White,
            Type = MaterialButton.MaterialButtonType.Contained,
            UseAccentColor = true
        };
        btnDelete.Click += (s, e) => { flowLayoutPanelStudents.Controls.Remove(rowCard); };

        MaterialButton btnUpdate = new MaterialButton
        {
            Text = "Güncelle",
            Location = new Point(700, 5),
            BackColor = Color.Blue,
            ForeColor = Color.White
        };
        btnUpdate.Click += (s, e) =>
        {
            MessageBox.Show($"Güncelle: {user.FirstName} {user.LastName}");
        };
        MaterialButton btnReview = new MaterialButton
        {
            Text = "İncele",
            Location = new Point(625, 5),
            BackColor = Color.Blue,
            ForeColor = Color.White
        };
        btnReview.Click += (s, e) =>
        {
            MessageBox.Show($"İncele: {user.FirstName} {user.LastName}");
        };

        rowCard.Controls.Add(btnReview);
        rowCard.Controls.Add(btnUpdate);
        rowCard.Controls.Add(btnDelete);
        
        return rowCard;
    }

    private Label CreateHeaderLabel(string text, int x)
    {
        return new Label
        {
            Text = text,
            Font = new Font("Roboto", 10, FontStyle.Bold),
            Location = new Point(x, 10),
            AutoSize = true
        };
    }

    private Label CreateDataLabel(string text, int x)
    {
        return new Label
        {
            Text = text,
            Font = new Font("Roboto", 10),
            Location = new Point(x, 10),
            AutoSize = true
        };
    }

    private void LoadTeachers()
    {

        MaterialCard headerCard = new MaterialCard
        {
            Size = new Size(flowLayoutPanelTeachers.Width - 20, 40),
            BackColor = Color.LightGray
        };
        headerCard.Controls.Add(CreateHeaderLabel("Kimlik NO", 10));
        headerCard.Controls.Add(CreateHeaderLabel("Adı", 140));
        headerCard.Controls.Add(CreateHeaderLabel("Soyadı", 250));
        headerCard.Controls.Add(CreateHeaderLabel("E-Posta", 400));
        headerCard.Controls.Add(CreateHeaderLabel("İşlemler", 700));
        flowLayoutPanelTeachers.Controls.Add(headerCard);

        List<User> users = new List<User>
        {
            new User { Id = 123424234, FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet@example.com" },
            new User { Id = 123424234, FirstName = "Ayşe", LastName = "Demir", Email = "ayse@example.com" },
            new User { Id = 123424234, FirstName = "Mehmet", LastName = "Can", Email = "mehmet@example.com" }
        };

        foreach (var user in users)
        {
            flowLayoutPanelTeachers.Controls.Add(CreateTeacherRow(user));
        }
    }

    private Control CreateTeacherRow(User user)
    {
        MaterialCard rowCard = new MaterialCard
        {
            Size = new Size(flowLayoutPanelTeachers.Width - 20, 40),
            BackColor = Color.White,
            Tag = user
        };

        rowCard.Controls.Add(CreateDataLabel(user.Id.ToString(), 10));
        rowCard.Controls.Add(CreateDataLabel(user.FirstName, 140));
        rowCard.Controls.Add(CreateDataLabel(user.LastName, 250));
        rowCard.Controls.Add(CreateDataLabel(user.Email, 400));

        MaterialButton btnDelete = new MaterialButton
        {
            Text = "Sil",
            Location = new Point(800, 5),
            BackColor = Color.Red,
            ForeColor = Color.White,
            Type = MaterialButton.MaterialButtonType.Contained,
            UseAccentColor = true
        };
        btnDelete.Click += (s, e) => { flowLayoutPanelTeachers.Controls.Remove(rowCard); };

        MaterialButton btnUpdate = new MaterialButton
        {
            Text = "Güncelle",
            Location = new Point(700, 5),
            BackColor = Color.Blue,
            ForeColor = Color.White
        };
        btnUpdate.Click += (s, e) =>
        {
            MessageBox.Show($"Güncelle: {user.FirstName} {user.LastName}");
        };

        MaterialButton btnReview = new MaterialButton
        {
            Text = "İncele",
            Location = new Point(625, 5),
            BackColor = Color.Blue,
            ForeColor = Color.White
        };
        btnReview.Click += (s, e) =>
        {
            MessageBox.Show($"İncele: {user.FirstName} {user.LastName}");
        };

        rowCard.Controls.Add(btnReview);
        rowCard.Controls.Add(btnUpdate);
        rowCard.Controls.Add(btnDelete);

        return rowCard;
    }

   
}

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}