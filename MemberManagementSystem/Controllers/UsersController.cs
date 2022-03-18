using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Services;
using Services.IServices;
using Model;
namespace MemberManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        IUserService userService;
        IMemberService memberService;
        public UsersController()
        {
            userService = new UserService();
            memberService = new MemberService();
        }
        // GET: User
        public ActionResult Index()
        {
            var data = userService.ListAllData();
            
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = userService.GetUserById(Id);
            var data2 = memberService.ListAllData();
            List<SelectListItem> memberlist = new List<SelectListItem>();
            foreach (MemberModel item in data2)
            {
                memberlist.Add(new SelectListItem
                {
                    Text = item.FirstName + " " + item.LastName,
                    Value = item.MemberID.ToString()
                });
            }
            ViewBag.Members = memberlist;
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var data2 = memberService.ListAllData();
            List<SelectListItem> memberlist = new List<SelectListItem>();
            foreach (MemberModel item in data2)
            {
                memberlist.Add(new SelectListItem
                {
                    Text = item.FirstName + " " + item.LastName,
                    Value = item.MemberID.ToString()
                });
            }
            ViewBag.Members = memberlist;
            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(UserModel Model)
        {
            userService.Update(Model);
            var data = userService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(UserModel Model)
        {
            userService.Save(Model);
            var data = userService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            userService.Delete(Id);
            var data = userService.ListAllData();
            return View("Index", data);
        }
    }
}