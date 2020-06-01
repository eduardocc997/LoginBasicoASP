using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projecBlue.Models;
using System.Data.SqlClient;
using System.Data;

namespace projecBlue.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            clsConsultas consulta = new clsConsultas();
            DataTable logeado = consulta.Login(acc.Name, acc.Password);
            if (logeado.Rows.Count != 0)
            {
                ViewBag.idLogeado = logeado.Rows[0]["id"];
                ViewBag.nombreLogeado = logeado.Rows[0]["usuario"];
                return View("Create");
            }
            else
            {
                ViewBag.Errores = "Verifica tu usuario o contraseña";
                return View("Login");
            }
        }
    }
}