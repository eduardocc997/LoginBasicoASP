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
        public int Login(string user, string pass)
        {
            try
            {
                SqlDataAdapter com = new SqlDataAdapter("SELECT * FROM tblLogin WHERE usuario=@usuario AND pass=@pass", con);
                com.SelectCommand.Parameters.AddWithValue("@usuario", user);
                com.SelectCommand.Parameters.AddWithValue("@pass", pass);
                DataTable dt = new DataTable();
                com.Fill(dt);
                con.Close();
                int cantidad = dt.Rows.Count;
                if (cantidad != 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["id"]); //Regresamos el ID del usuario logeado
                }
                else
                {
                    return 0; // si no se encontro el usuario o hubo un error
                }
            }
            catch
            {
                return 0; // si no se encontro el usuario o hubo un error
            }
        }
    }
}