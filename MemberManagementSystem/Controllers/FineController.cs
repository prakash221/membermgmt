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
    public class FineController : Controller
    {
        IFineService fineService;
        IDesignationService designationService;
        IOrganizationLevelService organizationLevelService;

        public FineController()
        {
            fineService = new FineService();
            designationService = new DesignationService();
            organizationLevelService = new OrganizationLevelService();
        }
        // GET: Fine
        public ActionResult Index()
        {
            var data = fineService.ListAllData();
           
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = fineService.GetFineById(Id);
            var data2 = organizationLevelService.ListAllData();
            List<SelectListItem> organizationlevellist = new List<SelectListItem>();
            foreach (OrganizationLevelModel item in data2)
            {
                organizationlevellist.Add(new SelectListItem
                {
                    Text = item.OrganizationLevelName,
                    Value = item.OrganizationLevelID.ToString()
                });
            }
            ViewBag.organizationlevels = organizationlevellist;

            var data3 = designationService.ListAllData();
            List<SelectListItem> designationlist = new List<SelectListItem>();
            foreach (DesignationModel item in data3)
            {
                designationlist.Add(new SelectListItem
                {
                    Text = item.DesignationName,
                    Value = item.DesignationID.ToString()
                });
            }
            ViewBag.designations = designationlist;

            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var data2 = organizationLevelService.ListAllData();
            List<SelectListItem> organizationlevellist = new List<SelectListItem>();
            foreach (OrganizationLevelModel item in data2)
            {
                organizationlevellist.Add(new SelectListItem
                {
                    Text = item.OrganizationLevelName,
                    Value = item.OrganizationLevelID.ToString()
                });
            }
            ViewBag.organizationlevels = organizationlevellist;

            var data3 = designationService.ListAllData();
            List<SelectListItem> designationlist = new List<SelectListItem>();
            foreach (DesignationModel item in data3)
            {
                designationlist.Add(new SelectListItem
                {
                    Text = item.DesignationName,
                    Value = item.DesignationID.ToString()
                });
            }
            ViewBag.designations = designationlist;

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(FineModel Model)
        {
            fineService.Update(Model);
            var data = fineService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(FineModel Model)
        {
            fineService.Save(Model);
            var data = fineService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            fineService.Delete(Id);
            var data = fineService.ListAllData();
            return View("Index", data);
        }
    }
}