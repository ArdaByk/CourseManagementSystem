namespace CMS.Presentation
{
    partial class AddTeacherForm
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
            addTeacherBtn = new MaterialSkin.Controls.MaterialButton();
            teacherStatusSwitch = new MaterialSkin.Controls.MaterialSwitch();
            teacherSalaryAmountTxt = new MaterialSkin.Controls.MaterialTextBox2();
            teacherPhoneTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            teacherHiredDate = new DateTimePicker();
            teacherLastNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            teacherFirstNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            specializationComboBox = new MaterialSkin.Controls.MaterialComboBox();
            teacherSalaryTypeComboBox = new MaterialSkin.Controls.MaterialComboBox();
            SuspendLayout();
            // 
            // addTeacherBtn
            // 
            addTeacherBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addTeacherBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addTeacherBtn.Depth = 0;
            addTeacherBtn.HighEmphasis = true;
            addTeacherBtn.Icon = null;
            addTeacherBtn.Location = new Point(16, 473);
            addTeacherBtn.Margin = new Padding(4, 6, 4, 6);
            addTeacherBtn.MouseState = MaterialSkin.MouseState.HOVER;
            addTeacherBtn.Name = "addTeacherBtn";
            addTeacherBtn.NoAccentTextColor = Color.Empty;
            addTeacherBtn.Size = new Size(138, 36);
            addTeacherBtn.TabIndex = 33;
            addTeacherBtn.Text = "Öğretmen Ekle";
            addTeacherBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addTeacherBtn.UseAccentColor = false;
            addTeacherBtn.UseVisualStyleBackColor = true;
            // 
            // teacherStatusSwitch
            // 
            teacherStatusSwitch.AutoSize = true;
            teacherStatusSwitch.Checked = true;
            teacherStatusSwitch.CheckState = CheckState.Checked;
            teacherStatusSwitch.Depth = 0;
            teacherStatusSwitch.Location = new Point(16, 430);
            teacherStatusSwitch.Margin = new Padding(0);
            teacherStatusSwitch.MouseLocation = new Point(-1, -1);
            teacherStatusSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            teacherStatusSwitch.Name = "teacherStatusSwitch";
            teacherStatusSwitch.Ripple = true;
            teacherStatusSwitch.Size = new Size(164, 37);
            teacherStatusSwitch.TabIndex = 30;
            teacherStatusSwitch.Text = "Aktif Öğretmen";
            teacherStatusSwitch.UseVisualStyleBackColor = true;
            // 
            // teacherSalaryAmountTxt
            // 
            teacherSalaryAmountTxt.AnimateReadOnly = false;
            teacherSalaryAmountTxt.BackgroundImageLayout = ImageLayout.None;
            teacherSalaryAmountTxt.CharacterCasing = CharacterCasing.Normal;
            teacherSalaryAmountTxt.Depth = 0;
            teacherSalaryAmountTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            teacherSalaryAmountTxt.HideSelection = true;
            teacherSalaryAmountTxt.Hint = "Maaş Miktarı";
            teacherSalaryAmountTxt.LeadingIcon = null;
            teacherSalaryAmountTxt.Location = new Point(16, 270);
            teacherSalaryAmountTxt.MaxLength = 32767;
            teacherSalaryAmountTxt.MouseState = MaterialSkin.MouseState.OUT;
            teacherSalaryAmountTxt.Name = "teacherSalaryAmountTxt";
            teacherSalaryAmountTxt.PasswordChar = '\0';
            teacherSalaryAmountTxt.PrefixSuffixText = null;
            teacherSalaryAmountTxt.ReadOnly = false;
            teacherSalaryAmountTxt.RightToLeft = RightToLeft.No;
            teacherSalaryAmountTxt.SelectedText = "";
            teacherSalaryAmountTxt.SelectionLength = 0;
            teacherSalaryAmountTxt.SelectionStart = 0;
            teacherSalaryAmountTxt.ShortcutsEnabled = true;
            teacherSalaryAmountTxt.Size = new Size(250, 48);
            teacherSalaryAmountTxt.TabIndex = 25;
            teacherSalaryAmountTxt.TabStop = false;
            teacherSalaryAmountTxt.TextAlign = HorizontalAlignment.Left;
            teacherSalaryAmountTxt.TrailingIcon = null;
            teacherSalaryAmountTxt.UseSystemPasswordChar = false;
            // 
            // teacherPhoneTxt
            // 
            teacherPhoneTxt.AllowPromptAsInput = true;
            teacherPhoneTxt.AnimateReadOnly = false;
            teacherPhoneTxt.AsciiOnly = false;
            teacherPhoneTxt.BackgroundImageLayout = ImageLayout.None;
            teacherPhoneTxt.BeepOnError = false;
            teacherPhoneTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            teacherPhoneTxt.Depth = 0;
            teacherPhoneTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            teacherPhoneTxt.HidePromptOnLeave = false;
            teacherPhoneTxt.HideSelection = true;
            teacherPhoneTxt.Hint = "Telefon Numarası";
            teacherPhoneTxt.InsertKeyMode = InsertKeyMode.Default;
            teacherPhoneTxt.LeadingIcon = null;
            teacherPhoneTxt.Location = new Point(16, 187);
            teacherPhoneTxt.Mask = "(999) 000-0000";
            teacherPhoneTxt.MaxLength = 32767;
            teacherPhoneTxt.MouseState = MaterialSkin.MouseState.OUT;
            teacherPhoneTxt.Name = "teacherPhoneTxt";
            teacherPhoneTxt.PasswordChar = '\0';
            teacherPhoneTxt.PrefixSuffixText = null;
            teacherPhoneTxt.PromptChar = '_';
            teacherPhoneTxt.ReadOnly = false;
            teacherPhoneTxt.RejectInputOnFirstFailure = false;
            teacherPhoneTxt.ResetOnPrompt = true;
            teacherPhoneTxt.ResetOnSpace = true;
            teacherPhoneTxt.RightToLeft = RightToLeft.No;
            teacherPhoneTxt.SelectedText = "";
            teacherPhoneTxt.SelectionLength = 0;
            teacherPhoneTxt.SelectionStart = 0;
            teacherPhoneTxt.ShortcutsEnabled = true;
            teacherPhoneTxt.Size = new Size(250, 48);
            teacherPhoneTxt.SkipLiterals = true;
            teacherPhoneTxt.TabIndex = 24;
            teacherPhoneTxt.TabStop = false;
            teacherPhoneTxt.Text = "(   )    -";
            teacherPhoneTxt.TextAlign = HorizontalAlignment.Left;
            teacherPhoneTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            teacherPhoneTxt.TrailingIcon = null;
            teacherPhoneTxt.UseSystemPasswordChar = false;
            teacherPhoneTxt.ValidatingType = null;
            // 
            // teacherHiredDate
            // 
            teacherHiredDate.CalendarMonthBackground = Color.FromArgb(64, 64, 64);
            teacherHiredDate.Location = new Point(16, 241);
            teacherHiredDate.Name = "teacherHiredDate";
            teacherHiredDate.Size = new Size(250, 23);
            teacherHiredDate.TabIndex = 23;
            // 
            // teacherLastNameTxt
            // 
            teacherLastNameTxt.AnimateReadOnly = false;
            teacherLastNameTxt.BackgroundImageLayout = ImageLayout.None;
            teacherLastNameTxt.CharacterCasing = CharacterCasing.Normal;
            teacherLastNameTxt.Depth = 0;
            teacherLastNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            teacherLastNameTxt.HideSelection = true;
            teacherLastNameTxt.Hint = "Öğretmen Soyadı";
            teacherLastNameTxt.LeadingIcon = null;
            teacherLastNameTxt.Location = new Point(16, 133);
            teacherLastNameTxt.MaxLength = 32767;
            teacherLastNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            teacherLastNameTxt.Name = "teacherLastNameTxt";
            teacherLastNameTxt.PasswordChar = '\0';
            teacherLastNameTxt.PrefixSuffixText = null;
            teacherLastNameTxt.ReadOnly = false;
            teacherLastNameTxt.RightToLeft = RightToLeft.No;
            teacherLastNameTxt.SelectedText = "";
            teacherLastNameTxt.SelectionLength = 0;
            teacherLastNameTxt.SelectionStart = 0;
            teacherLastNameTxt.ShortcutsEnabled = true;
            teacherLastNameTxt.Size = new Size(250, 48);
            teacherLastNameTxt.TabIndex = 20;
            teacherLastNameTxt.TabStop = false;
            teacherLastNameTxt.TextAlign = HorizontalAlignment.Left;
            teacherLastNameTxt.TrailingIcon = null;
            teacherLastNameTxt.UseSystemPasswordChar = false;
            // 
            // teacherFirstNameTxt
            // 
            teacherFirstNameTxt.AnimateReadOnly = false;
            teacherFirstNameTxt.BackgroundImageLayout = ImageLayout.None;
            teacherFirstNameTxt.CharacterCasing = CharacterCasing.Normal;
            teacherFirstNameTxt.Depth = 0;
            teacherFirstNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            teacherFirstNameTxt.HideSelection = true;
            teacherFirstNameTxt.Hint = "Öğretmen Adı";
            teacherFirstNameTxt.LeadingIcon = null;
            teacherFirstNameTxt.Location = new Point(16, 79);
            teacherFirstNameTxt.MaxLength = 32767;
            teacherFirstNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            teacherFirstNameTxt.Name = "teacherFirstNameTxt";
            teacherFirstNameTxt.PasswordChar = '\0';
            teacherFirstNameTxt.PrefixSuffixText = null;
            teacherFirstNameTxt.ReadOnly = false;
            teacherFirstNameTxt.RightToLeft = RightToLeft.No;
            teacherFirstNameTxt.SelectedText = "";
            teacherFirstNameTxt.SelectionLength = 0;
            teacherFirstNameTxt.SelectionStart = 0;
            teacherFirstNameTxt.ShortcutsEnabled = true;
            teacherFirstNameTxt.Size = new Size(250, 48);
            teacherFirstNameTxt.TabIndex = 19;
            teacherFirstNameTxt.TabStop = false;
            teacherFirstNameTxt.TextAlign = HorizontalAlignment.Left;
            teacherFirstNameTxt.TrailingIcon = null;
            teacherFirstNameTxt.UseSystemPasswordChar = false;
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
            specializationComboBox.Hint = "Uzmanlık Alanı";
            specializationComboBox.IntegralHeight = false;
            specializationComboBox.ItemHeight = 43;
            specializationComboBox.Items.AddRange(new object[] { "Aylık Maaş", "Saatlik Ücret", "Ders Başına Ücret" });
            specializationComboBox.Location = new Point(16, 378);
            specializationComboBox.MaxDropDownItems = 4;
            specializationComboBox.MouseState = MaterialSkin.MouseState.OUT;
            specializationComboBox.Name = "specializationComboBox";
            specializationComboBox.Size = new Size(250, 49);
            specializationComboBox.StartIndex = 0;
            specializationComboBox.TabIndex = 34;
            // 
            // teacherSalaryTypeComboBox
            // 
            teacherSalaryTypeComboBox.AutoResize = false;
            teacherSalaryTypeComboBox.BackColor = Color.FromArgb(255, 255, 255);
            teacherSalaryTypeComboBox.Depth = 0;
            teacherSalaryTypeComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            teacherSalaryTypeComboBox.DropDownHeight = 174;
            teacherSalaryTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            teacherSalaryTypeComboBox.DropDownWidth = 121;
            teacherSalaryTypeComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            teacherSalaryTypeComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            teacherSalaryTypeComboBox.FormattingEnabled = true;
            teacherSalaryTypeComboBox.Hint = "Maaş Tipi";
            teacherSalaryTypeComboBox.IntegralHeight = false;
            teacherSalaryTypeComboBox.ItemHeight = 43;
            teacherSalaryTypeComboBox.Items.AddRange(new object[] { "Aylık Maaş", "Saatlik Ücret", "Ders Başına Ücret" });
            teacherSalaryTypeComboBox.Location = new Point(16, 324);
            teacherSalaryTypeComboBox.MaxDropDownItems = 4;
            teacherSalaryTypeComboBox.MouseState = MaterialSkin.MouseState.OUT;
            teacherSalaryTypeComboBox.Name = "teacherSalaryTypeComboBox";
            teacherSalaryTypeComboBox.Size = new Size(250, 49);
            teacherSalaryTypeComboBox.StartIndex = 0;
            teacherSalaryTypeComboBox.TabIndex = 35;
            // 
            // AddTeacherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 523);
            Controls.Add(teacherSalaryTypeComboBox);
            Controls.Add(specializationComboBox);
            Controls.Add(addTeacherBtn);
            Controls.Add(teacherStatusSwitch);
            Controls.Add(teacherSalaryAmountTxt);
            Controls.Add(teacherPhoneTxt);
            Controls.Add(teacherHiredDate);
            Controls.Add(teacherLastNameTxt);
            Controls.Add(teacherFirstNameTxt);
            MaximizeBox = false;
            Name = "AddTeacherForm";
            Text = "Öğretmen Ekle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton addTeacherBtn;
        private MaterialSkin.Controls.MaterialSwitch teacherStatusSwitch;
        private MaterialSkin.Controls.MaterialTextBox2 teacherSalaryAmountTxt;
        private MaterialSkin.Controls.MaterialMaskedTextBox teacherPhoneTxt;
        private DateTimePicker teacherHiredDate;
        private MaterialSkin.Controls.MaterialTextBox2 teacherLastNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 teacherFirstNameTxt;
        private MaterialSkin.Controls.MaterialComboBox specializationComboBox;
        private MaterialSkin.Controls.MaterialComboBox teacherSalaryTypeComboBox;
    }
}