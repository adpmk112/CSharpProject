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
using System.Text.RegularExpressions;

namespace Hospital_Management.Forms
{
    public partial class frm_Patient : Form
    {
        clsPatient obj_clsPatient = new clsPatient();
        clsMainClass obj_clsMainClass = new clsMainClass();

        DataTable DT = new DataTable();
        string SPString = "";
        string value = "";
        public int _PatientID = 0;
        string ID = "PatientID";
        Regex Ph = new Regex(@"^(0)(9)\d{9}$");
        Regex Ph1 = new Regex(@"^(0)[12]\d{6}$");
        Regex Ph2 = new Regex(@"^(0)[3-8]\d{7}$");

        public frm_Patient()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowData()
        {
            SPString = string.Format
                ("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'", "0", "0", "0", "3");
            dgvPatient.DataSource = obj_clsMainClass.SelectData(SPString);

            dgvPatient.Columns[0].Width = (dgvPatient.Width / 100) * 5;
            dgvPatient.Columns[1].Visible = false;
            dgvPatient.Columns[2].Width = (dgvPatient.Width / 100) * 18;
            dgvPatient.Columns[3].Width = (dgvPatient.Width / 100) * 10;
            dgvPatient.Columns[4].Visible = false;
            dgvPatient.Columns[5].Width = (dgvPatient.Width / 100) * 15;
            dgvPatient.Columns[6].Width = (dgvPatient.Width / 100) * 15;
            dgvPatient.Columns[7].Width = (dgvPatient.Width / 100) * 18;
            dgvPatient.Columns[8].Width = (dgvPatient.Width / 100) * 13;

            tslLabel.Text = "--- Select ---";
        }
        private void frm_Patient_Load(object sender, EventArgs e)
        {
            Clear();
            ShowData();
            btnClear.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void RadioButton()
        {
            bool isChecked;
            if (isChecked = rdoMale.Checked)
                value = "Male";
            else
                value = "Female";
        }
        public void Clear()
        {
            tslLabel.Text = "--- Select ---";
            txtPatientName.Focus();
            txtPatientName.Text = "";
            txtAge.Text = "";
            txtDisease.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            SPString = string.Format
               ("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'", "0", "0", "0", "2");
            lblPatientID.Text = obj_clsMainClass.GetID(SPString, ID);
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            tstSearch.Text = "";
            dtpDate.Value = DateTime.Now;
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int Ok;

            if (txtPatientName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Patient Name");
                txtPatientName.Focus();
            }
            else if (txtAge.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Patient Age");
                txtAge.Focus();
            }
            else if (int.TryParse(txtAge.Text, out Ok) == false)
            {
                MessageBox.Show("Age Should Be Number");
                txtAge.Focus();
                txtAge.SelectAll();
            }
            else if (Convert.ToInt32(txtAge.Text) <= 0 || Convert.ToInt32(txtAge.Text) > 130)
            {
                MessageBox.Show("Age Should Be Between 0 and 130");
                txtAge.Focus();
                txtAge.SelectAll();
            }
            else if (rdoMale.Checked == false && rdoFemale.Checked == false)
            {
                MessageBox.Show("Please Choose Gender");
            }
            else if (txtDisease.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Disease");
                txtDisease.Focus();
            }
            else if (txtPhone.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Phone Number");
                txtPhone.Focus();
            }
            else if ((Ph.IsMatch(txtPhone.Text) || Ph1.IsMatch(txtPhone.Text) || Ph2.IsMatch(txtPhone.Text)) == false)
            {
                MessageBox.Show("Phone number is incorrect! Enter correctly");
                txtPhone.Focus();
                txtPhone.SelectAll();
            }
            else if (txtAddress.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Address");
                txtAddress.Focus();
            }
            else
            {
                SPString = string.Format
                    ("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'",
                    txtPatientName.Text.Trim().ToString(), txtPhone.Text.Trim().ToString(),
                    txtAddress.Text.Trim().ToString(), "1");
                DT = obj_clsMainClass.SelectData(SPString);

                if (DT.Rows.Count > 0 && 0 != Convert.ToInt32(DT.Rows[0]["PatientID"]))
                {
                    MessageBox.Show("This Patient Is Already Exist");
                    Clear();
                }
                else
                {
                    RadioButton();
                    obj_clsPatient.PATIENTID = _PatientID;
                    obj_clsPatient.PATIENTNAME = txtPatientName.Text;
                    obj_clsPatient.AGE = Convert.ToInt32(txtAge.Text);
                    obj_clsPatient.GENDER = value;
                    obj_clsPatient.DISEASE = txtDisease.Text;
                    obj_clsPatient.PHONE = txtPhone.Text;
                    obj_clsPatient.ADDRESS = txtAddress.Text;
                    obj_clsPatient.DATE = dtpDate.Text;
                    obj_clsPatient.ACTION = 0;
                    obj_clsPatient.SaveData();
                    MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK);
                    ShowData();
                    Clear();
                    dgvPatient.Update();
                    dgvPatient.Refresh();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Ok;

            if (txtPatientName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Patient Name");
                txtPatientName.Focus();
            }
            else if (txtAge.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Patient Age");
                txtAge.Focus();
            }
            else if (int.TryParse(txtAge.Text, out Ok) == false)
            {
                MessageBox.Show("Age Should Be Number");
                txtAge.Focus();
                txtAge.SelectAll();
            }
            else if (Convert.ToInt32(txtAge.Text) <= 0 || Convert.ToInt32(txtAge.Text) > 130)
            {
                MessageBox.Show("Age Should Be Between 0 and 130");
                txtAge.Focus();
                txtAge.SelectAll();
            }
            else if (rdoMale.Checked == false && rdoFemale.Checked == false)
            {
                MessageBox.Show("Please Choose Gender");
            }
            else if (txtDisease.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Disease");
                txtDisease.Focus();
            }
            else if (txtPhone.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Phone Number");
                txtPhone.Focus();
            }
            else if ((Ph.IsMatch(txtPhone.Text) || Ph1.IsMatch(txtPhone.Text) || Ph2.IsMatch(txtPhone.Text)) == false)
            {
                MessageBox.Show("Phone number is incorrect! Enter correctly");
                txtPhone.Focus();
                txtPhone.SelectAll();
            }
            else if (txtAddress.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Address");
                txtAddress.Focus();
            }
            else
            {
                RadioButton();
                obj_clsPatient.PATIENTID = _PatientID;
                obj_clsPatient.PATIENTNAME = txtPatientName.Text;
                obj_clsPatient.AGE = Convert.ToInt32(txtAge.Text);
                obj_clsPatient.GENDER = value;
                obj_clsPatient.DISEASE = txtDisease.Text;
                obj_clsPatient.PHONE = txtPhone.Text;
                obj_clsPatient.ADDRESS = txtAddress.Text;
                obj_clsPatient.DATE = dtpDate.Text;
                obj_clsPatient.ACTION = 1;
                obj_clsPatient.SaveData();
                MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK);
                Clear();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            ShowData();
            dgvPatient.Update();
            dgvPatient.Refresh();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete?", "Confirm", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                obj_clsPatient.PATIENTID = Convert.ToInt32(dgvPatient.CurrentRow.Cells["PatientID"].
                    Value.ToString());
                obj_clsPatient.ACTION = 2;
                obj_clsPatient.SaveData();
                MessageBox.Show("Successfully Delete");
                ShowData();
                dgvPatient.Update();
                dgvPatient.Refresh();
                btnDelete.Enabled = false;
                Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void tstSearch_TextChanged(object sender, EventArgs e)
        {
            if (tstSearch.Text.Trim() == "")
            {
                SPString = string.Format
               ("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'",
               "0", "0", "0", "3");
                dgvPatient.DataSource = obj_clsMainClass.SelectData(SPString);
            }
            else if (tslLabel.Text == "--- Select ---")
            {
                SPString = string.Format("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'",
               tstSearch.Text.Trim().ToString(), "0", "0", "3");
            }
            else if (tslLabel.Text == "PatientName")
            {
                SPString = string.Format("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'",
                  tstSearch.Text.Trim().ToString(), "0", "0", "5");
            }
            else if (tslLabel.Text == "Date")
            {
                SPString = string.Format("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'",
                   tstSearch.Text.Trim().ToString(), "0", "0", "4");
            }
            dgvPatient.DataSource = obj_clsMainClass.SelectData(SPString);
        }

        private void tsmPatientName_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "PatientName";
            SPString = string.Format
            ("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'",
            "0", "0", "0", "0");
            obj_clsMainClass.ToolStripTextBoxData(ref tstSearch, SPString, "PatientName");
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data");
                Clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
            else

            {
                btnDelete.Enabled = true;
            }
        }

        private void tsmDate_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "Date";
            SPString = string.Format
                ("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'", "0", "0", "0", "0");
            obj_clsMainClass.ToolStripTextBoxData(ref tstSearch, SPString, "Date");
        }

