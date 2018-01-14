using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampDios.Modelos;

namespace System.Web.Mvc
{
    public class AuthorizeUserAccesLevel : AuthorizeAttribute
    {
        public string UserRole { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            CampDiosEntities db = new CampDiosEntities();
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            string currentUser = HttpContext.Current.User.Identity.Name.ToString();
            GetUserAction_Result res = db.GetUserAction(currentUser).FirstOrDefault();
            string CurrentUserLogin = res.Login;
            if (this.UserRole.Contains(CurrentUserLogin))
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