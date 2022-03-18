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
    public class MemberController : Controller
    {
        IMemberService memberService;
        IDesignationService designationService;
        IBranchService branchService;
        IOccuptionService occuptionService;
        public MemberController()
        {
            memberService = new MemberService();
            designationService = new DesignationService();
            branchService = new BranchService();
            occuptionService = new OccupationService();
        }
        // GET: Memeber
        public ActionResult Index()
        {
            var data = memberService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = memberService.GetMemberById(Id);
            var data2 = branchService.ListAllData();
            List<SelectListItem> branchllist = new List<SelectListItem>();
            foreach (BranchModel item in data2)
            {
                branchllist.Add(new SelectListItem
                {
                    Text = item.BranchName,
                    Value = item.BranchID.ToString()
                });
            }
            ViewBag.branch = branchllist;

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
            var data4 = occuptionService.ListAllData();
            List<SelectListItem> occuptionlist = new List<SelectListItem>();
            foreach (OccupationModel item in data4)
            {
                occuptionlist.Add(new SelectListItem
                {
                    Text = item.OccupationName,
                    Value = item.OccupationID.ToString()
                });
            }
            ViewBag.occuption = occuptionlist;
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var data2 = branchService.ListAllData();
            List<SelectListItem> branchllist = new List<SelectListItem>();
            foreach (BranchModel item in data2)
            {
                branchllist.Add(new SelectListItem
                {
                    Text = item.BranchName,
                    Value = item.BranchID.ToString()
                });
            }
            ViewBag.branch = branchllist;

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
            var data4 = occuptionService.ListAllData();
            List<SelectListItem> occuptionlist = new List<SelectListItem>();
            foreach (OccupationModel item in data4)
            {
                occuptionlist.Add(new SelectListItem
                {
                    Text = item.OccupationName,
                    Value = item.OccupationID.ToString()
                });
            }
            ViewBag.occuption = occuptionlist;
            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(MemberModel Model)
        {
            memberService.Update(Model);
            var data = memberService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(MemberModel Model)
        {
            memberService.Save(Model);
            var data = memberService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            memberService.Delete(Id);
            var data = memberService.ListAllData();
            return View("Index", data);
        }
    }
}