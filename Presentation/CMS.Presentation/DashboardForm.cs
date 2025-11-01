using CMS.Presentation.PageBuilders;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing.Drawing2D;
using CMS.Application.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;
using CMS.Application.Common.Authentication;

namespace CMS.Presentation;

public partial class DashboardForm : MaterialForm
{
    private Dictionary<string, IPageBuilder> _pageBuilders;
    private readonly IServiceProvider serviceProvider;
    public DashboardForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        this.serviceProvider = serviceProvider;

        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.DeepOrange700, TextShade.WHITE);

        _pageBuilders = new Dictionary<string, IPageBuilder>
        {
            { "students", new StudentPageBuilder(serviceProvider) },
            { "teachers", new TeachersPageBuilder(serviceProvider) },
            { "courses", new CoursesPageBuilder(serviceProvider) },
            { "classes", new ClassesPageBuilder(serviceProvider) },
            { "courseGroups", new CourseGroupsBuilder(serviceProvider) },
            { "exams", new ExamsPageBuilder(serviceProvider) },
            { "specializations", new SpecializationPageBuilder(serviceProvider) },
            { "users", new UsersPageBuilder(serviceProvider) }
        };

        this.Load += DashboardForm_Load;
        this.logoutBtn.Click += LogoutBtn_Click;
    }

    private void LogoutBtn_Click(object? sender, EventArgs e)
    {
        CurrentUserContext.Instance.Clear();

        var loginForm = serviceProvider.GetRequiredService<LoginForm>();
        loginForm.Show();

        this.Hide();
    }

    private async void DashboardForm_Load(object? sender, EventArgs e)
    {

        var studentService = (IStudentService)serviceProvider.GetService(typeof(IStudentService));
        var teacherService = (ITeacherService)serviceProvider.GetService(typeof(ITeacherService));
        var classService = (IClassService)serviceProvider.GetService(typeof(IClassService));
        var courseService = (ICourseService)serviceProvider.GetService(typeof(ICourseService));
        var courseGroupService = (ICourseGroupService)serviceProvider.GetService(typeof(ICourseGroupService));
        var userService = (IUserService)serviceProvider.GetService(typeof(IUserService));

        var students = await studentService.GetListAsync(enableTracking: false);
        var teachers = await teacherService.GetListAsync(enableTracking: false);
        var classesList = await classService.GetListAsync(enableTracking: false);
        var coursesList = await courseService.GetListAsync(enableTracking: false);
        var courseGroups = await courseGroupService.GetListAsync(enableTracking: false);
        var usersList = await userService.GetListAsync(enableTracking: false);

        materialLabel2.Text = students.Count.ToString();
        materialLabel3.Text = teachers.Count.ToString();
        materialLabel5.Text = classesList.Count.ToString();
        materialLabel7.Text = coursesList.Count.ToString();
        materialLabel9.Text = courseGroups.Count.ToString();
        materialLabel11.Text = usersList.Count.ToString();

        var currentUser = CurrentUserContext.Instance;
        materialLabel13.Text = currentUser.FullName ?? "Kullanıcı Adı";
        materialLabel14.Text = $"Kullanıcı adı: {currentUser.Username ?? "N/A"}";
        materialLabel15.Text = $"E-Posta Adresi: {currentUser.Email ?? "N/A"}";
        materialLabel16.Text = $"Rol: {currentUser.RoleName ?? "N/A"}";

    }

    private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedTabName = materialTabControl1.SelectedTab.Name;
        if (_pageBuilders.ContainsKey(selectedTabName))
        {
            _pageBuilders[selectedTabName].Build(materialTabControl1.SelectedTab);
        }
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
}