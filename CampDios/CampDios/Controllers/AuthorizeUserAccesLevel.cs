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
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            string CurrentUserRole = "Admin";
            if (this.UserRole.Contains(CurrentUserRole))
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