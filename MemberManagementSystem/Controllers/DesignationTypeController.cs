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
    public class DesignationTypeController : Controller
    {
        IDesignationTypeService designationTypeService;
        public DesignationTypeController()
        {
            designationTypeService = new DesignationTypeService();
        }
        // GET: DesignationType
        public ActionResult Index()
        {
            var data = designationTypeService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = designationTypeService.GetDesignationTypeById(Id);
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(DesignationTypeModel Model)
        {
            designationTypeService.Update(Model);
            var data = designationTypeService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(DesignationTypeModel Model)
        {
            designationTypeService.Save(Model);
            var data = designationTypeService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            designationTypeService.Delete(Id);
            var data = designationTypeService.ListAllData();
            return View("Index", data);
        }
    }
}