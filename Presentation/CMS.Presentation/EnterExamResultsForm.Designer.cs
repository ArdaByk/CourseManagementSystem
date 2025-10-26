namespace CMS.Presentation
{
    partial class EnterExamResultsForm
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
            examResultsPanel = new Panel();
            saveResultsBtn = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // examResultsPanel
            // 
            examResultsPanel.Dock = DockStyle.Fill;
            examResultsPanel.Location = new Point(3, 64);
            examResultsPanel.Name = "examResultsPanel";
            examResultsPanel.Size = new Size(794, 383);
            examResultsPanel.TabIndex = 0;
            // 
            // saveResultsBtn
            // 
            saveResultsBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            saveResultsBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            saveResultsBtn.Depth = 0;
            saveResultsBtn.Dock = DockStyle.Bottom;
            saveResultsBtn.HighEmphasis = true;
            saveResultsBtn.Icon = null;
            saveResultsBtn.Location = new Point(3, 411);
            saveResultsBtn.Margin = new Padding(4, 6, 4, 6);
            saveResultsBtn.MouseState = MaterialSkin.MouseState.HOVER;
            saveResultsBtn.Name = "saveResultsBtn";
            saveResultsBtn.NoAccentTextColor = Color.Empty;
            saveResultsBtn.Size = new Size(794, 36);
            saveResultsBtn.TabIndex = 1;
            saveResultsBtn.Text = "Sonuçları Kaydet";
            saveResultsBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            saveResultsBtn.UseAccentColor = false;
            saveResultsBtn.UseVisualStyleBackColor = true;
            saveResultsBtn.Click += saveResultsBtn_Click;
            // 
            // EnterExamResultsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveResultsBtn);
            Controls.Add(examResultsPanel);
            MaximizeBox = false;
            Name = "EnterExamResultsForm";
            Text = "Sınav Sonuçlarını Gir";
            Load += EnterExamResultsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel examResultsPanel;
        private MaterialSkin.Controls.MaterialButton saveResultsBtn;
    }
}