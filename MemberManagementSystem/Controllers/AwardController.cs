using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Services.Services;
using Services.IServices;
namespace MemberManagementSystem.Controllers
{
    public class AwardController : Controller
    {
        IAwardService awardService;
        public AwardController()
        {
            awardService = new AwardService();
        }
        // GET: Award
        public ActionResult Index()
        {
            var data = awardService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = awardService.GetAwardById(Id);
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Save()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(AwardModel Model)
        {
            awardService.Update(Model);
            var data = awardService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Save(AwardModel Model)
        {
            awardService.Save(Model);
            var data = awardService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            awardService.Delete(Id);
            var data = awardService.ListAllData();
            return View("Index", data);
        }
    }
}