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
    public partial class frm_Booking : Form
    {
        public frm_Booking()
        {
            InitializeComponent();
        }
        clsBooking obj_clsBooking = new clsBooking();
        clsMainClass obj_clsMainClass = new clsMainClass();

        DataTable DT = new DataTable();
        string SPString = "";
        public void AutoRetriveID()
        {
            SqlConnection con = new SqlConnection(Hospital_Management.Properties.Settings.Default.HMSCon);

            try
            {
                SPString = string.Format("SP_Select_Booking N'{0}',N'{1}','{2}'", "0","0", "0");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(SPString, con);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString()) + 1;
                    lblBookingID.Text = value.ToString();
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
        public void SelectPatientName()
        {
            DataTable DT = new DataTable();
            SPString = string.Format("SP_Select_Patient  N'{0}', N'{1}', N'{2}',N'{3}'", "0", "0","0", "0");
            DT = obj_clsMainClass.SelectData(SPString);
            if (DT.Rows.Count > 0)
            {
                DataRow DR = DT.NewRow();
                DR[0] = 0;
                DR[1] = "Choose Patient Name";
                DT.Rows.InsertAt(DR, 0);
                coboPatientName.DataSource = DT;
                coboPatientName.DisplayMember = "PatientName";
                coboPatientName.ValueMember = "PatientID";
            }
        }
        public void SelectUserName()
        {
            /*   DataTable DT = new DataTable();
               SPString = SPString = string.Format("SP_Select_UserSetting  N'{0}', N'{1}', '{2}'", "0", "0", "0");
               DT = obj_clsMainClass.SelectData(SPString);
               if (DT.Rows.Count > 0)
               {
                   DataRow DR = DT.NewRow();
                   DR[0] = 0;
                   DR[1] = "Choose User Name";
                   DT.Rows.InsertAt(DR, 0);
                   coboUserName.DataSource = DT;
                   coboUserName.DisplayMember = "UserName";
                   coboUserName.ValueMember = "UserID"; 
                } */
            DataTable DT = new DataTable();
            SPString = string.Format("SP_Select_UserSetting N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'",
                Program.UserID.ToString(), "0", "0", "0", "3");
            DT = obj_clsMainClass.SelectData(SPString);
            lblUserName.Text = DT.Rows[0]["UserName"].ToString();
            lblUID.Text = Program.UserID.ToString();
        }

        private void frm_Booking_Load(object sender, EventArgs e)
        {
            lblBookingID.Text = "1";
            AutoRetriveID();
            SelectPatientName();
            SelectUserName();

            lblPID.Text = "";
        }

        private void coboPatientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = coboPatientName.SelectedValue.ToString();
            lblPID.Text = ID;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblPID.Text == "")
            {
                MessageBox.Show("Choose Patient Name");

            }

            else
            {
                SPString = string.Format("SP_Select_Booking N'{0}',N'{1}','{2}'",
                dtpBookingDate.Text, Convert.ToInt32(lblPID.Text), "2");
                DT = obj_clsMainClass.SelectData(SPString);

                if (DT.Rows.Count > 0 && 0 != Convert.ToInt32(DT.Rows[0]["BookingID"]))
                {
                    MessageBox.Show("Booking has been taken by this patient today!");
                    coboPatientName.Focus();

                }

                else
                {
                    obj_clsBooking.BOOKINGID = Convert.ToInt32(lblBookingID.Text);
                    obj_clsBooking.BOOKINGDATE = dtpBookingDate.Text;
                    obj_clsBooking.PATIENTID = Convert.ToInt32(lblPID.Text);
                    obj_clsBooking.USERID = Convert.ToInt32(lblUID.Text);
                    obj_clsBooking.ACTION = 0;
                    obj_clsBooking.SaveData();

                    MessageBox.Show("Successfully Save", "Successfully",
                    MessageBoxButtons.OK);
                    SelectPatientName();
                    SelectUserName();
                    AutoRetriveID();
                    lblPID.Text = "";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpBookingDate_ValueChanged(object sender, EventArgs e)
        {
            SPString = string.Format("SP_Select_Booking N'{0}',N'{1}','{2}'",dtpBookingDate.Text, "0", "1");
            DT = obj_clsMainClass.SelectData(SPString);

            int DateDiff = Convert.ToInt32(DT.Rows[0]["Date"]);
            if (DateDiff > 0)
            {
                MessageBox.Show("Please Checck Booking Date");
                dtpBookingDate.Text = DateTime.Now.ToShortDateString();
            }

            else if (DateDiff <= -7)
            {
                MessageBox.Show("Please Check Booking Date");
                dtpBookingDate.Text = DateTime.Now.ToShortDateString();
            }

        }
    }
}

