namespace CMS.Presentation
{
    partial class AddCourseForm
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
            courseNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            courseDescriptionTxt = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            durationWeekTxt = new MaterialSkin.Controls.MaterialTextBox2();
            weeklyHoursTxt = new MaterialSkin.Controls.MaterialTextBox2();
            courseStatusSwitch = new MaterialSkin.Controls.MaterialSwitch();
            addCourseBtn = new MaterialSkin.Controls.MaterialButton();
            specializationComboBox = new MaterialSkin.Controls.MaterialComboBox();
            SuspendLayout();
            // 
            // courseNameTxt
            // 
            courseNameTxt.AnimateReadOnly = false;
            courseNameTxt.BackgroundImageLayout = ImageLayout.None;
            courseNameTxt.CharacterCasing = CharacterCasing.Normal;
            courseNameTxt.Depth = 0;
            courseNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            courseNameTxt.HideSelection = true;
            courseNameTxt.Hint = "Kurs Adı";
            courseNameTxt.LeadingIcon = null;
            courseNameTxt.Location = new Point(8, 76);
            courseNameTxt.MaxLength = 32767;
            courseNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            courseNameTxt.Name = "courseNameTxt";
            courseNameTxt.PasswordChar = '\0';
            courseNameTxt.PrefixSuffixText = null;
            courseNameTxt.ReadOnly = false;
            courseNameTxt.RightToLeft = RightToLeft.No;
            courseNameTxt.SelectedText = "";
            courseNameTxt.SelectionLength = 0;
            courseNameTxt.SelectionStart = 0;
            courseNameTxt.ShortcutsEnabled = true;
            courseNameTxt.Size = new Size(250, 48);
            courseNameTxt.TabIndex = 0;
            courseNameTxt.TabStop = false;
            courseNameTxt.TextAlign = HorizontalAlignment.Left;
            courseNameTxt.TrailingIcon = null;
            courseNameTxt.UseSystemPasswordChar = false;
            // 
            // courseDescriptionTxt
            // 
            courseDescriptionTxt.AnimateReadOnly = false;
            courseDescriptionTxt.BackgroundImageLayout = ImageLayout.None;
            courseDescriptionTxt.CharacterCasing = CharacterCasing.Normal;
            courseDescriptionTxt.Depth = 0;
            courseDescriptionTxt.HideSelection = true;
            courseDescriptionTxt.Hint = "Kurs Açıklaması";
            courseDescriptionTxt.Location = new Point(6, 130);
            courseDescriptionTxt.MaxLength = 32767;
            courseDescriptionTxt.MouseState = MaterialSkin.MouseState.OUT;
            courseDescriptionTxt.Name = "courseDescriptionTxt";
            courseDescriptionTxt.PasswordChar = '\0';
            courseDescriptionTxt.ReadOnly = false;
            courseDescriptionTxt.ScrollBars = ScrollBars.None;
            courseDescriptionTxt.SelectedText = "";
            courseDescriptionTxt.SelectionLength = 0;
            courseDescriptionTxt.SelectionStart = 0;
            courseDescriptionTxt.ShortcutsEnabled = true;
            courseDescriptionTxt.Size = new Size(250, 100);
            courseDescriptionTxt.TabIndex = 1;
            courseDescriptionTxt.TabStop = false;
            courseDescriptionTxt.TextAlign = HorizontalAlignment.Left;
            courseDescriptionTxt.UseSystemPasswordChar = false;
            // 
            // durationWeekTxt
            // 
            durationWeekTxt.AnimateReadOnly = false;
            durationWeekTxt.BackgroundImageLayout = ImageLayout.None;
            durationWeekTxt.CharacterCasing = CharacterCasing.Normal;
            durationWeekTxt.Depth = 0;
            durationWeekTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            durationWeekTxt.HideSelection = true;
            durationWeekTxt.Hint = "Hafta Sayısı";
            durationWeekTxt.LeadingIcon = null;
            durationWeekTxt.Location = new Point(8, 236);
            durationWeekTxt.MaxLength = 32767;
            durationWeekTxt.MouseState = MaterialSkin.MouseState.OUT;
            durationWeekTxt.Name = "durationWeekTxt";
            durationWeekTxt.PasswordChar = '\0';
            durationWeekTxt.PrefixSuffixText = null;
            durationWeekTxt.ReadOnly = false;
            durationWeekTxt.RightToLeft = RightToLeft.No;
            durationWeekTxt.SelectedText = "";
            durationWeekTxt.SelectionLength = 0;
            durationWeekTxt.SelectionStart = 0;
            durationWeekTxt.ShortcutsEnabled = true;
            durationWeekTxt.Size = new Size(250, 48);
            durationWeekTxt.TabIndex = 2;
            durationWeekTxt.TabStop = false;
            durationWeekTxt.TextAlign = HorizontalAlignment.Left;
            durationWeekTxt.TrailingIcon = null;
            durationWeekTxt.UseSystemPasswordChar = false;
            // 
            // weeklyHoursTxt
            // 
            weeklyHoursTxt.AnimateReadOnly = false;
            weeklyHoursTxt.BackgroundImageLayout = ImageLayout.None;
            weeklyHoursTxt.CharacterCasing = CharacterCasing.Normal;
            weeklyHoursTxt.Depth = 0;
            weeklyHoursTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            weeklyHoursTxt.HideSelection = true;
            weeklyHoursTxt.Hint = "Haftalık Saat";
            weeklyHoursTxt.LeadingIcon = null;
            weeklyHoursTxt.Location = new Point(8, 290);
            weeklyHoursTxt.MaxLength = 32767;
            weeklyHoursTxt.MouseState = MaterialSkin.MouseState.OUT;
            weeklyHoursTxt.Name = "weeklyHoursTxt";
            weeklyHoursTxt.PasswordChar = '\0';
            weeklyHoursTxt.PrefixSuffixText = null;
            weeklyHoursTxt.ReadOnly = false;
            weeklyHoursTxt.RightToLeft = RightToLeft.No;
            weeklyHoursTxt.SelectedText = "";
            weeklyHoursTxt.SelectionLength = 0;
            weeklyHoursTxt.SelectionStart = 0;
            weeklyHoursTxt.ShortcutsEnabled = true;
            weeklyHoursTxt.Size = new Size(250, 48);
            weeklyHoursTxt.TabIndex = 3;
            weeklyHoursTxt.TabStop = false;
            weeklyHoursTxt.TextAlign = HorizontalAlignment.Left;
            weeklyHoursTxt.TrailingIcon = null;
            weeklyHoursTxt.UseSystemPasswordChar = false;
            // 
            // courseStatusSwitch
            // 
            courseStatusSwitch.AutoSize = true;
            courseStatusSwitch.Checked = true;
            courseStatusSwitch.CheckState = CheckState.Checked;
            courseStatusSwitch.Depth = 0;
            courseStatusSwitch.Location = new Point(8, 402);
            courseStatusSwitch.Margin = new Padding(0);
            courseStatusSwitch.MouseLocation = new Point(-1, -1);
            courseStatusSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            courseStatusSwitch.Name = "courseStatusSwitch";
            courseStatusSwitch.Ripple = true;
            courseStatusSwitch.Size = new Size(127, 37);
            courseStatusSwitch.TabIndex = 4;
            courseStatusSwitch.Text = "Aktif Kurs";
            courseStatusSwitch.UseVisualStyleBackColor = true;
            // 
            // addCourseBtn
            // 
            addCourseBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addCourseBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addCourseBtn.Depth = 0;
            addCourseBtn.HighEmphasis = true;
            addCourseBtn.Icon = null;
            addCourseBtn.Location = new Point(8, 449);
            addCourseBtn.Margin = new Padding(4, 6, 4, 6);
            addCourseBtn.MouseState = MaterialSkin.MouseState.HOVER;
            addCourseBtn.Name = "addCourseBtn";
            addCourseBtn.NoAccentTextColor = Color.Empty;
            addCourseBtn.Size = new Size(96, 36);
            addCourseBtn.TabIndex = 5;
            addCourseBtn.Text = "Kurs Ekle";
            addCourseBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addCourseBtn.UseAccentColor = false;
            addCourseBtn.UseVisualStyleBackColor = true;
            addCourseBtn.Click += addCourseBtn_Click;
            // 
            // specializationComboBox
            // 
            specializationComboBox.AutoResize = false;
            specializationComboBox.BackColor = Color.FromArgb(255, 255, 255);
            specializationComboBox.Depth = 0;
            specializationComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            specializationComboBox.DropDownHeight = 174;
            specializationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            specializationComboBox.DropDownWidth = 121;
            specializationComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            specializationComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            specializationComboBox.FormattingEnabled = true;
            specializationComboBox.Hint = "Kurs Alanı";
            specializationComboBox.IntegralHeight = false;
            specializationComboBox.ItemHeight = 43;
            specializationComboBox.Location = new Point(6, 344);
            specializationComboBox.MaxDropDownItems = 4;
            specializationComboBox.MouseState = MaterialSkin.MouseState.OUT;
            specializationComboBox.Name = "specializationComboBox";
            specializationComboBox.Size = new Size(250, 49);
            specializationComboBox.StartIndex = 0;
            specializationComboBox.TabIndex = 9;
            // 
            // AddCourseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(268, 510);
            Controls.Add(specializationComboBox);
            Controls.Add(addCourseBtn);
            Controls.Add(courseStatusSwitch);
            Controls.Add(weeklyHoursTxt);
            Controls.Add(durationWeekTxt);
            Controls.Add(courseDescriptionTxt);
            Controls.Add(courseNameTxt);
            MaximizeBox = false;
            Name = "AddCourseForm";
            Text = "Kurs Ekle";
            Load += AddCourseForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 courseNameTxt;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 courseDescriptionTxt;
        private MaterialSkin.Controls.MaterialTextBox2 durationWeekTxt;
        private MaterialSkin.Controls.MaterialTextBox2 weeklyHoursTxt;
        private MaterialSkin.Controls.MaterialSwitch courseStatusSwitch;
        private MaterialSkin.Controls.MaterialButton addCourseBtn;
        private MaterialSkin.Controls.MaterialComboBox specializationComboBox;
    }
}