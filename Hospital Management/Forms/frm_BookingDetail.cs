using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital_Management.Classes;
using Hospital_Management.Report;


namespace Hospital_Management.Forms
{
    public partial class frm_BookingDetail : Form
    {
        public frm_BookingDetail()
        {
            InitializeComponent();
        }
        clsMainClass obj_clsMainClass = new clsMainClass();
        clsBookingDetail obj_clsBookingDetail = new clsBookingDetail();
        DataTable DT = new DataTable();
        string SPString = "";

        private void ShowData()
        {
            SPString = string.Format("SP_Select_BookingDetail N'{0}',N'{1}',N'{2}'", "0", "0", "1");
            dgvBookingDetail.DataSource = obj_clsMainClass.SelectData(SPString);

            dgvBookingDetail.Columns[0].Width = (dgvBookingDetail.Width / 100) * 5;
            dgvBookingDetail.Columns[1].Visible = false;
            dgvBookingDetail.Columns[2].Width = (dgvBookingDetail.Width / 100) * 15;
            dgvBookingDetail.Columns[3].Width = (dgvBookingDetail.Width / 100) * 10;
            dgvBookingDetail.Columns[4].Width = (dgvBookingDetail.Width / 100) * 10;
            dgvBookingDetail.Columns[5].Width = (dgvBookingDetail.Width / 100) * 12;
            dgvBookingDetail.Columns[6].Width = (dgvBookingDetail.Width / 100) * 10;
            dgvBookingDetail.Columns[7].Width = (dgvBookingDetail.Width / 100) * 10;
            dgvBookingDetail.Columns[8].Width = (dgvBookingDetail.Width / 100) * 10;
            dgvBookingDetail.Columns[9].Width = (dgvBookingDetail.Width / 100) * 9;
            dgvBookingDetail.Columns[10].Width = (dgvBookingDetail.Width / 100) * 9;
            dgvBookingDetail.Columns[11].Visible = false;
        }

        private void ShowEntry()
        {
            if (dgvBookingDetail.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is No Data");
            }

            else
            {

                txtBID.Text = dgvBookingDetail.CurrentRow.Cells["Booking ID"].Value.ToString();
                txtPName.Text = dgvBookingDetail.CurrentRow.Cells["Patient Name"].Value.ToString();
                txtDisease.Text = dgvBookingDetail.CurrentRow.Cells["Disease"].Value.ToString();
                txtSID.Text = dgvBookingDetail.CurrentRow.Cells["ScheduleID"].Value.ToString();
                txtDName.Text = dgvBookingDetail.CurrentRow.Cells["Doctor Name"].Value.ToString();
                txtSType.Text = dgvBookingDetail.CurrentRow.Cells["Specialist Type"].Value.ToString();

            }
        }

        private void frm_BookingDetail_Load(object sender, EventArgs e)
        {
            dgvBookingDetail.Refresh();
            ShowData();
            Clear();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtBID.Text == "")
            {
                MessageBox.Show("Enter Booking ID (Only Number)");
                txtBID.Focus();
                txtBID.SelectAll();
            }

            else if (txtSID.Text == "")
            {
                MessageBox.Show("Enter Schedule ID (Only Number)");
                txtSID.Focus();
                txtSID.SelectAll();
            }

            else
            {
                int BID = 0; int SID = 0;

                bool res = Int32.TryParse(txtBID.Text, out BID);
                bool res1 = Int32.TryParse(txtSID.Text, out SID);

                if (res == true && res1 == true)
                {

                    SPString = string.Format("SP_Select_BookingDetail'{0}',N'{1}',N'{2}'", BID, SID, "0");
                    DT = obj_clsMainClass.SelectData(SPString);

                    if (DT.Rows.Count > 0 && BID == Convert.ToInt32(DT.Rows[0]["BookingID"]) && SID == Convert.ToInt32(DT.Rows[0]["ScheduleID"]))
                    {
                        MessageBox.Show("This Patient has been taken this Schedule");
                        Clear();
                    }

                    else
                    {
                        obj_clsBookingDetail.BOOKINGID = Convert.ToInt32(txtBID.Text);
                        obj_clsBookingDetail.SCHEDULEID = Convert.ToInt32(txtSID.Text);

                        obj_clsBookingDetail.ACTION = 0;
                        obj_clsBookingDetail.SaveData();

                        MessageBox.Show("Successfullly Save", "Successfully", MessageBoxButtons.OK);

                        Clear();

                        dgvBookingDetail.Refresh();
                        ShowData();

                    }

                }

            }

        }