        private void dgvPatient_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvPatient.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data");
                Clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
            else
            {
                _PatientID = Convert.ToInt32(dgvPatient.CurrentRow.Cells["PatientID"].Value.ToString());
                SPString = string.Format
                   ("SP_Select_Patient N'{0}',N'{1}',N'{2}',N'{3}'", _PatientID, "0", "0", "6");
                lblPatientID.Text = obj_clsMainClass.DoubleClickID(SPString, ID);
                txtPatientName.Text = dgvPatient.CurrentRow.Cells["PatientName"].Value.ToString();
                txtAge.Text = dgvPatient.CurrentRow.Cells["Age"].Value.ToString();
                if (dgvPatient.CurrentRow.Cells["Gender"].Value.ToString() == "Male")
                {
                    rdoMale.Checked = true;
                }
                else if (dgvPatient.CurrentRow.Cells["Gender"].Value.ToString() == "Female")
                {
                    rdoFemale.Checked = true;
                }
                txtDisease.Text = dgvPatient.CurrentRow.Cells["Disease"].Value.ToString();
                txtPhone.Text = dgvPatient.CurrentRow.Cells["Phone"].Value.ToString();
                txtAddress.Text = dgvPatient.CurrentRow.Cells["Address"].Value.ToString();
                dtpDate.Text = dgvPatient.CurrentRow.Cells["Date"].Value.ToString();
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
                btnClear.Enabled = true;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
