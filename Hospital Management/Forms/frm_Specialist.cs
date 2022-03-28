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
using System.Data.SqlClient;

namespace Hospital_Management.Forms
{
    public partial class frm_Specialist : Form
    {
        public frm_Specialist()
        {
            InitializeComponent();
        }

        clsSpecialist obj_clsSpecialist = new clsSpecialist();
        clsMainClass obj_clsMainClass = new clsMainClass();
        DataTable DT = new DataTable();
        DataTable DTSpecialist = new DataTable();
        string SPString = "";
        int _SpecialsitID = 0;
        bool edit = false;

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Specialist N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            dgvSpecialist.DataSource = obj_clsMainClass.SelectData(SPString);
            dgvSpecialist.Columns[0].Width = (dgvSpecialist.Width / 100) * 10;
            dgvSpecialist.Columns[1].Width = (dgvSpecialist.Width / 100) * 35;
            dgvSpecialist.Columns[2].Width = (dgvSpecialist.Width / 100) * 63;
        }

        private void frm_Specialist_Load(object sender, EventArgs e)
        {
            txtSpecialistType.Text = "";
            txtSpecialistType.Focus();
            ShowData();
            btnDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            edit = false;
            Check();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
          if (MessageBox.Show("Are You Sure You Want To Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsSpecialist.SPECIALISTID = Convert.ToInt32(dgvSpecialist.CurrentRow.Cells["SpecialistID"].Value.ToString());
                    obj_clsSpecialist.ACTION = 2;
                    obj_clsSpecialist.SaveData();
                    MessageBox.Show("Delete Successfully");
                    btnDelete.Enabled = false;
                    ShowData();
                }
        }
        private void Clear()
        {
            txtSpecialistType.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Check()
        {
            if (txtSpecialistType.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Specialist Name");
                txtSpecialistType.Focus();
            }
            else
            {
                SPString = string.Format("SP_Select_Specialist N'{0}',N'{1}',N'{2}'", txtSpecialistType.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMainClass.SelectData(SPString);
                if (DT.Rows.Count > 0 && _SpecialsitID != Convert.ToInt32(DT.Rows[0]["SpecialistID"]))
                {
                    MessageBox.Show("This Specialist Type Is Already Exist");
                    txtSpecialistType.Focus();
                }
                else
                {
                    obj_clsSpecialist.SPECIALISTID = _SpecialsitID;
                    obj_clsSpecialist.SPECIALSITTYPE = txtSpecialistType.Text;
                    if (edit)
                    {
                        obj_clsSpecialist.ACTION = 1;
                        obj_clsSpecialist.SaveData();
                        MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK);
                        dgvSpecialist.Refresh();
                        ShowData();
                        Clear();
                    }
                    else
                    {
                        obj_clsSpecialist.ACTION = 0;
                        obj_clsSpecialist.SaveData();
                        MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK);
                        dgvSpecialist.Refresh();
                        ShowData();
                        Clear();
                    }
                }
            }
        }

        private void dgvSpecialist_Click(object sender, EventArgs e)
        {
            if (dgvSpecialist.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data");
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }
            }
    }
}
