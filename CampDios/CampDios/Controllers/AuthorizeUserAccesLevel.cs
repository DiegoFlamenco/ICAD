using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampDios.Modelos;

namespace System.Web.Mvc
{
    public class AuthorizeUserAccesLevel : AuthorizeAttribute
    {
        public bool UserRole { get; set; }
        public string Vista { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            CampDiosEntities db = new CampDiosEntities();
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            /*string currentUser = HttpContext.Current.User.Identity.Name.ToString();
            GetUserAction_Result res = db.GetUserAction(currentUser).FirstOrDefault();
            string CurrentUserLogin = res.Login;
            */

            //var usr = db.Usuarios.Where(u => u.Login == user.Login && u.Contraseña == user.Contraseña).FirstOrDefault();



            string currentUser = HttpContext.Current.User.Identity.Name.ToString();

            var res = db.Usuarios_Opciones.Where(u => u.Edicion == UserRole && u.Usuarios.Login == currentUser && u.Opciones.Nombre_Opciones == Vista).FirstOrDefault();

            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}