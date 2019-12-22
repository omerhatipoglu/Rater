using RateYourIdea.BL.BLs.UserBL;
using RateYourIdea.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateYourIdea.Controllers
{
    [CustomAuthorize(AppRoles.Admin)]
    public class HomeController : Controller
    {
        private readonly IUserBL userBL;

        public HomeController()
        {
            userBL = new UserBL();
        }
        // GET: Home
        public ActionResult Index()
        {
            var result = userBL.GetUsers();
            return View();
        }

        public ActionResult CreateQuestion()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        
    }
}