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
using System.Data.SqlClient;

namespace Hospital_Management.Forms
{
    public partial class frm_UserRegister : Form
    {
        public frm_UserRegister()
        {
            InitializeComponent();
        }
        clsUserSetting obj_clsUserSetting = new clsUserSetting();
        clsMainClass obj_clsMainClass = new clsMainClass();
        DataTable DT = new DataTable();
        public int UserID = 0;
        string SPString = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
            Regex Ph = new Regex(@"^(0)(9)\d{9}$");
            Regex Ph1 = new Regex(@"^(0)[12]\d{6}$");
            Regex Ph2 = new Regex(@"^(0)[3-8]\d{7}$");
            Regex R = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");

            if (txtUserName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type UserName");
                txtUserName.Focus();
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
            else if (txtPassword.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Password");
                txtPassword.Focus();
            }
            else if (txtConfirmPassword.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type ConfirmPassword");
                txtConfirmPassword.Focus();
            }
            else if (txtPassword.Text.Trim().ToString() != txtConfirmPassword.Text.Trim().ToString())
            {
                MessageBox.Show("Password and ConfirmPassword Should Be Same");
                txtConfirmPassword.Focus();
                txtPassword.SelectAll();
            }
            else if (txtContactNo.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Contact No");
                txtContactNo.Focus();
            }
            else if ((Ph.IsMatch(txtContactNo.Text) || Ph1.IsMatch(txtContactNo.Text) || Ph2.IsMatch(txtContactNo.Text)) == false)
            {
                MessageBox.Show("Phone number is incorrect! Enter correctly");
                txtContactNo.Focus();
                txtContactNo.SelectAll();
            }
            else
            {
                SPString = string.Format("SP_Select_UserSetting N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'", txtUserName.Text.Trim().ToString(), txtPassword.Text.Trim().ToString(),
                txtContactNo.Text.Trim().ToString(), txtEmail.Text.Trim().ToString(), "1");
                DT = obj_clsMainClass.SelectData(SPString);
                if (DT.Rows.Count > 0 && UserID != Convert.ToInt32(DT.Rows[0]["UserID"].ToString()))
                {
                    MessageBox.Show("This User Is Already Exist!");
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                }
                else
                {
                    obj_clsUserSetting.USERNAME = txtUserName.Text.Trim().ToString();
                    obj_clsUserSetting.PASSWORD = txtPassword.Text.Trim().ToString();
                    obj_clsUserSetting.CONFIRMPASSWORD = txtConfirmPassword.Text.Trim().ToString();
                    obj_clsUserSetting.CONTACTNO = txtContactNo.Text.Trim().ToString();
                    obj_clsUserSetting.EMAIL = txtEmail.Text.Trim().ToString();
                    obj_clsUserSetting.ACTION = 0;
                    obj_clsUserSetting.SaveData();
                    MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK);
                    this.Close();
                }
                Clear();
                AutoRetriveID();
            }


        }

        private void frm_UserRegister_Load(object sender, EventArgs e)
        {
            lblUserID.Text = "1";
            AutoRetriveID();
            Clear();
        }
        private void Clear()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtContactNo.Text = "";
            txtEmail.Text = "";
            txtUserName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AutoRetriveID()
        {
            SqlConnection con = new SqlConnection(Hospital_Management.Properties.Settings.Default.HMSCon);

            try
            {
                SPString = string.Format("SP_Select_UserSetting N'{0}',N'{1}','{2}'", "0", "0", "0");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(SPString, con);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString()) + 1;
                    lblUserID.Text = value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

    }
}
