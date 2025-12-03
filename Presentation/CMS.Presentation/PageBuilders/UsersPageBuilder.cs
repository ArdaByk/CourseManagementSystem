using CMS.Application.Features.Classes.Commands.Delete;
using CMS.Application.Features.Classes.Queries.GetListClasses;
using CMS.Application.Features.Users.Commands.Delete;
using CMS.Application.Features.Users.Queries.GetListUsers;
using CMS.Domain.Entities;
using MaterialSkin.Controls;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public class UsersPageBuilder : IPageBuilder
{
    private ICollection<GetListUsersResponse> users;
    private readonly IServiceProvider serviceProvider;
    private readonly IMediator mediator;
    private DataGridView usersDataGridView;
    private BindingSource bs;
    public UsersPageBuilder(IServiceProvider serviceProvider)
    {
        this.mediator = serviceProvider.GetRequiredService<IMediator>();

        this.serviceProvider = serviceProvider;
    }

    public async void Build(TabPage tabPage)
    {
        this.users = await mediator.Send(new GetListUsersQuery());

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
        var updateUserBtn = CreateButton("updateUserBtn", "Kullanıcı Güncelle", new Point(148, 57));
        var deleteUserBtn = CreateButton("deleteUserBtn", "Kullanıcı Sil", new Point(330, 57));


        deleteUserBtn.Type = MaterialButton.MaterialButtonType.Contained;
        deleteUserBtn.UseAccentColor = true;

        Panel usersPanel = new Panel
        {
            Name = "usersPanel",
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        usersDataGridView = CreateUsersDataGridView(users);

        addUserBtn.MouseClick += (o, e) =>
        {
            AddUserForm addUserForm = serviceProvider.GetRequiredService<AddUserForm>();

            addUserForm.NewUserAdded += addUserForm_NewUserAdded;

            addUserForm.ShowDialog();
        };

        updateUserBtn.MouseClick += (o, e) =>
        {
            DataGridViewRow selectedRow = usersDataGridView.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

            UpdateUserForm updateUserForm = serviceProvider.GetRequiredService<UpdateUserForm>();

            updateUserForm.UserId = id;

            updateUserForm.UserUpdated += updateUserForm_UserUpdated;

            updateUserForm.ShowDialog();
        };

        deleteUserBtn.MouseClick +=async (o, e) =>
        {
            var selectedRow = usersDataGridView.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bu kullanıcıyı silmek istediğinizden emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var userId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());

                    await mediator.Send(new DeleteUserCommand { Id = userId });

                    users.Remove(users.First(u => u.Id == userId));
                    bs.ResetBindings(false);

                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme işlemi başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };

        usersPanel.Controls.Add(usersDataGridView);

        inputPanel.Controls.Add(userNameTextBox);
        inputPanel.Controls.Add(fullNameTextBox);
        inputPanel.Controls.Add(rolesComboBox);
        inputPanel.Controls.Add(addUserBtn);
        inputPanel.Controls.Add(updateUserBtn);
        inputPanel.Controls.Add(deleteUserBtn);

        mainPanel.Controls.Add(usersPanel);
        mainPanel.Controls.Add(inputPanel);

        tabPage.Controls.Add(mainPanel);

        void ApplyFilter()
        {
            string userNameFilter = userNameTextBox.Text.Trim().ToLower();
            string fullNameFilter = fullNameTextBox.Text.Trim().ToLower();

            bs = (BindingSource)usersDataGridView.DataSource;

            IEnumerable<GetListUsersResponse> filtered = users;

            if (!string.IsNullOrEmpty(userNameFilter))
                filtered = filtered.Where(u => u.Username.ToLower().Contains(userNameFilter));

            if (!string.IsNullOrEmpty(fullNameFilter))
                filtered = filtered.Where(u => u.FullName.ToLower().Contains(fullNameFilter));

            if (rolesComboBox.SelectedItem != null)
            {
                string roleFilter = rolesComboBox.SelectedItem.ToString();
                filtered = filtered.Where(u => u.Role.RoleName == roleFilter);
            }

            bs.DataSource = filtered.ToList();
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
            Width = 180,
            UseAccentColor = useAccent
        };
    }

    private DataGridView CreateUsersDataGridView(ICollection<GetListUsersResponse> users)
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

        bs = new BindingSource { DataSource = users.Select(u => new { u.Id, u.FullName, u.Username, u.Role.RoleName }).ToList() };
        dataGridView.DataSource = bs ;
        bs.ResetBindings(false);

        dataGridView.DataBindingComplete += (s, e) =>
        {
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["FullName"].HeaderText = "Tam Adı";
            dataGridView.Columns["UserName"].HeaderText = "Kullanıcı Adı";
            dataGridView.Columns["RoleName"].HeaderText = "Rolü";
        };

        return dataGridView;
    }

    public async void addUserForm_NewUserAdded(object o, EventArgs e)
    {
        this.users = await mediator.Send(new GetListUsersQuery());
        bs.DataSource = this.users.Select(u => new { u.Id, u.FullName, u.Username, u.Role.RoleName }).ToList();
        bs.ResetBindings(false);
    }

    public async void updateUserForm_UserUpdated(object o, EventArgs e)
    {
        this.users = await mediator.Send(new GetListUsersQuery());
        bs.DataSource = this.users.Select(u => new { u.Id, u.FullName, u.Username, u.Role.RoleName }).ToList();
        bs.ResetBindings(false);
    }
}
