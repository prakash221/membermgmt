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
    public class OrganizationSchemaController : Controller
    {
        IOrganizationSchemaService organizationSchemaService;
        public OrganizationSchemaController()
        {
            organizationSchemaService = new OrganizationSchemaService();
        }
        // GET: OrganizationSchema
        public ActionResult Index()
        {
            var data = organizationSchemaService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = organizationSchemaService.GetOrganizationSchemaById(Id);
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Save()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(OrganizationSchemaModel Model)
        {
            organizationSchemaService.Update(Model);
            var data = organizationSchemaService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Save(OrganizationSchemaModel Model)
        {
            organizationSchemaService.Save(Model);
            var data = organizationSchemaService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            organizationSchemaService.Delete(Id);
            var data = organizationSchemaService.ListAllData();
            return View("Index", data);
        }
    }
}