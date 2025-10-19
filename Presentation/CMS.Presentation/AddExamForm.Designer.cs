namespace CMS.Presentation
{
    partial class AddExamForm
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
            examNameTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            maxScoreTxt = new MaterialSkin.Controls.MaterialMaskedTextBox();
            ExamDate = new DateTimePicker();
            courseComboBox = new MaterialSkin.Controls.MaterialComboBox();
            createExamBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // examNameTxt
            // 
            examNameTxt.AllowPromptAsInput = true;
            examNameTxt.AnimateReadOnly = false;
            examNameTxt.AsciiOnly = false;
            examNameTxt.BackgroundImageLayout = ImageLayout.None;
            examNameTxt.BeepOnError = false;
            examNameTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            examNameTxt.Depth = 0;
            examNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            examNameTxt.HidePromptOnLeave = false;
            examNameTxt.HideSelection = true;
            examNameTxt.Hint = "Sınav Adı";
            examNameTxt.InsertKeyMode = InsertKeyMode.Default;
            examNameTxt.LeadingIcon = null;
            examNameTxt.Location = new Point(9, 75);
            examNameTxt.Mask = "";
            examNameTxt.MaxLength = 32767;
            examNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            examNameTxt.Name = "examNameTxt";
            examNameTxt.PasswordChar = '\0';
            examNameTxt.PrefixSuffixText = null;
            examNameTxt.PromptChar = '_';
            examNameTxt.ReadOnly = false;
            examNameTxt.RejectInputOnFirstFailure = false;
            examNameTxt.ResetOnPrompt = true;
            examNameTxt.ResetOnSpace = true;
            examNameTxt.RightToLeft = RightToLeft.No;
            examNameTxt.SelectedText = "";
            examNameTxt.SelectionLength = 0;
            examNameTxt.SelectionStart = 0;
            examNameTxt.ShortcutsEnabled = true;
            examNameTxt.Size = new Size(250, 48);
            examNameTxt.SkipLiterals = true;
            examNameTxt.TabIndex = 0;
            examNameTxt.TabStop = false;
            examNameTxt.TextAlign = HorizontalAlignment.Left;
            examNameTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            examNameTxt.TrailingIcon = null;
            examNameTxt.UseSystemPasswordChar = false;
            examNameTxt.ValidatingType = null;
            // 
            // maxScoreTxt
            // 
            maxScoreTxt.AllowPromptAsInput = true;
            maxScoreTxt.AnimateReadOnly = false;
            maxScoreTxt.AsciiOnly = false;
            maxScoreTxt.BackgroundImageLayout = ImageLayout.None;
            maxScoreTxt.BeepOnError = false;
            maxScoreTxt.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            maxScoreTxt.Depth = 0;
            maxScoreTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            maxScoreTxt.HidePromptOnLeave = false;
            maxScoreTxt.HideSelection = true;
            maxScoreTxt.Hint = "Maksimum Puan";
            maxScoreTxt.InsertKeyMode = InsertKeyMode.Default;
            maxScoreTxt.LeadingIcon = null;
            maxScoreTxt.Location = new Point(9, 129);
            maxScoreTxt.Mask = "";
            maxScoreTxt.MaxLength = 32767;
            maxScoreTxt.MouseState = MaterialSkin.MouseState.OUT;
            maxScoreTxt.Name = "maxScoreTxt";
            maxScoreTxt.PasswordChar = '\0';
            maxScoreTxt.PrefixSuffixText = null;
            maxScoreTxt.PromptChar = '_';
            maxScoreTxt.ReadOnly = false;
            maxScoreTxt.RejectInputOnFirstFailure = false;
            maxScoreTxt.ResetOnPrompt = true;
            maxScoreTxt.ResetOnSpace = true;
            maxScoreTxt.RightToLeft = RightToLeft.No;
            maxScoreTxt.SelectedText = "";
            maxScoreTxt.SelectionLength = 0;
            maxScoreTxt.SelectionStart = 0;
            maxScoreTxt.ShortcutsEnabled = true;
            maxScoreTxt.Size = new Size(250, 48);
            maxScoreTxt.SkipLiterals = true;
            maxScoreTxt.TabIndex = 1;
            maxScoreTxt.TabStop = false;
            maxScoreTxt.TextAlign = HorizontalAlignment.Left;
            maxScoreTxt.TextMaskFormat = MaskFormat.IncludeLiterals;
            maxScoreTxt.TrailingIcon = null;
            maxScoreTxt.UseSystemPasswordChar = false;
            maxScoreTxt.ValidatingType = null;
            // 
            // ExamDate
            // 
            ExamDate.Location = new Point(9, 238);
            ExamDate.Name = "ExamDate";
            ExamDate.Size = new Size(250, 23);
            ExamDate.TabIndex = 2;
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
            courseComboBox.Location = new Point(9, 183);
            courseComboBox.MaxDropDownItems = 4;
            courseComboBox.MouseState = MaterialSkin.MouseState.OUT;
            courseComboBox.Name = "courseComboBox";
            courseComboBox.Size = new Size(250, 49);
            courseComboBox.StartIndex = 0;
            courseComboBox.TabIndex = 3;
            // 
            // createExamBtn
            // 
            createExamBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            createExamBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            createExamBtn.Depth = 0;
            createExamBtn.HighEmphasis = true;
            createExamBtn.Icon = null;
            createExamBtn.Location = new Point(7, 270);
            createExamBtn.Margin = new Padding(4, 6, 4, 6);
            createExamBtn.MouseState = MaterialSkin.MouseState.HOVER;
            createExamBtn.Name = "createExamBtn";
            createExamBtn.NoAccentTextColor = Color.Empty;
            createExamBtn.Size = new Size(136, 36);
            createExamBtn.TabIndex = 4;
            createExamBtn.Text = "Sınavı Oluştur";
            createExamBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            createExamBtn.UseAccentColor = false;
            createExamBtn.UseVisualStyleBackColor = true;
            createExamBtn.Click += createExamBtn_Click;
            // 
            // AddExamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 327);
            Controls.Add(createExamBtn);
            Controls.Add(courseComboBox);
            Controls.Add(ExamDate);
            Controls.Add(maxScoreTxt);
            Controls.Add(examNameTxt);
            MaximizeBox = false;
            Name = "AddExamForm";
            Text = "Sınav Oluştur";
            Load += AddExamForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialMaskedTextBox examNameTxt;
        private MaterialSkin.Controls.MaterialMaskedTextBox maxScoreTxt;
        private DateTimePicker ExamDate;
        private MaterialSkin.Controls.MaterialComboBox courseComboBox;
        private MaterialSkin.Controls.MaterialButton createExamBtn;
    }
}