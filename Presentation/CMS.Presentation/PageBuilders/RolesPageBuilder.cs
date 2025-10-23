using CMS.Domain.Entities;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class RolesPageBuilder : IPageBuilder
{
    private List<User> roles;

    public RolesPageBuilder()
    {
        this.roles = new List<User>
        {
            new User { Id = 123424234, FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet@example.com" },
            new User { Id = 123424234, FirstName = "Ayşe", LastName = "Demir", Email = "ayse@example.com" },
            new User { Id = 123424234, FirstName = "Mehmet", LastName = "Can", Email = "mehmet@example.com" }
        };
    }

    public void Build(TabPage tabPage)
    {
        Panel mainPanel = new Panel
        {
            Dock = DockStyle.Fill
        };

        Panel inputPanel = new Panel
        {
            Dock = DockStyle.Top
        };

        var roleNameTextBox = CreateTextBox("roleNameTextBox", "Rol Adı", new Point(8, 3));

        var addRoleBtn = CreateButton("addRoleBtn", "Rol Ekle", new Point(10, 57));
        var reviewRoleBtn = CreateButton("reviewRoleBtn", "Rol İncele", new Point(113, 57));
        var updateRoleBtn = CreateButton("updateRoleBtn", "Rol Güncelle", new Point(230, 57));
        var deleteRoleBtn = CreateButton("deleteRoleBtn", "Rol Sil", new Point(375, 57), true);

        deleteRoleBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteRoleBtn.UseAccentColor = true;

        Panel rolePanel = new Panel
        {
            Name = "rolePanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        addRoleBtn.MouseClick += (o, e) =>
        {
            AddRoleForm addRoleForm = new AddRoleForm();
            addRoleForm.Show();
        };

        reviewRoleBtn.MouseClick += (o, e) =>
        {
        };

        updateRoleBtn.MouseClick += (o, e) =>
        {
            ShowAttendanceForm showAttendanceForm = new ShowAttendanceForm();
            showAttendanceForm.Show();
        };

        deleteRoleBtn.MouseClick += (o, e) =>
        {
            TakeAttendanceForm takeAttendanceForm = new TakeAttendanceForm();
            takeAttendanceForm.Show();
        };

        DataGridView rolesDataGridView = CreateRolesDataGridView(roles);

        rolePanel.Controls.Add(rolesDataGridView);

        inputPanel.Controls.Add(roleNameTextBox);
        inputPanel.Controls.Add(addRoleBtn);
        inputPanel.Controls.Add(reviewRoleBtn);
        inputPanel.Controls.Add(updateRoleBtn);
        inputPanel.Controls.Add(deleteRoleBtn);

        mainPanel.Controls.Add(rolePanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string roleNameFilter = roleNameTextBox.Text.Trim().ToLower();

            var bs = (BindingSource)rolesDataGridView.DataSource;
            bs.DataSource = roles.Where(t =>
                (string.IsNullOrEmpty(roleNameFilter) || t.FirstName.ToLower().Contains(roleNameFilter))
            ).ToList();

            bs.ResetBindings(false);
        }

        roleNameTextBox.TextChanged += (s, e) => ApplyFilter();
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

    private DataGridView CreateRolesDataGridView(List<User> students)
    {
        var dataGridView = new DataGridView
        {
            Name = "rolesDataGridView",
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
            dataGridView.Columns["FirstName"].HeaderText = "Kurs Adı";
            dataGridView.Columns["LastName"].HeaderText = "Kurs Grup Adı";
        };

        return dataGridView;
    }
}
