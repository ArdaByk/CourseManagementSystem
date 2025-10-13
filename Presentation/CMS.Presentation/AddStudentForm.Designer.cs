namespace CMS.Presentation
{
    partial class AddStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStudentForm));
            studentFirstNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            studentLastNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            studentNationalIDTxt = new MaterialSkin.Controls.MaterialTextBox2();
            studentGenderComboBox = new MaterialSkin.Controls.MaterialComboBox();
            studentBirthDate = new DateTimePicker();
            studentPhoneTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            studentEmailTxt = new MaterialSkin.Controls.MaterialTextBox2();
            studentAdressTxt = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            EmergencyContactNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            EmergencyContactPhoneTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            EmergencyContactRelation = new MaterialSkin.Controls.MaterialTextBox2();
            studentStatusSwitch = new MaterialSkin.Controls.MaterialSwitch();
            studentPhotoPath = new PictureBox();
            studentPhotoUploadBtn = new MaterialSkin.Controls.MaterialButton();
            addStudentBtn = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)studentPhotoPath).BeginInit();
            SuspendLayout();
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
            studentFirstNameTxt.Location = new Point(15, 77);
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
            studentFirstNameTxt.TabIndex = 0;
            studentFirstNameTxt.TabStop = false;
            studentFirstNameTxt.TextAlign = HorizontalAlignment.Left;
            studentFirstNameTxt.TrailingIcon = null;
            studentFirstNameTxt.UseSystemPasswordChar = false;
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
            studentLastNameTxt.Location = new Point(15, 131);
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
            studentLastNameTxt.TabIndex = 1;
            studentLastNameTxt.TabStop = false;
            studentLastNameTxt.TextAlign = HorizontalAlignment.Left;
            studentLastNameTxt.TrailingIcon = null;
            studentLastNameTxt.UseSystemPasswordChar = false;
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
            studentNationalIDTxt.Location = new Point(15, 185);
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
            studentNationalIDTxt.TabIndex = 2;
            studentNationalIDTxt.TabStop = false;
            studentNationalIDTxt.TextAlign = HorizontalAlignment.Left;
            studentNationalIDTxt.TrailingIcon = null;
            studentNationalIDTxt.UseSystemPasswordChar = false;
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
            studentGenderComboBox.Location = new Point(15, 239);
            studentGenderComboBox.MaxDropDownItems = 4;
            studentGenderComboBox.MouseState = MaterialSkin.MouseState.OUT;
            studentGenderComboBox.Name = "studentGenderComboBox";
            studentGenderComboBox.Size = new Size(250, 49);
            studentGenderComboBox.StartIndex = 0;
            studentGenderComboBox.TabIndex = 3;
            // 
            // studentBirthDate
            // 
            studentBirthDate.CalendarMonthBackground = Color.FromArgb(64, 64, 64);
            studentBirthDate.Location = new Point(15, 295);
            studentBirthDate.Name = "studentBirthDate";
            studentBirthDate.Size = new Size(250, 23);
            studentBirthDate.TabIndex = 4;
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
            studentPhoneTxt.Hint = "Telefon Numarası";
            studentPhoneTxt.InsertKeyMode = InsertKeyMode.Default;
            studentPhoneTxt.LeadingIcon = null;
            studentPhoneTxt.Location = new Point(15, 327);
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
            studentPhoneTxt.TabIndex = 5;
            studentPhoneTxt.TabStop = false;
            studentPhoneTxt.Text = "(   )    -";
            studentPhoneTxt.TextAlign = HorizontalAlignment.Left;
            studentPhoneTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            studentPhoneTxt.TrailingIcon = null;
            studentPhoneTxt.UseSystemPasswordChar = false;
            studentPhoneTxt.ValidatingType = null;
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
            studentEmailTxt.Location = new Point(15, 381);
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
            studentEmailTxt.TabIndex = 6;
            studentEmailTxt.TabStop = false;
            studentEmailTxt.TextAlign = HorizontalAlignment.Left;
            studentEmailTxt.TrailingIcon = null;
            studentEmailTxt.UseSystemPasswordChar = false;
            // 
            // studentAdressTxt
            // 
            studentAdressTxt.AnimateReadOnly = false;
            studentAdressTxt.BackgroundImageLayout = ImageLayout.None;
            studentAdressTxt.CharacterCasing = CharacterCasing.Normal;
            studentAdressTxt.Depth = 0;
            studentAdressTxt.HideSelection = true;
            studentAdressTxt.Hint = "Adres";
            studentAdressTxt.Location = new Point(15, 435);
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
            studentAdressTxt.TabIndex = 7;
            studentAdressTxt.TabStop = false;
            studentAdressTxt.TextAlign = HorizontalAlignment.Left;
            studentAdressTxt.UseSystemPasswordChar = false;
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
            EmergencyContactNameTxt.Location = new Point(15, 594);
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
            EmergencyContactNameTxt.TabIndex = 8;
            EmergencyContactNameTxt.TabStop = false;
            EmergencyContactNameTxt.TextAlign = HorizontalAlignment.Left;
            EmergencyContactNameTxt.TrailingIcon = null;
            EmergencyContactNameTxt.UseSystemPasswordChar = false;
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
            EmergencyContactPhoneTxt.Location = new Point(15, 648);
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
            EmergencyContactPhoneTxt.TabIndex = 9;
            EmergencyContactPhoneTxt.TabStop = false;
            EmergencyContactPhoneTxt.Text = "(   )    -";
            EmergencyContactPhoneTxt.TextAlign = HorizontalAlignment.Left;
            EmergencyContactPhoneTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            EmergencyContactPhoneTxt.TrailingIcon = null;
            EmergencyContactPhoneTxt.UseSystemPasswordChar = false;
            EmergencyContactPhoneTxt.ValidatingType = null;
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
            EmergencyContactRelation.Location = new Point(15, 702);
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
            EmergencyContactRelation.TabIndex = 10;
            EmergencyContactRelation.TabStop = false;
            EmergencyContactRelation.TextAlign = HorizontalAlignment.Left;
            EmergencyContactRelation.TrailingIcon = null;
            EmergencyContactRelation.UseSystemPasswordChar = false;
            // 
            // studentStatusSwitch
            // 
            studentStatusSwitch.AutoSize = true;
            studentStatusSwitch.Checked = true;
            studentStatusSwitch.CheckState = CheckState.Checked;
            studentStatusSwitch.Depth = 0;
            studentStatusSwitch.Location = new Point(15, 538);
            studentStatusSwitch.Margin = new Padding(0);
            studentStatusSwitch.MouseLocation = new Point(-1, -1);
            studentStatusSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            studentStatusSwitch.Name = "studentStatusSwitch";
            studentStatusSwitch.Ripple = true;
            studentStatusSwitch.Size = new Size(149, 37);
            studentStatusSwitch.TabIndex = 15;
            studentStatusSwitch.Text = "Aktif Öğrenci";
            studentStatusSwitch.UseVisualStyleBackColor = true;
            // 
            // studentPhotoPath
            // 
            studentPhotoPath.Image = (Image)resources.GetObject("studentPhotoPath.Image");
            studentPhotoPath.Location = new Point(299, 77);
            studentPhotoPath.Name = "studentPhotoPath";
            studentPhotoPath.Size = new Size(232, 211);
            studentPhotoPath.SizeMode = PictureBoxSizeMode.StretchImage;
            studentPhotoPath.TabIndex = 16;
            studentPhotoPath.TabStop = false;
            // 
            // studentPhotoUploadBtn
            // 
            studentPhotoUploadBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            studentPhotoUploadBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            studentPhotoUploadBtn.Depth = 0;
            studentPhotoUploadBtn.HighEmphasis = true;
            studentPhotoUploadBtn.Icon = null;
            studentPhotoUploadBtn.Location = new Point(350, 297);
            studentPhotoUploadBtn.Margin = new Padding(4, 6, 4, 6);
            studentPhotoUploadBtn.MouseState = MaterialSkin.MouseState.HOVER;
            studentPhotoUploadBtn.Name = "studentPhotoUploadBtn";
            studentPhotoUploadBtn.NoAccentTextColor = Color.Empty;
            studentPhotoUploadBtn.Size = new Size(113, 36);
            studentPhotoUploadBtn.TabIndex = 17;
            studentPhotoUploadBtn.Text = "Resim Yükle";
            studentPhotoUploadBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            studentPhotoUploadBtn.UseAccentColor = false;
            studentPhotoUploadBtn.UseVisualStyleBackColor = true;
            studentPhotoUploadBtn.Click += studentPhotoUploadBtn_Click;
            // 
            // addStudentBtn
            // 
            addStudentBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addStudentBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addStudentBtn.Depth = 0;
            addStudentBtn.HighEmphasis = true;
            addStudentBtn.Icon = null;
            addStudentBtn.Location = new Point(15, 768);
            addStudentBtn.Margin = new Padding(4, 6, 4, 6);
            addStudentBtn.MouseState = MaterialSkin.MouseState.HOVER;
            addStudentBtn.Name = "addStudentBtn";
            addStudentBtn.NoAccentTextColor = Color.Empty;
            addStudentBtn.Size = new Size(121, 36);
            addStudentBtn.TabIndex = 18;
            addStudentBtn.Text = "Öğrenci Ekle";
            addStudentBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addStudentBtn.UseAccentColor = false;
            addStudentBtn.UseVisualStyleBackColor = true;
            // 
            // AddStudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 825);
            Controls.Add(addStudentBtn);
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
            Name = "AddStudentForm";
            Text = "Öğrenci Ekle";
            ((System.ComponentModel.ISupportInitialize)studentPhotoPath).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 studentFirstNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 studentLastNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 studentNationalIDTxt;
        private MaterialSkin.Controls.MaterialComboBox studentGenderComboBox;
        private DateTimePicker studentBirthDate;
        private MaterialSkin.Controls.MaterialMaskedTextBox studentPhoneTxt;
        private MaterialSkin.Controls.MaterialTextBox2 studentEmailTxt;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 studentAdressTxt;
        private MaterialSkin.Controls.MaterialTextBox2 EmergencyContactNameTxt;
        private MaterialSkin.Controls.MaterialMaskedTextBox EmergencyContactPhoneTxt;
        private MaterialSkin.Controls.MaterialTextBox2 EmergencyContactRelation;
        private MaterialSkin.Controls.MaterialSwitch studentStatusSwitch;
        private PictureBox studentPhotoPath;
        private MaterialSkin.Controls.MaterialButton studentPhotoUploadBtn;
        private MaterialSkin.Controls.MaterialButton addStudentBtn;
    }
}