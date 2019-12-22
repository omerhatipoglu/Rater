using RateYourIdea.BL.BLs.UserBL;
using RateYourIdea.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RateYourIdea.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserBL userBL;
        public AccountController()
        {
            userBL = new UserBL();
        }
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            //var user = userBL.GetUsers().Data.FirstOrDefault(x => x.UserName == username && x.Password == password);


            //NOTE:  web config , global.asax and extension folder

            if(username=="asd" && password=="asd")//user!=null)
            {
                var authTicket = new FormsAuthenticationTicket(   
                1,                                                // version
                username,                                         // username
                DateTime.Now,                                     // issue date
                DateTime.Now.AddMinutes(20),                      // expire date
                true,                                             // remember me 
                Enum.GetName(typeof(AppRoles),AppRoles.Admin));   // role as string 

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}