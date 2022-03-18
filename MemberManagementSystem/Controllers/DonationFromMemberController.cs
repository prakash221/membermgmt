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
    public class DonationFromMemberController : Controller
    {
        IDonationService donationService;
        IDonationTypeService donationTypeService;
        IDonorService donorService;
        IMemberService memberService;
        public DonationFromMemberController()
        {
            donationService = new DonationService();
            donationTypeService = new DonationTypeService();
            memberService = new MemberService();
        }
        // GET: Donation
        public ActionResult Index()
        {
            var data = donationService.ListAllDataM();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = donationService.GeDotionById(Id);

            var data2 = donationTypeService.ListAllData();
            List<SelectListItem> donationTypeList = new List<SelectListItem>();
            foreach (DonationTypeModel item in data2)
            {
                donationTypeList.Add(new SelectListItem
                {
                    Text = item.DonationTypeName,
                    Value = item.DonationTypeID.ToString()
                });
            }
            ViewBag.donationTypes = donationTypeList;


            var data5 = memberService.ListAllData();
            List<SelectListItem> memberList = new List<SelectListItem>();
            foreach (MemberModel item in data5)
            {
                memberList.Add(new SelectListItem
                {
                    Text = item.FirstName +" "+ item.LastName,
                    Value = item.MemberID.ToString()
                });
            }
            ViewBag.members = memberList;
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var data2 = donationTypeService.ListAllData();
            List<SelectListItem> donationTypeList = new List<SelectListItem>();
            foreach (DonationTypeModel item in data2)
            {
                donationTypeList.Add(new SelectListItem
                {
                    Text = item.DonationTypeName,
                    Value = item.DonationTypeID.ToString()
                });
            }
            ViewBag.donationTypes = donationTypeList;

           
            var data5 = memberService.ListAllData();
            List<SelectListItem> memberList = new List<SelectListItem>();
            foreach (MemberModel item in data5)
            {
                memberList.Add(new SelectListItem
                {
                    Text = item.FirstName + " " + item.LastName,
                    Value = item.MemberID.ToString()
                });
            }
            ViewBag.members = memberList;

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(DonationModel Model)
        {
            donationService.UpdateM(Model);
            var data = donationService.ListAllDataM();
            return View("Index", data);
        }
        public ActionResult Create(DonationModel Model)
        {            
            donationService.SaveM(Model);            
            var data = donationService.ListAllDataM();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            donationService.Delete(Id);
            var data = donationService.ListAllDataM();
            return View("Index", data);
        }
    }
}