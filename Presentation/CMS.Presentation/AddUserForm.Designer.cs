namespace CMS.Presentation
{
    partial class AddUserForm
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
            userNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            fullNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            emailTxt = new MaterialSkin.Controls.MaterialTextBox2();
            userPhoneTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            userPasswordTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            roleComboBox = new MaterialSkin.Controls.MaterialComboBox();
            addUserBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
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
            userNameTxt.Location = new Point(8, 73);
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
            userNameTxt.TabIndex = 0;
            userNameTxt.TabStop = false;
            userNameTxt.TextAlign = HorizontalAlignment.Left;
            userNameTxt.TrailingIcon = null;
            userNameTxt.UseSystemPasswordChar = false;
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
            fullNameTxt.Location = new Point(8, 127);
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
            fullNameTxt.TabIndex = 1;
            fullNameTxt.TabStop = false;
            fullNameTxt.TextAlign = HorizontalAlignment.Left;
            fullNameTxt.TrailingIcon = null;
            fullNameTxt.UseSystemPasswordChar = false;
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
            emailTxt.Location = new Point(7, 181);
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
            emailTxt.TabIndex = 2;
            emailTxt.TabStop = false;
            emailTxt.TextAlign = HorizontalAlignment.Left;
            emailTxt.TrailingIcon = null;
            emailTxt.UseSystemPasswordChar = false;
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
            userPhoneTxt.Location = new Point(8, 235);
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
            userPhoneTxt.TabIndex = 6;
            userPhoneTxt.TabStop = false;
            userPhoneTxt.Text = "(   )    -";
            userPhoneTxt.TextAlign = HorizontalAlignment.Left;
            userPhoneTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            userPhoneTxt.TrailingIcon = null;
            userPhoneTxt.UseSystemPasswordChar = false;
            userPhoneTxt.ValidatingType = null;
            // 
            // userPasswordTxt
            // 
            userPasswordTxt.AllowPromptAsInput = true;
            userPasswordTxt.AnimateReadOnly = false;
            userPasswordTxt.AsciiOnly = false;
            userPasswordTxt.BackgroundImageLayout = ImageLayout.None;
            userPasswordTxt.BeepOnError = false;
            userPasswordTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            userPasswordTxt.Depth = 0;
            userPasswordTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            userPasswordTxt.HidePromptOnLeave = false;
            userPasswordTxt.HideSelection = true;
            userPasswordTxt.Hint = "Şifre";
            userPasswordTxt.InsertKeyMode = InsertKeyMode.Default;
            userPasswordTxt.LeadingIcon = null;
            userPasswordTxt.Location = new Point(8, 289);
            userPasswordTxt.Mask = "";
            userPasswordTxt.MaxLength = 32767;
            userPasswordTxt.MouseState = MaterialSkin.MouseState.OUT;
            userPasswordTxt.Name = "userPasswordTxt";
            userPasswordTxt.PasswordChar = '*';
            userPasswordTxt.PrefixSuffixText = null;
            userPasswordTxt.PromptChar = '_';
            userPasswordTxt.ReadOnly = false;
            userPasswordTxt.RejectInputOnFirstFailure = false;
            userPasswordTxt.ResetOnPrompt = true;
            userPasswordTxt.ResetOnSpace = true;
            userPasswordTxt.RightToLeft = RightToLeft.No;
            userPasswordTxt.SelectedText = "";
            userPasswordTxt.SelectionLength = 0;
            userPasswordTxt.SelectionStart = 0;
            userPasswordTxt.ShortcutsEnabled = true;
            userPasswordTxt.Size = new Size(250, 48);
            userPasswordTxt.SkipLiterals = true;
            userPasswordTxt.TabIndex = 7;
            userPasswordTxt.TabStop = false;
            userPasswordTxt.TextAlign = HorizontalAlignment.Left;
            userPasswordTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            userPasswordTxt.TrailingIcon = null;
            userPasswordTxt.UseSystemPasswordChar = false;
            userPasswordTxt.ValidatingType = null;
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
            roleComboBox.Location = new Point(8, 343);
            roleComboBox.MaxDropDownItems = 4;
            roleComboBox.MouseState = MaterialSkin.MouseState.OUT;
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(250, 49);
            roleComboBox.StartIndex = 0;
            roleComboBox.TabIndex = 8;
            // 
            // addUserBtn
            // 
            addUserBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addUserBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addUserBtn.Depth = 0;
            addUserBtn.HighEmphasis = true;
            addUserBtn.Icon = null;
            addUserBtn.Location = new Point(8, 398);
            addUserBtn.Margin = new Padding(4, 6, 4, 6);
            addUserBtn.MouseState = MaterialSkin.MouseState.HOVER;
            addUserBtn.Name = "addUserBtn";
            addUserBtn.NoAccentTextColor = Color.Empty;
            addUserBtn.Size = new Size(132, 36);
            addUserBtn.TabIndex = 9;
            addUserBtn.Text = "Kullanıcı Ekle";
            addUserBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addUserBtn.UseAccentColor = false;
            addUserBtn.UseVisualStyleBackColor = true;
            addUserBtn.Click += addUserBtn_Click;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 443);
            Controls.Add(addUserBtn);
            Controls.Add(roleComboBox);
            Controls.Add(userPasswordTxt);
            Controls.Add(userPhoneTxt);
            Controls.Add(emailTxt);
            Controls.Add(fullNameTxt);
            Controls.Add(userNameTxt);
            MaximizeBox = false;
            Name = "AddUserForm";
            Text = "Kullanıcı Ekle";
            Load += AddUserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 userNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 fullNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 emailTxt;
        private MaterialSkin.Controls.MaterialMaskedTextBox userPhoneTxt;
        private MaterialSkin.Controls.MaterialMaskedTextBox userPasswordTxt;
        private MaterialSkin.Controls.MaterialComboBox roleComboBox;
        private MaterialSkin.Controls.MaterialButton addUserBtn;
    }
}