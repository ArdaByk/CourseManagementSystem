namespace CMS.Presentation
{
    partial class AddRoleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            roleNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            roleDescriptionTxt = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            addRoleBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // roleNameTxt
            // 
            roleNameTxt.AnimateReadOnly = false;
            roleNameTxt.BackgroundImageLayout = ImageLayout.None;
            roleNameTxt.CharacterCasing = CharacterCasing.Normal;
            roleNameTxt.Depth = 0;
            roleNameTxt.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            roleNameTxt.HideSelection = true;
            roleNameTxt.Hint = "Rol Adı";
            roleNameTxt.LeadingIcon = null;
            roleNameTxt.Location = new Point(9, 77);
            roleNameTxt.MaxLength = 32767;
            roleNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            roleNameTxt.Name = "roleNameTxt";
            roleNameTxt.PasswordChar = '\0';
            roleNameTxt.PrefixSuffixText = null;
            roleNameTxt.ReadOnly = false;
            roleNameTxt.RightToLeft = RightToLeft.No;
            roleNameTxt.SelectedText = "";
            roleNameTxt.SelectionLength = 0;
            roleNameTxt.SelectionStart = 0;
            roleNameTxt.ShortcutsEnabled = true;
            roleNameTxt.Size = new Size(250, 48);
            roleNameTxt.TabIndex = 0;
            roleNameTxt.TabStop = false;
            roleNameTxt.TextAlign = HorizontalAlignment.Left;
            roleNameTxt.TrailingIcon = null;
            roleNameTxt.UseSystemPasswordChar = false;
            // 
            // roleDescriptionTxt
            // 
            roleDescriptionTxt.AnimateReadOnly = false;
            roleDescriptionTxt.BackgroundImageLayout = ImageLayout.None;
            roleDescriptionTxt.CharacterCasing = CharacterCasing.Normal;
            roleDescriptionTxt.Depth = 0;
            roleDescriptionTxt.HideSelection = true;
            roleDescriptionTxt.Hint = "Rol Açıklaması";
            roleDescriptionTxt.Location = new Point(9, 131);
            roleDescriptionTxt.MaxLength = 32767;
            roleDescriptionTxt.MouseState = MaterialSkin.MouseState.OUT;
            roleDescriptionTxt.Name = "roleDescriptionTxt";
            roleDescriptionTxt.PasswordChar = '\0';
            roleDescriptionTxt.ReadOnly = false;
            roleDescriptionTxt.ScrollBars = ScrollBars.None;
            roleDescriptionTxt.SelectedText = "";
            roleDescriptionTxt.SelectionLength = 0;
            roleDescriptionTxt.SelectionStart = 0;
            roleDescriptionTxt.ShortcutsEnabled = true;
            roleDescriptionTxt.Size = new Size(250, 100);
            roleDescriptionTxt.TabIndex = 1;
            roleDescriptionTxt.TabStop = false;
            roleDescriptionTxt.TextAlign = HorizontalAlignment.Left;
            roleDescriptionTxt.UseSystemPasswordChar = false;
            // 
            // addRoleBtn
            // 
            addRoleBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addRoleBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addRoleBtn.Depth = 0;
            addRoleBtn.HighEmphasis = true;
            addRoleBtn.Icon = null;
            addRoleBtn.Location = new Point(9, 237);
            addRoleBtn.Margin = new Padding(4, 6, 4, 6);
            addRoleBtn.MouseState = MaterialSkin.MouseState.HOVER;
            addRoleBtn.Name = "addRoleBtn";
            addRoleBtn.NoAccentTextColor = Color.Empty;
            addRoleBtn.Size = new Size(86, 36);
            addRoleBtn.TabIndex = 2;
            addRoleBtn.Text = "Rol Ekle";
            addRoleBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addRoleBtn.UseAccentColor = false;
            addRoleBtn.UseVisualStyleBackColor = true;
            // 
            // AddRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 284);
            Controls.Add(addRoleBtn);
            Controls.Add(roleDescriptionTxt);
            Controls.Add(roleNameTxt);
            MaximizeBox = false;
            Name = "AddRoleForm";
            Text = "Rol Ekle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 roleNameTxt;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 roleDescriptionTxt;
        private MaterialSkin.Controls.MaterialButton addRoleBtn;
    }
}