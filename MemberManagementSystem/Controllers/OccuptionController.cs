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
    public class OccuptionController : Controller
    {
        IOccuptionService occuptionService;
        public OccuptionController()
        {
            occuptionService = new OccupationService();
        }
        // GET: Occuption
        public ActionResult Index()
        {
            var data = occuptionService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = occuptionService.GetOccuptionById(Id);
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Save()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(OccupationModel Model)
        {
            occuptionService.Update(Model);
            var data = occuptionService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Save(OccupationModel Model)
        {
            occuptionService.Save(Model);
            var data = occuptionService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            occuptionService.Delete(Id);
            var data = occuptionService.ListAllData();
            return View("Index", data);
        }
    }
}