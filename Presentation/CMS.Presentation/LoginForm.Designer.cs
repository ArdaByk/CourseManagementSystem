namespace CMS.Presentation
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            emailTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            passwordTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            loginBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // emailTxt
            // 
            emailTxt.AllowPromptAsInput = true;
            emailTxt.AnimateReadOnly = false;
            emailTxt.AsciiOnly = false;
            emailTxt.BackgroundImageLayout = ImageLayout.None;
            emailTxt.BeepOnError = false;
            emailTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            emailTxt.Depth = 0;
            emailTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            emailTxt.HidePromptOnLeave = false;
            emailTxt.HideSelection = true;
            emailTxt.Hint = "E-posta veya Kullanıcı Adı";
            emailTxt.InsertKeyMode = InsertKeyMode.Default;
            emailTxt.LeadingIcon = null;
            emailTxt.Location = new Point(68, 140);
            emailTxt.Mask = "";
            emailTxt.MaxLength = 32767;
            emailTxt.MouseState = MaterialSkin.MouseState.OUT;
            emailTxt.Name = "emailTxt";
            emailTxt.PasswordChar = '\0';
            emailTxt.PrefixSuffixText = null;
            emailTxt.PromptChar = '_';
            emailTxt.ReadOnly = false;
            emailTxt.RejectInputOnFirstFailure = false;
            emailTxt.ResetOnPrompt = true;
            emailTxt.ResetOnSpace = true;
            emailTxt.RightToLeft = RightToLeft.No;
            emailTxt.SelectedText = "";
            emailTxt.SelectionLength = 0;
            emailTxt.SelectionStart = 0;
            emailTxt.ShortcutsEnabled = true;
            emailTxt.Size = new Size(250, 48);
            emailTxt.SkipLiterals = true;
            emailTxt.TabIndex = 0;
            emailTxt.TabStop = false;
            emailTxt.TextAlign = HorizontalAlignment.Left;
            emailTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            emailTxt.TrailingIcon = null;
            emailTxt.UseSystemPasswordChar = false;
            emailTxt.ValidatingType = null;
            // 
            // passwordTxt
            // 
            passwordTxt.AllowPromptAsInput = true;
            passwordTxt.AnimateReadOnly = false;
            passwordTxt.AsciiOnly = false;
            passwordTxt.BackgroundImageLayout = ImageLayout.None;
            passwordTxt.BeepOnError = false;
            passwordTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            passwordTxt.Depth = 0;
            passwordTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            passwordTxt.HidePromptOnLeave = false;
            passwordTxt.HideSelection = true;
            passwordTxt.Hint = "Şifre";
            passwordTxt.InsertKeyMode = InsertKeyMode.Default;
            passwordTxt.LeadingIcon = null;
            passwordTxt.Location = new Point(68, 205);
            passwordTxt.Mask = "";
            passwordTxt.MaxLength = 32767;
            passwordTxt.MouseState = MaterialSkin.MouseState.OUT;
            passwordTxt.Name = "passwordTxt";
            passwordTxt.PasswordChar = '*';
            passwordTxt.PrefixSuffixText = null;
            passwordTxt.PromptChar = '_';
            passwordTxt.ReadOnly = false;
            passwordTxt.RejectInputOnFirstFailure = false;
            passwordTxt.ResetOnPrompt = true;
            passwordTxt.ResetOnSpace = true;
            passwordTxt.RightToLeft = RightToLeft.No;
            passwordTxt.SelectedText = "";
            passwordTxt.SelectionLength = 0;
            passwordTxt.SelectionStart = 0;
            passwordTxt.ShortcutsEnabled = true;
            passwordTxt.Size = new Size(250, 48);
            passwordTxt.SkipLiterals = true;
            passwordTxt.TabIndex = 1;
            passwordTxt.TabStop = false;
            passwordTxt.TextAlign = HorizontalAlignment.Left;
            passwordTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            passwordTxt.TrailingIcon = null;
            passwordTxt.UseSystemPasswordChar = false;
            passwordTxt.ValidatingType = null;
            // 
            // loginBtn
            // 
            loginBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            loginBtn.Depth = 0;
            loginBtn.HighEmphasis = true;
            loginBtn.Icon = null;
            loginBtn.Location = new Point(139, 262);
            loginBtn.Margin = new Padding(4, 6, 4, 6);
            loginBtn.MouseState = MaterialSkin.MouseState.HOVER;
            loginBtn.Name = "loginBtn";
            loginBtn.NoAccentTextColor = Color.Empty;
            loginBtn.Size = new Size(89, 36);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "Giriş Yap";
            loginBtn.TextAlign = ContentAlignment.BottomLeft;
            loginBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            loginBtn.UseAccentColor = false;
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 442);
            Controls.Add(loginBtn);
            Controls.Add(passwordTxt);
            Controls.Add(emailTxt);
            MaximizeBox = false;
            Name = "LoginForm";
            Sizable = false;
            Text = "Giriş Yap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialMaskedTextBox emailTxt;
        private MaterialSkin.Controls.MaterialMaskedTextBox passwordTxt;
        private MaterialSkin.Controls.MaterialButton loginBtn;
    }
}
