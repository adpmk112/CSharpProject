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

namespace Hospital_Management.Forms
{
    public partial class frm_Schedule : Form
    {
        public frm_Schedule()
        {
            InitializeComponent();
        }
        clsMainClass obj_clsMainClass = new clsMainClass();
        clsSchedule obj_clsSchedule = new clsSchedule();
        DataTable DT = new DataTable();

        string ID = "ScheduleID";
        string SPString = "";
        public int _ScheduleID = 0;

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Schedule N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'", "0","0", "0", "0", "1"); 
            lblScheduleID.Text = obj_clsMainClass.GetID(SPString, ID);

            SPString = string.Format("SP_Select_Doctor N'{0}',N'{1}',N'{2}',N'{3}'", "0","0", "0", "4");
            obj_clsMainClass.AddCombo(ref cboDoctorName, SPString, "DoctorName", "DoctorID");

            SPString = string.Format("SP_Select_Schedule N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'", "0","0", "0","0", "2");
            dgvSchedule.DataSource = obj_clsMainClass.SelectData(SPString);

            dgvSchedule.Columns[0].Width = (dgvSchedule.Width / 100) * 6;
            dgvSchedule.Columns[1].Visible = false; 
            dgvSchedule.Columns[2].Width = (dgvSchedule.Width / 100) * 14;
            dgvSchedule.Columns[3].Width = (dgvSchedule.Width / 100) * 14;
            dgvSchedule.Columns[4].Width =  (dgvSchedule.Width / 100) * 14;
            dgvSchedule.Columns[5].Visible = false;
            dgvSchedule.Columns[6].Width = (dgvSchedule.Width / 100) * 19;
            dgvSchedule.Columns[7].Width = (dgvSchedule.Width / 100) * 19;
            dgvSchedule.Columns[8].Width = (dgvSchedule.Width / 100) * 19;

            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.CustomFormat = "HH:mm tt";
            dtpStartTime.ShowUpDown = true;
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.CustomFormat = "HH:mm tt";
            dtpEndTime.ShowUpDown = true;
        }
        private void frm_Schedule_Load(object sender, EventArgs e)
        {
            Clear();
            ShowData();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            String[] Sarr = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            cboDay.Items.AddRange(Sarr);
            cboDay.Text = "Select The Day";
        }
        public void Clear()
        {
            txtAPatient.Text = "";
            SPString = string.Format("SP_Select_Doctor N'{0}',N'{1}',N'{2}',N'{3}'","0", "0", "0", "4");
            obj_clsMainClass.AddCombo(ref cboDoctorName, SPString, "DoctorName", "DoctorID");
            SPString = string.Format("SP_Select_Schedule N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'","0", "0", "0", "0", "1");
            lblScheduleID.Text = obj_clsMainClass.GetID(SPString, ID);
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            dtpStartTime.Text = "00:00";
            dtpEndTime.Text = "00:00";
            cboDay.Text = "Select The Day";
            tstSpecialist.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Ok;

            if (int.TryParse(txtAPatient.Text, out Ok) == false)
            {
                MessageBox.Show("Enter Digit for Accepted Patient");
                txtAPatient.Focus();
                txtAPatient.SelectAll();
            }
            else
            {
                SPString = string.Format("SP_Select_Schedule N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'", cboDay.SelectedItem.ToString(),
                   Convert.ToInt32(cboDoctorName.SelectedValue).ToString(), dtpStartTime.Text, dtpEndTime.Text,"3");
                DT = obj_clsMainClass.SelectData(SPString);
                if (DT.Rows.Count > 0 && 0 != Convert.ToInt32(DT.Rows[0]["ScheduleID"]))
                {
                    MessageBox.Show("That Time is filled");
                    Clear();
                }
                else
                {
                    obj_clsSchedule.SCHEDULEID = _ScheduleID;
                    obj_clsSchedule.STARTTIME = dtpStartTime.Text;
                    obj_clsSchedule.ENDTIME = dtpEndTime.Text;
                    obj_clsSchedule.DAY = cboDay.SelectedItem.ToString();
                    obj_clsSchedule.ACCEPTEDPATIENT = Convert.ToInt32(txtAPatient.Text);
                    obj_clsSchedule.DOCTORID = Convert.ToInt32(cboDoctorName.SelectedValue.ToString());
                    obj_clsSchedule.ACTION = 0;
                    obj_clsSchedule.SaveData();
                    MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK);

                    ShowData();
                    dgvSchedule.Refresh();
                    dgvSchedule.Update();
                    SPString = string.Format("SP_Select_Schedule N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'", "0", "0", "0", "0", "1");
                    lblScheduleID.Text = obj_clsMainClass.GetID(SPString, ID);
                    Clear();
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Ok;

            if (int.TryParse(txtAPatient.Text, out Ok) == false)
            {
                MessageBox.Show("Enter Digit for Accepted Patient");
                txtAPatient.Focus();
                txtAPatient.SelectAll();
            }
            else
            { 
                obj_clsSchedule.SCHEDULEID = _ScheduleID;
                obj_clsSchedule.STARTTIME = dtpStartTime.Text;
                obj_clsSchedule.ENDTIME = dtpEndTime.Text;
                obj_clsSchedule.DAY = cboDay.SelectedItem.ToString();
                obj_clsSchedule.ACCEPTEDPATIENT = Convert.ToInt32(txtAPatient.Text);
                obj_clsSchedule.DOCTORID = Convert.ToInt32(cboDoctorName.SelectedValue.ToString());
                obj_clsSchedule.ACTION = 1;
                obj_clsSchedule.SaveData();
                MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK);

                ShowData();
                dgvSchedule.Refresh();
                dgvSchedule.Update();
                Clear();
                btnSave.Enabled = true;
                
            }
        }

