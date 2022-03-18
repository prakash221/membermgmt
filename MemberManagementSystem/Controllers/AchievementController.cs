using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.IServices;
using Services.Services;
using Model;
namespace MemberManagementSystem.Controllers
{
    public class AchievementController : Controller
    {
        IAchievementService achievementService;
        IMemberService memberService;
        IAwardService awardService;
        public AchievementController()
        {
            achievementService = new AchievementService();
            memberService = new MemberService();
            awardService = new AwardService();
        }

        // GET: Achievement
        public ActionResult Index()
        {
            var data = achievementService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = achievementService.GetAchievementById(Id);

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

            var data3 = awardService.ListAllData();
            List<SelectListItem> awardlist = new List<SelectListItem>();
            foreach (AwardModel item in data3)
            {
                awardlist.Add(new SelectListItem
                {
                    Text = item.AwardName,
                    Value = item.AwardID.ToString()
                });
            }
            ViewBag.Awards = awardlist;
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var data2 = memberService.ListAllData();
            var data3 = awardService.ListAllData();
            List<SelectListItem> memberlist = new List<SelectListItem>();
            List<SelectListItem> awardlist = new List<SelectListItem>();
            foreach (MemberModel item in data2)
            {
                memberlist.Add(new SelectListItem
                {
                    Text = item.FirstName + " " + item.LastName,
                    Value = item.MemberID.ToString()
                });
            }
            ViewBag.Members = memberlist;
            foreach (AwardModel item in data3)
            {
                awardlist.Add(new SelectListItem
                {
                    Text = item.AwardName,
                    Value = item.AwardID.ToString()
                });
            }
            ViewBag.Awards = awardlist;
            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(AchievementModel Model)
        {
            achievementService.Update(Model);
            var data = achievementService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(AchievementModel Model)
        {
            achievementService.Save(Model);
            var data = achievementService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            achievementService.Delete(Id);
            var data = achievementService.ListAllData();
            return View("Index", data);
        }
    }
}