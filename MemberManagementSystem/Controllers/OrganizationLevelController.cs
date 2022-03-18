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
    public class OrganizationLevelController : Controller
    {
        IOrganizationLevelService organizationLevelService;
        public OrganizationLevelController()
        {
            organizationLevelService = new OrganizationLevelService();
        }
        // GET: OrganizationLevel
        public ActionResult Index()
        {
            var data = organizationLevelService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = organizationLevelService.GetOrganizationLevelById(Id);
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Save()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(OrganizationLevelModel Model)
        {
            organizationLevelService.Update(Model);
            var data = organizationLevelService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Save(OrganizationLevelModel Model)
        {
            organizationLevelService.Save(Model);
            var data = organizationLevelService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            organizationLevelService.Delete(Id);
            var data = organizationLevelService.ListAllData();
            return View("Index", data);
        }
    }
}