using CMS.Presentation.PageBuilders;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing.Drawing2D;

namespace CMS.Presentation;

public partial class DashboardForm : MaterialForm
{
    private Dictionary<string, IPageBuilder> _pageBuilders;
    public DashboardForm()
    {
        InitializeComponent();

        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.DeepOrange700, TextShade.WHITE);

        _pageBuilders = new Dictionary<string, IPageBuilder>
        {
            { "students", new StudentPageBuilder() }
        };
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

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}