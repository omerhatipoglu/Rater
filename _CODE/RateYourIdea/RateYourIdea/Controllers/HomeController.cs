using RateYourIdea.BL.BLs.AnswerTypeBL;
using RateYourIdea.BL.BLs.UserBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateYourIdea.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserBL userBL;
        private readonly IAnswerTypeBL answerTypeBL;

        public HomeController()
        {
            userBL = new UserBL();
            answerTypeBL = new AnswerTypeBL();
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

        [HttpGet]
        public JsonResult GetAnswerTypes()
        {
            return Json(answerTypeBL.GetAnswerTypes(), JsonRequestBehavior.AllowGet);
        }
    }
}