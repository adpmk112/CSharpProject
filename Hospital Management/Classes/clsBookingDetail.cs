using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Hospital_Management.Classes
{
    class clsBookingDetail
    {
        public int BOOKINGID { get; set; }
        public int SCHEDULEID { get; set; }
        public int ACTION { get; set; }

        clsMainClass obj_MainClass = new clsMainClass();

        public void SaveData()
        {
            try
            {
                obj_MainClass.DBCon();
                SqlCommand sql = new SqlCommand("SP_Insert_BookingDetail", obj_MainClass.con);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@BookingID", BOOKINGID);
                sql.Parameters.AddWithValue("@ScheduleID", SCHEDULEID);
                sql.Parameters.AddWithValue("@action", ACTION);

                sql.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In Save Data");
            }

            finally
            {
                obj_MainClass.con.Close();
            }

        }
    }
}
