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
    class clsPatient
    {
        public int PATIENTID { get; set; }
        public string PATIENTNAME { get; set; }
        public int  AGE { get; set; }
        public string GENDER { get; set; }
        public string DISEASE { get; set; }
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }
        public string DATE { get; set; }
        public int ACTION { get; set; }

        clsMainClass obj_MainClass = new clsMainClass();

        public void SaveData()
        {
            try
            {
                obj_MainClass.DBCon();
                SqlCommand sql = new SqlCommand("SP_Insert_Patient", obj_MainClass.con);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@action", ACTION);
                sql.Parameters.AddWithValue("@PatientID", PATIENTID);
                sql.Parameters.AddWithValue("@PatientName", PATIENTNAME);
                sql.Parameters.AddWithValue("@Age", AGE);
                sql.Parameters.AddWithValue("@Gender", GENDER);
                sql.Parameters.AddWithValue("@Disease", DISEASE);
                sql.Parameters.AddWithValue("@Phone", PHONE);
                sql.Parameters.AddWithValue("@Address", ADDRESS);
                sql.Parameters.AddWithValue("@Date", DATE);
                

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
