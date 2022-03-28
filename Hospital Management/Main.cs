using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital_Management.Forms;
using Hospital_Management.Classes;
using System.Data.SqlClient;

namespace Hospital_Management
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            mnuPatient.Enabled = false;
            mnuDoctor.Enabled = false;
            mnuBooking.Enabled = false;
            mnuBookingDetail.Enabled = false;
            mnuSchedule.Enabled = false;
            mnuSpecialist.Enabled = false;
        }

        private void mnuBooking_Click(object sender, EventArgs e)
        {
            frm_Booking frm = new frm_Booking();
            frm.ShowDialog();
        }

        private void mnuUserRegister_Click(object sender, EventArgs e)
        {
            frm_UserRegister frm = new frm_UserRegister();
            frm.ShowDialog();
        }

        private void mnuUserLogin_Click(object sender, EventArgs e)
        {
            if (mnuUserLogin.Text == "Logout")
            {
                
                if (MessageBox.Show("Are You Sure You Want To Logout", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    mnuUserLogin.Text = "LogIn";
                    mnuUserRegister.Enabled = true;
                    mnuPatient.Enabled = false;
                    mnuDoctor.Enabled = false;
                    mnuBooking.Enabled = false;
                    mnuBookingDetail.Enabled = false;
                    mnuSchedule.Enabled = false;
                    mnuSpecialist.Enabled = false;
                }
                return;
            }
            clsMainClass obj_clsMainClass = new clsMainClass();
            frm_UserLogin obj_frm_UserLogin = new frm_UserLogin();
            DataTable DT = new DataTable();
            String UserName;
            String Password;

        Start:
            obj_frm_UserLogin.txtUserName.Text = "";
            obj_frm_UserLogin.txtPassword.Text = "";
            if (obj_frm_UserLogin.ShowDialog() == DialogResult.OK)
            {

                if (obj_frm_UserLogin.txtUserName.Text.Trim().ToString() == string.Empty)
                {
                    MessageBox.Show("Please Type User Name");
                    obj_frm_UserLogin.txtUserName.Focus();
                    goto Start;
                }

                if (obj_frm_UserLogin.txtPassword.Text.Trim().ToString() == string.Empty)
                {
                    MessageBox.Show("Please Type Password");
                    obj_frm_UserLogin.txtPassword.Focus();
                    goto Start;
                }
                UserName = obj_frm_UserLogin.txtUserName.Text;
                Password = obj_frm_UserLogin.txtPassword.Text;


                string SPString = string.Format("SP_Select_UserSetting N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'",
                obj_frm_UserLogin.txtUserName.Text.Trim().ToString(),
                obj_frm_UserLogin.txtPassword.Text.Trim().ToString(),"0", "0", "2");
                DT = obj_clsMainClass.SelectData(SPString);

                if (DT.Rows.Count > 0)
                {
                    Program.UserID = Convert.ToInt32(DT.Rows[0]["UserID"].ToString());
                    mnuUserLogin.Text = "Logout";
                }
                else
                {
                    MessageBox.Show("Invalid UserName And Password");
                    goto Start;
                }
                mnuPatient.Enabled = true;
                mnuDoctor.Enabled = true;
                mnuBooking.Enabled = true;
                mnuBookingDetail.Enabled = true;
                mnuSchedule.Enabled = true;
                mnuSpecialist.Enabled = true;
                mnuUserRegister.Enabled = false;
            }

        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Patient frm = new frm_Patient();
            frm.ShowDialog();
        }

        private void mnuBookingDetail_Click(object sender, EventArgs e)
        {
            frm_BookingDetail frm = new frm_BookingDetail();
            frm.ShowDialog();
        }

        private void mnuDoctor_Click(object sender, EventArgs e)
        {
            frm_Doctor frm = new frm_Doctor();
            frm.ShowDialog();
        }

        private void mnuSpecialist_Click(object sender, EventArgs e)
        {
            frm_Specialist frm = new frm_Specialist();
            frm.ShowDialog();
        }

        private void mnuSchedule_Click(object sender, EventArgs e)
        {
            frm_Schedule frm = new frm_Schedule();
            frm.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
