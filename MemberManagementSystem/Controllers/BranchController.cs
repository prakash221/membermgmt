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
    public class BranchController : Controller
    {
        IBranchService branchService;
        IOrganizationLevelService organizationLevelService;
        public BranchController()
        {
            branchService = new BranchService();
            organizationLevelService = new OrganizationLevelService();
        }
        // GET: Branch
        public ActionResult Index()
        {
            var data = branchService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = branchService.GetBranchById(Id);

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

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(BranchModel Model)
        {
            branchService.Update(Model);
            var data = branchService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(BranchModel Model)
        {
            branchService.Save(Model);
            var data = branchService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            branchService.Delete(Id);
            var data = branchService.ListAllData();
            return View("Index", data);
        }
    }
}