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
    class clsDoctor
    {
        public int DOCTORID { get; set; }
        public string DOCTORNAME { get; set; }
        public string GENDER { get; set; }
        public int AGE { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }       
        public int FEES { get; set; }
        public int SPECIALISTID{ get; set; }
        public int ACTION { get; set; }

        clsMainClass obj_MainClass = new clsMainClass();

        public void SaveData()
        {
            try
            {
                obj_MainClass.DBCon();
                SqlCommand sql = new SqlCommand("SP_Insert_Doctor", obj_MainClass.con);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@DoctorID", DOCTORID);
                sql.Parameters.AddWithValue("@DoctorName", DOCTORNAME);
                sql.Parameters.AddWithValue("@Gender", GENDER);
                sql.Parameters.AddWithValue("@Age", AGE);
                sql.Parameters.AddWithValue("@Phone", PHONE);
                sql.Parameters.AddWithValue("@Email", EMAIL);      
                sql.Parameters.AddWithValue("@Fees", FEES);
                sql.Parameters.AddWithValue("@SpecialistID", SPECIALISTID);
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
