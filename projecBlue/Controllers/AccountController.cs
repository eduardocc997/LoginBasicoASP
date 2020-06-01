using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projecBlue.Models;
using System.Data.SqlClient;

namespace projecBlue.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-3J5RQC4\\SQLEXPRESS; database=pruebas; integrated security=SSPI;");
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {

            con.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM tblLogin WHERE usuario=@usuario AND pass=@pass", con);
            com.Parameters.AddWithValue("@usuario", acc.Name);
            com.Parameters.AddWithValue("@pass", acc.Password);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}