namespace Hospital_Management.Forms
{
    partial class frm_BookingDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBID = new System.Windows.Forms.TextBox();
            this.txtDName = new System.Windows.Forms.TextBox();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.txtDisease = new System.Windows.Forms.TextBox();
            this.dgvBookingDetail = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSType = new System.Windows.Forms.TextBox();
            this.bntConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCheckBID = new System.Windows.Forms.Button();
            this.btnCheckSID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Schedule ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Booking ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Doctor Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(777, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Disease";
            // 
            // txtBID
            // 
            this.txtBID.Location = new System.Drawing.Point(131, 33);
            this.txtBID.Name = "txtBID";
            this.txtBID.Size = new System.Drawing.Size(153, 23);
            this.txtBID.TabIndex = 2;
            // 
            // txtDName
            // 
            this.txtDName.Location = new System.Drawing.Point(513, 94);
            this.txtDName.Name = "txtDName";
            this.txtDName.Size = new System.Drawing.Size(153, 23);
            this.txtDName.TabIndex = 3;
            // 
            // txtSID
            // 
            this.txtSID.Location = new System.Drawing.Point(131, 94);
            this.txtSID.Name = "txtSID";
            this.txtSID.Size = new System.Drawing.Size(153, 23);
            this.txtSID.TabIndex = 3;
            // 
            // txtDisease
            // 
            this.txtDisease.Location = new System.Drawing.Point(867, 36);
            this.txtDisease.Name = "txtDisease";
            this.txtDisease.Size = new System.Drawing.Size(153, 23);
            this.txtDisease.TabIndex = 3;
            // 
            // dgvBookingDetail
            // 
            this.dgvBookingDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookingDetail.Location = new System.Drawing.Point(40, 190);
            this.dgvBookingDetail.Name = "dgvBookingDetail";
            this.dgvBookingDetail.RowTemplate.Height = 24;
            this.dgvBookingDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookingDetail.Size = new System.Drawing.Size(1043, 238);
            this.dgvBookingDetail.TabIndex = 4;
            this.dgvBookingDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookingDetail_CellClick);
            this.dgvBookingDetail.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBookingDetail_CellMouseDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(348, 464);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 464);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 30);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Patient Name:";
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(513, 36);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(153, 23);
            this.txtPName.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(729, 97);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Speicialist Type";
            // 
            // txtSType
            // 
            this.txtSType.Location = new System.Drawing.Point(867, 97);
            this.txtSType.Name = "txtSType";
            this.txtSType.Size = new System.Drawing.Size(153, 23);
            this.txtSType.TabIndex = 9;
            // 
            // bntConfirm
            // 
            this.bntConfirm.Location = new System.Drawing.Point(577, 141);
            this.bntConfirm.Name = "bntConfirm";
            this.bntConfirm.Size = new System.Drawing.Size(89, 30);
            this.bntConfirm.TabIndex = 10;
            this.bntConfirm.Text = "Confirm";
            this.bntConfirm.UseVisualStyleBackColor = true;
            this.bntConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(747, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(914, 141);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 30);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCheckBID
            // 
            this.btnCheckBID.Location = new System.Drawing.Point(131, 62);
            this.btnCheckBID.Name = "btnCheckBID";
            this.btnCheckBID.Size = new System.Drawing.Size(75, 23);
            this.btnCheckBID.TabIndex = 13;
            this.btnCheckBID.Text = "Check ID";
            this.btnCheckBID.UseVisualStyleBackColor = true;
            this.btnCheckBID.Click += new System.EventHandler(this.btnCheckBID_Click);
            // 
            // btnCheckSID
            // 
            this.btnCheckSID.Location = new System.Drawing.Point(131, 123);
            this.btnCheckSID.Name = "btnCheckSID";
            this.btnCheckSID.Size = new System.Drawing.Size(75, 23);
            this.btnCheckSID.TabIndex = 14;
            this.btnCheckSID.Text = "Check ID";
            this.btnCheckSID.UseVisualStyleBackColor = true;
            this.btnCheckSID.Click += new System.EventHandler(this.btnCheckSID_Click);
            // 
            // frm_BookingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 529);
            this.Controls.Add(this.btnCheckSID);
            this.Controls.Add(this.btnCheckBID);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntConfirm);
            this.Controls.Add(this.txtSType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvBookingDetail);
            this.Controls.Add(this.txtDisease);
            this.Controls.Add(this.txtSID);
            this.Controls.Add(this.txtDName);
            this.Controls.Add(this.txtBID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_BookingDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking Detail";
            this.Load += new System.EventHandler(this.frm_BookingDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBID;
        private System.Windows.Forms.TextBox txtDName;
        private System.Windows.Forms.TextBox txtSID;
        private System.Windows.Forms.TextBox txtDisease;
        private System.Windows.Forms.DataGridView dgvBookingDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSType;
        private System.Windows.Forms.Button bntConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCheckBID;
        private System.Windows.Forms.Button btnCheckSID;
    }
}