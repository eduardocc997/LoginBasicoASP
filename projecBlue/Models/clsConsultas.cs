using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using projecBlue.Models;
using System.Data;

namespace projecBlue.Models
{
    public class clsConsultas
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-3J5RQC4\\SQLEXPRESS; database=pruebas; integrated security=SSPI;");
        public DataTable Login(string user, string pass)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter com = new SqlDataAdapter("SELECT * FROM tblLogin WHERE usuario=@usuario AND pass=@pass", con);
                com.SelectCommand.Parameters.AddWithValue("@usuario", user);
                com.SelectCommand.Parameters.AddWithValue("@pass", pass);

                com.Fill(dt);
                con.Close();
                return dt;
            }
            catch
            {
                return dt;
            }
        }
    }
}