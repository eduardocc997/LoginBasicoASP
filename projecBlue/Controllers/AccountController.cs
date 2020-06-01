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
            int idLogeado = consulta.Login(acc.Name, acc.Password);
            if (idLogeado == 0)
            {
                return View("Error");
            }
            else
            {
                return View("Create");
            }
        }
    }
}