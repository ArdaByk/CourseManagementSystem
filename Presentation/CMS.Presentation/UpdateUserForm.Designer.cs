namespace CMS.Presentation
{
    partial class UpdateUserForm
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
            updateUserBtn = new MaterialSkin.Controls.MaterialButton();
            roleComboBox = new MaterialSkin.Controls.MaterialComboBox();
            userPhoneTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            emailTxt = new MaterialSkin.Controls.MaterialTextBox2();
            fullNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            userNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            SuspendLayout();
            // 
            // updateUserBtn
            // 
            updateUserBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            updateUserBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            updateUserBtn.Depth = 0;
            updateUserBtn.HighEmphasis = true;
            updateUserBtn.Icon = null;
            updateUserBtn.Location = new Point(10, 345);
            updateUserBtn.Margin = new Padding(4, 6, 4, 6);
            updateUserBtn.MouseState = MaterialSkin.MouseState.HOVER;
            updateUserBtn.Name = "updateUserBtn";
            updateUserBtn.NoAccentTextColor = Color.Empty;
            updateUserBtn.Size = new Size(76, 36);
            updateUserBtn.TabIndex = 16;
            updateUserBtn.Text = "Kaydet";
            updateUserBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            updateUserBtn.UseAccentColor = false;
            updateUserBtn.UseVisualStyleBackColor = true;
            updateUserBtn.Click += updateUserBtn_Click;
            // 
            // roleComboBox
            // 
            roleComboBox.AutoResize = false;
            roleComboBox.BackColor = Color.FromArgb(255, 255, 255);
            roleComboBox.Depth = 0;
            roleComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            roleComboBox.DropDownHeight = 174;
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleComboBox.DropDownWidth = 121;
            roleComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            roleComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Hint = "Rolü";
            roleComboBox.IntegralHeight = false;
            roleComboBox.ItemHeight = 43;
            roleComboBox.Location = new Point(10, 290);
            roleComboBox.MaxDropDownItems = 4;
            roleComboBox.MouseState = MaterialSkin.MouseState.OUT;
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(250, 49);
            roleComboBox.StartIndex = 0;
            roleComboBox.TabIndex = 15;
            // 
            // userPhoneTxt
            // 
            userPhoneTxt.AllowPromptAsInput = true;
            userPhoneTxt.AnimateReadOnly = false;
            userPhoneTxt.AsciiOnly = false;
            userPhoneTxt.BackgroundImageLayout = ImageLayout.None;
            userPhoneTxt.BeepOnError = false;
            userPhoneTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            userPhoneTxt.Depth = 0;
            userPhoneTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            userPhoneTxt.HidePromptOnLeave = false;
            userPhoneTxt.HideSelection = true;
            userPhoneTxt.Hint = "Telefon Numarası";
            userPhoneTxt.InsertKeyMode = InsertKeyMode.Default;
            userPhoneTxt.LeadingIcon = null;
            userPhoneTxt.Location = new Point(10, 236);
            userPhoneTxt.Mask = "(999) 000-0000";
            userPhoneTxt.MaxLength = 32767;
            userPhoneTxt.MouseState = MaterialSkin.MouseState.OUT;
            userPhoneTxt.Name = "userPhoneTxt";
            userPhoneTxt.PasswordChar = '\0';
            userPhoneTxt.PrefixSuffixText = null;
            userPhoneTxt.PromptChar = '_';
            userPhoneTxt.ReadOnly = false;
            userPhoneTxt.RejectInputOnFirstFailure = false;
            userPhoneTxt.ResetOnPrompt = true;
            userPhoneTxt.ResetOnSpace = true;
            userPhoneTxt.RightToLeft = RightToLeft.No;
            userPhoneTxt.SelectedText = "";
            userPhoneTxt.SelectionLength = 0;
            userPhoneTxt.SelectionStart = 0;
            userPhoneTxt.ShortcutsEnabled = true;
            userPhoneTxt.Size = new Size(250, 48);
            userPhoneTxt.SkipLiterals = true;
            userPhoneTxt.TabIndex = 13;
            userPhoneTxt.TabStop = false;
            userPhoneTxt.Text = "(   )    -";
            userPhoneTxt.TextAlign = HorizontalAlignment.Left;
            userPhoneTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            userPhoneTxt.TrailingIcon = null;
            userPhoneTxt.UseSystemPasswordChar = false;
            userPhoneTxt.ValidatingType = null;
            // 
            // emailTxt
            // 
            emailTxt.AnimateReadOnly = false;
            emailTxt.BackgroundImageLayout = ImageLayout.None;
            emailTxt.CharacterCasing = CharacterCasing.Normal;
            emailTxt.Depth = 0;
            emailTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            emailTxt.HideSelection = true;
            emailTxt.Hint = "E-posta";
            emailTxt.LeadingIcon = null;
            emailTxt.Location = new Point(9, 182);
            emailTxt.MaxLength = 32767;
            emailTxt.MouseState = MaterialSkin.MouseState.OUT;
            emailTxt.Name = "emailTxt";
            emailTxt.PasswordChar = '\0';
            emailTxt.PrefixSuffixText = null;
            emailTxt.ReadOnly = false;
            emailTxt.RightToLeft = RightToLeft.No;
            emailTxt.SelectedText = "";
            emailTxt.SelectionLength = 0;
            emailTxt.SelectionStart = 0;
            emailTxt.ShortcutsEnabled = true;
            emailTxt.Size = new Size(250, 48);
            emailTxt.TabIndex = 12;
            emailTxt.TabStop = false;
            emailTxt.TextAlign = HorizontalAlignment.Left;
            emailTxt.TrailingIcon = null;
            emailTxt.UseSystemPasswordChar = false;
            // 
            // fullNameTxt
            // 
            fullNameTxt.AnimateReadOnly = false;
            fullNameTxt.BackgroundImageLayout = ImageLayout.None;
            fullNameTxt.CharacterCasing = CharacterCasing.Normal;
            fullNameTxt.Depth = 0;
            fullNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            fullNameTxt.HideSelection = true;
            fullNameTxt.Hint = "Adı";
            fullNameTxt.LeadingIcon = null;
            fullNameTxt.Location = new Point(10, 128);
            fullNameTxt.MaxLength = 32767;
            fullNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            fullNameTxt.Name = "fullNameTxt";
            fullNameTxt.PasswordChar = '\0';
            fullNameTxt.PrefixSuffixText = null;
            fullNameTxt.ReadOnly = false;
            fullNameTxt.RightToLeft = RightToLeft.No;
            fullNameTxt.SelectedText = "";
            fullNameTxt.SelectionLength = 0;
            fullNameTxt.SelectionStart = 0;
            fullNameTxt.ShortcutsEnabled = true;
            fullNameTxt.Size = new Size(250, 48);
            fullNameTxt.TabIndex = 11;
            fullNameTxt.TabStop = false;
            fullNameTxt.TextAlign = HorizontalAlignment.Left;
            fullNameTxt.TrailingIcon = null;
            fullNameTxt.UseSystemPasswordChar = false;
            // 
            // userNameTxt
            // 
            userNameTxt.AnimateReadOnly = false;
            userNameTxt.BackgroundImageLayout = ImageLayout.None;
            userNameTxt.CharacterCasing = CharacterCasing.Normal;
            userNameTxt.Depth = 0;
            userNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            userNameTxt.HideSelection = true;
            userNameTxt.Hint = "Kullanıcı Adı";
            userNameTxt.LeadingIcon = null;
            userNameTxt.Location = new Point(10, 74);
            userNameTxt.MaxLength = 32767;
            userNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            userNameTxt.Name = "userNameTxt";
            userNameTxt.PasswordChar = '\0';
            userNameTxt.PrefixSuffixText = null;
            userNameTxt.ReadOnly = false;
            userNameTxt.RightToLeft = RightToLeft.No;
            userNameTxt.SelectedText = "";
            userNameTxt.SelectionLength = 0;
            userNameTxt.SelectionStart = 0;
            userNameTxt.ShortcutsEnabled = true;
            userNameTxt.Size = new Size(250, 48);
            userNameTxt.TabIndex = 10;
            userNameTxt.TabStop = false;
            userNameTxt.TextAlign = HorizontalAlignment.Left;
            userNameTxt.TrailingIcon = null;
            userNameTxt.UseSystemPasswordChar = false;
            // 
            // UpdateUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 391);
            Controls.Add(updateUserBtn);
            Controls.Add(roleComboBox);
            Controls.Add(userPhoneTxt);
            Controls.Add(emailTxt);
            Controls.Add(fullNameTxt);
            Controls.Add(userNameTxt);
            MaximizeBox = false;
            Name = "UpdateUserForm";
            Text = "Kullanıcı Güncelle";
            Load += UpdateUserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton updateUserBtn;
        private MaterialSkin.Controls.MaterialComboBox roleComboBox;
        private MaterialSkin.Controls.MaterialMaskedTextBox userPhoneTxt;
        private MaterialSkin.Controls.MaterialTextBox2 emailTxt;
        private MaterialSkin.Controls.MaterialTextBox2 fullNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 userNameTxt;
    }
}