        public void Clear()
        {
            txtBID.Clear();
            txtPName.Text = "";
            txtDisease.Text = "";

            txtSID.Clear();
            txtDName.Text = "";
            txtSType.Text = "";

            bntConfirm.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string BID = dgvBookingDetail.CurrentRow.Cells["Booking ID"].Value.ToString();

            if (BID == string.Empty)
            {
                MessageBox.Show("There is No Data");
            }

            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsBookingDetail.BOOKINGID = Convert.ToInt32(BID);
                    obj_clsBookingDetail.ACTION = 2;
                    obj_clsBookingDetail.SaveData();
                    MessageBox.Show("Successfully Delete");

                    ShowData();

                    Clear();
                    btnDelete.Enabled = false;
                    bntConfirm.Enabled = true;
                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvBookingDetail.Rows.Count > 1)
            {
                DataTable DT = new DataTable();
                DT = obj_clsMainClass.SelectData(SPString);

                frm_Report frmReport = new frm_Report();
                //crpt_BookingDetail crpt = new crpt_BookingDetail();
                //crpt.SetDataSource(DT);
                // frmReport.crystalReportViewer1.ReportSoure = crpt;
                frmReport.ShowDialog();
                ShowData();
            }

            else
            {
                MessageBox.Show("There is No Data");
            }

        }

        private void dgvBookingDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if(dgvBookingDetail.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is No Data");
                Clear();
                bntConfirm.Enabled = true;
            }
        }

        private void btnCheckBID_Click(object sender, EventArgs e)
        {
            int BID = 0;

            bool res = Int32.TryParse(txtBID.Text, out BID);

            if (res == true)
            {

                SPString = string.Format("SP_Select_BookingDetail'{0}',N'{1}',N'{2}'", BID, "0", "5");
                DT = obj_clsMainClass.SelectData(SPString);

                if (DT.Rows.Count > 0)
                {
                    txtPName.Text = DT.Rows[0]["PatientName"].ToString();
                    txtDisease.Text = DT.Rows[0]["Disease"].ToString();
                }

                else
                {
                    MessageBox.Show("Booking ID is not Exist");
                    txtBID.Focus();
                    txtBID.SelectAll();
                    Clear();
                }
            }

            else
            {
                txtBID.Clear();
                txtPName.Text = "";
                txtDisease.Text = "";
            }
        }

        private void btnCheckSID_Click(object sender, EventArgs e)
        {
            int SID = 0;

            bool res = Int32.TryParse(txtSID.Text, out SID);

            if (res == true)
            {

                SPString = string.Format("SP_Select_BookingDetail '{0}',N'{1}',N'{2}'", SID, "0", "3");
                DT = obj_clsMainClass.SelectData(SPString);

                if (DT.Rows.Count > 0)
                {
                    txtDName.Text = DT.Rows[0]["DoctorName"].ToString();
                    txtSType.Text = DT.Rows[0]["SpecialistType"].ToString();
                }

                else
                {
                    MessageBox.Show("Schedule ID is not Exist");
                    txtSID.Focus();
                    txtSID.SelectAll();
                    // Clear();
                }
            }

            else
            {
                txtSID.Clear();
                txtDName.Text = "";
                txtSType.Text = "";
            }
        }

        private void dgvBookingDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowEntry();
            btnDelete.Enabled = true;
            bntConfirm.Enabled = false;
        }
    }
}
