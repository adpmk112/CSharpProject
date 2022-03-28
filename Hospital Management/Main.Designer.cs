namespace Hospital_Management
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSpecialist = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoctor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBookingDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuPatient = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 76);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1022, 341);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // mnuHome
            // 
            this.mnuHome.AutoSize = false;
            this.mnuHome.BackColor = System.Drawing.Color.MistyRose;
            this.mnuHome.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUserLogin,
            this.mnuUserRegister,
            this.mnuExit});
            this.mnuHome.Name = "mnuHome";
            this.mnuHome.Size = new System.Drawing.Size(200, 90);
            this.mnuHome.Text = "Home";
            // 
            // mnuUserLogin
            // 
            this.mnuUserLogin.Name = "mnuUserLogin";
            this.mnuUserLogin.Size = new System.Drawing.Size(152, 22);
            this.mnuUserLogin.Text = "User Login";
            this.mnuUserLogin.Click += new System.EventHandler(this.mnuUserLogin_Click);
            // 
            // mnuUserRegister
            // 
            this.mnuUserRegister.Name = "mnuUserRegister";
            this.mnuUserRegister.Size = new System.Drawing.Size(152, 22);
            this.mnuUserRegister.Text = "User Reigster";
            this.mnuUserRegister.Click += new System.EventHandler(this.mnuUserRegister_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuView
            // 
            this.mnuView.AutoSize = false;
            this.mnuView.BackColor = System.Drawing.Color.MistyRose;
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSpecialist,
            this.mnuDoctor});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(200, 90);
            this.mnuView.Text = "Doctor View";
            // 
            // mnuSpecialist
            // 
            this.mnuSpecialist.Name = "mnuSpecialist";
            this.mnuSpecialist.Size = new System.Drawing.Size(123, 22);
            this.mnuSpecialist.Text = "Specialist";
            this.mnuSpecialist.Click += new System.EventHandler(this.mnuSpecialist_Click);
            // 
            // mnuDoctor
            // 
            this.mnuDoctor.Name = "mnuDoctor";
            this.mnuDoctor.Size = new System.Drawing.Size(123, 22);
            this.mnuDoctor.Text = "Doctor";
            this.mnuDoctor.Click += new System.EventHandler(this.mnuDoctor_Click);
            // 
            // mnuBooking
            // 
            this.mnuBooking.AutoSize = false;
            this.mnuBooking.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnuBooking.Name = "mnuBooking";
            this.mnuBooking.Size = new System.Drawing.Size(200, 90);
            this.mnuBooking.Text = "Booking";
            this.mnuBooking.Click += new System.EventHandler(this.mnuBooking_Click);
            // 
            // mnuBookingDetail
            // 
            this.mnuBookingDetail.AutoSize = false;
            this.mnuBookingDetail.BackColor = System.Drawing.Color.MistyRose;
            this.mnuBookingDetail.Name = "mnuBookingDetail";
            this.mnuBookingDetail.Size = new System.Drawing.Size(200, 90);
            this.mnuBookingDetail.Text = "Booking Detail";
            this.mnuBookingDetail.Click += new System.EventHandler(this.mnuBookingDetail_Click);
            // 
            // mnuSchedule
            // 
            this.mnuSchedule.AutoSize = false;
            this.mnuSchedule.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnuSchedule.Name = "mnuSchedule";
            this.mnuSchedule.Size = new System.Drawing.Size(200, 90);
            this.mnuSchedule.Text = "Schedule";
            this.mnuSchedule.Click += new System.EventHandler(this.mnuSchedule_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHome,
            this.mnuPatient,
            this.mnuView,
            this.mnuBooking,
            this.mnuBookingDetail,
            this.mnuSchedule});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1022, 76);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuPatient
            // 
            this.mnuPatient.AutoSize = false;
            this.mnuPatient.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnuPatient.Name = "mnuPatient";
            this.mnuPatient.Size = new System.Drawing.Size(200, 90);
            this.mnuPatient.Text = "Patient Record";
            this.mnuPatient.Click += new System.EventHandler(this.patientToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 417);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Hospital Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuHome;
        private System.Windows.Forms.ToolStripMenuItem mnuUserRegister;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuSpecialist;
        private System.Windows.Forms.ToolStripMenuItem mnuDoctor;
        private System.Windows.Forms.ToolStripMenuItem mnuBooking;
        private System.Windows.Forms.ToolStripMenuItem mnuBookingDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuSchedule;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuPatient;
        public System.Windows.Forms.ToolStripMenuItem mnuUserLogin;
    }
}

