using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateYourIdea.Extensions
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(params AppRoles [] roles)
        {
            Roles = string.Join(",", Array.ConvertAll(roles, x => Enum.GetName(typeof(AppRoles), x)));
        }
    }

    public enum AppRoles
    {
        Admin=0,
        Developer,
        User,
        ProUser
    }


}