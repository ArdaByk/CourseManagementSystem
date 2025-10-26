namespace CMS.Presentation
{
    partial class UpdateTeacherForm
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
            teacherSalaryTypeComboBox = new MaterialSkin.Controls.MaterialComboBox();
            updateTeacherBtn = new MaterialSkin.Controls.MaterialButton();
            teacherStatusSwitch = new MaterialSkin.Controls.MaterialSwitch();
            teacherSalaryAmountTxt = new MaterialSkin.Controls.MaterialTextBox2();
            teacherPhoneTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            teacherHiredDate = new DateTimePicker();
            teacherLastNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            teacherFirstNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            teacherEmailTxt = new MaterialSkin.Controls.MaterialTextBox2();
            specializationCheckedListBox = new MaterialSkin.Controls.MaterialCheckedListBox();
            SuspendLayout();
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
            teacherSalaryTypeComboBox.Items.AddRange(new object[] { "Aylık Maaş", "Saatlik Ücret" });
            teacherSalaryTypeComboBox.Location = new Point(14, 375);
            teacherSalaryTypeComboBox.MaxDropDownItems = 4;
            teacherSalaryTypeComboBox.MouseState = MaterialSkin.MouseState.OUT;
            teacherSalaryTypeComboBox.Name = "teacherSalaryTypeComboBox";
            teacherSalaryTypeComboBox.Size = new Size(250, 49);
            teacherSalaryTypeComboBox.StartIndex = 0;
            teacherSalaryTypeComboBox.TabIndex = 44;
            // 
            // updateTeacherBtn
            // 
            updateTeacherBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            updateTeacherBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            updateTeacherBtn.Depth = 0;
            updateTeacherBtn.HighEmphasis = true;
            updateTeacherBtn.Icon = null;
            updateTeacherBtn.Location = new Point(14, 577);
            updateTeacherBtn.Margin = new Padding(4, 6, 4, 6);
            updateTeacherBtn.MouseState = MaterialSkin.MouseState.HOVER;
            updateTeacherBtn.Name = "updateTeacherBtn";
            updateTeacherBtn.NoAccentTextColor = Color.Empty;
            updateTeacherBtn.Size = new Size(76, 36);
            updateTeacherBtn.TabIndex = 42;
            updateTeacherBtn.Text = "Kaydet";
            updateTeacherBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            updateTeacherBtn.UseAccentColor = false;
            updateTeacherBtn.UseVisualStyleBackColor = true;
            updateTeacherBtn.Click += updateTeacherBtn_Click;
            // 
            // teacherStatusSwitch
            // 
            teacherStatusSwitch.AutoSize = true;
            teacherStatusSwitch.Checked = true;
            teacherStatusSwitch.CheckState = CheckState.Checked;
            teacherStatusSwitch.Depth = 0;
            teacherStatusSwitch.Location = new Point(14, 534);
            teacherStatusSwitch.Margin = new Padding(0);
            teacherStatusSwitch.MouseLocation = new Point(-1, -1);
            teacherStatusSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            teacherStatusSwitch.Name = "teacherStatusSwitch";
            teacherStatusSwitch.Ripple = true;
            teacherStatusSwitch.Size = new Size(164, 37);
            teacherStatusSwitch.TabIndex = 41;
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
            teacherSalaryAmountTxt.Location = new Point(14, 321);
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
            teacherSalaryAmountTxt.TabIndex = 40;
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
            teacherPhoneTxt.Location = new Point(14, 183);
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
            teacherPhoneTxt.TabIndex = 39;
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
            teacherHiredDate.Location = new Point(14, 292);
            teacherHiredDate.Name = "teacherHiredDate";
            teacherHiredDate.Size = new Size(250, 23);
            teacherHiredDate.TabIndex = 38;
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
            teacherLastNameTxt.Location = new Point(14, 129);
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
            teacherLastNameTxt.TabIndex = 37;
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
            teacherFirstNameTxt.Location = new Point(14, 75);
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
            teacherFirstNameTxt.TabIndex = 36;
            teacherFirstNameTxt.TabStop = false;
            teacherFirstNameTxt.TextAlign = HorizontalAlignment.Left;
            teacherFirstNameTxt.TrailingIcon = null;
            teacherFirstNameTxt.UseSystemPasswordChar = false;
            // 
            // teacherEmailTxt
            // 
            teacherEmailTxt.AnimateReadOnly = false;
            teacherEmailTxt.BackgroundImageLayout = ImageLayout.None;
            teacherEmailTxt.CharacterCasing = CharacterCasing.Normal;
            teacherEmailTxt.Depth = 0;
            teacherEmailTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            teacherEmailTxt.HideSelection = true;
            teacherEmailTxt.Hint = "E-Posta";
            teacherEmailTxt.LeadingIcon = null;
            teacherEmailTxt.Location = new Point(14, 237);
            teacherEmailTxt.MaxLength = 32767;
            teacherEmailTxt.MouseState = MaterialSkin.MouseState.OUT;
            teacherEmailTxt.Name = "teacherEmailTxt";
            teacherEmailTxt.PasswordChar = '\0';
            teacherEmailTxt.PrefixSuffixText = null;
            teacherEmailTxt.ReadOnly = false;
            teacherEmailTxt.RightToLeft = RightToLeft.No;
            teacherEmailTxt.SelectedText = "";
            teacherEmailTxt.SelectionLength = 0;
            teacherEmailTxt.SelectionStart = 0;
            teacherEmailTxt.ShortcutsEnabled = true;
            teacherEmailTxt.Size = new Size(250, 48);
            teacherEmailTxt.TabIndex = 45;
            teacherEmailTxt.TabStop = false;
            teacherEmailTxt.TextAlign = HorizontalAlignment.Left;
            teacherEmailTxt.TrailingIcon = null;
            teacherEmailTxt.UseSystemPasswordChar = false;
            // 
            // specializationCheckedListBox
            // 
            specializationCheckedListBox.AutoScroll = true;
            specializationCheckedListBox.BackColor = SystemColors.Control;
            specializationCheckedListBox.Depth = 0;
            specializationCheckedListBox.Location = new Point(14, 430);
            specializationCheckedListBox.MouseState = MaterialSkin.MouseState.HOVER;
            specializationCheckedListBox.Name = "specializationCheckedListBox";
            specializationCheckedListBox.Size = new Size(250, 100);
            specializationCheckedListBox.Striped = false;
            specializationCheckedListBox.StripeDarkColor = Color.Empty;
            specializationCheckedListBox.TabIndex = 46;
            // 
            // UpdateTeacherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 632);
            Controls.Add(specializationCheckedListBox);
            Controls.Add(teacherEmailTxt);
            Controls.Add(teacherSalaryTypeComboBox);
            Controls.Add(updateTeacherBtn);
            Controls.Add(teacherStatusSwitch);
            Controls.Add(teacherSalaryAmountTxt);
            Controls.Add(teacherPhoneTxt);
            Controls.Add(teacherHiredDate);
            Controls.Add(teacherLastNameTxt);
            Controls.Add(teacherFirstNameTxt);
            MaximizeBox = false;
            Name = "UpdateTeacherForm";
            Text = "Öğretmen Güncelle";
            Load += UpdateTeacherForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox teacherSalaryTypeComboBox;
        private MaterialSkin.Controls.MaterialButton updateTeacherBtn;
        private MaterialSkin.Controls.MaterialSwitch teacherStatusSwitch;
        private MaterialSkin.Controls.MaterialTextBox2 teacherSalaryAmountTxt;
        private MaterialSkin.Controls.MaterialMaskedTextBox teacherPhoneTxt;
        private DateTimePicker teacherHiredDate;
        private MaterialSkin.Controls.MaterialTextBox2 teacherLastNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 teacherFirstNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 teacherEmailTxt;
        private MaterialSkin.Controls.MaterialCheckedListBox specializationCheckedListBox;
    }
}