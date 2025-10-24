namespace CMS.Presentation
{
    partial class TakeAttendanceForm
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
            studentsPanel = new Panel();
            saveAttendanceBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // studentsPanel
            // 
            studentsPanel.Dock = DockStyle.Fill;
            studentsPanel.Location = new Point(3, 64);
            studentsPanel.Name = "studentsPanel";
            studentsPanel.Size = new Size(930, 541);
            studentsPanel.TabIndex = 0;
            // 
            // saveAttendanceBtn
            // 
            saveAttendanceBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            saveAttendanceBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            saveAttendanceBtn.Depth = 0;
            saveAttendanceBtn.Dock = DockStyle.Bottom;
            saveAttendanceBtn.HighEmphasis = true;
            saveAttendanceBtn.Icon = null;
            saveAttendanceBtn.Location = new Point(3, 569);
            saveAttendanceBtn.Margin = new Padding(4, 6, 4, 6);
            saveAttendanceBtn.MouseState = MaterialSkin.MouseState.HOVER;
            saveAttendanceBtn.Name = "saveAttendanceBtn";
            saveAttendanceBtn.NoAccentTextColor = Color.Empty;
            saveAttendanceBtn.Size = new Size(930, 36);
            saveAttendanceBtn.TabIndex = 1;
            saveAttendanceBtn.Text = "Yoklamayı Kaydet";
            saveAttendanceBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            saveAttendanceBtn.UseAccentColor = false;
            saveAttendanceBtn.UseVisualStyleBackColor = true;
            saveAttendanceBtn.Click += saveAttendanceBtn_Click;
            // 
            // TakeAttendanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 608);
            Controls.Add(saveAttendanceBtn);
            Controls.Add(studentsPanel);
            MaximizeBox = false;
            Name = "TakeAttendanceForm";
            Text = "Yoklama Ekranı";
            Load += TakeAttendanceForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel studentsPanel;
        private MaterialSkin.Controls.MaterialButton saveAttendanceBtn;
    }
}