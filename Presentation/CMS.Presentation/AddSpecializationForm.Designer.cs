namespace CMS.Presentation
{
    partial class AddSpecializationForm
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
            specializationNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            addSpecializationBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // specializationNameTxt
            // 
            specializationNameTxt.AnimateReadOnly = false;
            specializationNameTxt.BackgroundImageLayout = ImageLayout.None;
            specializationNameTxt.CharacterCasing = CharacterCasing.Normal;
            specializationNameTxt.Depth = 0;
            specializationNameTxt.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            specializationNameTxt.HideSelection = true;
            specializationNameTxt.Hint = "Uzmanlık Alanı Adı";
            specializationNameTxt.LeadingIcon = null;
            specializationNameTxt.Location = new Point(8, 72);
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
            specializationNameTxt.TabIndex = 0;
            specializationNameTxt.TabStop = false;
            specializationNameTxt.TextAlign = HorizontalAlignment.Left;
            specializationNameTxt.TrailingIcon = null;
            specializationNameTxt.UseSystemPasswordChar = false;
            // 
            // addSpecializationBtn
            // 
            addSpecializationBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addSpecializationBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addSpecializationBtn.Depth = 0;
            addSpecializationBtn.HighEmphasis = true;
            addSpecializationBtn.Icon = null;
            addSpecializationBtn.Location = new Point(8, 129);
            addSpecializationBtn.Margin = new Padding(4, 6, 4, 6);
            addSpecializationBtn.MouseState = MaterialSkin.MouseState.HOVER;
            addSpecializationBtn.Name = "addSpecializationBtn";
            addSpecializationBtn.NoAccentTextColor = Color.Empty;
            addSpecializationBtn.Size = new Size(178, 36);
            addSpecializationBtn.TabIndex = 1;
            addSpecializationBtn.Text = "Uzmanlık Alanı Ekle";
            addSpecializationBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addSpecializationBtn.UseAccentColor = false;
            addSpecializationBtn.UseVisualStyleBackColor = true;
            // 
            // AddSpecializationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(268, 176);
            Controls.Add(addSpecializationBtn);
            Controls.Add(specializationNameTxt);
            MaximizeBox = false;
            Name = "AddSpecializationForm";
            Text = "Uzmanlık Alanı Ekle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 specializationNameTxt;
        private MaterialSkin.Controls.MaterialButton addSpecializationBtn;
    }
}