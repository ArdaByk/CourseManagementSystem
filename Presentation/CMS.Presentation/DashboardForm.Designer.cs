namespace CMS.Presentation
{
    partial class DashboardForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            dashboard = new TabPage();
            panel1 = new Panel();
            materialFloatingActionButton5 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialFloatingActionButton3 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialFloatingActionButton2 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            label2 = new Label();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialFloatingActionButton7 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            label1 = new Label();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialFloatingActionButton6 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialCard3 = new MaterialSkin.Controls.MaterialCard();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            label3 = new Label();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            label4 = new Label();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            materialFloatingActionButton4 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialCard5 = new MaterialSkin.Controls.MaterialCard();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            label5 = new Label();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            materialCard6 = new MaterialSkin.Controls.MaterialCard();
            materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            label6 = new Label();
            materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            materialCard7 = new MaterialSkin.Controls.MaterialCard();
            logoutBtn = new MaterialSkin.Controls.MaterialButton();
            materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            materialFloatingActionButton1 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            students = new TabPage();
            materialComboBox2 = new MaterialSkin.Controls.MaterialComboBox();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            materialTextBox23 = new MaterialSkin.Controls.MaterialTextBox2();
            materialTextBox22 = new MaterialSkin.Controls.MaterialTextBox2();
            materialTextBox21 = new MaterialSkin.Controls.MaterialTextBox2();
            flowLayoutPanelStudents = new FlowLayoutPanel();
            teachers = new TabPage();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialTextBox24 = new MaterialSkin.Controls.MaterialTextBox2();
            materialTextBox25 = new MaterialSkin.Controls.MaterialTextBox2();
            materialTextBox26 = new MaterialSkin.Controls.MaterialTextBox2();
            flowLayoutPanelTeachers = new FlowLayoutPanel();
            courses = new TabPage();
            courseGroups = new TabPage();
            classes = new TabPage();
            exams = new TabPage();
            specializations = new TabPage();
            users = new TabPage();
            roles = new TabPage();
            imageList1 = new ImageList(components);
            materialTabControl1.SuspendLayout();
            dashboard.SuspendLayout();
            panel1.SuspendLayout();
            materialCard2.SuspendLayout();
            materialCard1.SuspendLayout();
            materialCard3.SuspendLayout();
            materialCard4.SuspendLayout();
            materialCard5.SuspendLayout();
            materialCard6.SuspendLayout();
            materialCard7.SuspendLayout();
            students.SuspendLayout();
            teachers.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(dashboard);
            materialTabControl1.Controls.Add(students);
            materialTabControl1.Controls.Add(teachers);
            materialTabControl1.Controls.Add(courses);
            materialTabControl1.Controls.Add(courseGroups);
            materialTabControl1.Controls.Add(classes);
            materialTabControl1.Controls.Add(exams);
            materialTabControl1.Controls.Add(specializations);
            materialTabControl1.Controls.Add(users);
            materialTabControl1.Controls.Add(roles);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1637, 919);
            materialTabControl1.TabIndex = 0;
            materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
            // 
            // dashboard
            // 
            dashboard.Controls.Add(panel1);
            dashboard.ImageKey = "home.png";
            dashboard.Location = new Point(4, 39);
            dashboard.Name = "dashboard";
            dashboard.Padding = new Padding(3);
            dashboard.Size = new Size(1629, 876);
            dashboard.TabIndex = 0;
            dashboard.Text = "Anasayfa";
            dashboard.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(materialFloatingActionButton5);
            panel1.Controls.Add(materialFloatingActionButton3);
            panel1.Controls.Add(materialFloatingActionButton2);
            panel1.Controls.Add(materialCard2);
            panel1.Controls.Add(materialFloatingActionButton7);
            panel1.Controls.Add(materialCard1);
            panel1.Controls.Add(materialFloatingActionButton6);
            panel1.Controls.Add(materialCard3);
            panel1.Controls.Add(materialCard4);
            panel1.Controls.Add(materialFloatingActionButton4);
            panel1.Controls.Add(materialCard5);
            panel1.Controls.Add(materialCard6);
            panel1.Controls.Add(materialCard7);
            panel1.Location = new Point(172, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(1217, 524);
            panel1.TabIndex = 12;
            // 
            // materialFloatingActionButton5
            // 
            materialFloatingActionButton5.Depth = 0;
            materialFloatingActionButton5.ForeColor = Color.Silver;
            materialFloatingActionButton5.Icon = (Image)resources.GetObject("materialFloatingActionButton5.Icon");
            materialFloatingActionButton5.Location = new Point(364, 39);
            materialFloatingActionButton5.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton5.Name = "materialFloatingActionButton5";
            materialFloatingActionButton5.Size = new Size(56, 56);
            materialFloatingActionButton5.TabIndex = 9;
            materialFloatingActionButton5.Text = "materialFloatingActionButton5";
            materialFloatingActionButton5.UseVisualStyleBackColor = true;
            // 
            // materialFloatingActionButton3
            // 
            materialFloatingActionButton3.Depth = 0;
            materialFloatingActionButton3.ForeColor = Color.Silver;
            materialFloatingActionButton3.Icon = (Image)resources.GetObject("materialFloatingActionButton3.Icon");
            materialFloatingActionButton3.Location = new Point(18, 164);
            materialFloatingActionButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton3.Name = "materialFloatingActionButton3";
            materialFloatingActionButton3.Size = new Size(56, 56);
            materialFloatingActionButton3.TabIndex = 7;
            materialFloatingActionButton3.Text = "materialFloatingActionButton3";
            materialFloatingActionButton3.UseVisualStyleBackColor = true;
            // 
            // materialFloatingActionButton2
            // 
            materialFloatingActionButton2.Depth = 0;
            materialFloatingActionButton2.ForeColor = Color.Silver;
            materialFloatingActionButton2.Icon = (Image)resources.GetObject("materialFloatingActionButton2.Icon");
            materialFloatingActionButton2.Location = new Point(18, 39);
            materialFloatingActionButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton2.Name = "materialFloatingActionButton2";
            materialFloatingActionButton2.Size = new Size(56, 56);
            materialFloatingActionButton2.TabIndex = 6;
            materialFloatingActionButton2.Text = "materialFloatingActionButton2";
            materialFloatingActionButton2.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(materialLabel3);
            materialCard2.Controls.Add(label2);
            materialCard2.Controls.Add(materialLabel4);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(377, 60);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(332, 99);
            materialCard2.TabIndex = 1;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(49, 46);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(28, 19);
            materialLabel3.TabIndex = 2;
            materialLabel3.Text = "125";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 40F);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(3, 54);
            label2.Name = "label2";
            label2.Size = new Size(0, 66);
            label2.TabIndex = 1;
            label2.UseCompatibleTextRendering = true;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(48, 17);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(176, 19);
            materialLabel4.TabIndex = 0;
            materialLabel4.Text = "Toplam Öğretmen Sayısı";
            // 
            // materialFloatingActionButton7
            // 
            materialFloatingActionButton7.Depth = 0;
            materialFloatingActionButton7.ForeColor = Color.Silver;
            materialFloatingActionButton7.Icon = (Image)resources.GetObject("materialFloatingActionButton7.Icon");
            materialFloatingActionButton7.Location = new Point(364, 288);
            materialFloatingActionButton7.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton7.Name = "materialFloatingActionButton7";
            materialFloatingActionButton7.Size = new Size(56, 56);
            materialFloatingActionButton7.TabIndex = 11;
            materialFloatingActionButton7.Text = "materialFloatingActionButton7";
            materialFloatingActionButton7.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(materialLabel2);
            materialCard1.Controls.Add(label1);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(28, 60);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(332, 99);
            materialCard1.TabIndex = 0;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(54, 46);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(28, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "125";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 40F);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(3, 54);
            label1.Name = "label1";
            label1.Size = new Size(0, 66);
            label1.TabIndex = 1;
            label1.UseCompatibleTextRendering = true;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(53, 17);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(161, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Toplam Öğrenci Sayısı";
            // 
            // materialFloatingActionButton6
            // 
            materialFloatingActionButton6.Depth = 0;
            materialFloatingActionButton6.ForeColor = Color.Silver;
            materialFloatingActionButton6.Icon = (Image)resources.GetObject("materialFloatingActionButton6.Icon");
            materialFloatingActionButton6.Location = new Point(365, 164);
            materialFloatingActionButton6.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton6.Name = "materialFloatingActionButton6";
            materialFloatingActionButton6.Size = new Size(56, 56);
            materialFloatingActionButton6.TabIndex = 10;
            materialFloatingActionButton6.Text = "materialFloatingActionButton6";
            materialFloatingActionButton6.UseVisualStyleBackColor = true;
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(materialLabel5);
            materialCard3.Controls.Add(label3);
            materialCard3.Controls.Add(materialLabel6);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(28, 184);
            materialCard3.Margin = new Padding(14);
            materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14);
            materialCard3.Size = new Size(332, 99);
            materialCard3.TabIndex = 2;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(56, 46);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(28, 19);
            materialLabel5.TabIndex = 2;
            materialLabel5.Text = "125";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 40F);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(3, 54);
            label3.Name = "label3";
            label3.Size = new Size(0, 66);
            label3.TabIndex = 1;
            label3.UseCompatibleTextRendering = true;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(53, 19);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(140, 19);
            materialLabel6.TabIndex = 0;
            materialLabel6.Text = "Toplam Sınıf Sayısı";
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(materialLabel7);
            materialCard4.Controls.Add(label4);
            materialCard4.Controls.Add(materialLabel8);
            materialCard4.Depth = 0;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(377, 184);
            materialCard4.Margin = new Padding(14);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(332, 99);
            materialCard4.TabIndex = 3;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(52, 46);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(28, 19);
            materialLabel7.TabIndex = 2;
            materialLabel7.Text = "125";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 40F);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(3, 54);
            label4.Name = "label4";
            label4.Size = new Size(0, 66);
            label4.TabIndex = 1;
            label4.UseCompatibleTextRendering = true;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(51, 17);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(139, 19);
            materialLabel8.TabIndex = 0;
            materialLabel8.Text = "Toplam Kurs Sayısı";
            // 
            // materialFloatingActionButton4
            // 
            materialFloatingActionButton4.Depth = 0;
            materialFloatingActionButton4.ForeColor = Color.Silver;
            materialFloatingActionButton4.Icon = (Image)resources.GetObject("materialFloatingActionButton4.Icon");
            materialFloatingActionButton4.Location = new Point(19, 288);
            materialFloatingActionButton4.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton4.Name = "materialFloatingActionButton4";
            materialFloatingActionButton4.Size = new Size(56, 56);
            materialFloatingActionButton4.TabIndex = 8;
            materialFloatingActionButton4.Text = "materialFloatingActionButton4";
            materialFloatingActionButton4.UseVisualStyleBackColor = true;
            // 
            // materialCard5
            // 
            materialCard5.BackColor = Color.FromArgb(255, 255, 255);
            materialCard5.Controls.Add(materialLabel9);
            materialCard5.Controls.Add(label5);
            materialCard5.Controls.Add(materialLabel10);
            materialCard5.Depth = 0;
            materialCard5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard5.Location = new Point(28, 313);
            materialCard5.Margin = new Padding(14);
            materialCard5.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard5.Name = "materialCard5";
            materialCard5.Padding = new Padding(14);
            materialCard5.Size = new Size(332, 99);
            materialCard5.TabIndex = 4;
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(51, 46);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(28, 19);
            materialLabel9.TabIndex = 2;
            materialLabel9.Text = "125";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 40F);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(3, 54);
            label5.Name = "label5";
            label5.Size = new Size(0, 66);
            label5.TabIndex = 1;
            label5.UseCompatibleTextRendering = true;
            // 
            // materialLabel10
            // 
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(50, 17);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(186, 19);
            materialLabel10.TabIndex = 0;
            materialLabel10.Text = "Toplam Kurs Grubu Sayısı";
            // 
            // materialCard6
            // 
            materialCard6.BackColor = Color.FromArgb(255, 255, 255);
            materialCard6.Controls.Add(materialLabel11);
            materialCard6.Controls.Add(label6);
            materialCard6.Controls.Add(materialLabel12);
            materialCard6.Depth = 0;
            materialCard6.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard6.Location = new Point(374, 313);
            materialCard6.Margin = new Padding(14);
            materialCard6.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard6.Name = "materialCard6";
            materialCard6.Padding = new Padding(14);
            materialCard6.Size = new Size(332, 99);
            materialCard6.TabIndex = 3;
            // 
            // materialLabel11
            // 
            materialLabel11.AutoSize = true;
            materialLabel11.Depth = 0;
            materialLabel11.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel11.Location = new Point(49, 46);
            materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel11.Name = "materialLabel11";
            materialLabel11.Size = new Size(28, 19);
            materialLabel11.TabIndex = 2;
            materialLabel11.Text = "125";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 40F);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(3, 54);
            label6.Name = "label6";
            label6.Size = new Size(0, 66);
            label6.TabIndex = 1;
            label6.UseCompatibleTextRendering = true;
            // 
            // materialLabel12
            // 
            materialLabel12.AutoSize = true;
            materialLabel12.Depth = 0;
            materialLabel12.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel12.Location = new Point(48, 17);
            materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel12.Name = "materialLabel12";
            materialLabel12.Size = new Size(233, 19);
            materialLabel12.TabIndex = 0;
            materialLabel12.Text = "Toplam Sistem Kullanıcısı Sayısı";
            // 
            // materialCard7
            // 
            materialCard7.BackColor = Color.FromArgb(255, 255, 255);
            materialCard7.Controls.Add(logoutBtn);
            materialCard7.Controls.Add(materialLabel16);
            materialCard7.Controls.Add(materialLabel15);
            materialCard7.Controls.Add(materialLabel14);
            materialCard7.Controls.Add(materialLabel13);
            materialCard7.Controls.Add(materialFloatingActionButton1);
            materialCard7.Depth = 0;
            materialCard7.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard7.Location = new Point(725, 60);
            materialCard7.Margin = new Padding(14);
            materialCard7.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard7.Name = "materialCard7";
            materialCard7.Padding = new Padding(14);
            materialCard7.Size = new Size(473, 353);
            materialCard7.TabIndex = 5;
            // 
            // logoutBtn
            // 
            logoutBtn.AutoSize = false;
            logoutBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logoutBtn.BackColor = Color.MediumBlue;
            logoutBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            logoutBtn.Depth = 0;
            logoutBtn.HighEmphasis = true;
            logoutBtn.Icon = null;
            logoutBtn.Location = new Point(17, 297);
            logoutBtn.Margin = new Padding(4, 6, 4, 6);
            logoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            logoutBtn.Name = "logoutBtn";
            logoutBtn.NoAccentTextColor = Color.Empty;
            logoutBtn.Size = new Size(158, 36);
            logoutBtn.TabIndex = 5;
            logoutBtn.Text = "Çıkış Yap";
            logoutBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            logoutBtn.UseAccentColor = true;
            logoutBtn.UseVisualStyleBackColor = false;
            // 
            // materialLabel16
            // 
            materialLabel16.AutoSize = true;
            materialLabel16.Depth = 0;
            materialLabel16.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel16.Location = new Point(17, 203);
            materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel16.Name = "materialLabel16";
            materialLabel16.Size = new Size(51, 19);
            materialLabel16.TabIndex = 4;
            materialLabel16.Text = "Tel No:";
            // 
            // materialLabel15
            // 
            materialLabel15.AutoSize = true;
            materialLabel15.Depth = 0;
            materialLabel15.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel15.Location = new Point(17, 162);
            materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel15.Name = "materialLabel15";
            materialLabel15.Size = new Size(107, 19);
            materialLabel15.TabIndex = 3;
            materialLabel15.Text = "E-Posta Adresi:";
            // 
            // materialLabel14
            // 
            materialLabel14.AutoSize = true;
            materialLabel14.Depth = 0;
            materialLabel14.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel14.Location = new Point(17, 120);
            materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel14.Name = "materialLabel14";
            materialLabel14.Size = new Size(92, 19);
            materialLabel14.TabIndex = 2;
            materialLabel14.Text = "Kullanıcı adı:";
            // 
            // materialLabel13
            // 
            materialLabel13.AutoSize = true;
            materialLabel13.Depth = 0;
            materialLabel13.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel13.Location = new Point(165, 80);
            materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel13.Name = "materialLabel13";
            materialLabel13.Size = new Size(144, 19);
            materialLabel13.TabIndex = 1;
            materialLabel13.Text = "Yetkili Adı ve Soyadı";
            // 
            // materialFloatingActionButton1
            // 
            materialFloatingActionButton1.Depth = 0;
            materialFloatingActionButton1.ForeColor = Color.Silver;
            materialFloatingActionButton1.Icon = Properties.Resources.users;
            materialFloatingActionButton1.Location = new Point(208, 9);
            materialFloatingActionButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton1.Name = "materialFloatingActionButton1";
            materialFloatingActionButton1.Size = new Size(56, 56);
            materialFloatingActionButton1.TabIndex = 0;
            materialFloatingActionButton1.Text = "materialFloatingActionButton1";
            materialFloatingActionButton1.UseVisualStyleBackColor = true;
            // 
            // students
            // 
            students.Controls.Add(materialComboBox2);
            students.Controls.Add(materialButton1);
            students.Controls.Add(materialComboBox1);
            students.Controls.Add(materialTextBox23);
            students.Controls.Add(materialTextBox22);
            students.Controls.Add(materialTextBox21);
            students.Controls.Add(flowLayoutPanelStudents);
            students.ImageKey = "student.png";
            students.Location = new Point(4, 39);
            students.Name = "students";
            students.Padding = new Padding(3);
            students.Size = new Size(1629, 876);
            students.TabIndex = 1;
            students.Text = "Öğrenciler";
            students.UseVisualStyleBackColor = true;
            // 
            // materialComboBox2
            // 
            materialComboBox2.AutoResize = false;
            materialComboBox2.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox2.Depth = 0;
            materialComboBox2.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox2.DropDownHeight = 174;
            materialComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox2.DropDownWidth = 121;
            materialComboBox2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox2.FormattingEnabled = true;
            materialComboBox2.Hint = "Öğrenci Durumu";
            materialComboBox2.IntegralHeight = false;
            materialComboBox2.ItemHeight = 43;
            materialComboBox2.Items.AddRange(new object[] { "Aktif", "Pasif" });
            materialComboBox2.Location = new Point(1054, 9);
            materialComboBox2.MaxDropDownItems = 4;
            materialComboBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox2.Name = "materialComboBox2";
            materialComboBox2.Size = new Size(272, 49);
            materialComboBox2.StartIndex = 0;
            materialComboBox2.TabIndex = 12;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(1344, 17);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(157, 36);
            materialButton1.TabIndex = 6;
            materialButton1.Text = "Yeni Öğrenci Ekle";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialComboBox1
            // 
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 174;
            materialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.Hint = "Cinsiyet";
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Items.AddRange(new object[] { "Erkek", "Kız" });
            materialComboBox1.Location = new Point(776, 9);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(272, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 5;
            // 
            // materialTextBox23
            // 
            materialTextBox23.AnimateReadOnly = false;
            materialTextBox23.BackgroundImageLayout = ImageLayout.None;
            materialTextBox23.CharacterCasing = CharacterCasing.Normal;
            materialTextBox23.Depth = 0;
            materialTextBox23.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox23.HideSelection = true;
            materialTextBox23.Hint = "Soyad";
            materialTextBox23.LeadingIcon = null;
            materialTextBox23.Location = new Point(520, 10);
            materialTextBox23.MaxLength = 32767;
            materialTextBox23.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox23.Name = "materialTextBox23";
            materialTextBox23.PasswordChar = '\0';
            materialTextBox23.PrefixSuffixText = null;
            materialTextBox23.ReadOnly = false;
            materialTextBox23.RightToLeft = RightToLeft.No;
            materialTextBox23.SelectedText = "";
            materialTextBox23.SelectionLength = 0;
            materialTextBox23.SelectionStart = 0;
            materialTextBox23.ShortcutsEnabled = true;
            materialTextBox23.Size = new Size(250, 48);
            materialTextBox23.TabIndex = 4;
            materialTextBox23.TabStop = false;
            materialTextBox23.TextAlign = HorizontalAlignment.Left;
            materialTextBox23.TrailingIcon = null;
            materialTextBox23.UseSystemPasswordChar = false;
            // 
            // materialTextBox22
            // 
            materialTextBox22.AnimateReadOnly = false;
            materialTextBox22.BackgroundImageLayout = ImageLayout.None;
            materialTextBox22.CharacterCasing = CharacterCasing.Normal;
            materialTextBox22.Depth = 0;
            materialTextBox22.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox22.HideSelection = true;
            materialTextBox22.Hint = "Ad";
            materialTextBox22.LeadingIcon = null;
            materialTextBox22.Location = new Point(264, 10);
            materialTextBox22.MaxLength = 32767;
            materialTextBox22.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox22.Name = "materialTextBox22";
            materialTextBox22.PasswordChar = '\0';
            materialTextBox22.PrefixSuffixText = null;
            materialTextBox22.ReadOnly = false;
            materialTextBox22.RightToLeft = RightToLeft.No;
            materialTextBox22.SelectedText = "";
            materialTextBox22.SelectionLength = 0;
            materialTextBox22.SelectionStart = 0;
            materialTextBox22.ShortcutsEnabled = true;
            materialTextBox22.Size = new Size(250, 48);
            materialTextBox22.TabIndex = 3;
            materialTextBox22.TabStop = false;
            materialTextBox22.TextAlign = HorizontalAlignment.Left;
            materialTextBox22.TrailingIcon = null;
            materialTextBox22.UseSystemPasswordChar = false;
            // 
            // materialTextBox21
            // 
            materialTextBox21.AnimateReadOnly = false;
            materialTextBox21.BackgroundImageLayout = ImageLayout.None;
            materialTextBox21.CharacterCasing = CharacterCasing.Normal;
            materialTextBox21.Depth = 0;
            materialTextBox21.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox21.HideSelection = true;
            materialTextBox21.Hint = "Kimlik No";
            materialTextBox21.LeadingIcon = null;
            materialTextBox21.Location = new Point(8, 10);
            materialTextBox21.MaxLength = 32767;
            materialTextBox21.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox21.Name = "materialTextBox21";
            materialTextBox21.PasswordChar = '\0';
            materialTextBox21.PrefixSuffixText = null;
            materialTextBox21.ReadOnly = false;
            materialTextBox21.RightToLeft = RightToLeft.No;
            materialTextBox21.SelectedText = "";
            materialTextBox21.SelectionLength = 0;
            materialTextBox21.SelectionStart = 0;
            materialTextBox21.ShortcutsEnabled = true;
            materialTextBox21.Size = new Size(250, 48);
            materialTextBox21.TabIndex = 1;
            materialTextBox21.TabStop = false;
            materialTextBox21.TextAlign = HorizontalAlignment.Left;
            materialTextBox21.TrailingIcon = null;
            materialTextBox21.UseSystemPasswordChar = false;
            // 
            // flowLayoutPanelStudents
            // 
            flowLayoutPanelStudents.Location = new Point(3, 68);
            flowLayoutPanelStudents.Name = "flowLayoutPanelStudents";
            flowLayoutPanelStudents.Size = new Size(1623, 805);
            flowLayoutPanelStudents.TabIndex = 0;
            // 
            // teachers
            // 
            teachers.Controls.Add(materialButton2);
            teachers.Controls.Add(materialTextBox24);
            teachers.Controls.Add(materialTextBox25);
            teachers.Controls.Add(materialTextBox26);
            teachers.Controls.Add(flowLayoutPanelTeachers);
            teachers.ImageKey = "teacher.png";
            teachers.Location = new Point(4, 39);
            teachers.Name = "teachers";
            teachers.Size = new Size(1629, 876);
            teachers.TabIndex = 2;
            teachers.Text = "Öğretmenler";
            teachers.UseVisualStyleBackColor = true;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(1373, 14);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(174, 36);
            materialButton2.TabIndex = 12;
            materialButton2.Text = "Yeni Öğretmen Ekle";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            // 
            // materialTextBox24
            // 
            materialTextBox24.AnimateReadOnly = false;
            materialTextBox24.BackgroundImageLayout = ImageLayout.None;
            materialTextBox24.CharacterCasing = CharacterCasing.Normal;
            materialTextBox24.Depth = 0;
            materialTextBox24.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox24.HideSelection = true;
            materialTextBox24.Hint = "Soyad";
            materialTextBox24.LeadingIcon = null;
            materialTextBox24.Location = new Point(520, 7);
            materialTextBox24.MaxLength = 32767;
            materialTextBox24.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox24.Name = "materialTextBox24";
            materialTextBox24.PasswordChar = '\0';
            materialTextBox24.PrefixSuffixText = null;
            materialTextBox24.ReadOnly = false;
            materialTextBox24.RightToLeft = RightToLeft.No;
            materialTextBox24.SelectedText = "";
            materialTextBox24.SelectionLength = 0;
            materialTextBox24.SelectionStart = 0;
            materialTextBox24.ShortcutsEnabled = true;
            materialTextBox24.Size = new Size(250, 48);
            materialTextBox24.TabIndex = 10;
            materialTextBox24.TabStop = false;
            materialTextBox24.TextAlign = HorizontalAlignment.Left;
            materialTextBox24.TrailingIcon = null;
            materialTextBox24.UseSystemPasswordChar = false;
            // 
            // materialTextBox25
            // 
            materialTextBox25.AnimateReadOnly = false;
            materialTextBox25.BackgroundImageLayout = ImageLayout.None;
            materialTextBox25.CharacterCasing = CharacterCasing.Normal;
            materialTextBox25.Depth = 0;
            materialTextBox25.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox25.HideSelection = true;
            materialTextBox25.Hint = "Ad";
            materialTextBox25.LeadingIcon = null;
            materialTextBox25.Location = new Point(264, 7);
            materialTextBox25.MaxLength = 32767;
            materialTextBox25.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox25.Name = "materialTextBox25";
            materialTextBox25.PasswordChar = '\0';
            materialTextBox25.PrefixSuffixText = null;
            materialTextBox25.ReadOnly = false;
            materialTextBox25.RightToLeft = RightToLeft.No;
            materialTextBox25.SelectedText = "";
            materialTextBox25.SelectionLength = 0;
            materialTextBox25.SelectionStart = 0;
            materialTextBox25.ShortcutsEnabled = true;
            materialTextBox25.Size = new Size(250, 48);
            materialTextBox25.TabIndex = 9;
            materialTextBox25.TabStop = false;
            materialTextBox25.TextAlign = HorizontalAlignment.Left;
            materialTextBox25.TrailingIcon = null;
            materialTextBox25.UseSystemPasswordChar = false;
            // 
            // materialTextBox26
            // 
            materialTextBox26.AnimateReadOnly = false;
            materialTextBox26.BackgroundImageLayout = ImageLayout.None;
            materialTextBox26.CharacterCasing = CharacterCasing.Normal;
            materialTextBox26.Depth = 0;
            materialTextBox26.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox26.HideSelection = true;
            materialTextBox26.Hint = "Kimlik No";
            materialTextBox26.LeadingIcon = null;
            materialTextBox26.Location = new Point(8, 7);
            materialTextBox26.MaxLength = 32767;
            materialTextBox26.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox26.Name = "materialTextBox26";
            materialTextBox26.PasswordChar = '\0';
            materialTextBox26.PrefixSuffixText = null;
            materialTextBox26.ReadOnly = false;
            materialTextBox26.RightToLeft = RightToLeft.No;
            materialTextBox26.SelectedText = "";
            materialTextBox26.SelectionLength = 0;
            materialTextBox26.SelectionStart = 0;
            materialTextBox26.ShortcutsEnabled = true;
            materialTextBox26.Size = new Size(250, 48);
            materialTextBox26.TabIndex = 8;
            materialTextBox26.TabStop = false;
            materialTextBox26.TextAlign = HorizontalAlignment.Left;
            materialTextBox26.TrailingIcon = null;
            materialTextBox26.UseSystemPasswordChar = false;
            // 
            // flowLayoutPanelTeachers
            // 
            flowLayoutPanelTeachers.Location = new Point(3, 65);
            flowLayoutPanelTeachers.Name = "flowLayoutPanelTeachers";
            flowLayoutPanelTeachers.Size = new Size(1623, 805);
            flowLayoutPanelTeachers.TabIndex = 7;
            // 
            // courses
            // 
            courses.ImageKey = "course.png";
            courses.Location = new Point(4, 39);
            courses.Name = "courses";
            courses.Size = new Size(1629, 876);
            courses.TabIndex = 3;
            courses.Text = "Kurslar";
            courses.UseVisualStyleBackColor = true;
            // 
            // courseGroups
            // 
            courseGroups.ImageKey = "course_group.png";
            courseGroups.Location = new Point(4, 39);
            courseGroups.Name = "courseGroups";
            courseGroups.Size = new Size(1629, 876);
            courseGroups.TabIndex = 4;
            courseGroups.Text = "Kurs Grupları";
            courseGroups.UseVisualStyleBackColor = true;
            // 
            // classes
            // 
            classes.ImageKey = "class.png";
            classes.Location = new Point(4, 39);
            classes.Name = "classes";
            classes.Size = new Size(1629, 876);
            classes.TabIndex = 5;
            classes.Text = "Sınıflar";
            classes.UseVisualStyleBackColor = true;
            // 
            // exams
            // 
            exams.ImageKey = "exam.png";
            exams.Location = new Point(4, 39);
            exams.Name = "exams";
            exams.Size = new Size(1629, 876);
            exams.TabIndex = 6;
            exams.Text = "Sınavlar";
            exams.UseVisualStyleBackColor = true;
            // 
            // specializations
            // 
            specializations.ImageKey = "specialization.png";
            specializations.Location = new Point(4, 39);
            specializations.Name = "specializations";
            specializations.Size = new Size(1629, 876);
            specializations.TabIndex = 7;
            specializations.Text = "Öğretmen Uzmanlık Alanları";
            specializations.UseVisualStyleBackColor = true;
            // 
            // users
            // 
            users.ImageKey = "users.png";
            users.Location = new Point(4, 39);
            users.Name = "users";
            users.Size = new Size(1629, 876);
            users.TabIndex = 8;
            users.Text = "Sistem Kullanıcıları";
            users.UseVisualStyleBackColor = true;
            // 
            // roles
            // 
            roles.ImageKey = "role.png";
            roles.Location = new Point(4, 39);
            roles.Name = "roles";
            roles.Size = new Size(1629, 876);
            roles.TabIndex = 9;
            roles.Text = "Kullanıcı Rolleri";
            roles.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "class.png");
            imageList1.Images.SetKeyName(1, "course.png");
            imageList1.Images.SetKeyName(2, "course_group.png");
            imageList1.Images.SetKeyName(3, "exam.png");
            imageList1.Images.SetKeyName(4, "home.png");
            imageList1.Images.SetKeyName(5, "role.png");
            imageList1.Images.SetKeyName(6, "specialization.png");
            imageList1.Images.SetKeyName(7, "student.png");
            imageList1.Images.SetKeyName(8, "teacher.png");
            imageList1.Images.SetKeyName(9, "users.png");
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1643, 986);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            MaximizeBox = false;
            Name = "DashboardForm";
            Sizable = false;
            Text = "Kurs Yönetim Merkezi Otomasyonu";
            materialTabControl1.ResumeLayout(false);
            dashboard.ResumeLayout(false);
            panel1.ResumeLayout(false);
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
            materialCard4.ResumeLayout(false);
            materialCard4.PerformLayout();
            materialCard5.ResumeLayout(false);
            materialCard5.PerformLayout();
            materialCard6.ResumeLayout(false);
            materialCard6.PerformLayout();
            materialCard7.ResumeLayout(false);
            materialCard7.PerformLayout();
            students.ResumeLayout(false);
            students.PerformLayout();
            teachers.ResumeLayout(false);
            teachers.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage dashboard;
        private TabPage students;
        private ImageList imageList1;
        private TabPage teachers;
        private TabPage courses;
        private TabPage courseGroups;
        private TabPage classes;
        private TabPage exams;
        private TabPage specializations;
        private TabPage users;
        private TabPage roles;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Label label1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialCard materialCard7;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialButton logoutBtn;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton2;
        private MaterialSkin.Controls.MaterialCard materialCard6;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private Label label6;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialCard materialCard5;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private Label label5;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private Label label4;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private Label label3;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private Label label2;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton3;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton4;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton6;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton5;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton7;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanelStudents;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox23;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox22;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox2;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox24;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox25;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox26;
        private FlowLayoutPanel flowLayoutPanelTeachers;
    }
}