        private void dgvSchedule_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSchedule.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data");
            }
            else
            {
                _ScheduleID = Convert.ToInt32(dgvSchedule.CurrentRow.Cells["ScheduleID"].Value.ToString());
                SPString = string.Format
                   ("SP_Select_Schedule N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'", _ScheduleID, "0", "0","0", "4");
                lblScheduleID.Text = obj_clsMainClass.DoubleClickID(SPString, ID);
                cboDoctorName.SelectedValue = dgvSchedule.CurrentRow.Cells["DoctorID"].Value.ToString();
                dtpStartTime.Text = dgvSchedule.CurrentRow.Cells["StartTime"].Value.ToString();
                dtpEndTime.Text = dgvSchedule.CurrentRow.Cells["EndTime"].Value.ToString();
                cboDay.SelectedItem = dgvSchedule.CurrentRow.Cells["Day"].Value.ToString();
                txtAPatient.Text = dgvSchedule.CurrentRow.Cells["AcceptedPatient"].Value.ToString();
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete", "Confirm", MessageBoxButtons.YesNo) ==
                  DialogResult.Yes)
            {
                obj_clsSchedule.SCHEDULEID = Convert.ToInt32(dgvSchedule.CurrentRow.Cells["ScheduleID"].
                    Value.ToString());
                obj_clsSchedule.ACTION = 2;
                obj_clsSchedule.SaveData();
                MessageBox.Show("Successfully Delete");
                ShowData();
                dgvSchedule.Update();
                dgvSchedule.Refresh();
                btnDelete.Enabled = false;
                Clear();
            }  
        }
        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSchedule.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data");
                Clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblScheduleID_Click(object sender, EventArgs e)
        {

        }

        private void tstSpecialist_TextChanged(object sender, EventArgs e)
        {
            SPString = string.Format("SP_Select_Schedule N'{0}', N'{1}', N'{2}', N'{3}',N'{4}'",
                       tstSpecialist.Text.Trim(),"0","0","0","5");
            dgvSchedule.DataSource = obj_clsMainClass.SelectData(SPString);
            if (tstSpecialist.Text.Trim() == "") 
            {
                SPString = string.Format("SP_Select_Schedule N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'", "0", "0", "0", "0", "2");
                dgvSchedule.DataSource = obj_clsMainClass.SelectData(SPString);
            }
        }
    }
}
