namespace CMS.Presentation
{
    partial class UpdateRoleForm
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
            updateRoleBtn = new MaterialSkin.Controls.MaterialButton();
            roleDescriptionTxt = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            roleNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            SuspendLayout();
            // 
            // updateRoleBtn
            // 
            updateRoleBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            updateRoleBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            updateRoleBtn.Depth = 0;
            updateRoleBtn.HighEmphasis = true;
            updateRoleBtn.Icon = null;
            updateRoleBtn.Location = new Point(6, 233);
            updateRoleBtn.Margin = new Padding(4, 6, 4, 6);
            updateRoleBtn.MouseState = MaterialSkin.MouseState.HOVER;
            updateRoleBtn.Name = "updateRoleBtn";
            updateRoleBtn.NoAccentTextColor = Color.Empty;
            updateRoleBtn.Size = new Size(86, 36);
            updateRoleBtn.TabIndex = 5;
            updateRoleBtn.Text = "Kaydet";
            updateRoleBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            updateRoleBtn.UseAccentColor = false;
            updateRoleBtn.UseVisualStyleBackColor = true;
            // 
            // roleDescriptionTxt
            // 
            roleDescriptionTxt.AnimateReadOnly = false;
            roleDescriptionTxt.BackgroundImageLayout = ImageLayout.None;
            roleDescriptionTxt.CharacterCasing = CharacterCasing.Normal;
            roleDescriptionTxt.Depth = 0;
            roleDescriptionTxt.HideSelection = true;
            roleDescriptionTxt.Hint = "Rol Açıklaması";
            roleDescriptionTxt.Location = new Point(6, 127);
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
            roleDescriptionTxt.TabIndex = 4;
            roleDescriptionTxt.TabStop = false;
            roleDescriptionTxt.TextAlign = HorizontalAlignment.Left;
            roleDescriptionTxt.UseSystemPasswordChar = false;
            // 
            // roleNameTxt
            // 
            roleNameTxt.AnimateReadOnly = false;
            roleNameTxt.BackgroundImageLayout = ImageLayout.None;
            roleNameTxt.CharacterCasing = CharacterCasing.Normal;
            roleNameTxt.Depth = 0;
            roleNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            roleNameTxt.HideSelection = true;
            roleNameTxt.Hint = "Rol Adı";
            roleNameTxt.LeadingIcon = null;
            roleNameTxt.Location = new Point(6, 73);
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
            roleNameTxt.TabIndex = 3;
            roleNameTxt.TabStop = false;
            roleNameTxt.TextAlign = HorizontalAlignment.Left;
            roleNameTxt.TrailingIcon = null;
            roleNameTxt.UseSystemPasswordChar = false;
            // 
            // UpdateRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 277);
            Controls.Add(updateRoleBtn);
            Controls.Add(roleDescriptionTxt);
            Controls.Add(roleNameTxt);
            MaximizeBox = false;
            Name = "UpdateRoleForm";
            Text = "Rol Güncelle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton updateRoleBtn;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 roleDescriptionTxt;
        private MaterialSkin.Controls.MaterialTextBox2 roleNameTxt;
    }
}