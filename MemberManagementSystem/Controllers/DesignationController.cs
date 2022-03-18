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
    public class DesignationController : Controller
    {
        IDesignationService designationService;
        IDesignationTypeService designationTypeService;
        public DesignationController()
        {
            designationService = new DesignationService();
            designationTypeService = new DesignationTypeService();
        }
        // GET: Designation
        public ActionResult Index()
        {
            var data = designationService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = designationService.GetDesignationById(Id);
            var data2 = designationTypeService.ListAllData();
            List<SelectListItem> designationtypelist = new List<SelectListItem>();
            foreach (DesignationTypeModel item in data2)
            {
                designationtypelist.Add(new SelectListItem
                {
                    Text = item.DesinationTypeName,
                    Value = item.DesignationTypeID.ToString()
                });
            }
            ViewBag.designationtypes = designationtypelist;
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var data2 = designationTypeService.ListAllData();
            List<SelectListItem> designationtypelist = new List<SelectListItem>();
            foreach (DesignationTypeModel item in data2)
            {
                designationtypelist.Add(new SelectListItem
                {
                    Text = item.DesinationTypeName,
                    Value = item.DesignationTypeID.ToString()
                });
            }
            ViewBag.designationtypes = designationtypelist;
            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(DesignationModel Model)
        {
            designationService.Update(Model);
            var data = designationService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(DesignationModel Model)
        {
            designationService.Save(Model);
            var data = designationService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            designationService.Delete(Id);
            var data = designationService.ListAllData();
            return View("Index", data);
        }
    }
}