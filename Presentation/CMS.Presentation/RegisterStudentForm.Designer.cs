namespace CMS.Presentation
{
    partial class RegisterStudentForm
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
            registeredDate = new DateTimePicker();
            completionDate = new DateTimePicker();
            nationalIDTxt = new MaterialSkin.Controls.MaterialTextBox2();
            courseComboBox = new MaterialSkin.Controls.MaterialComboBox();
            courseGroupComboBox = new MaterialSkin.Controls.MaterialComboBox();
            registerStudentBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // registeredDate
            // 
            registeredDate.Location = new Point(9, 76);
            registeredDate.Name = "registeredDate";
            registeredDate.Size = new Size(250, 23);
            registeredDate.TabIndex = 0;
            // 
            // completionDate
            // 
            completionDate.Location = new Point(9, 105);
            completionDate.Name = "completionDate";
            completionDate.Size = new Size(250, 23);
            completionDate.TabIndex = 1;
            // 
            // nationalIDTxt
            // 
            nationalIDTxt.AnimateReadOnly = false;
            nationalIDTxt.BackgroundImageLayout = ImageLayout.None;
            nationalIDTxt.CharacterCasing = CharacterCasing.Normal;
            nationalIDTxt.Depth = 0;
            nationalIDTxt.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            nationalIDTxt.HideSelection = true;
            nationalIDTxt.Hint = "TC Kimlik NO";
            nationalIDTxt.LeadingIcon = null;
            nationalIDTxt.Location = new Point(9, 134);
            nationalIDTxt.MaxLength = 32767;
            nationalIDTxt.MouseState = MaterialSkin.MouseState.OUT;
            nationalIDTxt.Name = "nationalIDTxt";
            nationalIDTxt.PasswordChar = '\0';
            nationalIDTxt.PrefixSuffixText = null;
            nationalIDTxt.ReadOnly = false;
            nationalIDTxt.RightToLeft = RightToLeft.No;
            nationalIDTxt.SelectedText = "";
            nationalIDTxt.SelectionLength = 0;
            nationalIDTxt.SelectionStart = 0;
            nationalIDTxt.ShortcutsEnabled = true;
            nationalIDTxt.Size = new Size(250, 48);
            nationalIDTxt.TabIndex = 2;
            nationalIDTxt.TabStop = false;
            nationalIDTxt.TextAlign = HorizontalAlignment.Left;
            nationalIDTxt.TrailingIcon = null;
            nationalIDTxt.UseSystemPasswordChar = false;
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
            courseComboBox.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            courseComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            courseComboBox.FormattingEnabled = true;
            courseComboBox.Hint = "Kurs";
            courseComboBox.IntegralHeight = false;
            courseComboBox.ItemHeight = 43;
            courseComboBox.Location = new Point(9, 188);
            courseComboBox.MaxDropDownItems = 4;
            courseComboBox.MouseState = MaterialSkin.MouseState.OUT;
            courseComboBox.Name = "courseComboBox";
            courseComboBox.Size = new Size(250, 49);
            courseComboBox.StartIndex = 0;
            courseComboBox.TabIndex = 3;
            // 
            // courseGroupComboBox
            // 
            courseGroupComboBox.AutoResize = false;
            courseGroupComboBox.BackColor = Color.FromArgb(255, 255, 255);
            courseGroupComboBox.Depth = 0;
            courseGroupComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            courseGroupComboBox.DropDownHeight = 174;
            courseGroupComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            courseGroupComboBox.DropDownWidth = 121;
            courseGroupComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            courseGroupComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            courseGroupComboBox.FormattingEnabled = true;
            courseGroupComboBox.Hint = "Kurs Grubu";
            courseGroupComboBox.IntegralHeight = false;
            courseGroupComboBox.ItemHeight = 43;
            courseGroupComboBox.Location = new Point(9, 243);
            courseGroupComboBox.MaxDropDownItems = 4;
            courseGroupComboBox.MouseState = MaterialSkin.MouseState.OUT;
            courseGroupComboBox.Name = "courseGroupComboBox";
            courseGroupComboBox.Size = new Size(250, 49);
            courseGroupComboBox.StartIndex = 0;
            courseGroupComboBox.TabIndex = 4;
            // 
            // registerStudentBtn
            // 
            registerStudentBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            registerStudentBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            registerStudentBtn.Depth = 0;
            registerStudentBtn.HighEmphasis = true;
            registerStudentBtn.Icon = null;
            registerStudentBtn.Location = new Point(9, 301);
            registerStudentBtn.Margin = new Padding(4, 6, 4, 6);
            registerStudentBtn.MouseState = MaterialSkin.MouseState.HOVER;
            registerStudentBtn.Name = "registerStudentBtn";
            registerStudentBtn.NoAccentTextColor = Color.Empty;
            registerStudentBtn.Size = new Size(76, 36);
            registerStudentBtn.TabIndex = 5;
            registerStudentBtn.Text = "Kaydet";
            registerStudentBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            registerStudentBtn.UseAccentColor = false;
            registerStudentBtn.UseVisualStyleBackColor = true;
            // 
            // RegisterStudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 350);
            Controls.Add(registerStudentBtn);
            Controls.Add(courseGroupComboBox);
            Controls.Add(courseComboBox);
            Controls.Add(nationalIDTxt);
            Controls.Add(completionDate);
            Controls.Add(registeredDate);
            MaximizeBox = false;
            Name = "RegisterStudentForm";
            Text = "Öğrenci Kaydı";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker registeredDate;
        private DateTimePicker completionDate;
        private MaterialSkin.Controls.MaterialTextBox2 nationalIDTxt;
        private MaterialSkin.Controls.MaterialComboBox courseComboBox;
        private MaterialSkin.Controls.MaterialComboBox courseGroupComboBox;
        private MaterialSkin.Controls.MaterialButton registerStudentBtn;
    }
}