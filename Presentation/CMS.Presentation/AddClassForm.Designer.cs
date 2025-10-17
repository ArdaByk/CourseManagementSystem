namespace CMS.Presentation
{
    partial class AddClassForm
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
            classNameTxt = new MaterialSkin.Controls.MaterialTextBox2();
            capacityTxt = new MaterialSkin.Controls.MaterialTextBox2();
            locationTxt = new MaterialSkin.Controls.MaterialTextBox2();
            addClassBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // classNameTxt
            // 
            classNameTxt.AnimateReadOnly = false;
            classNameTxt.BackgroundImageLayout = ImageLayout.None;
            classNameTxt.CharacterCasing = CharacterCasing.Normal;
            classNameTxt.Depth = 0;
            classNameTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            classNameTxt.HideSelection = true;
            classNameTxt.Hint = "Sınıf Adı";
            classNameTxt.LeadingIcon = null;
            classNameTxt.Location = new Point(9, 77);
            classNameTxt.MaxLength = 32767;
            classNameTxt.MouseState = MaterialSkin.MouseState.OUT;
            classNameTxt.Name = "classNameTxt";
            classNameTxt.PasswordChar = '\0';
            classNameTxt.PrefixSuffixText = null;
            classNameTxt.ReadOnly = false;
            classNameTxt.RightToLeft = RightToLeft.No;
            classNameTxt.SelectedText = "";
            classNameTxt.SelectionLength = 0;
            classNameTxt.SelectionStart = 0;
            classNameTxt.ShortcutsEnabled = true;
            classNameTxt.Size = new Size(250, 48);
            classNameTxt.TabIndex = 0;
            classNameTxt.TabStop = false;
            classNameTxt.TextAlign = HorizontalAlignment.Left;
            classNameTxt.TrailingIcon = null;
            classNameTxt.UseSystemPasswordChar = false;
            // 
            // capacityTxt
            // 
            capacityTxt.AnimateReadOnly = false;
            capacityTxt.BackgroundImageLayout = ImageLayout.None;
            capacityTxt.CharacterCasing = CharacterCasing.Normal;
            capacityTxt.Depth = 0;
            capacityTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            capacityTxt.HideSelection = true;
            capacityTxt.Hint = "Sınıf Kapasitesi";
            capacityTxt.LeadingIcon = null;
            capacityTxt.Location = new Point(9, 131);
            capacityTxt.MaxLength = 32767;
            capacityTxt.MouseState = MaterialSkin.MouseState.OUT;
            capacityTxt.Name = "capacityTxt";
            capacityTxt.PasswordChar = '\0';
            capacityTxt.PrefixSuffixText = null;
            capacityTxt.ReadOnly = false;
            capacityTxt.RightToLeft = RightToLeft.No;
            capacityTxt.SelectedText = "";
            capacityTxt.SelectionLength = 0;
            capacityTxt.SelectionStart = 0;
            capacityTxt.ShortcutsEnabled = true;
            capacityTxt.Size = new Size(250, 48);
            capacityTxt.TabIndex = 1;
            capacityTxt.TabStop = false;
            capacityTxt.TextAlign = HorizontalAlignment.Left;
            capacityTxt.TrailingIcon = null;
            capacityTxt.UseSystemPasswordChar = false;
            // 
            // locationTxt
            // 
            locationTxt.AnimateReadOnly = false;
            locationTxt.BackgroundImageLayout = ImageLayout.None;
            locationTxt.CharacterCasing = CharacterCasing.Normal;
            locationTxt.Depth = 0;
            locationTxt.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            locationTxt.HideSelection = true;
            locationTxt.Hint = "Sınıf Konumu";
            locationTxt.LeadingIcon = null;
            locationTxt.Location = new Point(7, 185);
            locationTxt.MaxLength = 32767;
            locationTxt.MouseState = MaterialSkin.MouseState.OUT;
            locationTxt.Name = "locationTxt";
            locationTxt.PasswordChar = '\0';
            locationTxt.PrefixSuffixText = null;
            locationTxt.ReadOnly = false;
            locationTxt.RightToLeft = RightToLeft.No;
            locationTxt.SelectedText = "";
            locationTxt.SelectionLength = 0;
            locationTxt.SelectionStart = 0;
            locationTxt.ShortcutsEnabled = true;
            locationTxt.Size = new Size(250, 48);
            locationTxt.TabIndex = 2;
            locationTxt.TabStop = false;
            locationTxt.TextAlign = HorizontalAlignment.Left;
            locationTxt.TrailingIcon = null;
            locationTxt.UseSystemPasswordChar = false;
            // 
            // addClassBtn
            // 
            addClassBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addClassBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addClassBtn.Depth = 0;
            addClassBtn.HighEmphasis = true;
            addClassBtn.Icon = null;
            addClassBtn.Location = new Point(6, 242);
            addClassBtn.Margin = new Padding(4, 6, 4, 6);
            addClassBtn.MouseState = MaterialSkin.MouseState.HOVER;
            addClassBtn.Name = "addClassBtn";
            addClassBtn.NoAccentTextColor = Color.Empty;
            addClassBtn.Size = new Size(99, 36);
            addClassBtn.TabIndex = 3;
            addClassBtn.Text = "Sınıfı Ekle";
            addClassBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addClassBtn.UseAccentColor = false;
            addClassBtn.UseVisualStyleBackColor = true;
            addClassBtn.Click += addClassBtn_Click;
            // 
            // AddClassForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(268, 307);
            Controls.Add(addClassBtn);
            Controls.Add(locationTxt);
            Controls.Add(capacityTxt);
            Controls.Add(classNameTxt);
            MaximizeBox = false;
            Name = "AddClassForm";
            Text = "Sınıf Ekle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 classNameTxt;
        private MaterialSkin.Controls.MaterialTextBox2 capacityTxt;
        private MaterialSkin.Controls.MaterialTextBox2 locationTxt;
        private MaterialSkin.Controls.MaterialButton addClassBtn;
    }
}