using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebApp1.Models;
/// <summary>
/// Main objective of this controller class is register functionality
/// </summary>

namespace LearningWebApp1.Controllers
{
    
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserProfileViewModel userModel)
        {

            return View(userModel);
        }
    }
}