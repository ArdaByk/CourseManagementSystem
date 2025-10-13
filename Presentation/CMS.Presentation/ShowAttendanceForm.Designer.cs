namespace CMS.Presentation
{
    partial class ShowAttendanceForm
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
            mainPanel = new Panel();
            dateGroupBox = new GroupBox();
            studentsPanel = new Panel();
            saveAttendanceBtn = new MaterialSkin.Controls.MaterialButton();
            mainPanel.SuspendLayout();
            dateGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.Controls.Add(dateGroupBox);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(3, 64);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1231, 817);
            mainPanel.TabIndex = 0;
            // 
            // dateGroupBox
            // 
            dateGroupBox.Controls.Add(studentsPanel);
            dateGroupBox.Location = new Point(12, 14);
            dateGroupBox.Name = "dateGroupBox";
            dateGroupBox.Size = new Size(1206, 282);
            dateGroupBox.TabIndex = 0;
            dateGroupBox.TabStop = false;
            dateGroupBox.Text = "xxxx Tarihli Yoklama";
            // 
            // studentsPanel
            // 
            studentsPanel.Dock = DockStyle.Fill;
            studentsPanel.Location = new Point(3, 19);
            studentsPanel.Name = "studentsPanel";
            studentsPanel.Size = new Size(1200, 260);
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
            saveAttendanceBtn.Location = new Point(3, 845);
            saveAttendanceBtn.Margin = new Padding(4, 6, 4, 6);
            saveAttendanceBtn.MouseState = MaterialSkin.MouseState.HOVER;
            saveAttendanceBtn.Name = "saveAttendanceBtn";
            saveAttendanceBtn.NoAccentTextColor = Color.Empty;
            saveAttendanceBtn.Size = new Size(1231, 36);
            saveAttendanceBtn.TabIndex = 1;
            saveAttendanceBtn.Text = "Yoklamayı Kaydet";
            saveAttendanceBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            saveAttendanceBtn.UseAccentColor = false;
            saveAttendanceBtn.UseVisualStyleBackColor = true;
            // 
            // ShowAttendanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 884);
            Controls.Add(saveAttendanceBtn);
            Controls.Add(mainPanel);
            MaximizeBox = false;
            Name = "ShowAttendanceForm";
            Text = "Yoklama Kayıtları";
            Load += ShowAttendanceForm_Load;
            mainPanel.ResumeLayout(false);
            dateGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel mainPanel;
        private GroupBox dateGroupBox;
        private MaterialSkin.Controls.MaterialButton saveAttendanceBtn;
        private Panel studentsPanel;
    }
}