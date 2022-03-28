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
    class clsUserSetting
    {
        public int USERID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string CONFIRMPASSWORD { get; set; }
        public string CONTACTNO { get; set; }
        public int ACTION { get; set; }
        public string EMAIL { get; set; }

        clsMainClass obj_MainClass = new clsMainClass();

        public void SaveData()
        {
            try
            {
                obj_MainClass.DBCon();
                SqlCommand sql = new SqlCommand("SP_Insert_UserSetting", obj_MainClass.con);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@UserID", USERID);
                sql.Parameters.AddWithValue("@UserName", USERNAME);
                sql.Parameters.AddWithValue("@Password", PASSWORD);
                sql.Parameters.AddWithValue("@ConfirmPassword", CONFIRMPASSWORD);
                sql.Parameters.AddWithValue("@ContactNo", CONTACTNO);
                sql.Parameters.AddWithValue("@action", ACTION);
                sql.Parameters.AddWithValue("@Email", EMAIL);

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
