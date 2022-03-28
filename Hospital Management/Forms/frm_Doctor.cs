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
    public partial class frm_Doctor : Form
    {
        public frm_Doctor()
        {
            InitializeComponent();
        }

        clsDoctor obj_clsDoctor = new clsDoctor();
        clsMainClass obj_clsMainClass = new clsMainClass();
        string SPString = "";
        int DoctorID = 0;
     Regex R = new Regex((@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$"));

            Regex Ph = new Regex(@"^(0)(9)\d{9}$");
            Regex Ph1 = new Regex(@"^(0)[12]\d{6}$");
            Regex Ph2 = new Regex(@"^(0)[3-8]\d{7}$");

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Doctor N'{0}',N'{1}',N'{2}',N'{3}'",
            "0", "0", "0", "0");
            dgvDoctor.DataSource = obj_clsMainClass.SelectData(SPString);

            dgvDoctor.Columns[0].Width = (dgvDoctor.Width / 100) * 10;
            dgvDoctor.Columns[1].Visible = false;
            dgvDoctor.Columns[2].Width = (dgvDoctor.Width / 100) * 26;
            dgvDoctor.Columns[3].Visible = false;
            dgvDoctor.Columns[4].Visible = false;
            dgvDoctor.Columns[5].Width = (dgvDoctor.Width / 100) * 20;
            dgvDoctor.Columns[6].Width = (dgvDoctor.Width / 100) * 33;
            dgvDoctor.Columns[7].Visible = false;
            dgvDoctor.Columns[8].Visible = false;
            dgvDoctor.Columns[9].Width = (dgvDoctor.Width / 100) * 20;

        }
        private void ShowEntry()
        {
            if (dgvDoctor.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is No Data");
            }

            else
            {

                DoctorID =
                Convert.ToInt32(dgvDoctor.CurrentRow.Cells["DoctorID"].Value.ToString());
                txtName.Text =
                dgvDoctor.CurrentRow.Cells["DoctorName"].Value.ToString();
                txtAge.Text = dgvDoctor.CurrentRow.Cells["Age"].Value.ToString();
                txtPhone.Text = dgvDoctor.CurrentRow.Cells["Phone"].Value.ToString();
                txtEmail.Text = dgvDoctor.CurrentRow.Cells["Email"].Value.ToString();
                txtFees.Text = dgvDoctor.CurrentRow.Cells["Fees"].Value.ToString();
                coboType.SelectedValue =
                dgvDoctor.CurrentRow.Cells["SpecialistID"].Value.ToString();
                dgvGender();
            }
        }
        public void SelectSpecialistType()
        {
            SPString = string.Format("SP_Select_Specialist N'{0}',N'{1}',N'{2}'", "0","0", "2");
            DataTable DT = new DataTable();
            DT = obj_clsMainClass.SelectData(SPString);

            if (DT.Rows.Count > 0)
            {
                DataRow DR = DT.NewRow();
                DR[0] = 0;
                DR[1] = "Choose Type";
                DT.Rows.InsertAt(DR, 0);
                coboType.DataSource = DT;
                coboType.DisplayMember = "SpecialistType";
                coboType.ValueMember = "SpecialistID";
            }
        }

        public string Gender()
        {
            string g;
            if (rdoMale.Checked == true)
            {
                g = "Male";
            }

            else
            {
                g = "Female";
            }
            return g;
        }


        public void dgvGender()
        {
            if (dgvDoctor.CurrentRow.Cells["Gender"].Value.ToString() == "Male")
            {
                rdoMale.Checked = true;
            }

            else if (dgvDoctor.CurrentRow.Cells["Gender"].Value.ToString() == "Female")
            {
                rdoFemale.Checked = true;
            }
        }

        public void clear()
        {
            tslLabel.Text = "Search List";
            txtName.Text = "";
            txtAge.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtFees.Text = "";
            SelectSpecialistType();
            txtName.Focus();
            tstSearchWith.Text = "";
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Ok;

            if (txtName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Doctor Name");
                txtName.Focus();
            }

            else if (rdoMale.Checked == false && rdoFemale.Checked == false)
            {
                MessageBox.Show("Please Choose Gender");
            }


            else if (txtAge.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Age");
                txtAge.Focus();
            }

            else if (int.TryParse(txtAge.Text, out Ok) == false)
            {
                MessageBox.Show("Age should be Number");
                txtAge.Focus();
                txtAge.SelectAll();
            }

            else if (Convert.ToInt32(txtAge.Text) < 18 || Convert.ToInt32(txtAge.Text)
            > 130)
            {
                MessageBox.Show("Age should be between 18 and 130");
                txtAge.Focus();
                txtAge.SelectAll();
            }

            else if (txtPhone.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Phone");
                txtPhone.Focus();
            }

            else if ((Ph.IsMatch(txtPhone.Text) || Ph1.IsMatch(txtPhone.Text) || Ph2.IsMatch(txtPhone.Text)) == false)
            {
                MessageBox.Show("Phone number is incorrect! Enter correctly");
                txtPhone.Focus();
            }

            else if (txtEmail.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Email");
                txtEmail.Focus();
            }

            else if (R.IsMatch(txtEmail.Text) == false)
            {
                MessageBox.Show("Email not Correct");
                txtEmail.Focus();
                txtEmail.SelectAll();
            }

            else if (txtFees.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Fees");
                txtFees.Focus();
            }

            else if (Convert.ToInt64(txtFees.Text) < 5000 ||
            Convert.ToInt64(txtFees.Text) > 1000000)
            {
                MessageBox.Show("Fees should be between 5000 and 1000000");
                txtFees.Focus();
                txtFees.SelectAll();
            }


            else if (int.TryParse(txtFees.Text, out Ok) == false)
            {
                MessageBox.Show("Fees should be Number");
                txtFees.Focus();
                txtFees.SelectAll();
            }

            else if (Convert.ToInt32(coboType.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Choose One Specialist Type");
                coboType.Focus();
            }

            else
            {
                SPString = string.Format("SP_Select_Doctor N'{0}', N'{1}', N'{2}', N'{3}'",
                    txtName.Text.Trim().ToString(), Convert.ToInt32(txtAge.Text).ToString(),
                Convert.ToInt32(txtSID.Text), "3");
                DataTable DT = new DataTable();
                DT = obj_clsMainClass.SelectData(SPString);


                if (DT.Rows.Count > 0 && 0 != Convert.ToInt32(DT.Rows[0]["DoctorID"]))
                {
                    MessageBox.Show("This Doctor is Already Exist");
                    txtName.Focus();
                    txtName.SelectAll();
                }

                else
                {
                    obj_clsDoctor.DOCTORID = DoctorID;
                    obj_clsDoctor.DOCTORNAME = txtName.Text;
                    obj_clsDoctor.GENDER = Gender();
                    obj_clsDoctor.AGE = Convert.ToInt32(txtAge.Text);
                    obj_clsDoctor.PHONE = txtPhone.Text;
                    obj_clsDoctor.EMAIL = txtEmail.Text;
                    obj_clsDoctor.FEES = Convert.ToInt32(txtFees.Text);
                    obj_clsDoctor.SPECIALISTID = Convert.ToInt32(coboType.SelectedValue.ToString());

                    obj_clsDoctor.ACTION = 0;
                    obj_clsDoctor.SaveData();
                    MessageBox.Show("Successfully Save", "Successfully",
                    MessageBoxButtons.OK);
                }

                ShowData();
                dgvDoctor.Refresh();
                clear();

            }
        }

        private void frm_Doctor_Load(object sender, EventArgs e)
        {
            ShowData();
            SelectSpecialistType();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            tslLabel.Text = "Search List";
        }
    
        private void btnClose_Click(object sender, EventArgs e)
        {
            clear();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int Ok;

            if (txtName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Doctor Name");
                txtName.Focus();
            }

            else if (rdoMale.Checked == false && rdoFemale.Checked == false)
            {
                MessageBox.Show("Please Choose Gender");
            }


            else if (txtAge.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Age");
                txtAge.Focus();
            }

            else if (int.TryParse(txtAge.Text, out Ok) == false)
            {
                MessageBox.Show("Age should be Number");
                txtAge.Focus();
                txtAge.SelectAll();
            }

            else if (Convert.ToInt32(txtAge.Text) < 0 || Convert.ToInt32(txtAge.Text) >
            130)
            {
                MessageBox.Show("Age should be between 0 and 130");
                txtAge.Focus();
                txtAge.SelectAll();
            }

            else if ((Ph.IsMatch(txtPhone.Text) || Ph1.IsMatch(txtPhone.Text) || Ph2.IsMatch(txtPhone.Text)) == false)
            {
                MessageBox.Show("Phone number is incorrect! Enter correctly");
                txtPhone.Focus();
            }

            else if (Ph.IsMatch(txtPhone.Text) == false)
            {
                MessageBox.Show("Phone number is incorrect! Enter correctly");
                txtPhone.SelectAll();
                txtPhone.Focus();
            }


            else if (txtEmail.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Email");
                txtEmail.Focus();
            }

            else if (R.IsMatch(txtEmail.Text) == false)
            {
                MessageBox.Show("Email not Correct");
                txtEmail.Focus();
                txtEmail.SelectAll();
            }

            else if (txtFees.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Fees");
                txtFees.Focus();
            }

            else if (int.TryParse(txtFees.Text, out Ok) == false)
            {
                MessageBox.Show("Fees should be Number");
                txtFees.Focus();
                txtFees.SelectAll();
            }

            else if (Convert.ToInt32(coboType.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Choose One Specialist Type");
                coboType.Focus();
            }

            else
            {
                obj_clsDoctor.DOCTORID = DoctorID;
                obj_clsDoctor.DOCTORNAME = txtName.Text;
                obj_clsDoctor.GENDER = Gender();
                obj_clsDoctor.AGE = Convert.ToInt32(txtAge.Text);
                obj_clsDoctor.PHONE = txtPhone.Text;
                obj_clsDoctor.EMAIL = txtEmail.Text;
                obj_clsDoctor.FEES = Convert.ToInt32(txtFees.Text);
                obj_clsDoctor.SPECIALISTID = Convert.ToInt32(txtSID.Text);

                obj_clsDoctor.ACTION = 1;
                obj_clsDoctor.SaveData();

                if (MessageBox.Show("Successfully Update", "Successfully",
                MessageBoxButtons.OK) == DialogResult.OK)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = true;
                }
                ShowData();
                dgvDoctor.Refresh();
                clear();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string DID = dgvDoctor.CurrentRow.Cells["DoctorID"].Value.ToString();

            if (DID == string.Empty)
            {
                MessageBox.Show("There is No Data");
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }

            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsDoctor.DOCTORID = Convert.ToInt32(DID);
                    obj_clsDoctor.ACTION = 2;
                    obj_clsDoctor.SaveData();
                    MessageBox.Show("Successfully Delete");

                    ShowData();

                    clear();

                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = true;

                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmName_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "DoctorName";
            SPString = string.Format("SP_Select_Doctor N'{0}',N'{1}',N'{2}',N'{3}'",
            "0", "0", "0", "0");
            obj_clsMainClass.ToolStripTextBoxData(ref tstSearchWith, SPString,
            "DoctorName");
        }

        private void tsmType_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "SpecialistType";
            SPString = string.Format("SP_Select_Doctor N'{0}',N'{1}',N'{2}',N'{3}'",
            "0", "0", "0", "0");
            obj_clsMainClass.ToolStripTextBoxData(ref tstSearchWith, SPString,
            "SpecialistType");
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslLabel.Text == "DoctorName")
            {
                SPString = string.Format("SP_Select_Doctor N'{0}', N'{1}', N'{2}', N'{3}'",
                    tstSearchWith.Text.Trim(), "0", "0", "1");
            }

            else if (tslLabel.Text == "SpecialistType")
            {
                SPString = string.Format("SP_Select_Doctor N'{0}', N'{1}', N'{2}', N'{3}'",
                    tstSearchWith.Text.Trim(), "0", "0", "2");
            }

            if (tslLabel.Text == "Search List")
            {
                SPString = string.Format("SP_Select_Doctor N'{0}',N'{1}',N'{2}',N'{3}'", tstSearchWith.Text.Trim(), "0", "0", "0");
            }

            dgvDoctor.DataSource = obj_clsMainClass.SelectData(SPString);

        }

        private void coboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ID = coboType.SelectedValue.ToString();
            txtSID.Text = ID;
        }

        private void dgvDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDoctor.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data");
                clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
        }

        private void dgvDoctor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowEntry();

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
    }
}
