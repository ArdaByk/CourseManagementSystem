namespace CMS.Presentation
{
    partial class UpdateCourseGroupForm
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
            endTimeTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            startTimeTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            sunday = new MaterialSkin.Controls.MaterialCheckbox();
            saturday = new MaterialSkin.Controls.MaterialCheckbox();
            friday = new MaterialSkin.Controls.MaterialCheckbox();
            thursday = new MaterialSkin.Controls.MaterialCheckbox();
            wednesday = new MaterialSkin.Controls.MaterialCheckbox();
            monday = new MaterialSkin.Controls.MaterialCheckbox();
            groupBox1 = new GroupBox();
            tuesday = new MaterialSkin.Controls.MaterialCheckbox();
            teacherComboBox = new MaterialSkin.Controls.MaterialComboBox();
            classComboBox = new MaterialSkin.Controls.MaterialComboBox();
            courseComboBox = new MaterialSkin.Controls.MaterialComboBox();
            endedDate = new DateTimePicker();
            startedDate = new DateTimePicker();
            CourseGroupQuotaTxt = new MaterialSkin.Controls.MaterialTextBox2();
            courseGroupNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            updateGroupBtn = new MaterialSkin.Controls.MaterialButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // endTimeTxt
            // 
            endTimeTxt.AllowPromptAsInput = true;
            endTimeTxt.AnimateReadOnly = false;
            endTimeTxt.AsciiOnly = false;
            endTimeTxt.BackgroundImageLayout = ImageLayout.None;
            endTimeTxt.BeepOnError = false;
            endTimeTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            endTimeTxt.Depth = 0;
            endTimeTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            endTimeTxt.HidePromptOnLeave = false;
            endTimeTxt.HideSelection = true;
            endTimeTxt.Hint = "Başlangıç Saati";
            endTimeTxt.InsertKeyMode = InsertKeyMode.Default;
            endTimeTxt.LeadingIcon = null;
            endTimeTxt.Location = new Point(11, 156);
            endTimeTxt.Mask = "99:99";
            endTimeTxt.MaxLength = 32767;
            endTimeTxt.MouseState = MaterialSkin.MouseState.OUT;
            endTimeTxt.Name = "endTimeTxt";
            endTimeTxt.PasswordChar = '\0';
            endTimeTxt.PrefixSuffixText = null;
            endTimeTxt.PromptChar = '_';
            endTimeTxt.ReadOnly = false;
            endTimeTxt.RejectInputOnFirstFailure = false;
            endTimeTxt.ResetOnPrompt = true;
            endTimeTxt.ResetOnSpace = true;
            endTimeTxt.RightToLeft = RightToLeft.No;
            endTimeTxt.SelectedText = "";
            endTimeTxt.SelectionLength = 0;
            endTimeTxt.SelectionStart = 0;
            endTimeTxt.ShortcutsEnabled = true;
            endTimeTxt.Size = new Size(250, 48);
            endTimeTxt.SkipLiterals = true;
            endTimeTxt.TabIndex = 10;
            endTimeTxt.TabStop = false;
            endTimeTxt.Text = "  :";
            endTimeTxt.TextAlign = HorizontalAlignment.Left;
            endTimeTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            endTimeTxt.TrailingIcon = null;
            endTimeTxt.UseSystemPasswordChar = false;
            endTimeTxt.ValidatingType = null;
            // 
            // startTimeTxt
            // 
            startTimeTxt.AllowPromptAsInput = true;
            startTimeTxt.AnimateReadOnly = false;
            startTimeTxt.AsciiOnly = false;
            startTimeTxt.BackgroundImageLayout = ImageLayout.None;
            startTimeTxt.BeepOnError = false;
            startTimeTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            startTimeTxt.Depth = 0;
            startTimeTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            startTimeTxt.HidePromptOnLeave = false;
            startTimeTxt.HideSelection = true;
            startTimeTxt.Hint = "Başlangıç Saati";
            startTimeTxt.InsertKeyMode = InsertKeyMode.Default;
            startTimeTxt.LeadingIcon = null;
            startTimeTxt.Location = new Point(11, 102);
            startTimeTxt.Mask = "99:99";
            startTimeTxt.MaxLength = 32767;
            startTimeTxt.MouseState = MaterialSkin.MouseState.OUT;
            startTimeTxt.Name = "startTimeTxt";
            startTimeTxt.PasswordChar = '\0';
            startTimeTxt.PrefixSuffixText = null;
            startTimeTxt.PromptChar = '_';
            startTimeTxt.ReadOnly = false;
            startTimeTxt.RejectInputOnFirstFailure = false;
            startTimeTxt.ResetOnPrompt = true;
            startTimeTxt.ResetOnSpace = true;
            startTimeTxt.RightToLeft = RightToLeft.No;
            startTimeTxt.SelectedText = "";
            startTimeTxt.SelectionLength = 0;
            startTimeTxt.SelectionStart = 0;
            startTimeTxt.ShortcutsEnabled = true;
            startTimeTxt.Size = new Size(250, 48);
            startTimeTxt.SkipLiterals = true;
            startTimeTxt.TabIndex = 9;
            startTimeTxt.TabStop = false;
            startTimeTxt.Text = "  :";
            startTimeTxt.TextAlign = HorizontalAlignment.Left;
            startTimeTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            startTimeTxt.TrailingIcon = null;
            startTimeTxt.UseSystemPasswordChar = false;
            startTimeTxt.ValidatingType = null;
            // 
            // sunday
            // 
            sunday.AutoSize = true;
            sunday.Depth = 0;
            sunday.Location = new Point(113, 62);
            sunday.Margin = new Padding(0);
            sunday.MouseLocation = new Point(-1, -1);
            sunday.MouseState = MaterialSkin.MouseState.HOVER;
            sunday.Name = "sunday";
            sunday.ReadOnly = false;
            sunday.Ripple = true;
            sunday.Size = new Size(76, 37);
            sunday.TabIndex = 6;
            sunday.Text = "Pazar";
            sunday.UseVisualStyleBackColor = true;
            // 
            // saturday
            // 
            saturday.AutoSize = true;
            saturday.Depth = 0;
            saturday.Location = new Point(6, 62);
            saturday.Margin = new Padding(0);
            saturday.MouseLocation = new Point(-1, -1);
            saturday.MouseState = MaterialSkin.MouseState.HOVER;
            saturday.Name = "saturday";
            saturday.ReadOnly = false;
            saturday.Ripple = true;
            saturday.Size = new Size(107, 37);
            saturday.TabIndex = 5;
            saturday.Text = "Cumartesi";
            saturday.UseVisualStyleBackColor = true;
            // 
            // friday
            // 
            friday.AutoSize = true;
            friday.Depth = 0;
            friday.Location = new Point(382, 25);
            friday.Margin = new Padding(0);
            friday.MouseLocation = new Point(-1, -1);
            friday.MouseState = MaterialSkin.MouseState.HOVER;
            friday.Name = "friday";
            friday.ReadOnly = false;
            friday.Ripple = true;
            friday.Size = new Size(77, 37);
            friday.TabIndex = 4;
            friday.Text = "Cuma";
            friday.UseVisualStyleBackColor = true;
            // 
            // thursday
            // 
            thursday.AutoSize = true;
            thursday.Depth = 0;
            thursday.Location = new Point(277, 26);
            thursday.Margin = new Padding(0);
            thursday.MouseLocation = new Point(-1, -1);
            thursday.MouseState = MaterialSkin.MouseState.HOVER;
            thursday.Name = "thursday";
            thursday.ReadOnly = false;
            thursday.Ripple = true;
            thursday.Size = new Size(105, 37);
            thursday.TabIndex = 3;
            thursday.Text = "Perşembe";
            thursday.UseVisualStyleBackColor = true;
            // 
            // wednesday
            // 
            wednesday.AutoSize = true;
            wednesday.Depth = 0;
            wednesday.Location = new Point(169, 26);
            wednesday.Margin = new Padding(0);
            wednesday.MouseLocation = new Point(-1, -1);
            wednesday.MouseState = MaterialSkin.MouseState.HOVER;
            wednesday.Name = "wednesday";
            wednesday.ReadOnly = false;
            wednesday.Ripple = true;
            wednesday.Size = new Size(108, 37);
            wednesday.TabIndex = 2;
            wednesday.Text = "Çarşamba";
            wednesday.UseVisualStyleBackColor = true;
            // 
            // monday
            // 
            monday.AutoSize = true;
            monday.Depth = 0;
            monday.Location = new Point(6, 25);
            monday.Margin = new Padding(0);
            monday.MouseLocation = new Point(-1, -1);
            monday.MouseState = MaterialSkin.MouseState.HOVER;
            monday.Name = "monday";
            monday.ReadOnly = false;
            monday.Ripple = true;
            monday.Size = new Size(101, 37);
            monday.TabIndex = 0;
            monday.Text = "Pazartesi";
            monday.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(endTimeTxt);
            groupBox1.Controls.Add(startTimeTxt);
            groupBox1.Controls.Add(sunday);
            groupBox1.Controls.Add(saturday);
            groupBox1.Controls.Add(friday);
            groupBox1.Controls.Add(thursday);
            groupBox1.Controls.Add(wednesday);
            groupBox1.Controls.Add(tuesday);
            groupBox1.Controls.Add(monday);
            groupBox1.Location = new Point(7, 403);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(469, 210);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ders Programı";
            // 
            // tuesday
            // 
            tuesday.AutoSize = true;
            tuesday.Depth = 0;
            tuesday.Location = new Point(107, 25);
            tuesday.Margin = new Padding(0);
            tuesday.MouseLocation = new Point(-1, -1);
            tuesday.MouseState = MaterialSkin.MouseState.HOVER;
            tuesday.Name = "tuesday";
            tuesday.ReadOnly = false;
            tuesday.Ripple = true;
            tuesday.Size = new Size(62, 37);
            tuesday.TabIndex = 1;
            tuesday.Text = "Salı";
            tuesday.UseVisualStyleBackColor = true;
            // 
            // teacherComboBox
            // 
            teacherComboBox.AutoResize = false;
            teacherComboBox.BackColor = Color.FromArgb(255, 255, 255);
            teacherComboBox.Depth = 0;
            teacherComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            teacherComboBox.DropDownHeight = 174;
            teacherComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            teacherComboBox.DropDownWidth = 121;
            teacherComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            teacherComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            teacherComboBox.FormattingEnabled = true;
            teacherComboBox.Hint = "Öğretmen";
            teacherComboBox.IntegralHeight = false;
            teacherComboBox.ItemHeight = 43;
            teacherComboBox.Location = new Point(7, 348);
            teacherComboBox.MaxDropDownItems = 4;
            teacherComboBox.MouseState = MaterialSkin.MouseState.OUT;
            teacherComboBox.Name = "teacherComboBox";
            teacherComboBox.Size = new Size(469, 49);
            teacherComboBox.StartIndex = 0;
            teacherComboBox.TabIndex = 15;
            // 
            // classComboBox
            // 
            classComboBox.AutoResize = false;
            classComboBox.BackColor = Color.FromArgb(255, 255, 255);
            classComboBox.Depth = 0;
            classComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            classComboBox.DropDownHeight = 174;
            classComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            classComboBox.DropDownWidth = 121;
            classComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            classComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            classComboBox.FormattingEnabled = true;
            classComboBox.Hint = "Sınıf";
            classComboBox.IntegralHeight = false;
            classComboBox.ItemHeight = 43;
            classComboBox.Location = new Point(7, 293);
            classComboBox.MaxDropDownItems = 4;
            classComboBox.MouseState = MaterialSkin.MouseState.OUT;
            classComboBox.Name = "classComboBox";
            classComboBox.Size = new Size(469, 49);
            classComboBox.StartIndex = 0;
            classComboBox.TabIndex = 14;
            // 
            // courseComboBox
            // 
            courseComboBox.AutoResize = false;
            courseComboBox.BackColor = Color.FromArgb(255, 255, 255);
            courseComboBox.Depth = 0;
            courseComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            courseComboBox.DropDownHeight = 174;
            courseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            courseComboBox.DropDownWidth = 121;
            courseComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            courseComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            courseComboBox.FormattingEnabled = true;
            courseComboBox.Hint = "Kurs";
            courseComboBox.IntegralHeight = false;
            courseComboBox.ItemHeight = 43;
            courseComboBox.Location = new Point(7, 238);
            courseComboBox.MaxDropDownItems = 4;
            courseComboBox.MouseState = MaterialSkin.MouseState.OUT;
            courseComboBox.Name = "courseComboBox";
            courseComboBox.Size = new Size(469, 49);
            courseComboBox.StartIndex = 0;
            courseComboBox.TabIndex = 13;
            // 
            // endedDate
            // 
            endedDate.Location = new Point(7, 209);
            endedDate.Name = "endedDate";
            endedDate.Size = new Size(469, 23);
            endedDate.TabIndex = 12;
            // 
            // startedDate
            // 
            startedDate.Location = new Point(7, 180);
            startedDate.Name = "startedDate";
            startedDate.Size = new Size(469, 23);
            startedDate.TabIndex = 11;
            // 
            // CourseGroupQuotaTxt
            // 
            CourseGroupQuotaTxt.AnimateReadOnly = false;
            CourseGroupQuotaTxt.BackgroundImageLayout = ImageLayout.None;
            CourseGroupQuotaTxt.CharacterCasing = CharacterCasing.Normal;
            CourseGroupQuotaTxt.Depth = 0;
            CourseGroupQuotaTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            CourseGroupQuotaTxt.HideSelection = true;
            CourseGroupQuotaTxt.Hint = "Grup Kontenjanı";
            CourseGroupQuotaTxt.LeadingIcon = null;
            CourseGroupQuotaTxt.Location = new Point(7, 126);
            CourseGroupQuotaTxt.MaxLength = 32767;
            CourseGroupQuotaTxt.MouseState = MaterialSkin.MouseState.OUT;
            CourseGroupQuotaTxt.Name = "CourseGroupQuotaTxt";
            CourseGroupQuotaTxt.PasswordChar = '\0';
            CourseGroupQuotaTxt.PrefixSuffixText = null;
            CourseGroupQuotaTxt.ReadOnly = false;
            CourseGroupQuotaTxt.RightToLeft = RightToLeft.No;
            CourseGroupQuotaTxt.SelectedText = "";
            CourseGroupQuotaTxt.SelectionLength = 0;
            CourseGroupQuotaTxt.SelectionStart = 0;
            CourseGroupQuotaTxt.ShortcutsEnabled = true;
            CourseGroupQuotaTxt.Size = new Size(469, 48);
            CourseGroupQuotaTxt.TabIndex = 10;
            CourseGroupQuotaTxt.TabStop = false;
            CourseGroupQuotaTxt.TextAlign = HorizontalAlignment.Left;
            CourseGroupQuotaTxt.TrailingIcon = null;
            CourseGroupQuotaTxt.UseSystemPasswordChar = false;
            // 
            // courseGroupNameTxt
            // 
            courseGroupNameTxt.AnimateReadOnly = false;
            courseGroupNameTxt.BackgroundImageLayout = ImageLayout.None;
            courseGroupNameTxt.CharacterCasing = CharacterCasing.Normal;
            courseGroupNameTxt.Depth = 0;
            courseGroupNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            courseGroupNameTxt.HideSelection = true;
            courseGroupNameTxt.Hint = "Grup Adı";
            courseGroupNameTxt.LeadingIcon = null;
            courseGroupNameTxt.Location = new Point(7, 72);
            courseGroupNameTxt.MaxLength = 32767;
            courseGroupNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            courseGroupNameTxt.Name = "courseGroupNameTxt";
            courseGroupNameTxt.PasswordChar = '\0';
            courseGroupNameTxt.PrefixSuffixText = null;
            courseGroupNameTxt.ReadOnly = false;
            courseGroupNameTxt.RightToLeft = RightToLeft.No;
            courseGroupNameTxt.SelectedText = "";
            courseGroupNameTxt.SelectionLength = 0;
            courseGroupNameTxt.SelectionStart = 0;
            courseGroupNameTxt.ShortcutsEnabled = true;
            courseGroupNameTxt.Size = new Size(469, 48);
            courseGroupNameTxt.TabIndex = 9;
            courseGroupNameTxt.TabStop = false;
            courseGroupNameTxt.TextAlign = HorizontalAlignment.Left;
            courseGroupNameTxt.TrailingIcon = null;
            courseGroupNameTxt.UseSystemPasswordChar = false;
            // 
            // updateGroupBtn
            // 
            updateGroupBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            updateGroupBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            updateGroupBtn.Depth = 0;
            updateGroupBtn.HighEmphasis = true;
            updateGroupBtn.Icon = null;
            updateGroupBtn.Location = new Point(10, 622);
            updateGroupBtn.Margin = new Padding(4, 6, 4, 6);
            updateGroupBtn.MouseState = MaterialSkin.MouseState.HOVER;
            updateGroupBtn.Name = "updateGroupBtn";
            updateGroupBtn.NoAccentTextColor = Color.Empty;
            updateGroupBtn.Size = new Size(76, 36);
            updateGroupBtn.TabIndex = 16;
            updateGroupBtn.Text = "Kaydet";
            updateGroupBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            updateGroupBtn.UseAccentColor = false;
            updateGroupBtn.UseVisualStyleBackColor = true;
            updateGroupBtn.Click += updateGroupBtn_Click;
            // 
            // UpdateCourseGroupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 669);
            Controls.Add(groupBox1);
            Controls.Add(teacherComboBox);
            Controls.Add(classComboBox);
            Controls.Add(courseComboBox);
            Controls.Add(endedDate);
            Controls.Add(startedDate);
            Controls.Add(CourseGroupQuotaTxt);
            Controls.Add(courseGroupNameTxt);
            Controls.Add(updateGroupBtn);
            MaximizeBox = false;
            Name = "UpdateCourseGroupForm";
            Text = "Grup Güncelle";
            Load += UpdateCourseGroupForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialMaskedTextBox endTimeTxt;
        private MaterialSkin.Controls.MaterialMaskedTextBox startTimeTxt;
        private MaterialSkin.Controls.MaterialCheckbox sunday;
        private MaterialSkin.Controls.MaterialCheckbox saturday;
        private MaterialSkin.Controls.MaterialCheckbox friday;
        private MaterialSkin.Controls.MaterialCheckbox thursday;
        private MaterialSkin.Controls.MaterialCheckbox wednesday;
        private MaterialSkin.Controls.MaterialCheckbox monday;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialCheckbox tuesday;
        private MaterialSkin.Controls.MaterialComboBox teacherComboBox;
        private MaterialSkin.Controls.MaterialComboBox classComboBox;
        private MaterialSkin.Controls.MaterialComboBox courseComboBox;
        private DateTimePicker endedDate;
        private DateTimePicker startedDate;
        private MaterialSkin.Controls.MaterialTextBox2 CourseGroupQuotaTxt;
        private MaterialSkin.Controls.MaterialTextBox2 courseGroupNameTxt;
        private MaterialSkin.Controls.MaterialButton updateGroupBtn;
    }
}