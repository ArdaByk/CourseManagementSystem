namespace CMS.Presentation
{
    partial class UpdateSpecializationForm
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
            updateSpecializationBtn = new MaterialSkin.Controls.MaterialButton();
            specializationNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            SuspendLayout();
            // 
            // updateSpecializationBtn
            // 
            updateSpecializationBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            updateSpecializationBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            updateSpecializationBtn.Depth = 0;
            updateSpecializationBtn.HighEmphasis = true;
            updateSpecializationBtn.Icon = null;
            updateSpecializationBtn.Location = new Point(9, 130);
            updateSpecializationBtn.Margin = new Padding(4, 6, 4, 6);
            updateSpecializationBtn.MouseState = MaterialSkin.MouseState.HOVER;
            updateSpecializationBtn.Name = "updateSpecializationBtn";
            updateSpecializationBtn.NoAccentTextColor = Color.Empty;
            updateSpecializationBtn.Size = new Size(76, 36);
            updateSpecializationBtn.TabIndex = 3;
            updateSpecializationBtn.Text = "Kaydet";
            updateSpecializationBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            updateSpecializationBtn.UseAccentColor = false;
            updateSpecializationBtn.UseVisualStyleBackColor = true;
            updateSpecializationBtn.Click += updateSpecializationBtn_Click;
            // 
            // specializationNameTxt
            // 
            specializationNameTxt.AnimateReadOnly = false;
            specializationNameTxt.BackgroundImageLayout = ImageLayout.None;
            specializationNameTxt.CharacterCasing = CharacterCasing.Normal;
            specializationNameTxt.Depth = 0;
            specializationNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            specializationNameTxt.HideSelection = true;
            specializationNameTxt.Hint = "Uzmanlık Alanı Adı";
            specializationNameTxt.LeadingIcon = null;
            specializationNameTxt.Location = new Point(9, 73);
            specializationNameTxt.MaxLength = 32767;
            specializationNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            specializationNameTxt.Name = "specializationNameTxt";
            specializationNameTxt.PasswordChar = '\0';
            specializationNameTxt.PrefixSuffixText = null;
            specializationNameTxt.ReadOnly = false;
            specializationNameTxt.RightToLeft = RightToLeft.No;
            specializationNameTxt.SelectedText = "";
            specializationNameTxt.SelectionLength = 0;
            specializationNameTxt.SelectionStart = 0;
            specializationNameTxt.ShortcutsEnabled = true;
            specializationNameTxt.Size = new Size(250, 48);
            specializationNameTxt.TabIndex = 2;
            specializationNameTxt.TabStop = false;
            specializationNameTxt.TextAlign = HorizontalAlignment.Left;
            specializationNameTxt.TrailingIcon = null;
            specializationNameTxt.UseSystemPasswordChar = false;
            // 
            // UpdateSpecializationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(268, 176);
            Controls.Add(updateSpecializationBtn);
            Controls.Add(specializationNameTxt);
            MaximizeBox = false;
            Name = "UpdateSpecializationForm";
            Text = "Uzmanlık Alanı Güncelle";
            Load += UpdateSpecializationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton updateSpecializationBtn;
        private MaterialSkin.Controls.MaterialTextBox2 specializationNameTxt;
    }
}