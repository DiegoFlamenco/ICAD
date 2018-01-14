using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CampDios.Modelos;

namespace CampDios.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(Usuarios user)
        {
            using (CampDiosEntities db = new CampDiosEntities())
            {
                var usr = db.Usuarios.Where(u => u.Login == user.Login && u.Contraseña == user.Contraseña).FirstOrDefault();
                var opc = db.Usuarios_Opciones.Where(o => o.Opciones_Opciones_Id == user.)
                if (usr != null)
                {
                    Session["Usuarios_id"] = usr.Usuarios_id.ToString();
                    Session["Login"] = usr.Login.ToString();
                    Session["Permisos"] =
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o contraseña Incorrectos.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Usuarios_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}