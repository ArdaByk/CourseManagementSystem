namespace CMS.Presentation
{
    partial class UpdateStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateStudentForm));
            updateStudentBtn = new MaterialSkin.Controls.MaterialButton();
            studentPhotoUploadBtn = new MaterialSkin.Controls.MaterialButton();
            studentPhotoPath = new PictureBox();
            studentStatusSwitch = new MaterialSkin.Controls.MaterialSwitch();
            EmergencyContactRelation = new MaterialSkin.Controls.MaterialTextBox2();
            EmergencyContactPhoneTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            EmergencyContactNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            studentAdressTxt = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            studentEmailTxt = new MaterialSkin.Controls.MaterialTextBox2();
            studentPhoneTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            studentBirthDate = new DateTimePicker();
            studentGenderComboBox = new MaterialSkin.Controls.MaterialComboBox();
            studentNationalIDTxt = new MaterialSkin.Controls.MaterialTextBox2();
            studentLastNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            studentFirstNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)studentPhotoPath).BeginInit();
            SuspendLayout();
            // 
            // updateStudentBtn
            // 
            updateStudentBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            updateStudentBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            updateStudentBtn.Depth = 0;
            updateStudentBtn.HighEmphasis = true;
            updateStudentBtn.Icon = null;
            updateStudentBtn.Location = new Point(18, 775);
            updateStudentBtn.Margin = new Padding(4, 6, 4, 6);
            updateStudentBtn.MouseState = MaterialSkin.MouseState.HOVER;
            updateStudentBtn.Name = "updateStudentBtn";
            updateStudentBtn.NoAccentTextColor = Color.Empty;
            updateStudentBtn.Size = new Size(76, 36);
            updateStudentBtn.TabIndex = 33;
            updateStudentBtn.Text = "Kaydet";
            updateStudentBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            updateStudentBtn.UseAccentColor = false;
            updateStudentBtn.UseVisualStyleBackColor = true;
            // 
            // studentPhotoUploadBtn
            // 
            studentPhotoUploadBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            studentPhotoUploadBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            studentPhotoUploadBtn.Depth = 0;
            studentPhotoUploadBtn.HighEmphasis = true;
            studentPhotoUploadBtn.Icon = null;
            studentPhotoUploadBtn.Location = new Point(353, 304);
            studentPhotoUploadBtn.Margin = new Padding(4, 6, 4, 6);
            studentPhotoUploadBtn.MouseState = MaterialSkin.MouseState.HOVER;
            studentPhotoUploadBtn.Name = "studentPhotoUploadBtn";
            studentPhotoUploadBtn.NoAccentTextColor = Color.Empty;
            studentPhotoUploadBtn.Size = new Size(113, 36);
            studentPhotoUploadBtn.TabIndex = 32;
            studentPhotoUploadBtn.Text = "Resim Yükle";
            studentPhotoUploadBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            studentPhotoUploadBtn.UseAccentColor = false;
            studentPhotoUploadBtn.UseVisualStyleBackColor = true;
            // 
            // studentPhotoPath
            // 
            studentPhotoPath.Image = (Image)resources.GetObject("studentPhotoPath.Image");
            studentPhotoPath.Location = new Point(302, 84);
            studentPhotoPath.Name = "studentPhotoPath";
            studentPhotoPath.Size = new Size(232, 211);
            studentPhotoPath.SizeMode = PictureBoxSizeMode.StretchImage;
            studentPhotoPath.TabIndex = 31;
            studentPhotoPath.TabStop = false;
            // 
            // studentStatusSwitch
            // 
            studentStatusSwitch.AutoSize = true;
            studentStatusSwitch.Checked = true;
            studentStatusSwitch.CheckState = CheckState.Checked;
            studentStatusSwitch.Depth = 0;
            studentStatusSwitch.Location = new Point(18, 545);
            studentStatusSwitch.Margin = new Padding(0);
            studentStatusSwitch.MouseLocation = new Point(-1, -1);
            studentStatusSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            studentStatusSwitch.Name = "studentStatusSwitch";
            studentStatusSwitch.Ripple = true;
            studentStatusSwitch.Size = new Size(149, 37);
            studentStatusSwitch.TabIndex = 30;
            studentStatusSwitch.Text = "Aktif Öğrenci";
            studentStatusSwitch.UseVisualStyleBackColor = true;
            // 
            // EmergencyContactRelation
            // 
            EmergencyContactRelation.AnimateReadOnly = false;
            EmergencyContactRelation.BackgroundImageLayout = ImageLayout.None;
            EmergencyContactRelation.CharacterCasing = CharacterCasing.Normal;
            EmergencyContactRelation.Depth = 0;
            EmergencyContactRelation.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            EmergencyContactRelation.HideSelection = true;
            EmergencyContactRelation.Hint = "Yakınıyla İlişkisi";
            EmergencyContactRelation.LeadingIcon = null;
            EmergencyContactRelation.Location = new Point(18, 709);
            EmergencyContactRelation.MaxLength = 32767;
            EmergencyContactRelation.MouseState = MaterialSkin.MouseState.OUT;
            EmergencyContactRelation.Name = "EmergencyContactRelation";
            EmergencyContactRelation.PasswordChar = '\0';
            EmergencyContactRelation.PrefixSuffixText = null;
            EmergencyContactRelation.ReadOnly = false;
            EmergencyContactRelation.RightToLeft = RightToLeft.No;
            EmergencyContactRelation.SelectedText = "";
            EmergencyContactRelation.SelectionLength = 0;
            EmergencyContactRelation.SelectionStart = 0;
            EmergencyContactRelation.ShortcutsEnabled = true;
            EmergencyContactRelation.Size = new Size(250, 48);
            EmergencyContactRelation.TabIndex = 29;
            EmergencyContactRelation.TabStop = false;
            EmergencyContactRelation.TextAlign = HorizontalAlignment.Left;
            EmergencyContactRelation.TrailingIcon = null;
            EmergencyContactRelation.UseSystemPasswordChar = false;
            // 
            // EmergencyContactPhoneTxt
            // 
            EmergencyContactPhoneTxt.AllowPromptAsInput = true;
            EmergencyContactPhoneTxt.AnimateReadOnly = false;
            EmergencyContactPhoneTxt.AsciiOnly = false;
            EmergencyContactPhoneTxt.BackgroundImageLayout = ImageLayout.None;
            EmergencyContactPhoneTxt.BeepOnError = false;
            EmergencyContactPhoneTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            EmergencyContactPhoneTxt.Depth = 0;
            EmergencyContactPhoneTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            EmergencyContactPhoneTxt.HidePromptOnLeave = false;
            EmergencyContactPhoneTxt.HideSelection = true;
            EmergencyContactPhoneTxt.InsertKeyMode = InsertKeyMode.Default;
            EmergencyContactPhoneTxt.LeadingIcon = null;
            EmergencyContactPhoneTxt.Location = new Point(18, 655);
            EmergencyContactPhoneTxt.Mask = "(999) 000-0000";
            EmergencyContactPhoneTxt.MaxLength = 32767;
            EmergencyContactPhoneTxt.MouseState = MaterialSkin.MouseState.OUT;
            EmergencyContactPhoneTxt.Name = "EmergencyContactPhoneTxt";
            EmergencyContactPhoneTxt.PasswordChar = '\0';
            EmergencyContactPhoneTxt.PrefixSuffixText = null;
            EmergencyContactPhoneTxt.PromptChar = '_';
            EmergencyContactPhoneTxt.ReadOnly = false;
            EmergencyContactPhoneTxt.RejectInputOnFirstFailure = false;
            EmergencyContactPhoneTxt.ResetOnPrompt = true;
            EmergencyContactPhoneTxt.ResetOnSpace = true;
            EmergencyContactPhoneTxt.RightToLeft = RightToLeft.No;
            EmergencyContactPhoneTxt.SelectedText = "";
            EmergencyContactPhoneTxt.SelectionLength = 0;
            EmergencyContactPhoneTxt.SelectionStart = 0;
            EmergencyContactPhoneTxt.ShortcutsEnabled = true;
            EmergencyContactPhoneTxt.Size = new Size(250, 48);
            EmergencyContactPhoneTxt.SkipLiterals = true;
            EmergencyContactPhoneTxt.TabIndex = 28;
            EmergencyContactPhoneTxt.TabStop = false;
            EmergencyContactPhoneTxt.Text = "(   )    -";
            EmergencyContactPhoneTxt.TextAlign = HorizontalAlignment.Left;
            EmergencyContactPhoneTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            EmergencyContactPhoneTxt.TrailingIcon = null;
            EmergencyContactPhoneTxt.UseSystemPasswordChar = false;
            EmergencyContactPhoneTxt.ValidatingType = null;
            // 
            // EmergencyContactNameTxt
            // 
            EmergencyContactNameTxt.AnimateReadOnly = false;
            EmergencyContactNameTxt.BackgroundImageLayout = ImageLayout.None;
            EmergencyContactNameTxt.CharacterCasing = CharacterCasing.Normal;
            EmergencyContactNameTxt.Depth = 0;
            EmergencyContactNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            EmergencyContactNameTxt.HideSelection = true;
            EmergencyContactNameTxt.Hint = "Yakını";
            EmergencyContactNameTxt.LeadingIcon = null;
            EmergencyContactNameTxt.Location = new Point(18, 601);
            EmergencyContactNameTxt.MaxLength = 32767;
            EmergencyContactNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            EmergencyContactNameTxt.Name = "EmergencyContactNameTxt";
            EmergencyContactNameTxt.PasswordChar = '\0';
            EmergencyContactNameTxt.PrefixSuffixText = null;
            EmergencyContactNameTxt.ReadOnly = false;
            EmergencyContactNameTxt.RightToLeft = RightToLeft.No;
            EmergencyContactNameTxt.SelectedText = "";
            EmergencyContactNameTxt.SelectionLength = 0;
            EmergencyContactNameTxt.SelectionStart = 0;
            EmergencyContactNameTxt.ShortcutsEnabled = true;
            EmergencyContactNameTxt.Size = new Size(250, 48);
            EmergencyContactNameTxt.TabIndex = 27;
            EmergencyContactNameTxt.TabStop = false;
            EmergencyContactNameTxt.TextAlign = HorizontalAlignment.Left;
            EmergencyContactNameTxt.TrailingIcon = null;
            EmergencyContactNameTxt.UseSystemPasswordChar = false;
            // 
            // studentAdressTxt
            // 
            studentAdressTxt.AnimateReadOnly = false;
            studentAdressTxt.BackgroundImageLayout = ImageLayout.None;
            studentAdressTxt.CharacterCasing = CharacterCasing.Normal;
            studentAdressTxt.Depth = 0;
            studentAdressTxt.HideSelection = true;
            studentAdressTxt.Hint = "Adres";
            studentAdressTxt.Location = new Point(18, 442);
            studentAdressTxt.MaxLength = 32767;
            studentAdressTxt.MouseState = MaterialSkin.MouseState.OUT;
            studentAdressTxt.Name = "studentAdressTxt";
            studentAdressTxt.PasswordChar = '\0';
            studentAdressTxt.ReadOnly = false;
            studentAdressTxt.ScrollBars = ScrollBars.None;
            studentAdressTxt.SelectedText = "";
            studentAdressTxt.SelectionLength = 0;
            studentAdressTxt.SelectionStart = 0;
            studentAdressTxt.ShortcutsEnabled = true;
            studentAdressTxt.Size = new Size(250, 100);
            studentAdressTxt.TabIndex = 26;
            studentAdressTxt.TabStop = false;
            studentAdressTxt.TextAlign = HorizontalAlignment.Left;
            studentAdressTxt.UseSystemPasswordChar = false;
            // 
            // studentEmailTxt
            // 
            studentEmailTxt.AnimateReadOnly = false;
            studentEmailTxt.BackgroundImageLayout = ImageLayout.None;
            studentEmailTxt.CharacterCasing = CharacterCasing.Normal;
            studentEmailTxt.Depth = 0;
            studentEmailTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            studentEmailTxt.HideSelection = true;
            studentEmailTxt.Hint = "E-posta";
            studentEmailTxt.LeadingIcon = null;
            studentEmailTxt.Location = new Point(18, 388);
            studentEmailTxt.MaxLength = 32767;
            studentEmailTxt.MouseState = MaterialSkin.MouseState.OUT;
            studentEmailTxt.Name = "studentEmailTxt";
            studentEmailTxt.PasswordChar = '\0';
            studentEmailTxt.PrefixSuffixText = null;
            studentEmailTxt.ReadOnly = false;
            studentEmailTxt.RightToLeft = RightToLeft.No;
            studentEmailTxt.SelectedText = "";
            studentEmailTxt.SelectionLength = 0;
            studentEmailTxt.SelectionStart = 0;
            studentEmailTxt.ShortcutsEnabled = true;
            studentEmailTxt.Size = new Size(250, 48);
            studentEmailTxt.TabIndex = 25;
            studentEmailTxt.TabStop = false;
            studentEmailTxt.TextAlign = HorizontalAlignment.Left;
            studentEmailTxt.TrailingIcon = null;
            studentEmailTxt.UseSystemPasswordChar = false;
            // 
            // studentPhoneTxt
            // 
            studentPhoneTxt.AllowPromptAsInput = true;
            studentPhoneTxt.AnimateReadOnly = false;
            studentPhoneTxt.AsciiOnly = false;
            studentPhoneTxt.BackgroundImageLayout = ImageLayout.None;
            studentPhoneTxt.BeepOnError = false;
            studentPhoneTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            studentPhoneTxt.Depth = 0;
            studentPhoneTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            studentPhoneTxt.HidePromptOnLeave = false;
            studentPhoneTxt.HideSelection = true;
            studentPhoneTxt.InsertKeyMode = InsertKeyMode.Default;
            studentPhoneTxt.LeadingIcon = null;
            studentPhoneTxt.Location = new Point(18, 334);
            studentPhoneTxt.Mask = "(999) 000-0000";
            studentPhoneTxt.MaxLength = 32767;
            studentPhoneTxt.MouseState = MaterialSkin.MouseState.OUT;
            studentPhoneTxt.Name = "studentPhoneTxt";
            studentPhoneTxt.PasswordChar = '\0';
            studentPhoneTxt.PrefixSuffixText = null;
            studentPhoneTxt.PromptChar = '_';
            studentPhoneTxt.ReadOnly = false;
            studentPhoneTxt.RejectInputOnFirstFailure = false;
            studentPhoneTxt.ResetOnPrompt = true;
            studentPhoneTxt.ResetOnSpace = true;
            studentPhoneTxt.RightToLeft = RightToLeft.No;
            studentPhoneTxt.SelectedText = "";
            studentPhoneTxt.SelectionLength = 0;
            studentPhoneTxt.SelectionStart = 0;
            studentPhoneTxt.ShortcutsEnabled = true;
            studentPhoneTxt.Size = new Size(250, 48);
            studentPhoneTxt.SkipLiterals = true;
            studentPhoneTxt.TabIndex = 24;
            studentPhoneTxt.TabStop = false;
            studentPhoneTxt.Text = "(   )    -";
            studentPhoneTxt.TextAlign = HorizontalAlignment.Left;
            studentPhoneTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            studentPhoneTxt.TrailingIcon = null;
            studentPhoneTxt.UseSystemPasswordChar = false;
            studentPhoneTxt.ValidatingType = null;
            // 
            // studentBirthDate
            // 
            studentBirthDate.CalendarMonthBackground = Color.FromArgb(64, 64, 64);
            studentBirthDate.Location = new Point(18, 302);
            studentBirthDate.Name = "studentBirthDate";
            studentBirthDate.Size = new Size(250, 23);
            studentBirthDate.TabIndex = 23;
            // 
            // studentGenderComboBox
            // 
            studentGenderComboBox.AutoResize = false;
            studentGenderComboBox.BackColor = Color.FromArgb(255, 255, 255);
            studentGenderComboBox.Depth = 0;
            studentGenderComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            studentGenderComboBox.DropDownHeight = 174;
            studentGenderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            studentGenderComboBox.DropDownWidth = 121;
            studentGenderComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            studentGenderComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            studentGenderComboBox.FormattingEnabled = true;
            studentGenderComboBox.Hint = "Cinsiyet";
            studentGenderComboBox.IntegralHeight = false;
            studentGenderComboBox.ItemHeight = 43;
            studentGenderComboBox.Items.AddRange(new object[] { "Erkek", "Kız" });
            studentGenderComboBox.Location = new Point(18, 246);
            studentGenderComboBox.MaxDropDownItems = 4;
            studentGenderComboBox.MouseState = MaterialSkin.MouseState.OUT;
            studentGenderComboBox.Name = "studentGenderComboBox";
            studentGenderComboBox.Size = new Size(250, 49);
            studentGenderComboBox.StartIndex = 0;
            studentGenderComboBox.TabIndex = 22;
            // 
            // studentNationalIDTxt
            // 
            studentNationalIDTxt.AnimateReadOnly = false;
            studentNationalIDTxt.BackgroundImageLayout = ImageLayout.None;
            studentNationalIDTxt.CharacterCasing = CharacterCasing.Normal;
            studentNationalIDTxt.Depth = 0;
            studentNationalIDTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            studentNationalIDTxt.HideSelection = true;
            studentNationalIDTxt.Hint = "TC Kimlik NO";
            studentNationalIDTxt.LeadingIcon = null;
            studentNationalIDTxt.Location = new Point(18, 192);
            studentNationalIDTxt.MaxLength = 32767;
            studentNationalIDTxt.MouseState = MaterialSkin.MouseState.OUT;
            studentNationalIDTxt.Name = "studentNationalIDTxt";
            studentNationalIDTxt.PasswordChar = '\0';
            studentNationalIDTxt.PrefixSuffixText = null;
            studentNationalIDTxt.ReadOnly = false;
            studentNationalIDTxt.RightToLeft = RightToLeft.No;
            studentNationalIDTxt.SelectedText = "";
            studentNationalIDTxt.SelectionLength = 0;
            studentNationalIDTxt.SelectionStart = 0;
            studentNationalIDTxt.ShortcutsEnabled = true;
            studentNationalIDTxt.Size = new Size(250, 48);
            studentNationalIDTxt.TabIndex = 21;
            studentNationalIDTxt.TabStop = false;
            studentNationalIDTxt.TextAlign = HorizontalAlignment.Left;
            studentNationalIDTxt.TrailingIcon = null;
            studentNationalIDTxt.UseSystemPasswordChar = false;
            // 
            // studentLastNameTxt
            // 
            studentLastNameTxt.AnimateReadOnly = false;
            studentLastNameTxt.BackgroundImageLayout = ImageLayout.None;
            studentLastNameTxt.CharacterCasing = CharacterCasing.Normal;
            studentLastNameTxt.Depth = 0;
            studentLastNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            studentLastNameTxt.HideSelection = true;
            studentLastNameTxt.Hint = "Öğrenci Soyadı";
            studentLastNameTxt.LeadingIcon = null;
            studentLastNameTxt.Location = new Point(18, 138);
            studentLastNameTxt.MaxLength = 32767;
            studentLastNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            studentLastNameTxt.Name = "studentLastNameTxt";
            studentLastNameTxt.PasswordChar = '\0';
            studentLastNameTxt.PrefixSuffixText = null;
            studentLastNameTxt.ReadOnly = false;
            studentLastNameTxt.RightToLeft = RightToLeft.No;
            studentLastNameTxt.SelectedText = "";
            studentLastNameTxt.SelectionLength = 0;
            studentLastNameTxt.SelectionStart = 0;
            studentLastNameTxt.ShortcutsEnabled = true;
            studentLastNameTxt.Size = new Size(250, 48);
            studentLastNameTxt.TabIndex = 20;
            studentLastNameTxt.TabStop = false;
            studentLastNameTxt.TextAlign = HorizontalAlignment.Left;
            studentLastNameTxt.TrailingIcon = null;
            studentLastNameTxt.UseSystemPasswordChar = false;
            // 
            // studentFirstNameTxt
            // 
            studentFirstNameTxt.AnimateReadOnly = false;
            studentFirstNameTxt.BackgroundImageLayout = ImageLayout.None;
            studentFirstNameTxt.CharacterCasing = CharacterCasing.Normal;
            studentFirstNameTxt.Depth = 0;
            studentFirstNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            studentFirstNameTxt.HideSelection = true;
            studentFirstNameTxt.Hint = "Öğrenci Adı";
            studentFirstNameTxt.LeadingIcon = null;
            studentFirstNameTxt.Location = new Point(18, 84);
            studentFirstNameTxt.MaxLength = 32767;
            studentFirstNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            studentFirstNameTxt.Name = "studentFirstNameTxt";
            studentFirstNameTxt.PasswordChar = '\0';
            studentFirstNameTxt.PrefixSuffixText = null;
            studentFirstNameTxt.ReadOnly = false;
            studentFirstNameTxt.RightToLeft = RightToLeft.No;
            studentFirstNameTxt.SelectedText = "";
            studentFirstNameTxt.SelectionLength = 0;
            studentFirstNameTxt.SelectionStart = 0;
            studentFirstNameTxt.ShortcutsEnabled = true;
            studentFirstNameTxt.Size = new Size(250, 48);
            studentFirstNameTxt.TabIndex = 19;
            studentFirstNameTxt.TabStop = false;
            studentFirstNameTxt.TextAlign = HorizontalAlignment.Left;
            studentFirstNameTxt.TrailingIcon = null;
            studentFirstNameTxt.UseSystemPasswordChar = false;
            // 
            // UpdateStudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 825);
            Controls.Add(updateStudentBtn);
            Controls.Add(studentPhotoUploadBtn);
            Controls.Add(studentPhotoPath);
            Controls.Add(studentStatusSwitch);
            Controls.Add(EmergencyContactRelation);
            Controls.Add(EmergencyContactPhoneTxt);
            Controls.Add(EmergencyContactNameTxt);
            Controls.Add(studentAdressTxt);
            Controls.Add(studentEmailTxt);
            Controls.Add(studentPhoneTxt);
            Controls.Add(studentBirthDate);
            Controls.Add(studentGenderComboBox);
            Controls.Add(studentNationalIDTxt);
            Controls.Add(studentLastNameTxt);
            Controls.Add(studentFirstNameTxt);
            MaximizeBox = false;
            Name = "UpdateStudentForm";
            Text = "Öğrenci Güncelle";
            ((System.ComponentModel.ISupportInitialize)studentPhotoPath).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton updateStudentBtn;
        private MaterialSkin.Controls.MaterialButton studentPhotoUploadBtn;
        private PictureBox studentPhotoPath;
        private MaterialSkin.Controls.MaterialSwitch studentStatusSwitch;
        private MaterialSkin.Controls.MaterialTextBox2 EmergencyContactRelation;
        private MaterialSkin.Controls.MaterialMaskedTextBox EmergencyContactPhoneTxt;
        private MaterialSkin.Controls.MaterialTextBox2 EmergencyContactNameTxt;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 studentAdressTxt;
        private MaterialSkin.Controls.MaterialTextBox2 studentEmailTxt;
        private MaterialSkin.Controls.MaterialMaskedTextBox studentPhoneTxt;
        private DateTimePicker studentBirthDate;
        private MaterialSkin.Controls.MaterialComboBox studentGenderComboBox;
        private MaterialSkin.Controls.MaterialTextBox2 studentNationalIDTxt;
        private MaterialSkin.Controls.MaterialTextBox2 studentLastNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 studentFirstNameTxt;
    }
}