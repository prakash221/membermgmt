using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Services.IServices;
using Services.Services;

namespace MemberManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        IUserService userService;
        public LoginController()
        {
            userService = new UserService();
        }

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel Model)
        {
            var data = userService.CheckAuthorization(Model);
            if (data != null)
            {
                Session["UserData"] = data;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("ErrPage");
            }
        }
    }
}