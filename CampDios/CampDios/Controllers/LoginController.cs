using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CampDios.Modelos;
using System.Web.Security;

namespace CampDios.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dologin(Usuarios user)
        {
            using (CampDiosEntities db = new CampDiosEntities())
            {
                var usr = db.Usuarios.Where(u => u.Login == user.Login && u.Contraseña == user.Contraseña).FirstOrDefault();
                //var opc = db.Usuarios_Opciones.Where(o => o.Opciones_Opciones_Id == user.)
                if (usr != null)
                {
                    FormsAuthentication.SetAuthCookie(usr.Login,false);
                    Session["Usuarios_id"] = usr.Usuarios_id.ToString();
                    Session["Login"] = usr.Login.ToString();
                    //Session["Permisos"] =
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o contraseña Incorrectos.");
                }
            }
            return View("login");
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