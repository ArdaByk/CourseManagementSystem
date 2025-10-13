using CMS.Domain.Entities;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class UsersPageBuilder : IPageBuilder
{
    private List<User> users;

    public UsersPageBuilder()
    {
        this.users = new List<User>
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

        var userNameTextBox = CreateTextBox("userNameTextBox", "Kullanıcı Adı", new Point(8, 3));
        var fullNameTextBox = CreateTextBox("fullNameTextBox", "Adı", new Point(267, 3));

        var rolesComboBox = CreateComboBox("rolesComboBox", "Rolü", 250, new List<string> { "Aktif", "Pasif" }, new Point(524, 3));

        var addUserBtn = CreateButton("addUserBtn", "Kullanıcı Ekle", new Point(10, 57));
        var reviewUserBtn = CreateButton("reviewUserBtn", "Kullanıcı İncele", new Point(155, 57));
        var updateUserBtn = CreateButton("updateUserBtn", "Kullanıcı Güncelle", new Point(318, 57));
        var deleteUserBtn = CreateButton("deleteUserBtn", "Kullanıcı Sil", new Point(500, 57));


        deleteUserBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteUserBtn.UseAccentColor = true;

        Panel usersPanel = new Panel
        {
            Name = "usersPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        addUserBtn.MouseClick += (o, e) =>
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.Show();
        };

        reviewUserBtn.MouseClick += (o, e) =>
        {
            ShowCourseStudentsForm showCourseStudentsForm = new ShowCourseStudentsForm();
            showCourseStudentsForm.Show();
        };

        updateUserBtn.MouseClick += (o, e) =>
        {
            ShowCourseStudentsForm showCourseStudentsForm = new ShowCourseStudentsForm();
            showCourseStudentsForm.Show();
        };

        deleteUserBtn.MouseClick += (o, e) =>
        {
            ShowCourseStudentsForm showCourseStudentsForm = new ShowCourseStudentsForm();
            showCourseStudentsForm.Show();
        };

        DataGridView usersDataGridView = CreateUsersDataGridView(users);

        usersPanel.Controls.Add(usersDataGridView);

        inputPanel.Controls.Add(userNameTextBox);
        inputPanel.Controls.Add(fullNameTextBox);
        inputPanel.Controls.Add(rolesComboBox);
        inputPanel.Controls.Add(addUserBtn);
        inputPanel.Controls.Add(reviewUserBtn);
        inputPanel.Controls.Add(updateUserBtn);
        inputPanel.Controls.Add(deleteUserBtn);

        mainPanel.Controls.Add(usersPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string userNameFilter = userNameTextBox.Text.Trim().ToLower();
            string fullNameFilter = fullNameTextBox.Text.Trim().ToLower();

            var bs = (BindingSource)usersDataGridView.DataSource;
            bs.DataSource = users.Where(t =>
                (string.IsNullOrEmpty(userNameFilter) || t.FirstName.ToLower().Contains(userNameFilter)) ||
                (string.IsNullOrEmpty(fullNameFilter) || t.FirstName.ToLower().Contains(fullNameFilter))
            ).ToList();

            bs.ResetBindings(false);
        }

        userNameTextBox.TextChanged += (s, e) => ApplyFilter();
        fullNameTextBox.TextChanged += (s, e) => ApplyFilter();
        rolesComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();
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

    private MaterialComboBox CreateComboBox(string name, string hint, int width, List<string> items, Point location)
    {
        var comboBox = new MaterialComboBox
        {
            Name = name,
            Hint = hint,
            Width = width,
            Location = location
        };
        comboBox.Items.AddRange(items.ToArray());
        return comboBox;
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

    private DataGridView CreateUsersDataGridView(List<User> students)
    {
        var dataGridView = new DataGridView
        {
            Name = "usersDataGridView",
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
            dataGridView.Columns["LastName"].HeaderText = "Açıklama";
        };

        return dataGridView;
    }
}
