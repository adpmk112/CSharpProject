using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Hospital_Management.Forms;

namespace Hospital_Management.Classes
{
    class clsSchedule
    {
        public int SCHEDULEID { get; set; }
        public string STARTTIME { get; set; }
        public string ENDTIME { get; set; }
        public string DAY {get; set; }
        public int ACCEPTEDPATIENT { get; set; }
        public int DOCTORID { get; set; }
        public int ACTION { get; set; }

        clsMainClass obj_MainClass = new clsMainClass();
        
        public void SaveData()
        {
            try
            {
                obj_MainClass.DBCon();
                SqlCommand sql = new SqlCommand("SP_Insert_Schedule", obj_MainClass.con);
                sql.CommandType = CommandType.StoredProcedure;
  
                sql.Parameters.AddWithValue("@ScheduleID", SCHEDULEID);
                sql.Parameters.AddWithValue("@StartTime", STARTTIME);
                sql.Parameters.AddWithValue("@EndTime", ENDTIME);
                sql.Parameters.AddWithValue("@Day",DAY);
                sql.Parameters.AddWithValue("@AcceptedPatient", ACCEPTEDPATIENT);
                sql.Parameters.AddWithValue("@DoctorID", DOCTORID);
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
